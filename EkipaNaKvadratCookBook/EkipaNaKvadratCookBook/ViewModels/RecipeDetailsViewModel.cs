using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Model;
using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class RecipeDetailsViewModel : BaseViewModel
    {
        private string _name;
        private string _backgroundImage;
        private string _longDescription;
        private string _liked;
        private ObservableCollection<NameViewModel> _steps;
        private ObservableCollection<IngredientViewModel> _ingredients;
        private IRecipeRepository _recipeRepository;
        private INavigationService _navigationService;

        public RecipeDetailsViewModel(IRecipeRepository recipeRepository, INavigationService navigationService)
        {
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
        }

        public string Liked
        {
            get => _liked;
            set
            {
                _liked = value;
                OnPropertyChanged(nameof(Liked));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<NameViewModel> Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }

        public string BackgroundImage
        {
            get => _backgroundImage;
            set
            {
                _backgroundImage = value;
                OnPropertyChanged(nameof(BackgroundImage));
            }
        }

        public ObservableCollection<IngredientViewModel> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public string LongDescription
        {
            get => _longDescription;
            set
            {
                _longDescription = value;
                OnPropertyChanged(nameof(LongDescription));
            }
        }

        public void LoadRecipe(string recipeName)
        {
            Recipe recipe = _recipeRepository.GetRecipeByName(recipeName);

            Name = recipe.name;
            BackgroundImage = recipe.backgroundImage;
            LongDescription = recipe.longDescription;
            Liked = recipe.Liked;
            LoadSteps(recipe.steps);
            LoadIngredients(recipe.ingredients);
        }

        private void LoadIngredients(IList<Ingredient> ingredients)
        {
            var ingredientViewModels = new List<Ingredient>(ingredients).Select(i => new IngredientViewModel(i));
            Ingredients = new ObservableCollection<IngredientViewModel>(ingredientViewModels);
        }

        private void LoadSteps(IList<Step> steps)
        {
            var stepsViewModels = new List<Step>(steps).Select(s => new NameViewModel(s));
            Steps = new ObservableCollection<NameViewModel>(stepsViewModels);
        }
    }
}