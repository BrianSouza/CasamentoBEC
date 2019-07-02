using CasamentoBEC.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class InfoViewModel : BaseViewModel
    {
        private bool _carregandoInformacoes;
        private ObservableCollection<Aviso> _listaInfo;
        public ObservableCollection<Aviso> ListaInfo
        {
            get => _listaInfo;
            set
            {
                _listaInfo = value;
                RaisePropertyChanged();
            }
        }
        public ICommand ClickCommand { get; set; }
        public bool CarregandoInformacoes
        {
            get => _carregandoInformacoes;
            set
            {
                _carregandoInformacoes = value;
                RaisePropertyChanged();
            }
        }

        public InfoViewModel()
        {
            Task.Run(async () => await GetAvisos());
            ClickCommand = new Command((TextoContato) => AbrirContato(TextoContato));
        }
        private async Task GetAvisos()
        {
            try
            {
                ValidarConexao();
                if (IsNotConnected)
                    return;

                CarregandoInformacoes = true;
                Avisos ieAvisos = await _api.GetAvisos();
                if (ieAvisos.Sucesso == true)
                {
                    FormatText(ieAvisos);
                    ListaInfo = new ObservableCollection<Aviso>(ieAvisos.IEAvisos);

                    if (ListaInfo.Count == 0)
                    {
                        await _message.ShowAsync("=o(", "Nenhum aviso foi encontrado!", "OK");
                    }
                }
                else
                {
                    await _message.ShowAsync("Ops...", "Não consegui consultar os avisos!", "OK");
                }
            }
            finally
            {
                CarregandoInformacoes = false;
            }
        }
        private void FormatText(Avisos ieAvisos)
        {
            foreach (Aviso aviso in ieAvisos.IEAvisos)
            {
                if (aviso.TextoDescricao.Length > 220)
                {
                    string[] stringQuebrada = aviso.TextoDescricao.Split('|');
                    for (int i = 0; i < stringQuebrada.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                aviso.TextoDescricao = stringQuebrada[i];
                                break;
                            case 1:
                                aviso.TextoDescricao2 = stringQuebrada[i];
                                aviso.IsVisible = true;
                                break;
                            case 2:
                                aviso.TextoDescricao3 = stringQuebrada[i];
                                aviso.IsVisible2 = true;
                                break;
                            case 3:
                                aviso.TextoDescricao4 = stringQuebrada[i];
                                aviso.IsVisible3 = true;
                                break;
                            case 4:
                                aviso.TextoDescricao5 = stringQuebrada[i];
                                aviso.IsVisible4 = true;
                                break;
                        }
                    }
                }
                else
                {
                    aviso.IsVisible = false;
                    aviso.IsVisible2 = false;
                    aviso.IsVisible3 = false;
                    aviso.IsVisible4 = false;

                }
            }
        }
        private void AbrirContato(object textoContato)
        {
            Device.OpenUri(new System.Uri(textoContato.ToString()));
        }
    }
}
