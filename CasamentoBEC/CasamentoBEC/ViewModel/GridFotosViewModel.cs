using CasamentoBEC.Model;
using System.Collections.Generic;
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
        private List<Fotos> imagesSources;
        private string titulo;

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

        public List<Fotos> ImagesSources
        {
            get => imagesSources;
            set
            {
                imagesSources = value;
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
            PreencherListaImagens();
            CmdFotoSelecionada = new Command(() => navigationService.AbrirFotoSelecionada(Foto));
        }
        private void PreencherListaImagens()
        {
            ImagesSources = new List<Fotos>()
            {
                new Fotos(){ ImgSource = GetImageSource("https://abrilveja.files.wordpress.com/2016/09/istock_82086545_large.jpg")},
                new Fotos(){ ImgSource =GetImageSource("https://www.papeleestilo.com.br/wp-content/uploads/2018/09/fotos-de-casamento-01-e1536947656634.jpg") },
                new Fotos(){ ImgSource =GetImageSource("https://cdn0.casamentos.com.br/img_e_163086/3/0/8/6/t30_caroline-roger-mini-wedding-casamento-intimista-rio-negrinho-fotografo-sc-boho-ganske-fotos-e-historias-41_13_163086_v1.jpg") },
                new Fotos(){ ImgSource =GetImageSource("https://inesquecivelcasamento.s3.amazonaws.com/wp-content/uploads/2018/05/casamento_niina_gui-187-IMG_1345-660x400.jpg") },
                new Fotos(){ ImgSource =GetImageSource("http://s2.glbimg.com/RhRreT6XqgjneN8bmSTN4DeMdCc=/smart/e.glbimg.com/og/ed/f/original/2015/05/21/casamento-abre.jpg") },
                new Fotos(){ ImgSource = GetImageSource("https://abrilveja.files.wordpress.com/2016/09/istock_82086545_large.jpg")},
                new Fotos(){ ImgSource =GetImageSource("https://www.papeleestilo.com.br/wp-content/uploads/2018/09/fotos-de-casamento-01-e1536947656634.jpg") },
                new Fotos(){ ImgSource =GetImageSource("https://cdn0.casamentos.com.br/img_e_163086/3/0/8/6/t30_caroline-roger-mini-wedding-casamento-intimista-rio-negrinho-fotografo-sc-boho-ganske-fotos-e-historias-41_13_163086_v1.jpg") },
                new Fotos(){ ImgSource =GetImageSource("https://inesquecivelcasamento.s3.amazonaws.com/wp-content/uploads/2018/05/casamento_niina_gui-187-IMG_1345-660x400.jpg") },
                new Fotos(){ ImgSource =GetImageSource("http://s2.glbimg.com/RhRreT6XqgjneN8bmSTN4DeMdCc=/smart/e.glbimg.com/og/ed/f/original/2015/05/21/casamento-abre.jpg") }
            };

        }
    }
}
