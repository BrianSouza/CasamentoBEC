using CasamentoBEC.Provider.Interface;
using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        internal INavigationService navigationService;
        internal readonly IAPIProvider _api;
        private bool processando;
        public event PropertyChangedEventHandler PropertyChanged;
        public BaseViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            _api = DependencyService.Get<IAPIProvider>();
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UriImageSource GetImageSource(string url)
        {
            UriImageSource uri = new UriImageSource()
            {
                Uri = new Uri(url)
            };

            return uri;
        }
        public bool Processando
        {
            get => processando;
            set
            {
                processando = value;
                RaisePropertyChanged();
            }
        }

    }
}
