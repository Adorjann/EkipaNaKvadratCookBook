using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal interface IRecipeRepository
    {
        List<string> GetTypesOfRecipes();
    }
}