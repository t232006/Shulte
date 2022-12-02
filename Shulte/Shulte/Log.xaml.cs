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
		public ObservableCollection<Grouping<string, saver>> DateGroup { get; set; }
		public ObservableCollection<saver> DateGroup1 { get; set; }
		//Label selected = new Label();
		public Log()
		{
			InitializeComponent();
			//save_load = new save_load_XML();
			//this.BindingContext = save_load;
		}
		private ObservableCollection<Grouping<string, saver>> getDateGroup()
		{
			var groups = save_load.AllRec
										.GroupBy(p => p.Date)
										.Select(g => new Grouping<string, saver>(g.Key, g));
			return new ObservableCollection<Grouping<string, saver>>(groups);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//LogView.ItemsSource = save_load.allRec;
			//this.BindingContext = save_load.allRec;
			DateGroup = getDateGroup();
			DateGroup1 = new ObservableCollection<saver>(save_load.AllRec);
			refresh();
			this.BindingContext = this;
		}

		private void refresh()
		{
			LogView.ItemsSource = DateGroup1;
			LogView.IsGroupingEnabled = false;
			DateGroup = getDateGroup();

			LogView.ItemsSource = DateGroup;
			LogView.IsGroupingEnabled = true;
		}
		private void onClick(object Sender, EventArgs e)
		{	
			saver s = (saver)(Sender as MenuItem).CommandParameter ;
			if (s == null) return;
			save_load.AllRec.Remove(s);
			refresh();

			
		}
	}
}
