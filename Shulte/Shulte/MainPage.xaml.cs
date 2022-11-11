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
		static gridBuilder gb;
		public MainPage()
		{
			InitializeComponent();
		}
		protected void onBlackAppearing(Object sender, EventArgs e)
		{
			gb = new gridBuilder();
			 (sender as PageBlack).LoadFromXaml(gb.getGrid(false));
			(sender as PageBlack).gb = gb;
		}
		protected void onRedAppearing(Object sender, EventArgs e)
		{
			gb = new gridBuilder();
			(sender as PageRed).LoadFromXaml(gb.getGrid(true));
			(sender as PageRed).gb = gb;
		}

	}
}
