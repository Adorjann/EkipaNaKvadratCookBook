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
            var currentTheme = ThemeService.Theme;

            switch (val)
            {
                case "System":
                    if (currentTheme != 0)
                    {
                        ThemeService.Theme = 0;
                        ThemeService.SetTheme();
                    }
                    break;

                case "Light":
                    if (currentTheme != 1)
                    {
                        ThemeService.Theme = 1;
                        ThemeService.SetTheme();
                    }
                    break;

                case "Dark":
                    if (currentTheme != 2)
                    {
                        ThemeService.Theme = 2;
                        ThemeService.SetTheme();
                    }
                    break;
            }
        }
    }
}