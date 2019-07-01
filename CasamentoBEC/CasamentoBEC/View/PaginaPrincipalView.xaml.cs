using CasamentoBEC.Provider.Interface;
using CasamentoBEC.ViewModel;
using FormsControls.Base;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasamentoBEC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalView : ContentPage 
    {
        private readonly double alturaPagina;
        private string StartColor = "#DC8686";
        private string EndColor = "#DC8686";
        private readonly IAPIProvider _api;

        private StackOrientation Orientation = StackOrientation.Horizontal;
        public PaginaPrincipalView()
        {
            InitializeComponent();
            //Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);//Esconde a navigationbar
            BindingContext = new PaginaPrincipalViewModel();
            SizeChanged += PaginaPrincipalView_SizeChanged;
            _api = DependencyService.Get<IAPIProvider>();
        }
       
        private void PaginaPrincipalView_SizeChanged(object sender, EventArgs e)
        {
            double alturaTela = Height;
            double larguraTela = Width;

            if(alturaTela <= 546 && larguraTela <= 321 && Device.RuntimePlatform == Device.Android)
            {
                var novoTamanhoMenu = new Rectangle(0, -150, 1, 150);
                AbsoluteLayout.SetLayoutBounds(frameMenu, novoTamanhoMenu);
                ImgMenu.HeightRequest = 35;
                ImgMenu.WidthRequest = 35;
                //ResizeMenuLabel();
            }
            else if (alturaTela <= 570 && larguraTela <= 321 && Device.RuntimePlatform == Device.iOS)
            {
                var novoTamanhoMenu = new Rectangle(0, -150, 1, 150);
                AbsoluteLayout.SetLayoutBounds(frameMenu, novoTamanhoMenu);
                ImgMenu.HeightRequest = 35;
                ImgMenu.WidthRequest = 35;
                //ResizeMenuLabel();
            }
            else if(Device.RuntimePlatform == Device.iOS)
            {
                ImgMenu.HeightRequest = 35;
                ImgMenu.WidthRequest = 35;
            }

            double larguraFrame = Math.Round((larguraTela / 4) - 6);
            frmDuvida.WidthRequest = larguraFrame;
            frmFotos.WidthRequest = larguraFrame;
            frmPresentes.WidthRequest = larguraFrame;
            frmRSVP.WidthRequest = larguraFrame;
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
            frameMenu.TranslateTo(0, 148, 1000, Easing.Linear);
        }
        private void FecharMenu()
        {
            frameMenu.TranslateTo(0, 0, 1000, Easing.Linear);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (frameMenu.TranslationY > 0)
            {
                FecharMenu();
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            var colors = new SKColor[] { Color.FromHex(StartColor).ToSKColor(), Color.FromHex(EndColor).ToSKColor() };

            SKPoint startColor = new SKPoint(0, 0);
            SKPoint endColor = Orientation == StackOrientation.Vertical ? new SKPoint(info.Width, 0) : new SKPoint(0, info.Height);

            var shader = SKShader.CreateLinearGradient(startColor, endColor, colors, null, SKShaderTileMode.Clamp);
            SKPaint paint = new SKPaint
            {

                Style = SKPaintStyle.Fill,

                Shader = shader,

                IsAntialias = true

            };

            float curve = 93f;
            float endpoint = 0.93f;
            float curveMargin = curve / 2;
            float height = (float)info.Height - curveMargin;

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(0, height);
                path.ConicTo(new SKPoint(info.Width / 2, height + curve), new SKPoint(info.Width, height), endpoint);
                path.LineTo(info.Width, 0);
                path.Close();
                canvas.DrawPath(path, paint);
            }
        }
    }
}