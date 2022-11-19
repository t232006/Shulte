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

		public Log()
		{
			InitializeComponent();
			//save_load = new save_load_XML();
			
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			LogView.ItemsSource = save_load.allRec;
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}
	}
}
