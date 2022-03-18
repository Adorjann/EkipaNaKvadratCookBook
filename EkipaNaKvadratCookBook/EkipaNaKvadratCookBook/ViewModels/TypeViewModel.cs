using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    public class TypeViewModel : BaseViewModel
    {
        private string _image;
        private string _name;

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

        public TypeViewModel(Recipe recipe)
        {
            SetImage(recipe.thumbnailImage);
            _name = recipe.type;
        }

        public TypeViewModel(string thumbnailImage, string shortDescription)
        {
            SetImage(thumbnailImage);
            Name = shortDescription;
        }

        private void SetImage(string thumbnailImage)
        {
            thumbnailImage = thumbnailImage.Replace(".png", "");
            Image = thumbnailImage;
        }
    }
}