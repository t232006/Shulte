using System;
using System.Collections.Generic;
using System.Text;

namespace Shulte
{
	class gridBuilder
	{
		StringBuilder xmpl;
		public engine en;
		string Cellscreator(byte volume, byte ii, byte jj)
		{
			string insstyle = "{StaticResource BlackButton}";
			return $@"<Button Text = ""{ volume} "" Pressed=""onButtonPressed"" Grid.Row = ""{ii}"" Grid.Column = ""{jj}"" Style = ""{insstyle}"" />";
		}
		public string getGrid(bool _rule)
		{
			en = new engine(_rule);
			byte i; byte j;
			xmpl = new StringBuilder();
			xmpl.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
				"<ContentPage xmlns = \"http://xamarin.com/schemas/2014/forms\" " +
				"xmlns:x = \"http://schemas.microsoft.com/winfx/2009/xaml\" " +
				"x:Class = \"Shulte.MainPage\">");
			xmpl.Append("<Grid><Grid.RowDefinitions>");
			for (i = 0; i < 7; i++)
				xmpl.Append(@"<RowDefinition Height="" * ""/>");
			xmpl.Append("</Grid.RowDefinitions>");
			xmpl.Append("<Grid.ColumnDefinitions>");
			for (i = 0; i < 7; i++)
				xmpl.Append(@"<ColumnDefinition Width="" * ""/>");
			xmpl.Append("</Grid.ColumnDefinitions>");
			for (i = 0; i < 7; i++)
				for (j = 0; j < 7; j++)
					xmpl.Append(Cellscreator(en.arr[i, j].Drawvalue, i, j));
			xmpl.Append("</Grid></ContentPage>");
			return xmpl.ToString();
			
		}
	}
}
