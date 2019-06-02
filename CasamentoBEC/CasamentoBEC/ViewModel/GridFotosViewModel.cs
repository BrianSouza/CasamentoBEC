using CasamentoBEC.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public enum TiposFotos
    {
        Instagram,
        Ensaio,
        Casamento
    }
    public class GridFotosViewModel : BaseViewModel
    {
        private Fotos foto;
        private ObservableCollection<FotosSelecionadas> imagesSources;
        private string titulo;
        private FotosSelecionadas _fotoSelecionada;

        private ICommand cmdFotoSelecionada;

        public string Titulo
        {
            get => titulo;
            set
            {
                titulo = value;
                RaisePropertyChanged();
            }
        }
        public Fotos Foto
        {
            get => foto;
            set
            {
                foto = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CmdFotoSelecionada
        {
            get => cmdFotoSelecionada;
            set
            {
                cmdFotoSelecionada = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<FotosSelecionadas>  ImagesSources
        {
            get => imagesSources;
            set
            {
                imagesSources = value;
                RaisePropertyChanged();
            }
        }

        public FotosSelecionadas FotoSelecionada
        {
            get => _fotoSelecionada;
            set
            {
                _fotoSelecionada = value;
                RaisePropertyChanged();
            }
        }

        public GridFotosViewModel(TiposFotos tipo)
        {
            switch (tipo)
            {
                case TiposFotos.Instagram:
                    Titulo = "Instagram";
                    break;
                case TiposFotos.Ensaio:
                    Titulo = "Ensaio";
                    break;
                case TiposFotos.Casamento:
                    Titulo = "Casamento";
                    break;
                default:
                    break;
            }
            PreencherListaImagens(tipo);
            CmdFotoSelecionada = new Command(() => navigationService.AbrirFotoSelecionada(FotoSelecionada));
        }
        private async void PreencherListaImagens(TiposFotos tipo)
        {
            Foto = await _api.GetFotosAsync((int)tipo);
            if (Foto.Sucesso)
            {
                ImagesSources = new ObservableCollection<FotosSelecionadas>();
                foreach (var item in Foto.FotosIE)
                {
                    ImagesSources.Add(new FotosSelecionadas { FotosObtidas = GetImageSource(item.LinkFoto) });
                }
                if(ImagesSources.Count == 0)
                {
                   await _message.ShowAsync("Ops...", $"Ainda não carregamos as fotos do {Titulo}, desculpe.", "Estão desculpados!");
                   await navigationService.GoBack();
                }
            }
            else
            {
               await _message.ShowAsync("Ops...", "Pedimos desculpas, mas não foi possível carregar as fotos.","Estão desculpados!");
            }
        }
    }

    public class FotosSelecionadas
    {
        public UriImageSource FotosObtidas { get; set; }
    }
}
