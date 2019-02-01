using CasamentoBEC.ViewModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasamentoBEC.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FotoSelecionadaView : PopupPage
    {
        private FotoSelecionadaViewModel fotoVM;
		public FotoSelecionadaView (Model.Fotos foto)
		{
			InitializeComponent ();
            fotoVM = new FotoSelecionadaViewModel();
            this.BindingContext = fotoVM;
            fotoVM.Foto = foto.ImgSource;
		}
	}
}