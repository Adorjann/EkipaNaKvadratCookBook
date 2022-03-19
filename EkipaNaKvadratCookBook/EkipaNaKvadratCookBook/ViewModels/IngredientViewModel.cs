using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class IngredientViewModel : BaseViewModel
    {
        private string name;
        private string unit;
        private string amount;

        public IngredientViewModel(Ingredient ingredient)
        {
            Name = ingredient.name;
            Unit = ingredient.unit;
            Amount = ingredient.amount;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
    }
}