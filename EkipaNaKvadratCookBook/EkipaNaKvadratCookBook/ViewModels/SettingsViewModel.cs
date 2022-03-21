using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
        }

        public ICommand BackToMainPageCommand { get; set; }

        private void OnBackToMainPageCommand(object obj)
        {
            _navigationService.BackToMainPage();
        }
    }
}