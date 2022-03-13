using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class OneStringViewModel : BaseViewModel
    {
        private string _typeName;

        public OneStringViewModel(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName
        {
            get => _typeName;
            set
            {
                _typeName = value;
                OnPropertyChanged(nameof(TypeName));
            }
        }
    }
}