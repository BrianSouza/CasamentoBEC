using CasamentoBEC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CasamentoBEC.ViewModel
{
    public class InfoViewModel : BaseViewModel
    {
        private ObservableCollection<Informacoes> _listaInfo;
        public ObservableCollection<Informacoes> ListaInfo
        {
            get {return _listaInfo; }
            set
            {
                _listaInfo = value;
                RaisePropertyChanged();
            }
        }
        public InfoViewModel()
        {
            ListaInfo = new ObservableCollection<Informacoes>()
            {
                new Informacoes{TextoCabecalho = "Acessoria" , TextoDescritivo = "Para conversar com a Val, nossa acessora, ligue para: (11)9999-9999."},
                new Informacoes{TextoCabecalho = "HOTEL EZ" , TextoDescritivo = "Nossos convidados estão optando por ficar no Hotel Ez, telefone para contato: (11) 2222-2222."}
            };
        }
    }
}
