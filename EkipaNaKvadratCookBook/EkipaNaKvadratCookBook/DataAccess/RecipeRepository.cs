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
        private const string FileName = "recipe.txt"; // name of file to save recipes on device
        private const string JSONFileName = "recipe.json"; // name of file with additional recipes
        private IRestRepository _restRepository;
        private static string _searchParam;
        private static long _counter = 0;

        public RecipeRepository(IRestRepository restRepository)
        {
            _restRepository = restRepository;
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

        public async Task<List<Recipe>> GetTypesOfRecipes(string searchParam)
        {
            await LoadRecipes();

            if (searchParam == "")
            {
                _searchParam = "";
                return _recipes.Distinct().OrderBy(r => r.type).ToList();
            }
            _searchParam = searchParam;
            return FilterRecipesByParam(searchParam).Distinct().OrderBy(r => r.type).ToList();
        }

        public async Task<List<Recipe>> GetLikedRecipes()
        {
            await LoadRecipes();
            return _recipes.Where(x => "heartFull".Equals(x.Liked)).ToList();
        }

        public Recipe GetRecipeByName(string recipeName)
        {
            _ = LoadRecipes();
            return _recipes.Where(r => r.name.Equals(recipeName)).ToList().FirstOrDefault();
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
                var recipeList = await _restRepository.GetRecipesAsync() as RecipeList;
                _recipes = new List<Recipe>(recipeList.recipe);
                ReadJson(); //adding recipes from embededResource
                Save();
                return;
            }

            var data = File.ReadAllText(path);
            _recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
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

        private void ReadJson()
        {
            var assembly = typeof(App).Assembly;
            var embededResources = assembly.GetManifestResourceNames();
            var pathToJsonFile = embededResources.Where(i => i.EndsWith(JSONFileName));
            List<Recipe> recipes;

            using (var stream = assembly.GetManifestResourceStream(pathToJsonFile.FirstOrDefault()))
            {
                using (var reader = new StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    var recipeList = JsonConvert.DeserializeObject<RecipeList>(data);
                    recipes = recipeList.recipe.ToList();
                }
            }

            recipes.ForEach(r => _recipes.Add(r));
        }
    }
}