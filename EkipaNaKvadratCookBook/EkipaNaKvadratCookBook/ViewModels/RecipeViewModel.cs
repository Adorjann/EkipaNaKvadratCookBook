using EkipaNaKvadratCookBook.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EkipaNaKvadratCookBook.ViewModels
{
    internal class RecipeViewModel : BaseViewModel
    {
        private string _image;
        private string _name;
        private string _shortDescription;
        private string _liked;
        private Recipe _recipe;
        private Action _action;

        public RecipeViewModel(Recipe recipe, Action action)
        {
            Image = recipe.thumbnailImage;
            ShortDescription = recipe.shortDescription;
            Name = recipe.name;
            Liked = recipe.Liked;
            _recipe = recipe;
            _action = action;

            LikeCommand = new Command(OnLikeCommand);
        }

        public ICommand LikeCommand { get; set; }

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

        public string Liked
        {
            get => _liked;
            set
            {
                _liked = value;
                OnPropertyChanged(nameof(Liked));
            }
        }

        private void OnLikeCommand(object obj)
        {
            if (_recipe.Liked.Equals("heartEmpty"))
            {
                _recipe.Liked = "heartFull";
                _action?.Invoke();
                return;
            }
            _recipe.Liked = "heartEmpty";
            _action?.Invoke();
        }
    }
}