using EkipaNaKvadratCookBook.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal class RecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes;
        private const string FileName = "recipe.txt";
        private const string JSONFileName = "recipe.json";
        private static string _searchParam = "";

        public RecipeRepository()
        {
            _ = LoadRecipes();
        }

        public List<Recipe> GetRecipesByType(string type)
        {
            _ = LoadRecipes();
            if (_searchParam == "")
            {
                return _recipes.Where(r => r.type.Equals(type)).ToList();
            }
            return FilterRecipesByParam(_searchParam).Where(r => r.type.Equals(type)).ToList();
        }

        public List<Recipe> GetTypesOfRecipes(string searchParam)
        {
            if (searchParam == "")
            {
                _searchParam = "";
                return _recipes.Distinct().ToList();
            }
            _searchParam = searchParam;
            return FilterRecipesByParam(searchParam).Distinct().ToList();
        }

        private IEnumerable<Recipe> FilterRecipesByParam(string searchParam)
        {
            var filteredRecipes = _recipes.Where(recipe =>
            {
                foreach (Ingredient ingredient in recipe.ingredients)
                {
                    if (ingredient.name.Contains(searchParam))
                    {
                        return true;
                    }
                }
                return false;
            });
            return filteredRecipes;
        }

        public async Task<List<Recipe>> GetLikedRecipes()
        {
            await LoadRecipes();
            return _recipes.Where(x => "heartFull".Equals(x.Liked)).ToList();
        }

        public Recipe GetRecipeByName(string recipeName)
        {
            return _recipes.Where(r => r.name.Equals(recipeName)).ToList()[0];
        }

        public void Save()
        {
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), JsonConvert.SerializeObject(_recipes));
        }

        private async Task LoadRecipes()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, FileName);
            if (!File.Exists(path))
            {
                await ReadJson();
                return;
            }

            var data = File.ReadAllText(path);
            _recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
        }

        private async Task ReadJson()
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(JSONFileName))
            {
                RecipeList recipeList = null;
                using (var reader = new StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    recipeList = JsonConvert.DeserializeObject<RecipeList>(data);
                    _recipes = new List<Recipe>(recipeList.recipe);
                    Save();
                }
            }
        }
    }
}