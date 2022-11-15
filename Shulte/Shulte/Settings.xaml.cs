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
		public SettingViewModel _svm;
		public Settings()
		{
			InitializeComponent();
			//this.BindingContext = _svm;

		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_svm.SaveModel();
		}
	}
}