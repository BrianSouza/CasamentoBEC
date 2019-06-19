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
	public partial class FotoView : ContentPage, IAnimationPage
    {
        public IPageAnimation PageAnimation { get; } = new PushPageAnimation { Duration = AnimationDuration.Long, Subtype = AnimationSubtype.FromBottom };
        FotoViewModel ftVM = null;
        
        public void OnAnimationFinished(bool isPopAnimation)
        {
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
        }
		public FotoView ()
		{
			InitializeComponent ();
            ftVM = new FotoViewModel();
            this.BindingContext = ftVM;
		}
	}
}