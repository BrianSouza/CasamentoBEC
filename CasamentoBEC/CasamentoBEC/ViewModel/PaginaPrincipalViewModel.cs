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
        private ICommand cmdOpenLocal;
        public ICommand CmdOpenLocal
        {
            get
            {
                return cmdOpenLocal;
            }
            set
            {
                cmdOpenLocal = value;
                RaisePropertyChanged();
            }
        }

        public PaginaPrincipalViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            string textoPaginaInicial = "...Como é bom poder contar com vocês na \n realização do nosso sonho! \n A contagem regressiva começa,\n o frio na barriga e toda a ansiedade do dia \n mais esperado de nossas vidas.\n Nos enche de alegria em tê-los ao nosso lado.\n Vamos juntos nesse grande sonho,\n o dia do nosso casamento...";

            PreencheCarousel(textoPaginaInicial);
            
            CmdOpenPresentes = new Command(() => navigationService.AbrirPresentes());
            CmdOpenFotos = new Command(() => navigationService.AbrirFotos());
            CmdOpenRSVP = new Command(() => navigationService.AbrirRSVP());
            CmdOpenLocal = new Command(() => navigationService.AbrirLocal());
            MudarImagensCarousel();
        }

        private void PreencheCarousel(string textoPaginaInicial)
        {
            Car = new ObservableCollection<Carousel>()
            {
                new Carousel{ ImageURL=GetImageSource("https://image.ibb.co/eat0aU/stdsemadornos.png"),Name="#CasorioMoziCamis",Description=GetTextoDia()},
                new Carousel{ImageURL =null ,Name="",Description=textoPaginaInicial}
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
