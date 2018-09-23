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
    public class MDPVDetailViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;
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

        public MDPVDetailViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();


            Car = new ObservableCollection<Carousel>()
            {
                new Carousel{ ImageURL="https://image.ibb.co/eat0aU/stdsemadornos.png",Name="#CasamentoMoziCamis",Description=GetTextoDia()},
                new Carousel{ImageURL ="https://image.ibb.co/c7cT59/Symbol_14_1.png",Name="Teste 2",Description=""}
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
            else if(diasParaCasamento > 0)
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
