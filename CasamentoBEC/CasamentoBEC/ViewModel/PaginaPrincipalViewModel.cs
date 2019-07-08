using CasamentoBEC.Model;
using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class PaginaPrincipalViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
       
        private string _textoDoDia;
       
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
        private ICommand cmdOpenInformacoes;
        public ICommand CmdOpenInformacoes
        {
            get
            {
                return cmdOpenInformacoes;
            }
            set
            {
                cmdOpenInformacoes = value;
                RaisePropertyChanged();
            }
        }

        public string TextoDoDia { get => _textoDoDia; set => _textoDoDia = value; }

        public PaginaPrincipalViewModel()
        {
            try
            {
                Processando = true;
                messageService = DependencyService.Get<IMessageService>();

                CmdOpenPresentes = new Command(() => AbrirSitePresentes());
                CmdOpenFotos = new Command(() => navigationService.AbrirFotos());
                CmdOpenRSVP = new Command(() => navigationService.AbrirRSVP());
                CmdOpenInformacoes = new Command(() => navigationService.AbrirInformacoes());
                TextoDoDia = GetTextoDia();
            }
            finally
            {
                Processando = false;
            }
            
        }
        private void AbrirSitePresentes()
        {
            ValidarConexao();
            if (IsNotConnected)
                return;

            Device.OpenUri(new Uri("https://sites.icasei.com.br/briancamila/pt_br/store/9/1/1"));
        }
        private string GetTextoDia()
        {
            DateTime dtAtual = DateTime.Now.Date;
            DateTime dtCasamento = Convert.ToDateTime("2019-08-17");
            TimeSpan tsParaCasamento = dtCasamento - dtAtual;
            int diasParaCasamento = tsParaCasamento.Days;
            string txtDiasParaCasamento = string.Empty;
            if (diasParaCasamento == 0)
            {
                txtDiasParaCasamento = "Hoje é o grande dia!!!";
            }
            else if (diasParaCasamento > 0)
            {
                txtDiasParaCasamento = $"...Faltam {diasParaCasamento} dias \n para o casamento...";
            }
            else
            {
                txtDiasParaCasamento = "Obrigado por sua presença!";
            }

            return txtDiasParaCasamento;

        }

    }
}
