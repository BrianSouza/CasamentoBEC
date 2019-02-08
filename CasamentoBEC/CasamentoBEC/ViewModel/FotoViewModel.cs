using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class FotoViewModel : BaseViewModel
    {
        private ICommand cmdFotoInstagram;
        private ICommand cmdFotoEnsaio;
        private ICommand cmdFotoCasamento;
        public ICommand CmdFotoInstagram
        {
            get { return cmdFotoInstagram; }
            set
            {
                cmdFotoInstagram = value;
                RaisePropertyChanged();
            }
        }
        public ICommand CmdFotoEnsaio
        {
            get { return cmdFotoEnsaio; }
            set
            {
                cmdFotoEnsaio = value;
                RaisePropertyChanged();
            }
        }
        public ICommand CmdFotoCasamento
        {
            get { return cmdFotoCasamento; }
            set
            {
                cmdFotoCasamento = value;
                RaisePropertyChanged();
            }
        }
        public FotoViewModel()
        {
            CmdFotoInstagram = new Command(navigationService.AbrirFotosInstagram);
            CmdFotoCasamento = new Command(navigationService.AbrirFotosCasamento);
            CmdFotoEnsaio = new Command(navigationService.AbrirFotosEnsaio);
        }


    }
}
