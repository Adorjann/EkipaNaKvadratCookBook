using EkipaNaKvadratCookBook.ViewModels;
using EkipaNaKvadratCookBook.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.Service
{
    internal class NavigationService : INavigationService
    {
        public void NavigateToRecipeListPage(string type)
        {
            var vm = App.Locator.RecipeListViewModel;
            vm.SetRecipes(type);

            Application.Current
                .MainPage
                .Navigation
                .PushAsync(new RecipeListView { BindingContext = vm });
        }

        public void NavigateToRecipeDetailsPage(string recipeName)
        {
            var vm = App.Locator.RecipeDetailsViewModel;
            vm.LoadRecipe(recipeName);

            Application.Current.MainPage.Navigation.PushAsync(new RecipeDetailsView { BindingContext = vm });
        }

        public void BackToMainPage()
        {
            Application.Current.MainPage.Navigation.PopAsync();

            var lastView = Application.Current
                .MainPage
                .Navigation
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

            Application.Current.MainPage.Navigation.PushAsync(new SettingsModalView { BindingContext = vm });
        }
    }
}