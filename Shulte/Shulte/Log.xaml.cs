using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shulte
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Log : ContentPage
	{
		public save_load_XML save_load;
		//Label selected = new Label();
		public Log()
		{
			InitializeComponent();
			//save_load = new save_load_XML();
			this.BindingContext = save_load;
	
		}
		void OnContClick (object sender, EventArgs e)
		{
			var mi = sender as MenuItem;
			DisplayAlert("menu", (mi.CommandParameter as saver).datetime.ToString(), "OK");
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			LogView.ItemsSource = save_load.allRec;
			//this.BindingContext = save_load.allRec;
		}

		private void onClick(object Sender, EventArgs e)
		{	
			saver s = (saver)(Sender as MenuItem).CommandParameter ;
			if (s == null) return;
			save_load.allRec.Remove(s);
		}
	}
}
