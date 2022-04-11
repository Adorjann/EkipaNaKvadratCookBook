using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    public class NameViewModel : BaseViewModel
    {
        private string _image;
        private string name;

        public NameViewModel(Recipe recipe)
        {
            Image = recipe.thumbnailImage;
            Name = recipe.type;
        }

        public NameViewModel(Step step)
        {
            if (step.image != null)
            {
                Image = step.image;
            }
            Name = step.text;
        }

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
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
    }
}