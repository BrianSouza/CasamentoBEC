using CasamentoBEC.ViewModel;
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
	public partial class GridFotosView : ContentPage
	{
        GridFotosViewModel gridVM = null;
		public GridFotosView ()
		{
			InitializeComponent ();
            gridVM = new GridFotosViewModel();
            this.BindingContext = gridVM;
		}

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            gridVM.Foto = (e.Item as Model.Fotos);
        }
    }
}