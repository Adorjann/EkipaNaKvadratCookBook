using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class RecipeViewModel : BaseViewModel
    {
        private string _image;
        private string _name;
        private string _shortDescription;

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

        public string ShortDescription
        {
            get => _shortDescription;
            set
            {
                _shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        public RecipeViewModel(Recipe recipe)
        {
            SetImage(recipe.thumbnailImage);
            ShortDescription = recipe.shortDescription;
            Name = recipe.name;
        }

        private void SetImage(string thumbnailImage)
        {
            thumbnailImage = thumbnailImage.Replace(".png", "");
            Image = thumbnailImage;
        }
    }
}
