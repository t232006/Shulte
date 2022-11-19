using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shulte
{
	public partial class MainPage : TabbedPage
	{
		readonly SettingViewModel settings;
		public MainPage()
		{
			settings = new SettingViewModel();
			InitializeComponent();
			pBlack.Settings = settings;
			pBlack.BindingContext = settings;
			pSettings._svm = settings;
			pSettings.BindingContext = settings;
		}
		protected void onBlackAppearing(Object sender, EventArgs e)
		{
			(sender as PageBlack).Show();
			(sender as PageBlack).Alive = true;
		}
		protected void onBlackDisappearing(Object sender, EventArgs e)
		{
			(sender as PageBlack).Alive = false;
		}

	}
}
