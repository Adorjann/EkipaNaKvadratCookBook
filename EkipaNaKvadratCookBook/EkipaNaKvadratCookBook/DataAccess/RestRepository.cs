using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EkipaNaKvadratCookBook.Model;
using System.Net.Http;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal class RestRepository : IRestRepository
    {
        public RestRepository(IAndroidHttpClientSupplier httpClientSupplier)
        {
        }

        public async Task<List<Recipe>> RestCallForRecipes()
        {
            using (HttpClient httpClient = new HttpClient())

                try
                {
                    var uri = new UriBuilder($"https://func-we-rest-test.azurewebsites.net/api/recipes?code=Qqe6h4MNxN4xTzA7UZmiD6KJkn81gLLjV8p09fQgkk6LssoRIBQmeA==");

                    var client = new RestClient(httpClient, new RestClientOptions { BaseUrl = uri.Uri });
                    var request = new RestRequest();
                    request.AddHeader("Accept", "application/json");

                    var response = await client.ExecuteAsync(request);

                    var recipeList = JsonConvert.DeserializeObject<RecipeList>(response.Content.ToString());
                    return recipeList.recipe as List<Recipe>;
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}