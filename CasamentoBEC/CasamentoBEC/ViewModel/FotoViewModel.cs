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
        public ICommand CmdFotoInstagram
        {
            get { return cmdFotoInstagram; }
            set
            {
                cmdFotoInstagram = value;
                RaisePropertyChanged();
            }
        }
        public FotoViewModel()
        {
            CmdFotoInstagram = new Command(navigationService.AbrirFotosInstagram);
        }


    }
}
