using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.Service
{
    internal static class ThemeService
    {
        // 0 = default, 1 = light, 2 = dark
        private const int theme = 0;

        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }

        public static void SetTheme()
        {
            var currentTheme = App.Current.UserAppTheme;

            switch (Theme)
            {
                //default
                case 0:
                    if (currentTheme != OSAppTheme.Unspecified)
                    {
                        App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    }
                    break;
                //light
                case 1:
                    if (currentTheme != OSAppTheme.Light)
                    {
                        App.Current.UserAppTheme = OSAppTheme.Light;
                    }
                    break;
                //dark
                case 2:
                    if (currentTheme != OSAppTheme.Dark)
                    {
                        App.Current.UserAppTheme = OSAppTheme.Dark;
                    }
                    break;
            }
        }
    }
}