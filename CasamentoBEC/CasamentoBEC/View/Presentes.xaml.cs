using CasamentoBEC.ViewModel;
using FormsControls.Base;
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
	public partial class Presentes : ContentPage , IAnimationPage
    {
        public IPageAnimation PageAnimation { get; } = new PushPageAnimation { Duration = AnimationDuration.Long, Subtype = AnimationSubtype.FromBottom };
        private PresentesViewModel presenteVM;
        
        public void OnAnimationFinished(bool isPopAnimation)
        {
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
        }

		public Presentes ()
		{
			InitializeComponent ();
            presenteVM = new PresentesViewModel();
            this.BindingContext = presenteVM;
		}

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            presenteVM.Processando = true;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            presenteVM.Processando = false;
        }
    }
}