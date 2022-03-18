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

        public RecipeRepository()
        {
            _ = LoadRecipes();
        }

        public List<Recipe> GetRecipesByType(string type)
        {
            return _recipes.Where(r => r.type.Equals(type)).ToList();
        }

        public List<Recipe> GetTypesOfRecipes()
        {
            return _recipes.Distinct().ToList();
        }

        private async Task LoadRecipes()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, FileName);
            if (!File.Exists(path))
            {
                //Init();
                await ReadJson();
                return;
            }

            var data = File.ReadAllText(path);
            _recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
        }

        private void Save()
        {
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), JsonConvert.SerializeObject(_recipes));
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