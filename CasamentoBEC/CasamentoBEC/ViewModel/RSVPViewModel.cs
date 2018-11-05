using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class RSVPViewModel : BaseViewModel
    {
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
        public RSVPViewModel()
        {
            CmdClose = new Command(() => navigationService.PopNavigation());
        }
    }
}
