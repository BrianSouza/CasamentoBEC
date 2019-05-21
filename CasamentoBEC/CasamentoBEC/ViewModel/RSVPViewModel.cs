using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class RSVPViewModel : BaseViewModel
    {
        private bool _naoConfirmado;
        private bool _confirmado;
        private ICommand cmdConfirmar;

        public bool Confirmado
        {
            get { return _confirmado; }
            set
            {
                _confirmado = value;
                RaisePropertyChanged();
            }
        }
        public bool NaoConfirmado
        {
            get { return _naoConfirmado; }
            set
            {
                _naoConfirmado = value;
                RaisePropertyChanged();
            }
        }
        public ICommand CmdConfirmar
        {
            get
            {
                return cmdConfirmar;
            }
            set
            {
                cmdConfirmar = value;
                RaisePropertyChanged();
            }
        }
        public RSVPViewModel()
        {
            ValidarUsuarioConfirmado();
            CmdConfirmar = new Command(ConfirmarPresenca);
        }

        private void ValidarUsuarioConfirmado()
        {
            if (App.ConvidadoLogado.PresencaConfirmada)
            {
                Confirmado = true;
                NaoConfirmado = false;
            }
            else
            {
                Confirmado = false;
                NaoConfirmado = true;
            }
        }

        private void ConfirmarPresenca()
        {
            if(!Confirmado)
            {
                try
                {
                    Processando = true;
                    Confirmado = true;
                    NaoConfirmado = false;
                    App.ConvidadoLogado.PresencaConfirmada = Confirmado;
                    _api.ConfirmarPresencaAsync(App.ConvidadoLogado);
                }
                finally
                {
                    Processando = false;
                }
                
            }
        }

        private void ValidarConfirmacao()
        {
            if (Confirmado)
                NaoConfirmado = false;
            else
                NaoConfirmado = true;
        }
    }
}
