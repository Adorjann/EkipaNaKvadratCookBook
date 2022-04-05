namespace EkipaNaKvadratCookBook.Service
{
    internal interface IMainNavigationService
    {
        void BackToMainPage();

        void NavigateToRecipeDetailsPage(string recipeName);

        void NavigateToRecipeListPage(string type, string searchParam);

        void NavigateToSettingsPage();

        void BackToRecipeList(string type);

        void FavoritesBackToMainTabb();

        void FromFavoritesToRecipeDetails(string name);
    }
}