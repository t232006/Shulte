using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shulte
{
	public partial class App : Application
	{
		save_load_XML Saver;
		public App()
		{
			InitializeComponent();
			Saver = new save_load_XML();
			MainPage = new MainPage(Saver);
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
			try
			{
				Saver.save();
			}
			catch { }
			
		}

		protected override void OnResume()
		{
		}
	}
}
