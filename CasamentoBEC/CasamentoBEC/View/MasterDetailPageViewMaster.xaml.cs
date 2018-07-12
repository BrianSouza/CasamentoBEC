﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CasamentoBEC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageViewMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageViewMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageViewMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageViewMenuItem> MenuItems { get; set; }
            
            public MasterDetailPageViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageViewMenuItem>(new[]
                {
                    new MasterDetailPageViewMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailPageViewMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailPageViewMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailPageViewMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailPageViewMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}