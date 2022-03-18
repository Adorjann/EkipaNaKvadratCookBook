using EkipaNaKvadratCookBook.ViewModels;
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
            var vm = App.Locator.RecipePageViewModel;
            vm.SetRecipes(type);

            Application.Current
                .MainPage
                .Navigation
                .PushAsync(new RecipeListPage { BindingContext = vm });
        }

        public void NavigateToRecipeDetailsPage()
        {
        }

        public void GoBack()
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
    }
}