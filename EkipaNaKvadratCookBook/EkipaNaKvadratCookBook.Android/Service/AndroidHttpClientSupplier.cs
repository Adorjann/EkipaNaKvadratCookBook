using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace EkipaNaKvadratCookBook.Droid.Service
{
    internal class AndroidHttpClientSupplier : IAndroidHttpClientSupplier
    {
        public HttpClient GetHttpClient()
        {
            var handler = new Xamarin.Android.Net.AndroidClientHandler();
            return new HttpClient(handler);
        }
    }
}