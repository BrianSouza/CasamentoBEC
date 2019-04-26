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
    public partial class InformacoesView : TabbedPage, IAnimationPage
    {
        public IPageAnimation PageAnimation { get; } = new PushPageAnimation { Duration = AnimationDuration.Long, Subtype = AnimationSubtype.FromBottom };


        public void OnAnimationFinished(bool isPopAnimation)
        {
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
        }
    
        public InformacoesView ()
        {
            InitializeComponent();
        }
    }
}