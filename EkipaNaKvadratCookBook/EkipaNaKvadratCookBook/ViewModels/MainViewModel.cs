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
        private ObservableCollection<NameViewModel> _typesOfRecipes;
        private readonly INavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private NameViewModel _selectedType;

        public MainViewModel(INavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

            SelectedTypeChanged = new Command(OnSelectedTypeChanged);
            LoadData();
        }

        public ICommand SelectedTypeChanged { get; }

        public ObservableCollection<NameViewModel> TypesOfRecipes
        {
            get => _typesOfRecipes;
            set
            {
                _typesOfRecipes = value;
                OnPropertyChanged(nameof(TypesOfRecipes));
            }
        }

        public NameViewModel SelectedType
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

            List<NameViewModel> vmlist = new List<NameViewModel>();

            foreach (Recipe r in listaStringTipova)
            {
                NameViewModel recipeVm = new NameViewModel(r);
                vmlist.Add(recipeVm);
            }

            TypesOfRecipes = new ObservableCollection<NameViewModel>(vmlist);
        }

        private void OnSelectedTypeChanged(object obj)
        {
            if (SelectedType != null)
            {
                _navigationService.NavigateToRecipeListPage(SelectedType.Name);
            }
            SelectedType = null;
        }
    }
}