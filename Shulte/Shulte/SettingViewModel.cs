using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shulte
{
	public class SettingViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		readonly private settingsModel setMod;
		public SettingViewModel()
		{
			setMod = new settingsModel();
		}
		public bool RedView
		{
			get => setMod.RedView;
			set
			{
				setMod.RedView = value;
				onPropertyChanged("RedView");
			}
		}
		public byte Dimension 
		{
			get => setMod.Dimension;
			set
			{
				setMod.Dimension = value;
				onPropertyChanged("Dimension");
			}
		}
		public bool SpotSelected
		{
			get => setMod.SpotSelected;
			set
			{
				setMod.SpotSelected = value;
				onPropertyChanged("SpotSelected");
			}
		}
		public bool TimeRestricted
		{
			get => setMod.TimeRestricted;
			set
			{
				setMod.TimeRestricted = value;
				onPropertyChanged("TimeRestricted");
			}
		}
		public byte GameTime
		{
			get => setMod.GameTime;
			set
			{
				setMod.GameTime = value;
				onPropertyChanged("GameTime");
			}
		}
		public bool Punish
		{
			get => setMod.Punish;
			set
			{
				setMod.Punish = value;
				onPropertyChanged("Punish");
			}
		}
		public bool ShowTime
		{
			get => setMod.ShowTime;
			set
			{
				setMod.ShowTime = value;
				onPropertyChanged("ShowTime");
			}
		}
		public void SaveModel()
		{
			setMod.saveModel();
		}
		private void onPropertyChanged(string v)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
		}
	}
}
