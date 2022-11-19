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
		Label lab;
		bool alive = true;
		public bool Alive { set => alive = value; }
		public engine en;
		SettingViewModel sett;
		public SettingViewModel Settings { set => sett = value; }
		public PageBlack()
		{
			InitializeComponent();
		}
		public void Show()
		{
			en = new engine(sett.RedView, sett.Dimension, sett.TimeRestricted, sett.GameTime);
			byte i; byte j;

			lab = new Label()
			{
				BindingContext = sett
			};
			lab.SetBinding(IsVisibleProperty, "ShowTime");
			Device.StartTimer(TimeSpan.FromSeconds(1), onTimerTick);

			Grid grid = new Grid
			{
				RowDefinitions =
				{ new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }}
			};
			grid.Children.Add(lab, 0, 0);
			for (i = 0; i < sett.Dimension; i++)
				for (j = 0; j < sett.Dimension; j++)
				{
					Style s = en.arr[i, j].DoRed ? (Style)Resources["RedButton"] : (Style)Resources["BlackButton"];
					Button b = new Button
					{ Text = en.arr[i, j].Drawvalue,
						Style = s,
						AutomationId = en.arr[i, j].Realvalue.ToString()
					};
					b.Clicked += onButtonPressed;
					grid.Children.Add(b, i, j + 1);
				}
			Content = grid;
		}
		private bool onTimerTick()
		{
			lab.Text = en.CheckTime;
			if (lab.Text == "00 : 00")
			{
				alive = false;
				DisplayAlert("Игра закончена, время вышло", "Результат" + en.Curnum,"OK");
			}
			return alive;
		}
		private void onButtonPressed(Object sender, EventArgs e)
		{
			string s = en.CheckAnsw(byte.Parse((sender as Button).AutomationId));
			if (s == "false")
				DisplayAlert("Неверно", "Неверно", "OK");
			else if (s != "true")
			{
				DisplayAlert("Игра закончена", s, "OK");
				alive = false;
			}
			else if (sett.SpotSelected)
			{
				(sender as Button).BackgroundColor = Color.Gold;
				(sender as Button).TextColor = Color.Gold;
			}
		}
	}
}