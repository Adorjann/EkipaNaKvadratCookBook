namespace EkipaNaKvadratCookBook.Service
{
    internal interface INavigationService
    {
        void GoBack();

        void NavigateToRecipeDetailsPage(string recipeName);

        void NavigateToRecipeListPage(string type);
    }
}