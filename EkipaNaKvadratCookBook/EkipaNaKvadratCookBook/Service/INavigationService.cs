namespace EkipaNaKvadratCookBook.Service
{
    internal interface INavigationService
    {
        void BackToMainPage();

        void NavigateToRecipeDetailsPage(string recipeName);

        void NavigateToRecipeListPage(string type);

        void NavigateToSettingsPage();
    }
}