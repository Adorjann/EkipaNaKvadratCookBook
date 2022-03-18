﻿using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.ViewModels
{
    public class TypeViewModel : BaseViewModel
    {
        private string _image;
        private string _type;

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public TypeViewModel(Recipe recipe)
        {
            SetImage(recipe.thumbnailImage);
            Type = recipe.type;
        }

        private void SetImage(string thumbnailImage)
        {
            thumbnailImage = thumbnailImage.Replace(".png", "");
            Image = thumbnailImage;
        }
    }
}