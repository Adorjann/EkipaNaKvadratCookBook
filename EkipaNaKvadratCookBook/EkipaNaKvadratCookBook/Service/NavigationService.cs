using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.Service
{
    internal class NavigationService : INavigationService
    {
        public void NavigateToRecipeListPage(string type)
        {
            Application.Current.MainPage.Navigation.PushAsync(new RecipePage(type));
        }

        public void NavigateToRecipeDetailsPage()
        {
        }

        public void GoBack()
        {
        }
    }
}