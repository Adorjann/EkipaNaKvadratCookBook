﻿using EkipaNaKvadratCookBook.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class RecipePageViewModel : BaseViewModel
    {
        public RecipePageViewModel(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        private string _title;
        private string _type;
        private IRecipeRepository _recipeRepository;
        private ObservableCollection<RecipeViewModel> _typesOfRecipes;

        public void SetRecipes(string type)
        {
            TypesOfRecipes = new ObservableCollection<RecipeViewModel>(_recipeRepository.GetRecipesByType(type)
                                           .Select(x => new RecipeViewModel(x)));
            Title = type;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public ObservableCollection<RecipeViewModel> TypesOfRecipes
        {
            get => _typesOfRecipes;
            set
            {
                _typesOfRecipes = value;
                OnPropertyChanged(nameof(TypesOfRecipes));
            }
        }
    }
}