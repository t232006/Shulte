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
		static gridBuilder gb;
		public MainPage()
		{
			settings = new SettingViewModel();
			InitializeComponent();
		}
		protected void onSettingAppearing(Object sender, EventArgs e)
		{
			(sender as Settings).BindingContext = settings;
			(sender as Settings)._svm = settings;
		}
		protected void onBlackAppearing(Object sender, EventArgs e)
		{
			gb = new gridBuilder();
			 (sender as PageBlack).LoadFromXaml(gb.getGrid(settings.RedView, settings.Dimension));
			(sender as PageBlack).Gb = gb;
			(sender as PageBlack).Settings = settings;
		}

	}
}
