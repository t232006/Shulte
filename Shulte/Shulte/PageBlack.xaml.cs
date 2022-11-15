using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shulte
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageBlack : ContentPage
	{
		gridBuilder gb;
		public gridBuilder Gb { set => gb = value; }
		SettingViewModel settings;
		public SettingViewModel Settings { set => settings = value; }
		public PageBlack()
		{
			InitializeComponent();
		}
		

		private void onButtonPressed(Object sender, EventArgs e)
		{
			string s = gb.en.CheckAnsw(byte.Parse((sender as Button).Text));
			if (s == "false")
				DisplayAlert("Неверно", "Неверно", "OK");
			else if (s != "true")
			{
				DisplayAlert("Игра закончена", s, "OK");
			}
			else if (settings.SpotSelected)
			{
				(sender as Button).BackgroundColor = Color.Gold;
				(sender as Button).TextColor = Color.Gold;
			}
				

		}
	}
}