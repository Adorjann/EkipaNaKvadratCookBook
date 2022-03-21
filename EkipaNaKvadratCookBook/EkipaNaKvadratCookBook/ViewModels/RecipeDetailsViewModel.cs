using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Model;
using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class RecipeDetailsViewModel : BaseViewModel
    {
        private string _name;
        private string _backgroundImage;
        private string _longDescription;
        private string _liked;
        private string _type;
        private ObservableCollection<NameViewModel> _steps;
        private ObservableCollection<IngredientViewModel> _ingredients;
        private IRecipeRepository _recipeRepository;
        private IMainNavigationService _navigationService;

        public RecipeDetailsViewModel(IRecipeRepository recipeRepository, IMainNavigationService navigationService)
        {
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            BackToRecipeListCommand = new Command(OnBackToRecipeListCommand);
        }

        public ICommand BackToRecipeListCommand { get; set; }

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

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public void LoadRecipe(string recipeName)
        {
            Recipe recipe = _recipeRepository.GetRecipeByName(recipeName);

            Name = recipe.name;
            Type = recipe.type;
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

        private void OnBackToRecipeListCommand(object obj)
        {
            _navigationService.BackToRecipeList(Type);
        }
    }
}