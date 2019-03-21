using CasamentoBEC.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasamentoBEC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalView : ContentPage
    {
        public PaginaPrincipalView()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);//Esconde a navigationbar
            BindingContext = new PaginaPrincipalViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ShowHideMenu();
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            ShowHideMenu();
        }

        private void ShowHideMenu()
        {
            //if (frameMenu.Height == 25)
            //{
            //    AbsoluteLayout.SetLayoutBounds(frameMenu, new Rectangle(0, 0, 1, 250));
            //    AbsoluteLayout.SetLayoutFlags(frameMenu, AbsoluteLayoutFlags.WidthProportional);
            //}
            //else
            //{
            //    AbsoluteLayout.SetLayoutBounds(frameMenu, new Rectangle(0, 0, 1, 25));
            //    AbsoluteLayout.SetLayoutFlags(frameMenu, AbsoluteLayoutFlags.WidthProportional);
            //}
        }
    }
}