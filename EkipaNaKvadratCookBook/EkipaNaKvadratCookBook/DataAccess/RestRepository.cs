using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EkipaNaKvadratCookBook.Model;
using System.Net.Http;
using EkipaNaKvadratCookBook.Service;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal class RestRepository : IRestRepository
    {
        private static readonly string BaseUrl = "https://func-we-rest-test.azurewebsites.net/api/recipes?code=Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==";

        private const string FunctionKeyHeader = "x-functions-key";
        private const string FunctionKey = "Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==";
        private readonly RestClient _restClient;

        public RestRepository()
        {
            _restClient = new RestClient(BaseUrl);
        }

        public async Task<object> GetRecipesAsync()
        {
            try
            {
                var request = new RestRequest("recipes")
                .AddHeader(FunctionKeyHeader, FunctionKey);

                var response = await _restClient.GetAsync(request);
                return JsonConvert.DeserializeObject<RecipeList>(response.Content);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}