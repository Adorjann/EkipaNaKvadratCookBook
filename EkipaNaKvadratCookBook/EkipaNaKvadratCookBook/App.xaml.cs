﻿using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Resources.Styling;
using EkipaNaKvadratCookBook.Service;
using EkipaNaKvadratCookBook.ViewModels;
using EkipaNaKvadratCookBook.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EkipaNaKvadratCookBook
{
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;
        private static ViewModelLocator _viewModelLocator;
        private static INavigation _mainViewNavigation;     // Explore Recipes Tab Navigation
        private static INavigation _favoritesViewNavigation; // Favorite Recipes Tab Navigation
        private static TabbedPage _tabbedPage;
        private static double _deviceWidth;
        private static double _deviceHeight;

        public App(double[] displayMetrics)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTk5ODAyQDMxMzkyZTM0MmUzMFZRcStrcWVTbHBIWFEzOHRIZ3VuSkx5UkJaOXpDYU9wbFJNdnJSbmJzUTg9");
            Application.Current.Resources.Add(new ThemesStyling());
            _deviceWidth = displayMetrics[0];
            _deviceHeight = displayMetrics[1];
            InitializeComponent();
            SetupServices();
            TabsPage tabbPage = new TabsPage();
            _tabbedPage = tabbPage;
            _mainViewNavigation = tabbPage.MainPage.Navigation;
            _favoritesViewNavigation = tabbPage.FavoritesPage.Navigation;

            MainPage = tabbPage;
        }

        internal static ViewModelLocator Locator
        {
            get
            {
                if (_viewModelLocator is null)
                {
                    _viewModelLocator = new ViewModelLocator(_serviceProvider);
                }

                return _viewModelLocator;
            }
        }

        public static INavigation MainViewNavigation { get => _mainViewNavigation; }
        public static INavigation FavoritesViewNavigation { get => _favoritesViewNavigation; }

        public static TabbedPage TabbPage { get => _tabbedPage; }
        public static double DeviceWidth { get => _deviceWidth; }
        public static double DeviceHeight { get => _deviceHeight; }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            ThemeService.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            ThemeService.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void SetupServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<RecipeListViewModel>();
            serviceCollection.AddTransient<RecipeDetailsViewModel>();
            serviceCollection.AddTransient<SettingsViewModel>();
            serviceCollection.AddTransient<FavoritesRecipeViewModel>();
            serviceCollection.AddTransient<IMainNavigationService, MainNavigationService>();
            serviceCollection.AddTransient<IRecipeRepository, RecipeRepository>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            if (ThemeService.Theme == 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ThemeService.SetTheme();
                });
            }
        }
    }
}