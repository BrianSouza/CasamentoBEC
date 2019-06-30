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
        readonly string textoPaginaInicial1 = @"...Como é bom poder contar com vocês na";
        readonly string textoPaginaInicial2 = @"realização do nosso sonho!";
        readonly string textoPaginaInicial3 = @"A contagem regressiva começa,";
        readonly string textoPaginaInicial4 = @"o frio na barriga e toda a ansiedade do dia";
        readonly string textoPaginaInicial5 = @"mais esperado de nossas vidas.";
        readonly string textoPaginaInicial6 = @"Nos enche de alegria em tê-los ao nosso lado.";
        readonly string textoPaginaInicial7 = @"Vamos juntos nesse grande sonho,";
        readonly string textoPaginaInicial8 = @"o dia do nosso casamento...";
        private readonly IMessageService messageService;
        private int exibirCarView;
        int slidePosition = 0;
        private string _textoDoDia;
        public int ExibirCarView
        {
            get { return exibirCarView; }
            set
            {
                exibirCarView = value;
                RaisePropertyChanged();
            }
        }
        ObservableCollection<Carousel> car;
        public ObservableCollection<Carousel> Car
        {
            get { return car; }
            set
            {
                car = value;
                RaisePropertyChanged();
            }
        }

       
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

                CmdOpenPresentes = new Command(() => navigationService.AbrirPresentes());
                CmdOpenFotos = new Command(() => navigationService.AbrirFotos());
                CmdOpenRSVP = new Command(() => navigationService.AbrirRSVP());
                CmdOpenInformacoes = new Command(() => navigationService.AbrirInformacoes());
            }
            finally
            {
                Processando = false;
            }
            
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
                txtDiasParaCasamento = "Hoje é o grande dia.";
            }
            else if (diasParaCasamento > 0)
            {
                txtDiasParaCasamento = $"...Faltam {diasParaCasamento} dias \n para o casamento...";
            }
            else
            {
                txtDiasParaCasamento = "";
            }

            return txtDiasParaCasamento;

        }

    }
}
