using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EkipaNaKvadratCookBook.Droid.CustomRenders;
using EkipaNaKvadratCookBook.Views;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using static Google.Android.Material.BottomNavigation.BottomNavigationView;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(TabsPage), typeof(TabsPageRender))]

namespace EkipaNaKvadratCookBook.Droid.CustomRenders
{
    public class TabsPageRender : TabbedPageRenderer, IOnNavigationItemReselectedListener
    {
        private bool _isShiftModeSet;
        private TabsPage _page;

        public TabsPageRender(Context context) : base(context)
        {
        }

        public void OnNavigationItemReselected(IMenuItem p0)
        {
            if (Element is TabsPage)
            {
                var _page = Element as TabsPage;
                _page.TabsPage_CurrentTabReselected();
            }
        }

        // Fixed Tabs
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            try
            {
                if (!_isShiftModeSet)
                {
                    var children = GetAllChildViews(ViewGroup);

                    if (children.SingleOrDefault(x => x is BottomNavigationView) is BottomNavigationView bottomNav)
                    {
                        bottomNav.SetOnNavigationItemReselectedListener(this);
                        bottomNav.SetShiftMode(false, false);
                        _isShiftModeSet = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error setting ShiftMode: {e}");
            }
        }

        private List<View> GetAllChildViews(View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<View> { view };
            }

            var result = new List<View>();

            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);

                var childList = new List<View> { child };
                childList.AddRange(GetAllChildViews(child));

                result.AddRange(childList);
            }

            return result.Distinct().ToList();
        }
    }
}