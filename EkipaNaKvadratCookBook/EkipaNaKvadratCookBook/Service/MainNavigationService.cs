using EkipaNaKvadratCookBook.ViewModels;
using EkipaNaKvadratCookBook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.Service
{
    internal class MainNavigationService : IMainNavigationService
    {
        //Explore Recipes Tabb Navigation Stack

        public void NavigateToRecipeListPage(string type)
        {
            var lastView = App.MainViewNavigation 
                              .NavigationStack.Last();
            if (lastView is RecipeListView) //da li sam na tom view - u, ako jesam nema sta da ulazim dva puta 
            {
                return;
            }
            var vm = App.Locator.RecipeListViewModel;
            vm.SetRecipes(type);

            App.MainViewNavigation
               .PushAsync(new RecipeListView { BindingContext = vm });
        }

        public void NavigateToRecipeDetailsPage(string recipeName)
        {
            var lastView = App.MainViewNavigation
                              .NavigationStack.Last();
            if (lastView is RecipeDetailsView)
            {
                return;
            }

                var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipe(recipeName, BackToRecipeList);

            App.MainViewNavigation
               .PushAsync(new RecipeDetailsView { BindingContext = vm });
        }

        public void BackToMainPage()
        {
            App.MainViewNavigation.PopAsync();

            var lastView = App.MainViewNavigation
                              .NavigationStack.Last();

            if (lastView is MainPage mainPage &&
                mainPage.BindingContext is MainViewModel mainViewModel)
            {
                mainViewModel.LoadData();
            }
        }
        public void NavigateToSettingsPage()
        {
            var vm = App.Locator.SettingsViewModel;

            App.MainViewNavigation
               .PushAsync(new SettingsModalView { BindingContext = vm });
        }

        public async void BackToRecipeList(string type)
        {
            await App.MainViewNavigation.PopAsync();

            var lastView = App.MainViewNavigation
                              .NavigationStack.Last();

            if (lastView is RecipeListView recipeList &&
                recipeList.BindingContext is RecipeListViewModel vm)
            {
                vm.SetRecipes(type);
            }
        }

        //Favorites Tabb Navigation Stack

        public void FavoritesBackToMainTabb()
        {
            App.TabbPage.CurrentPage = App.TabbPage.Children[0];
        }

        public async void BackToFavoritesList(string notUsedArg)
        {
            await App.FavoritesViewNavigation.PopAsync();

            var lastView = App.FavoritesViewNavigation
                              .NavigationStack.Last();

            if (lastView is FavoritesView favoritesList &&
                favoritesList.BindingContext is FavoritesRecipeViewModel vm)
            {
                _ = vm.SetFavorites();
            }
        }

        public void FromFavoritesToRecipeDetails(string name)
        {
            var lastView = App.FavoritesViewNavigation
                              .NavigationStack.Last();
            if (lastView is RecipeDetailsView)
            {
                return;
            }
            var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipe(name, BackToFavoritesList);

            App.FavoritesViewNavigation
               .PushAsync(new RecipeDetailsView { BindingContext = vm });
        }
    }
}