using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Shulte
{
	class settingsModel
	{
		public bool RedView { get; set; }
		public byte Dimension { get; set; }
		public bool SpotSelected { get; set; }
		public bool TimeRestricted { get; set; }
		public byte GameTime { get; set; }
		public bool ShowTime { get; set; }
		public settingsModel()
		{
			RedView = Preferences.Get("Re",false);
			Dimension = (byte)Preferences.Get("Dim", 7);
			SpotSelected = Preferences.Get("SpotSel", false);
			TimeRestricted = Preferences.Get("TimeRestr", false);
			GameTime = (byte)Preferences.Get("GameTime", 5);
			ShowTime = Preferences.Get("ShowTime", false);	
		}
		public void saveModel()
		{
			Preferences.Set("Red", RedView);
			Preferences.Set("Dim", Dimension);
			Preferences.Set("SpotSel", SpotSelected);
			Preferences.Set("TimeRestr", TimeRestricted);
			Preferences.Set("GameTime", GameTime);
			Preferences.Set("Showtime", ShowTime);
		}

	}
}
