using Syncfusion.XForms.Backdrop;
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

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            if (IsBackLayerRevealed)
            {
                IsBackLayerRevealed = false;
                button.Source = "downIcon";
                return;
            }

            IsBackLayerRevealed = true;
            button.Source = "upIcon";
        }
    }
}