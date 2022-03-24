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
        public void NavigateToRecipeListPage(string type)
        {
            var vm = App.Locator.RecipeListViewModel;
            vm.SetRecipes(type);

            App.MainViewNavigation
               .PushAsync(new RecipeListView { BindingContext = vm });
        }

        public void NavigateToRecipeDetailsPage(string recipeName)
        {
            var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipe(recipeName);

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

        public void FavoritesBackToMainTabb()
        {
            App.TabbPage.CurrentPage = App.TabbPage.Children[0];
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
    }
}