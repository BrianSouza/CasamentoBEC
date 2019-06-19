using CasamentoBEC.ViewModel;
using FormsControls.Base;
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
	public partial class GridFotosView : ContentPage, IAnimationPage
    {
        GridFotosViewModel gridVM = null;

        public IPageAnimation PageAnimation { get; } = new PushPageAnimation { Duration = AnimationDuration.Long, Subtype = AnimationSubtype.FromBottom };


        public void OnAnimationFinished(bool isPopAnimation)
        {
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
        }
		public GridFotosView (TiposFotos tipo)
		{
			InitializeComponent ();
            gridVM = new GridFotosViewModel(tipo);
            this.BindingContext = gridVM;
		}

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            gridVM.FotoSelecionada = (e.Item as FotosSelecionadas);
        }
    }
}