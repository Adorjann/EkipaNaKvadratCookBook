using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EkipaNaKvadratCookBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabsPage : TabbedPage
    {
        private MainPage _mainPage;
        private FavoritesView _favoritesView;

        public TabsPage()
        {
            InitializeComponent();
            MainPageView.BindingContext = App.Locator.MainViewModel;
            _mainPage = MainPageView;
            var favoritesVm = App.Locator.FavoritesRecipeViewModel;
            favoritesVm.SubscribeToCurrentPageChanged(this);
            FavoritesPageView.BindingContext = favoritesVm;
            _favoritesView = FavoritesPageView;
        }

        public MainPage MainPage { get => _mainPage; }
        public FavoritesView FavoritesPage { get => _favoritesView; }
    }
}