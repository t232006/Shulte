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
		
		public MainPage()
		{
			InitializeComponent();
			gridBuilder gb = new gridBuilder();
			this.LoadFromXaml(gb.getGrid());


		}
	}
}
