using EkipaNaKvadratCookBook.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EkipaNaKvadratCookBook.Service
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainViewModel MainViewModel
            => _serviceProvider.GetService<MainViewModel>();

        public RecipeListViewModel RecipeListViewModel
           => _serviceProvider.GetService<RecipeListViewModel>();

        public RecipeDetailsViewModel RecipeDetailsViewModel
            => _serviceProvider.GetService<RecipeDetailsViewModel>();
    }
}