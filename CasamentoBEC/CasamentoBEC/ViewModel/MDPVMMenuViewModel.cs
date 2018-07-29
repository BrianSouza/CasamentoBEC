using CasamentoBEC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasamentoBEC.ViewModel
{
    public class MDPVMMenuViewModel : BaseViewModel
    {
        List<MenuItens> menuItens;
        public List<MenuItens> MenuItens
        {
            get
            {
                return menuItens;
            }
                           
            set
            {
                menuItens = value;
                RaisePropertyChanged();
            }
        }

        public MDPVMMenuViewModel()
        {
            MenuItens = new List<MenuItens>
            {
                new MenuItens{ Index = 1, DescricaoMenu = "Confirme Sua Presença.", NomeImagem="check32.png"},
                new MenuItens{ Index = 2, DescricaoMenu = "Local", NomeImagem="Localizacao32.png"},
                new MenuItens{ Index = 3, DescricaoMenu = "Fotos", NomeImagem="camera32.png"},
                new MenuItens{ Index = 4, DescricaoMenu = "Presente Para os Noivos", NomeImagem="presente32.png"}
            };
        }

    }
}
