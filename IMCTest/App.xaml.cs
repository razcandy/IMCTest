using IMCTest.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMCTest
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			ResourceHelper.Load();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
