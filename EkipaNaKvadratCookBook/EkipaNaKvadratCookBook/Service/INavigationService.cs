namespace EkipaNaKvadratCookBook.Service
{
    internal interface INavigationService
    {
        void GoBack();
        void NavigateToRecipeDetailsPage();
        void NavigateToRecipeListPage(string type);
    }
}