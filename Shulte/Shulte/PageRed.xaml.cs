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
	public partial class PageRed : ContentPage
	{
		public gridBuilder gb;
		public PageRed()
		{
			InitializeComponent();
		}
		
		private void onButtonPressed(Object sender, EventArgs e)
		{
			if (!gb.en.CheckAnsw(Byte.Parse((sender as Button).Text)))
				DisplayAlert("Неверно", "Неверно", "OK");
		}

	}
}