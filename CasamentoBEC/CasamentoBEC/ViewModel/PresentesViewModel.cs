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
            ValidarConexao();
            Address = "https://sites.icasei.com.br/briancamila/pt_br/store/9/1/1";
        }
    }
}
