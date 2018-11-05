using CasamentoBEC.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public Task NavigateTo(string viewName, object param)
        {
            throw new NotImplementedException();
        }

        public void NavigateToMain()
        {
            App.Current.MainPage = new PaginaPrincipalView();
            
        }

        public async Task PopNavigation()
        {
            await PopupNavigation.PopAsync();
        }

        public async void AbrirMenu()
        {
            await PopupNavigation.PushAsync(new MenuView());

        }

        public async void AbrirPresentes()
        {
            await PopupNavigation.PushAsync(new Presentes());
        }
        public async void AbrirFotos()
        {
            await PopupNavigation.PushAsync(new FotosView());
        }
        public async void AbrirRSVP()
        {
            await PopupNavigation.PushAsync(new RSVPView());
        }
        public async void AbrirLocal()
        {
            await PopupNavigation.PushAsync(new LocalView());
        }
    }
}
