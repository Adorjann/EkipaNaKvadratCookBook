using System.Net.Http;

namespace EkipaNaKvadratCookBook.Droid.Service
{
    internal interface IAndroidHttpClientSupplier
    {
        HttpClient GetHttpClient();
    }
}