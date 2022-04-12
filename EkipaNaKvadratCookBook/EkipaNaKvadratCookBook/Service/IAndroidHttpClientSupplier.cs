using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EkipaNaKvadratCookBook.Service
{
    public interface IAndroidHttpClientSupplier
    {
        HttpClient GetHttpClient();
    }
}