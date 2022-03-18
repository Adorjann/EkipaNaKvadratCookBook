using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }             

        private void OnTapped(object sender, EventArgs e)
        {
           // _ = Navigation.PushAsync(new MainRecipeListPage());
        }
    }
}