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
            

        }


    }
}
