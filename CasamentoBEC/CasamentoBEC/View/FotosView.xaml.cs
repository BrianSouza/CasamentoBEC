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
	public partial class FotosView : PopupPage
	{
        private FotosViewModel fotosVM;
		public FotosView ()
		{
			InitializeComponent ();
            fotosVM = new FotosViewModel();
            this.BindingContext = fotosVM;
		}
	}
}