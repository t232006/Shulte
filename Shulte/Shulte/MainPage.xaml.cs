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
	public partial class MainPage : ContentPage
	{
		gridBuilder gb;
		public MainPage()
		{
			//InitializeComponent();
			gb = new gridBuilder();
			this.LoadFromXaml(gb.getGrid(false));
			

		}
		private void onButtonPressed(Object sender, EventArgs e)
		{
			if (!gb.en.CheckAnsw(Byte.Parse((sender as Button).Text)))
				DisplayAlert("Неверно","Неверно","OK") ;
		}
	}
}
