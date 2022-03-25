﻿namespace EkipaNaKvadratCookBook.Service
{
    internal interface IMainNavigationService
    {
        void BackToMainPage();

        void NavigateToRecipeDetailsPage(string recipeName);

        void NavigateToRecipeListPage(string type);

        void NavigateToSettingsPage();
        void BackToRecipeList(string type);
        void FavoritesBackToMainTabb();
        void NavigateFromFavoritesToRecipeDetailsPage(string recipeName);
        void BackToRecipeListFromFavorites(string type);
    }
}