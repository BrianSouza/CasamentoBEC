
using CasamentoBEC.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CasamentoBEC.Services
{
    interface INavigationService
    {
        //bool MenuIsPresented { get; set; }

        Task PopNavigation();

        //Task NavigateTo(string viewName, object param);

        void NavigateToMain();

        void AbrirMenu();
        Task AbrirErroConexao();
        void AbrirPresentes();

        void AbrirFotos();

        void AbrirRSVP();

        void AbrirInformacoes();

        void AbrirFotosInstagram();

        void AbrirFotosEnsaio();

        void AbrirFotosCasamento();


        void AbrirFotoSelecionada(FotosSelecionadas img);
        Task GoBack();
    }
}
