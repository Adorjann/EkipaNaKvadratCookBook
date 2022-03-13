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
    }
}