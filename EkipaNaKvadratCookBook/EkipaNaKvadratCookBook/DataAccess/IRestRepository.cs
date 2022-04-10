using EkipaNaKvadratCookBook.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal interface IRestRepository
    {
        Task<List<Recipe>> RestCallForRecipes();
    }
}