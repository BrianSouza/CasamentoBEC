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
        private readonly INavigationService navigationService;
        ObservableCollection<Carousel> car;
        private ICommand cmdAbriMenu; 
        public ObservableCollection<Carousel> Car
        {
            get { return car; }
            set
            {
                car = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdAbriMenu
        {
            get => cmdAbriMenu;
            set
            {
                cmdAbriMenu = value;
                RaisePropertyChanged();
            }
        }

        public PaginaPrincipalViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();

            string textoPaginaInicial = "...Como é bom poder contar com vocês na \n realização do nosso sonho! \n A contagem regressiva começa,\n o frio na barriga e toda a ansiedade do dia \n mais esperado de nossas vidas.\n Nos enche de alegria em tê-los ao nosso lado.\n Vamos juntos nesse grande sonho,\n o dia do nosso casamento...";

            Car = new ObservableCollection<Carousel>()
            {
                new Carousel{ ImageURL=GetImageSource("https://image.ibb.co/eat0aU/stdsemadornos.png"),Name="#CasamentoMoziCamis",Description=GetTextoDia()},
                new Carousel{ImageURL =null ,Name="",Description=textoPaginaInicial}
            };

            CmdAbriMenu = new Command(() => navigationService.AbrirMenu());
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
