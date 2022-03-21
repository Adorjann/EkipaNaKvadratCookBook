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

        public TabsPage()
        {
            InitializeComponent();
            MainView.BindingContext = App.Locator.MainViewModel;
            _mainPage = MainView;
        }

        public MainPage MainPage { get => _mainPage; }
    }
}