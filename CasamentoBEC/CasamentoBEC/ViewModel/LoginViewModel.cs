using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variaveis
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;
        private ImageSource image;
        private string toolBarImage;
        private string entryImage;
        private string placeHolderText;
        private string buttonEntrarText;
        #endregion

        #region Command
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Propriedades
        public string ButtonEntrarText
        {
            get { return buttonEntrarText; }
            set
            {
                buttonEntrarText = value;
                RaisePropertyChanged();
            }
        }
        public string PlaceHolderText
        {
            get { return placeHolderText; }
            set
            {
                placeHolderText = value;
                RaisePropertyChanged();
            }
        }
        public string EntryImage
        {
            get { return entryImage; }
            set
            {
                entryImage = value;
                RaisePropertyChanged();
            }
        }
        public string ToolBarImage
        {
            get { return toolBarImage; }
            set
            {
                toolBarImage = value;
                RaisePropertyChanged();
            }
        }
        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Metodos
        public LoginViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();
            LoginCommand = new Command(() => Login());
            SetImages();
            SetText();
        }

        private void SetImages()
        {
            this.Image = UriImageSource.FromUri(new Uri("https://image.ibb.co/gJBMCT/ftlogin.jpg"));
            this.EntryImage = "icon_edit.png";
            this.ToolBarImage = "coracao.png";
        }
        private void SetText()
        {
            this.PlaceHolderText = "Código Convite";
            this.ButtonEntrarText = "Entrar";
        }

        private void Login()
        {
            navigationService.NavigateToMain();
        }
        #endregion

    }
}
