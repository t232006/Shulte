using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Shulte
{
	class settingsModel
	{
		public bool RedView;
		public byte Dimension;
		public bool SpotSelected;
		public bool TimeRestricted;
		public bool Punish;
		public byte GameTime;
		public bool ShowTime;
		public settingsModel()
		{
			RedView = Preferences.Get("Red",false);
			Dimension = (byte)Preferences.Get("Dim", 7);
			SpotSelected = Preferences.Get("SpotSel", false);
			Punish = Preferences.Get("Pun", false);
			TimeRestricted = Preferences.Get("TimeRestr", false);
			GameTime = (byte)Preferences.Get("GameTime", 5);
			ShowTime = Preferences.Get("ShowTime", false);	
		}
		public void saveModel()
		{
			Preferences.Set("Red", RedView);
			Preferences.Set("Dim", Dimension);
			Preferences.Set("SpotSel", SpotSelected);
			Preferences.Set("Pun", Punish);
			Preferences.Set("TimeRestr", TimeRestricted);
			Preferences.Set("GameTime", GameTime);
			Preferences.Set("ShowTime", ShowTime);
		}

	}
}
