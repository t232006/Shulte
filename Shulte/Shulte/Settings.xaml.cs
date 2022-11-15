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
	public partial class Settings : ContentPage
	{
		readonly SettingViewModel svm = new SettingViewModel();
		public Settings()
		{
			InitializeComponent();
			this.BindingContext = svm;

		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			svm.SaveModel();
		}
	}
}