using CasamentoBEC.Services;
using DLToolkit.Forms.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace CasamentoBEC
{
	public partial class App : Application
	{
		public App ()
		{
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
			InitializeComponent();
            FlowListView.Init();
            MainPage = new View.LoginView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
