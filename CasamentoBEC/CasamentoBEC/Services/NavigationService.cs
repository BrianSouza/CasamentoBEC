using CasamentoBEC.View;
using CasamentoBEC.ViewModel;
using FormsControls.Base;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CasamentoBEC.Services
{
    public class NavigationService : INavigationService
    {
        //public bool MenuIsPresented
        //{
        //    get
        //    {
        //        return ((MasterDetailPageView)App.Current.MainPage).IsPresented;
        //    }
        //    set
        //    {
        //        ((MasterDetailPageView)App.Current.MainPage).IsPresented = value;
                
        //    }
        //}
        //public Task NavigateTo(string viewName, object param)
        //{
        //    throw new NotImplementedException();
        //}

        public void NavigateToMain()
        {
            //App.Current.MainPage = new PaginaPrincipalView();
            App.Current.MainPage = new AnimationNavigationPage(new PaginaPrincipalView()) { BarBackgroundColor = Color.FromHex("dc8686"), BarTextColor = Color.White };
        }

        public async Task PopNavigation()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public async Task GoBack()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        public async void AbrirMenu()
        {
            await PopupNavigation.Instance.PushAsync(new MenuView());
        }
        public async Task AbrirErroConexao()
        {
            await PopupNavigation.Instance.PushAsync(new PopupErroConexao());
        }
        public async void AbrirFotoSelecionada(FotosSelecionadas img)
        {
            await PopupNavigation.Instance.PushAsync(new FotoSelecionadaView(img));
        }
        public async void AbrirPresentes()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Presentes());

        }
        public async void AbrirFotos()
        {
            await App.Current.MainPage.Navigation.PushAsync(new FotoView());
        }
        public async void AbrirRSVP()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RSVPView());
        }
        public async void AbrirInformacoes()
        {
            await App.Current.MainPage.Navigation.PushAsync(new InformacoesView());
        }

        public async void AbrirFotosInstagram()
        {
            await App.Current.MainPage.Navigation.PushAsync(new GridFotosView(ViewModel.TiposFotos.Instagram));
        }

        public async void AbrirFotosEnsaio()
        {
            await App.Current.MainPage.Navigation.PushAsync(new GridFotosView(ViewModel.TiposFotos.Ensaio));
        }
        public async void AbrirFotosCasamento()
        {
            await App.Current.MainPage.Navigation.PushAsync(new GridFotosView(ViewModel.TiposFotos.Casamento));
        }
    }
}
