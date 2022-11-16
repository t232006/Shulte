using System;
using System.Collections.Generic;
using System.Text;

namespace Shulte
{
	public class gridBuilder
	{
		StringBuilder xmpl;
		public engine en;
		SettingViewModel sett;
		public gridBuilder(SettingViewModel _sett)
		{
			sett = _sett;
		}
		string Cellscreator(byte volume, bool Red, byte ii, byte jj)
		{
			string insstyle;
			if (Red) insstyle = "{StaticResource RedButton}";
			else insstyle = "{StaticResource BlackButton}";
			return $@"<Button Text = ""{ volume} "" Pressed=""onButtonPressed"" Grid.Row = ""{ii}"" Grid.Column = ""{jj}"" Style = ""{insstyle}"" />";
		}
		public string getGrid()
		{
			en = new engine(sett.RedView, sett.Dimension);
			byte i; byte j;
			xmpl = new StringBuilder();
			xmpl.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
				"<ContentPage xmlns = \"http://xamarin.com/schemas/2014/forms\" " +
				"xmlns:x = \"http://schemas.microsoft.com/winfx/2009/xaml\" " +
				"x:Class = \"Shulte.MainPage\">");
			xmpl.Append("<StackLayout x:Name=\"contentStack\">");
			xmpl.Append("<Grid x:Name=\"grid\"><Grid.RowDefinitions>");
			for (i = 0; i < sett.Dimension; i++)
				xmpl.Append(@"<RowDefinition Height="" * ""/>");
			xmpl.Append("</Grid.RowDefinitions>");
			xmpl.Append("<Grid.ColumnDefinitions>");
			for (i = 0; i < sett.Dimension; i++)
				xmpl.Append(@"<ColumnDefinition Width="" * ""/>");
			xmpl.Append("</Grid.ColumnDefinitions>");
			for (i = 0; i < sett.Dimension; i++)
				for (j = 0; j < sett.Dimension; j++)
					xmpl.Append(Cellscreator(en.arr[i, j].Drawvalue, en.arr[i, j].DoRed, i, j));
			xmpl.Append("</Grid>");
			xmpl.Append("</StackLayout></ContentPage>");
			return xmpl.ToString();
			
		}
	}
}
