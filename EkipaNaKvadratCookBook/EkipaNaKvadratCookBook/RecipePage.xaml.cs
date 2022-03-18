using EkipaNaKvadratCookBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EkipaNaKvadratCookBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipePage(string type)
        {
            InitializeComponent();
            var vm = App.Locator.RecipePageViewModel;
            vm.SetRecipes(type);
            BindingContext = vm;            
        }
    }
}