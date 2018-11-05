using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CasamentoBEC.Services
{
    interface INavigationService
    {
        //bool MenuIsPresented { get; set; }

        Task PopNavigation();

        Task NavigateTo(string viewName, object param);

        void NavigateToMain();

        void AbrirMenu();

        void AbrirPresentes();

        void AbrirFotos();

        void AbrirRSVP();

        void AbrirLocal();
    }
}
