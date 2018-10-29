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
	public partial class MenuView : PopupPage
    {
        MenuViewModel menuVM = null;
		public MenuView ()
		{
			InitializeComponent ();
            menuVM = new MenuViewModel();
            this.BindingContext = menuVM;
		}
	}
}