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
    public partial class MasterDetailPageViewDetail : ContentPage
    {
        MDPVDetailViewModel MDPV = new MDPVDetailViewModel();
        public MasterDetailPageViewDetail()
        {
            InitializeComponent();
            this.BindingContext = MDPV;
            CarouselTimer();
        }

        private void CarouselTimer()
        {
            int numPages = MDPV.Car.Count();
            int page = 0;
             
            Device.StartTimer(TimeSpan.FromSeconds(8), () =>
            {
                if (numPages > page)
                {
                    carPrincipal.Position = page;
                    page++;
                }
                else
                {
                    page = 0;
                    carPrincipal.Position = page;
                    page++;
                }

                return true;
            });
        }
    }
}