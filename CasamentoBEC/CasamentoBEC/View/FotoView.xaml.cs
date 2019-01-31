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
	public partial class FotoView : ContentPage
	{
        FotoViewModel ftVM = null;
		public FotoView ()
		{
			InitializeComponent ();
            ftVM = new FotoViewModel();
            this.BindingContext = ftVM;
		}
	}
}