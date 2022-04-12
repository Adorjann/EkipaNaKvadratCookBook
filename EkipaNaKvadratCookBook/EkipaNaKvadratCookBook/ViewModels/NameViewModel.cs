using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    public class NameViewModel : BaseViewModel
    {
        private string _image;
        private string _name;
        private bool _completed;

        public NameViewModel(Recipe recipe)
        {
            Image = recipe.thumbnailImage;
            Name = recipe.type;
        }

        public NameViewModel(Step step)
        {
            if (step.Image != null)
            {
                Image = step.Image;
            }
            Completed = step.Completed;
            Name = step.Text;
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
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                OnPropertyChanged(nameof(Step));
            }
        }
    }
}