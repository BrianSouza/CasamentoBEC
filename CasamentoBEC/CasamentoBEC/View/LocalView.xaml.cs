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
	public partial class LocalView : ContentPage , IAnimationPage
    {
        LocalViewModel LocalVM;
        public IPageAnimation PageAnimation { get; } = new PushPageAnimation { Duration = AnimationDuration.Long, Subtype = AnimationSubtype.FromBottom };


        public void OnAnimationFinished(bool isPopAnimation)
        {
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
        }
        public LocalView ()
		{
			InitializeComponent ();
            LocalVM = new LocalViewModel();
            this.BindingContext = LocalVM;
		}
	}
}