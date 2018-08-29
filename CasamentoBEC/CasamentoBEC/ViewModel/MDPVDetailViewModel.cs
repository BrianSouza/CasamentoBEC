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
                new Carousel{ ImageURL="https://image.ibb.co/i2rudU/savethedate.png",Name="Teste 1"},
                new Carousel{ImageURL ="https://image.ibb.co/c7cT59/Symbol_14_1.png",Name="Teste 2"}
            };
        }


    }
}
