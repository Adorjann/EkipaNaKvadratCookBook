using EkipaNaKvadratCookBook.ViewModels;
using Syncfusion.XForms.Backdrop;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EkipaNaKvadratCookBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailsView : SfBackdropPage
    {
        public RecipeDetailsView()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var vm = this.BindingContext as RecipeDetailsViewModel;

            if (vm.AnyStepChecked())
            {
                await AskUserToSaveChecked(vm);
                return;
            }
            vm.SaveSteps();
        }

        private async Task AskUserToSaveChecked(RecipeDetailsViewModel vm)
        {
            bool answer = await DisplayAlert("Your checked steps will be lost.",
                "Would you like to save your progress?", "Yes", "No");

            if (answer)
            {
                vm.SaveSteps();
            }
        }
    }
}