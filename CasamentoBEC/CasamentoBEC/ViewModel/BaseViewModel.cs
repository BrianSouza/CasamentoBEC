using CasamentoBEC.Provider.Interface;
using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        internal readonly INavigationService navigationService;
        internal readonly IAPIProvider _api;
        internal readonly IMessageService _message;
        private bool processando;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isNotConnected;
        public bool IsNotConnected
        {
            get
            {
                return _isNotConnected;
            }
            set
            {
                _isNotConnected = value;
                RaisePropertyChanged();
                ExibirPopupErroConexao();
            }
        }

        public BaseViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            _api = DependencyService.Get<IAPIProvider>();
            _message = DependencyService.Get<IMessageService>();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            ValidarConexao();
        }
        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }
        public void ExibirPopupErroConexao()
        {
            if (IsNotConnected)
                navigationService.AbrirErroConexao();
        }
        public void ValidarConexao()
        {
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
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
