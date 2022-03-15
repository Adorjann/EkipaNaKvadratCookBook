using EkipaNaKvadratCookBook.DataAccess;
using EkipaNaKvadratCookBook.Model;
using EkipaNaKvadratCookBook.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TypeViewModel> _typesOfRecipes;
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private TypeViewModel _selectedType;

        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

            SelectedTypeChanged = new Command(OnSelectedTypeChanged);

            LoadData();
        }

        public ICommand SelectedTypeChanged { get; }

        public ObservableCollection<TypeViewModel> TypesOfRecipes
        {
            get => _typesOfRecipes;
            set
            {
                _typesOfRecipes = value;
                OnPropertyChanged(nameof(TypesOfRecipes));
            }
        }

        public TypeViewModel SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public void LoadData()
        {
            List<Recipe> listaStringTipova = _recipeRepository.GetTypesOfRecipes();

            List<TypeViewModel> vmlist = new List<TypeViewModel>();

            foreach (Recipe r in listaStringTipova)
            {
                TypeViewModel recipeVm = new TypeViewModel(r);
                vmlist.Add(recipeVm);
            }

            TypesOfRecipes = new ObservableCollection<TypeViewModel>(vmlist);
        }

        private void OnSelectedTypeChanged(object obj)
        {
            //TODO: _navigationService.NavigateToRecipePage(SelectedType.Name)
        }
    }
}