﻿using System;
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
		//Label selected = new Label();
		public Log()
		{
			InitializeComponent();
			//save_load = new save_load_XML();
			//this.BindingContext = save_load;
		}
		
		protected override void OnAppearing()
		{
			base.OnAppearing();
			//LogView.ItemsSource = save_load.allRec;
			//this.BindingContext = save_load.allRec;
			var groups = save_load.allRec
										.GroupBy(p => p.Date)
										.Select(g => new Grouping<string, saver>(g.Key, g));
			DateGroup = new ObservableCollection<Grouping<string, saver>>(groups);
			this.BindingContext = this;
		}

		private void onClick(object Sender, EventArgs e)
		{	
			saver s = (saver)(Sender as MenuItem).CommandParameter ;
			if (s == null) return;
			save_load.allRec.Remove(s);
		}
	}
}
