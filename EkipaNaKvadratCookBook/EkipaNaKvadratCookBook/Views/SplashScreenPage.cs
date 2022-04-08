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

            var style = Application.Current.Resources["PageStyle"];

            this.Style = (Style)style;
            this.Content = splash;

            Label header = new Label
            {
                Text = "Shef's Secret",
                TextColor = Color.WhiteSmoke,
                FontSize = 42,
                //HorizontalOptions = LayoutOptions.Center,
            };
            AbsoluteLayout.SetLayoutFlags((BindableObject)header,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds((BindableObject)header,
                new Rectangle(0.5, 0.3, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            splash.Children.Add(header);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 600);
            await splashImage.ScaleTo(0.9, 1000, Easing.Linear);
            //await splashImage.ScaleTo(150, 1500, Easing.Linear);
            Application.Current.MainPage = App.TabbPage;
        }
    }
}
