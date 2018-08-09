﻿using CasamentoBEC.ViewModel;
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
        public MasterDetailPageViewDetail()
        {
            InitializeComponent();
            this.BindingContext = new MDPVDetailViewModel();
        }
    }
}