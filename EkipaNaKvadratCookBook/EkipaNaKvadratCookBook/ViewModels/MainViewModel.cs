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
        private readonly IMainNavigationService _navigationService;
        private readonly IRecipeRepository _recipeRepository;
        private NameViewModel _selectedType;
        private string _searchParam = string.Empty;

        public MainViewModel(IMainNavigationService navigationService, IRecipeRepository recipeRepository)
        {
            _navigationService = navigationService;
            _recipeRepository = recipeRepository;

            SelectedTypeChanged = new Command(OnSelectedTypeChanged);
            SettingsPageCommand = new Command(OnSettingsPageCommand);
            SearchParamsChangedCommand = new Command(OnSearchParamsChangedCommand);
            LoadData();
        }

        public ICommand SearchParamsChangedCommand { get; set; }

        public ICommand SelectedTypeChanged { get; set; }
        public ICommand SettingsPageCommand { get; set; }

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

        public string SearchParam
        {
            get => _searchParam;
            set
            {
                if (_searchParam == value)
                {
                    return;
                }

                _searchParam = value;
                OnPropertyChanged(nameof(SearchParam));
            }
        }

        public async void LoadData()
        {
            List<Recipe> listaStringTipova = await _recipeRepository.GetTypesOfRecipes(SearchParam);

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
                _navigationService.NavigateToRecipeListPage(SelectedType.Name, SearchParam);
            }
            SelectedType = null;
        }

        private void OnSettingsPageCommand(object obj)
        {
            _navigationService.NavigateToSettingsPage();
        }

        private void OnSearchParamsChangedCommand(object obj)
        {
            LoadData();
        }
    }
}