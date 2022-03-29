using EkipaNaKvadratCookBook.Service;
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
    public partial class SettingsModalView : ContentPage
    {
        public SettingsModalView()
        {
            InitializeComponent();

            switch (ThemeService.Theme)
            {
                case 0:
                    RButtonSystem.IsChecked = true;
                    break;

                case 1:
                    RButtonLight.IsChecked = true;
                    break;

                case 2:
                    RButtonDark.IsChecked = true;
                    break;
            }
        }
    }
}