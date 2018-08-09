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

        public ICommand ClickChevron1Cmd { get; set; }
        public ICommand ClickChevron2Cmd { get; set; }
        public ICommand ClickChevron3Cmd { get; set; }


        private string chevron1;
        private string chevron2;
        private string chevron3;

        private int heightFrame1;
        private int heightFrame2;
        private int heightFrame3;

        private bool visibleStk1 = false;
        private bool visibleStk2 = false;
        private bool visibleStk3 = false;


        public MDPVDetailViewModel()
        {
            messageService = DependencyService.Get<IMessageService>();
            navigationService = DependencyService.Get<INavigationService>();
            SetImages();
            SetHeight();
            ClickChevron1Cmd = new Command(ClickChevron1);
            ClickChevron2Cmd = new Command(ClickChevron2);
            ClickChevron3Cmd = new Command(ClickChevron3);

        }

        private void SetHeight()
        {
            heightFrame1 = 40;
            heightFrame2 = 40;
            heightFrame3 = 40;

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
        public string Chevron2
        {
            get => chevron2;
            set
            {
                chevron2 = value;
                RaisePropertyChanged();
            }
        }
        public string Chevron3
        {
            get => chevron3;
            set
            {
                chevron3 = value;
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
        public int HeightFrame2
        {
            get => heightFrame2;
            set
            {
                heightFrame2 = value;
                RaisePropertyChanged();
            }
        }
        public int HeightFrame3
        {
            get => heightFrame3;
            set
            {
                heightFrame3 = value;
                RaisePropertyChanged();
            }
        }

        public bool VisibleStk1
        {
            get => visibleStk1;
            set
            {
                visibleStk1 = value;
                RaisePropertyChanged();
            }
        }
        public bool VisibleStk2
        {
            get => visibleStk2;
            set
            {
                visibleStk2 = value;
                RaisePropertyChanged();
            }
        }
        public bool VisibleStk3
        {
            get => visibleStk3;
            set
            {
                visibleStk3 = value;
                RaisePropertyChanged();
            }
        }

        private void SetImages()
        {
            Chevron1 = "ic_chevron_right.png";
            Chevron2 = "ic_chevron_right.png";
            Chevron3 = "ic_chevron_right.png";

        }

        private void ClickChevron1()
        {
            if (Chevron1 == "ic_chevron_right.png")
            {
                HeightFrame1 = 135;
                VisibleStk1 = true;
                Chevron1 = "ic_expand_more.png";
            }
            else
            {
                Chevron1 = "ic_chevron_right.png";
                HeightFrame1 = 40;
                VisibleStk1 = false;
            }
        }
        private void ClickChevron2()
        {
            if (Chevron2 == "ic_chevron_right.png")
            {
                HeightFrame2 = 150;
                VisibleStk2 = true;
                Chevron2 = "ic_expand_more.png";
            }
            else
            {
                Chevron2 = "ic_chevron_right.png";
                HeightFrame2 = 40;
                VisibleStk2 = false;
            }
        }
        private void ClickChevron3()
        {
            if (Chevron3 == "ic_chevron_right.png")
            {
                HeightFrame3 = 160;
                VisibleStk3 = true;
                Chevron3 = "ic_expand_more.png";
            }
            else
            {
                Chevron3 = "ic_chevron_right.png";
                HeightFrame3 = 40;
                VisibleStk3 = false;
            }
        }

    }
}
