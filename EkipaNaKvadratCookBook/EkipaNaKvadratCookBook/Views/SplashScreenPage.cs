using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.Views
{
    internal class SplashScreenPage : ContentPage
    {
        Image splashImage;

        public SplashScreenPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var splash = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "icontransparent.png",
                WidthRequest = 200,
                HeightRequest = 200
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage, 
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            splash.Children.Add(splashImage);

            this.BackgroundColor = Color.AntiqueWhite;
            this.Content = splash;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 700);
            // await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            // await splashImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = App.TabbPage;
        }
    }
}
