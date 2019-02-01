using CasamentoBEC.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class FotoSelecionadaViewModel : BaseViewModel
    {
        private ImageSource foto;
        public ImageSource Foto
        {
            get { return foto;}
            set
            {
                foto = value;
                RaisePropertyChanged();
            }
        }
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
        public FotoSelecionadaViewModel()
        {
            CmdClose = new Command(() => navigationService.PopNavigation());
        }

    }
}
