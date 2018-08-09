using CasamentoBEC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CasamentoBEC.ViewModel
{
    public class MDPVDetailViewModel : BaseViewModel
    {
        private readonly IMessageService messageService;
        private readonly INavigationService navigationService;

        private ICommand ClickChevron1Cmd { get; set; }

        private string chevron1;
        private int heightFrame1;

        public MDPVDetailViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();
            SetImages();
            SetHeight();
            ClickChevron1Cmd = new Command(ClickChevron1);
        }

        private void SetHeight()
        {
            heightFrame1 = 175;
        }

        public string Chevron1
        {
            get => chevron1;
            set
            {
                chevron1 = value;
                RaisePropertyChanged();
            }

        }

        public int HeightFrame1
        {
            get => heightFrame1;
            set
            {
                heightFrame1 = value;
                RaisePropertyChanged();
            }
        }

        private void SetImages()
        {
            Chevron1 = "ic_chevron_right.png";
        }

        private void ClickChevron1()
        {
            if (Chevron1 == "ic_chevron_right.png")
            {
                HeightFrame1 = 175;
                Chevron1 = "ic_expand_more.png";
            }
            else
            {
                Chevron1 = "ic_expand_more.png";
                HeightFrame1 = 30;
            }
        }

    }
}
