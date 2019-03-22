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
            if (frameMenu.TranslationY == 0)
            {
                AbrirMenu();
            }
            else if (frameMenu.TranslationY > 0)
            {
                FecharMenu();
            }
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            AbrirMenu();
        }
        private void SwipeGestureRecognizer_Swiped_1(object sender, SwipedEventArgs e)
        {
            FecharMenu();
        }

        private void AbrirMenu()
        {
            frameMenu.TranslateTo(0, 225, 2000, Easing.Linear);
        }
        private void FecharMenu()
        {
            frameMenu.TranslateTo(0, 0, 2000, Easing.Linear);
        }

        
        
    }
}