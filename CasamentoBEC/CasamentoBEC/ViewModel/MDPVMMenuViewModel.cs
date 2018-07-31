using CasamentoBEC.Model;
using CasamentoBEC.Services;
using CasamentoBEC.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class MDPVMMenuViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;

        MenuItens selectedMenu;
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

        public MenuItens SelectedMenu
        {
            get => selectedMenu;
            set
            {
                selectedMenu = value;
                RaisePropertyChanged();
                MenuSelected(value);
            }
        }
        

        public MDPVMMenuViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            messageService = DependencyService.Get<IMessageService>();
            MenuItens = new List<MenuItens>
            {
                new MenuItens{ Index = 1, DescricaoMenu = "Confirme Sua Presença.", NomeImagem="check32.png"},
                new MenuItens{ Index = 2, DescricaoMenu = "Local", NomeImagem="Localizacao32.png"},
                new MenuItens{ Index = 3, DescricaoMenu = "Fotos", NomeImagem="camera32.png"},
                new MenuItens{ Index = 4, DescricaoMenu = "Presente Para os Noivos", NomeImagem="presente32.png"}
            };
        }

        private void MenuSelected(MenuItens menu)
        {
            if (menu == null)
                return;

            switch (menu.Index)
            {
                case 1:
                    messageService.ShowAsync("", "1", "");
                    break;
                case 2:
                    messageService.ShowAsync("", "2", "");
                    break;
                case 3:
                    messageService.ShowAsync("", "3", "");

                    break;
                case 4:
                    messageService.ShowAsync("", "4", "");

                    break;

                default:
                    break;
            }
            navigationService.MenuIsPresented = false;
            this.SelectedMenu = null;
        }

    }
}
