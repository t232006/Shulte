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
		public save_load_XML Saver;
		public MainPage(save_load_XML _Saver)
		{

			this.Saver = _Saver;
			settings = new SettingViewModel();
			InitializeComponent();
			pBlack.Settings = settings;
			pBlack.BindingContext = settings;
			pSettings._svm = settings;
			pSettings.BindingContext = settings;
			pLog.save_load = Saver;
			pBlack.save_Load = Saver;
		}
		protected void onBlackAppearing(Object sender, EventArgs e)
		{
			(sender as PageBlack).Show();
			(sender as PageBlack).Alive = true;
		}
		protected void onBlackDisappearing(Object sender, EventArgs e)
		{
			(sender as PageBlack).Alive = false;
			//Saver = (sender as PageBlack).save_Load;
		}

		/*protected void onLogAppearing(Object sender, EventArgs e)
		{
			
		}*/

	}
}
