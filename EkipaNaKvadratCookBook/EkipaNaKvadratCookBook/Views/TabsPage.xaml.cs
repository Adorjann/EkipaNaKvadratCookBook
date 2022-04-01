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

            this.CurrentPageChanged += TabsPage_CurrentPageChanged;
        }

        public MainPage MainPage { get => _mainPage; }
        public FavoritesView FavoritesPage { get => _favoritesView; }

        private void TabsPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var index = this.Children.IndexOf(this.CurrentPage);
            if (index == 1)
            {
                App.MainViewNavigation.PopToRootAsync();
            }
            else
            {
                App.FavoritesViewNavigation.PopToRootAsync();
            }
        }
    }
}