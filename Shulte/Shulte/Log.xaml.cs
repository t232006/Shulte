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

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", (e.Item as saver).datetime.ToString(), "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}
	}
}
