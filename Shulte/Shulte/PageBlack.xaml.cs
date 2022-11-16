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
	public partial class PageBlack : ContentPage
	{
		bool alive = true;
		//public bool Alive { set => alive = value; }
		public Label TimeLab;
		gridBuilder gb;
		public gridBuilder Gb { set => gb = value; }
		SettingViewModel settings;
		public SettingViewModel Settings { set => settings = value; }
		public void Start()
		{
			if (!this.FindByName<StackLayout>("contentStack").Children.Contains(TimeLab))
				this.FindByName<StackLayout>("contentStack").Children.Insert(0, TimeLab);
			Device.StartTimer(TimeSpan.FromSeconds(1), onTimerTick);
			TimeLab.SetBinding(Label.IsVisibleProperty, "ShowTime");
		}
		public PageBlack()
		{
			//InitializeComponent();

			TimeLab = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BindingContext = settings
			};
			
			//contentStack.Children.Insert(0, TimeLab);
			/*StackLayout st = new StackLayout();
			st.Children.i*/
			//Device.StartTimer(TimeSpan.FromSeconds(1), onTimerTick);
		}
		private bool onTimerTick()
		{
			TimeLab.Text = gb.en.CheckTime;
			return alive;
		}
		private void onButtonPressed(Object sender, EventArgs e)
		{
			string s = gb.en.CheckAnsw(byte.Parse((sender as Button).Text));
			if (s == "false")
				DisplayAlert("Неверно", "Неверно", "OK");
			else if (s != "true")
			{
				DisplayAlert("Игра закончена", s, "OK");
				alive = false;
			}
			else if (settings.SpotSelected)
			{
				(sender as Button).BackgroundColor = Color.Gold;
				(sender as Button).TextColor = Color.Gold;
			}
				

		}
	}
}