using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        private ICommand cmdOpenMenu;
        public ICommand CmdOpenMenu
        {
            get
            {
                return cmdOpenMenu;
            }
            set
            {
                cmdOpenMenu = value;
                RaisePropertyChanged();
            }
        }

        private ICommand cmdCloseMenu;
        public ICommand CmdCloseMenu
        {
            get
            {
                return cmdCloseMenu;
            }
            set
            {
                cmdCloseMenu = value;
                RaisePropertyChanged();
            }
        }
        public MenuViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            CmdOpenMenu = new Command(() => navigationService.AbrirMenu());
            CmdCloseMenu = new Command(() => navigationService.PopNavigation());
        }

        
    }
}
