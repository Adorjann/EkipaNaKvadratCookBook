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

        protected override void OnAppearing()
        {
            SetFrontLayerRevealedHeight();
        }

        private void SetFrontLayerRevealedHeight()
        {
            var XandYofVisualElement = GetElementPositionOnTheScreen(longLabel);
            var labelHight = longLabel.Height;

            var bottomEdgeOfLabel = labelHight + XandYofVisualElement[1];

            //dimensions of the devices screen
            var deviceWidth = App.DeviceWidth;
            var deviceHeight = App.DeviceHeight;

            frontLayer.RevealedHeight = (deviceHeight - bottomEdgeOfLabel) + 40;
        }

        private double[] GetElementPositionOnTheScreen(VisualElement ve)
        {
            //Calculates visual element position relative to screen size
            double screenCordinateX = ve.X;
            double screenCordinateY = ve.Y;

            if (ve.Parent.GetType() != typeof(App))
            {
                VisualElement parent = ve.Parent as VisualElement;

                while (parent != null)
                {
                    screenCordinateX += parent.X;
                    screenCordinateY += parent.Y;

                    if (parent.Parent == null)
                    {
                        parent = null;
                    }
                    else if (parent.Parent.GetType() == typeof(App))
                    {
                        parent = null;
                    }
                    else
                    {
                        parent = parent.Parent as VisualElement;
                    }
                }
            }
            return new double[] { screenCordinateX, screenCordinateY };
        }
    }
}