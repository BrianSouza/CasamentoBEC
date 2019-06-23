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

        public PaginaPrincipalViewModel()
        {
            try
            {
                Processando = true;
                messageService = DependencyService.Get<IMessageService>();
                PreencheCarousel();

                CmdOpenPresentes = new Command(() => navigationService.AbrirPresentes());
                CmdOpenFotos = new Command(() => navigationService.AbrirFotos());
                CmdOpenRSVP = new Command(() => navigationService.AbrirRSVP());
                CmdOpenInformacoes = new Command(() => navigationService.AbrirInformacoes());
                MudarImagensCarousel();
            }
            finally
            {
                Processando = false;
            }
            
        }

        private void PreencheCarousel()
        {
            Car = new ObservableCollection<Carousel>()
            {
                new Carousel{ ImageURL=GetImageSource("https://casamentobucket.s3-sa-east-1.amazonaws.com/savethedate.png"),Name="",Description=GetTextoDia()},
                new Carousel{ ImageURL=GetImageSource("https://casamentobucket.s3-sa-east-1.amazonaws.com/noivos.png"),Name="#CamisEMozi",Description=""},
                new Carousel{ImageURL =GetImageSource("https://casamentobucket.s3-sa-east-1.amazonaws.com/fundoarvore.png") ,
                    Description1 =textoPaginaInicial1,
                    Description2 =textoPaginaInicial2,
                    Description3 =textoPaginaInicial3,
                    Description4 =textoPaginaInicial4,
                    Description5 =textoPaginaInicial5,
                    Description6 =textoPaginaInicial6,
                    Description7 =textoPaginaInicial7,
                    Description8 =textoPaginaInicial8}
            };
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

        private void MudarImagensCarousel()
        {
            
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                slidePosition++;
                if (slidePosition == car.Count) slidePosition = 0;
                ExibirCarView = slidePosition;
                return true;
            });
        }
    }
}
