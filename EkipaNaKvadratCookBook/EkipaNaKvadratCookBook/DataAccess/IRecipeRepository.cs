using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal interface IRecipeRepository
    {
        List<Recipe> GetTypesOfRecipes();

        List<Recipe> GetRecipesByType(string type);

        void Save();
        Recipe GetRecipeByName(string recipeName);
    }
}