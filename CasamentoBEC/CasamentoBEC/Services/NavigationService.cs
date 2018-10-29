﻿using CasamentoBEC.View;
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
    }
}
