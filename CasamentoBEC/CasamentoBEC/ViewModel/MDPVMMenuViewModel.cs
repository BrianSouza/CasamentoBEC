using CasamentoBEC.Model;
using CasamentoBEC.Services;
using CasamentoBEC.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class MDPVMMenuViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;
        private ICommand cmdTap;
        
        public ICommand CmdTap
        {
            get
            {
                return cmdTap;
            }
        }

        public MDPVMMenuViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            messageService = DependencyService.Get<IMessageService>();
            cmdTap = new Command(BotaoClicado);
        }
        
        private void BotaoClicado()
        {
            messageService.ShowAsync("", "Botao clicado", "");
        }
    }
}
