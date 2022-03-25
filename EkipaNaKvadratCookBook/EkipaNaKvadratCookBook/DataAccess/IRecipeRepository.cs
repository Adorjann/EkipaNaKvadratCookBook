﻿using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EkipaNaKvadratCookBook.DataAccess
{
    internal interface IRecipeRepository
    {
        List<Recipe> GetTypesOfRecipes();

        List<Recipe> GetRecipesByType(string type);

        Task<List<Recipe>> GetLikedRecipes();

        void Save();
        Recipe GetRecipeByName(string recipeName);
    }
}