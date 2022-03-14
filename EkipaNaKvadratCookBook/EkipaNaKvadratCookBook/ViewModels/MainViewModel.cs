using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Model;
using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<OneStringViewModel> _typesOfRecipes;
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;

        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;
        }

        internal ObservableCollection<OneStringViewModel> TypesOfRecipes
        {
            get => _typesOfRecipes;
            set
            {
                _typesOfRecipes = value;
                OnPropertyChanged(nameof(TypesOfRecipes));
            }
        }

        public void LoadData()
        {
            List<Recipe> listaStringTipova = _recipeRepository.GetTypesOfRecipes();

            List<OneStringViewModel> vmlist = new List<OneStringViewModel>();

            foreach (Recipe r in listaStringTipova)
            {
                OneStringViewModel stringVm = new OneStringViewModel(r.type);
                vmlist.Add(stringVm);
            }

            TypesOfRecipes = new ObservableCollection<OneStringViewModel>(vmlist);
        }
    }
}