using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class SettingsViewModel : BaseViewModel
    {
        private IMainNavigationService _navigationService;

        public SettingsViewModel(IMainNavigationService navigationService)
        {
            _navigationService = navigationService;
            BackToMainPageCommand = new Command(OnBackToMainPageCommand);
            CheckChangedCommand = new Command<string>(OnCheckChangedCommand);
        }

        public ICommand BackToMainPageCommand { get; set; }
        public ICommand CheckChangedCommand { get; set; }

        private void OnBackToMainPageCommand(object obj)
        {
            _navigationService.BackToMainPage();
        }

        private void OnCheckChangedCommand(string val)
        {
            switch (val)
            {
                case "System":
                    ThemeService.Theme = 0;
                    break;

                case "Light":
                    ThemeService.Theme = 1;
                    break;

                case "Dark":
                    ThemeService.Theme = 2;
                    break;
            }

            ThemeService.SetTheme();
        }
    }
}