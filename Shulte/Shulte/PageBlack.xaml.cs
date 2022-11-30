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
		Label labTime;
		bool alive = true;
		public bool Alive { set => alive = value; }
		public engine en;
		SettingViewModel sett;
		public save_load_XML save_Load;
		public SettingViewModel Settings { set => sett = value; }
		byte mistakes;
		public PageBlack()
		{
			InitializeComponent();
			//this.BindingContext = sett
		}
		private void saverecord()
		{
			string spendTime;
			if (en.CheckTime(mistakes) == "00 : 00")
			{
				TimeSpan ts = new TimeSpan(0, sett.GameTime, 0);
				spendTime = String.Format("{0:00} : {1:00}", ts.Minutes, ts.Seconds);
			}
			else
				spendTime = en.CheckTime(mistakes);
			save_Load.AllRec.Add(new saver
			{
				Datetime = DateTime.Now,
				dimention = sett.Dimension,
				rule = sett.RedView ? "чередующиеся" : "черные",
				totaltime = sett.TimeRestricted ? spendTime : labTime.Text,
				count = en.Curnum.ToString(),
				mistakes = this.mistakes
			}); 
		} 
		public void Show()
		{
			en = new engine(sett.RedView, sett.Dimension, sett.TimeRestricted, sett.GameTime);
			byte i; byte j; mistakes = 0;

			labTime = new Label()
			{
				BindingContext = sett
			};
			labTime.SetBinding(IsVisibleProperty, "ShowTime");
			Device.StartTimer(TimeSpan.FromSeconds(1), onTimerTick);

			Grid grid = new Grid
			{
				RowDefinitions =
				{ new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }}
			};
			grid.Children.Add(labTime, 0, 0);
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
			if (sett.Punish)
				labTime.Text = en.CheckTime(mistakes);
			else
				labTime.Text = en.CheckTime(0);
			if (labTime.Text == "00 : 00")
			{
				alive = false;
				DisplayAlert("Игра закончена, время вышло", "Результат: " + (en.Curnum-1).ToString(),"OK");
				saverecord();
			}
			return alive;
		}
		private void onButtonPressed(Object sender, EventArgs e)
		{
			//saverecord();
			string s = en.CheckAnsw(byte.Parse((sender as Button).AutomationId));
			if (s == "false")
			{
				DisplayAlert("Неверно", "Неверно", "OK");
				mistakes++;
			}
			else if (s == "finish")
			{
				DisplayAlert("Игра закончена", labTime.Text, "OK");
				saverecord();
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