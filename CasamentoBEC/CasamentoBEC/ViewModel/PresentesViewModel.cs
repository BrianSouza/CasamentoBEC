using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class PresentesViewModel : BaseViewModel
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
        public PresentesViewModel()
        {
            CmdClose = new Command(() => navigationService.PopNavigation());
        }
    }
}
