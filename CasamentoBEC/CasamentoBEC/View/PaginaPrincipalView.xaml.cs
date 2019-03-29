﻿using CasamentoBEC.ViewModel;
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
            SizeChanged += PaginaPrincipalView_SizeChanged;
        }

        private void PaginaPrincipalView_SizeChanged(object sender, EventArgs e)
        {
            double alturaTela = Height;
            double larguraTela = Width;

            if(alturaTela <= 546 && larguraTela <= 321 && Device.RuntimePlatform == Device.Android)
            {
                var novoTamanhoMenu = new Rectangle(0, -230, 1, 300);
                AbsoluteLayout.SetLayoutBounds(frameMenu, novoTamanhoMenu);
                //ResizeMenuLabel();
            }
            else if (alturaTela <= 570 && larguraTela <= 321 && Device.RuntimePlatform == Device.iOS)
            {
                var novoTamanhoMenu = new Rectangle(0, -230, 1, 310);
                AbsoluteLayout.SetLayoutBounds(frameMenu, novoTamanhoMenu);
                //ResizeMenuLabel();
            }
        }

        private void ResizeMenuLabel()
        {
            menuContatos.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            menuCronograma.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            menuFotos.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            menuLocal.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            menuPresentes.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            menuRSVP.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
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
            frameMenu.TranslateTo(0, 225, 1000, Easing.Linear);
        }
        private void FecharMenu()
        {
            frameMenu.TranslateTo(0, 0, 1000, Easing.Linear);
        }

        
        
    }
}