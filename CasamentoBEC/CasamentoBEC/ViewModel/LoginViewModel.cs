using CasamentoBEC.Provider.Interface;
using CasamentoBEC.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variaveis
        private readonly IMessageService messageService;
        

        private ImageSource image;
        private string toolBarImage;
        private string entryImage;
        private string placeHolderText;
        private string buttonEntrarText;
        private string codigoConvite;
        #endregion

        #region Command
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Propriedades
        public string ButtonEntrarText
        {
            get => buttonEntrarText;
            set
            {
                buttonEntrarText = value;
                RaisePropertyChanged();
            }
        }
        public string PlaceHolderText
        {
            get => placeHolderText;
            set
            {
                placeHolderText = value;
                RaisePropertyChanged();
            }
        }
        public string EntryImage
        {
            get => entryImage;
            set
            {
                entryImage = value;
                RaisePropertyChanged();
            }
        }
        public string ToolBarImage
        {
            get => toolBarImage;
            set
            {
                toolBarImage = value;
                RaisePropertyChanged();
            }
        }
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                RaisePropertyChanged();
            }
        }
        public string CodigoConvite
        {
            get => codigoConvite;
            set
            {
                codigoConvite = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Metodos
        public LoginViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            
            LoginCommand = new Command(() => Login());
            SetImages();
            SetText();
        }

        private void SetImages()
        {
            Image = UriImageSource.FromUri(new Uri("https://image.ibb.co/gJBMCT/ftlogin.jpg"));
            EntryImage = "icon_edit.png";
            ToolBarImage = "coracao.png";
        }
        private void SetText()
        {
            PlaceHolderText = "Código Convite";
            ButtonEntrarText = "Entrar";
        }

        private async Task Login()
        {
            try
            {
                ValidarConexao();
                if (IsNotConnected)
                    return;

                Processando = true;
                if (string.IsNullOrEmpty(CodigoConvite))
                {
                    await messageService.ShowAsync("Atenção", "Um código de convite deve ser informado!", "OK");
                    return;
                }

                var convidado = App.ConvidadoLogado = await _api.GetConvidadoAsync(CodigoConvite);

                if (convidado != null && convidado.Sucesso)
                {
                    navigationService.NavigateToMain();
                }
                else
                {
                    await messageService.ShowAsync("Atenção", "Verifique se o código informado esta correto!", "OK");
                }
            }
            finally
            {
                Processando = false;
            }
            
        }
        #endregion

    }
}
