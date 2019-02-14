using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class PresentesViewModel : BaseViewModel
    {
        private string address;

        private ICommand cmdClose;
        public ICommand CmdClose
        {
            get
            {
                return cmdClose;
            }
            set
            {
                cmdClose = value;
                RaisePropertyChanged();
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                RaisePropertyChanged();
            }
        }
       
        public PresentesViewModel()
        {
            CmdClose = new Command(() => navigationService.PopNavigation());
            Address = "https://sites.icasei.com.br/briancamila/pt_br/store/9/1/1";
        }
    }
}
