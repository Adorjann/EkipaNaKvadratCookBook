using EkipaNaKvadratCookBook.DataAccess;
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
    internal class RecipeListViewModel : BaseViewModel
    {
        private string _title;
        private IRecipeRepository _recipeRepository;
        private INavigationService _navigationService;
        private ObservableCollection<RecipeViewModel> _recipes;
        private RecipeViewModel _selectedRecipe;

        public RecipeListViewModel(IRecipeRepository recipeRepository, INavigationService navigationService)
        {
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            BackToRecipeTypesCommand = new Command(OnBackToRecipeCommand);
            SelectedRecipeChange = new Command(OnSelectedRecipeChangeCommand);
        }

        public ICommand BackToRecipeTypesCommand { get; set; }
        public ICommand SelectedRecipeChange { get; set; }

        public void SetRecipes(string type)
        {
            var listOfRecipes = _recipeRepository.GetRecipesByType(type);
            var recipeViewModels = listOfRecipes.Select(x => new RecipeViewModel(x, LikedRecipe));
            Recipes = new ObservableCollection<RecipeViewModel>(recipeViewModels);
            Title = type;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public ObservableCollection<RecipeViewModel> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public RecipeViewModel SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private void OnBackToRecipeCommand(object obj)
        {
            _navigationService.BackToMainPage();
        }

        private void OnSelectedRecipeChangeCommand(object obj)
        {
            if (_selectedRecipe != null)
            {
                _navigationService.NavigateToRecipeDetailsPage(_selectedRecipe.Name);
            }
            _selectedRecipe = null;
        }

        private void LikedRecipe()
        {
            _recipeRepository.Save();
            SetRecipes(_title);
        }
    }
}