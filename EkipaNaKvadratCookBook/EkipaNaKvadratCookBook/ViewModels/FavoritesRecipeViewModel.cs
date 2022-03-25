using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class FavoritesRecipeViewModel : BaseViewModel
    {
        private IRecipeRepository _recipeRepository;
        private IMainNavigationService _navigationService;
        private ObservableCollection<RecipeViewModel> _recipes;
        private RecipeViewModel _selectedRecipe;


        public FavoritesRecipeViewModel(IRecipeRepository recipeRepository, IMainNavigationService navigationService)
        {
            _recipeRepository = recipeRepository;
            _navigationService = navigationService;
            BackToMainPageCommand = new Command(OnBackToMainPageCommand);
            SelectedRecipeChange = new Command(OnSelectedRecipeChangeCommand);           
        }
        public ICommand BackToMainPageCommand { get; set; }
        public ICommand SelectedRecipeChange { get; set; }

        public void SubscribeToCurrentPageChanged(TabbedPage tabbedPage)
        {
            tabbedPage.CurrentPageChanged += OnCurrentPageChanged; //da znam na kojem sam tabu
        }
        private async Task SetFavorites()
        {
            Recipes = new ObservableCollection<RecipeViewModel>(
               (await _recipeRepository.GetLikedRecipes())
               .Select(x => new RecipeViewModel(x, LikedRecipe)));
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            var tabbedPage = (TabbedPage)sender;
            var index = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
            if(index == 1)
            {
                _ = SetFavorites();
            }
        }

        public void SetRecipes(string type)
        {
            var listOfRecipes = _recipeRepository.GetRecipesByType(type);
            var recipeViewModels = listOfRecipes.Select(x => new RecipeViewModel(x, LikedRecipe));
            Recipes = new ObservableCollection<RecipeViewModel>(recipeViewModels);
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
        private void OnSelectedRecipeChangeCommand(object obj)
        {
            if (_selectedRecipe != null)
            {
                _navigationService.NavigateFromFavoritesToRecipeDetailsPage(_selectedRecipe.Name);
            }
            _selectedRecipe = null;
        }

        private void OnBackToMainPageCommand(object obj)
        {
            _navigationService.FavoritesBackToMainTabb();
        }

        private void LikedRecipe()
        {
            _recipeRepository.Save();
            SetRecipes(null);
            _ = SetFavorites();
        }
    }
}
