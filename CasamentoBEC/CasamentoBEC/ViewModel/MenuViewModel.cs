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

        private ICommand cmdOpenPresentes;
        public ICommand CmdOpenPresentes
        {
            get
            {
                return cmdOpenPresentes;
            }
            set
            {
                cmdOpenPresentes = value;
                RaisePropertyChanged();
            }
        }
        private ICommand cmdOpenFotos;
        public ICommand CmdOpenFotos
        {
            get
            {
                return cmdOpenFotos;
            }
            set
            {
                CmdCloseMenu.Execute(null);

                cmdOpenFotos = value;
                RaisePropertyChanged();
            }
        }
        private ICommand cmdOpenRSVP;
        public ICommand CmdOpenRSVP
        {
            get
            {
                return cmdOpenRSVP;
            }
            set
            {
                cmdOpenRSVP = value;
                RaisePropertyChanged();
            }
        }
        private ICommand cmdOpenLocal;
        public ICommand CmdOpenLocal
        {
            get
            {
                return cmdOpenLocal;
            }
            set
            {
                cmdOpenLocal = value;
                RaisePropertyChanged();
            }
        }
        public MenuViewModel()
        {
            CmdOpenMenu = new Command(() => navigationService.AbrirMenu());
            CmdCloseMenu = new Command(() => navigationService.PopNavigation());
            CmdOpenPresentes = new Command(() => navigationService.AbrirPresentes());
            CmdOpenFotos = new Command(() => navigationService.AbrirFotos());
            CmdOpenRSVP= new Command(() => navigationService.AbrirRSVP());
            CmdOpenLocal = new Command(() => navigationService.AbrirLocal());

        }


    }
}
