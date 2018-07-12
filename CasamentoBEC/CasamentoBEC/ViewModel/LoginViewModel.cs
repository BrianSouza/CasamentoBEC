using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();
            LoginCommand = new Command(() => Login());
        }

        private void Login()
        {
            navigationService.NavigateToMain();
        }


    }
}
