using CasamentoBEC.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigateTo(string viewName, object param)
        {
            throw new NotImplementedException();
        }

        public void NavigateToMain()
        {
            App.Current.MainPage = new MasterDetailPageView();
        }

        public async Task PopNavigation()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        
    }
}
