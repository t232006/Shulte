using System;
using System.Collections.Generic;
using System.Text;

namespace Shulte
{
	public class gridBuilder
	{
		StringBuilder xmpl;
		public engine en;
		string Cellscreator(byte volume, bool Red, byte ii, byte jj)
		{
			string insstyle;
			if (Red) insstyle = "{StaticResource RedButton}";
			else insstyle = "{StaticResource BlackButton}";
			return $@"<Button Text = ""{ volume} "" Pressed=""onButtonPressed"" Grid.Row = ""{ii}"" Grid.Column = ""{jj}"" Style = ""{insstyle}"" />";
		}
		public string getGrid(bool _rule, byte dim)
		{
			en = new engine(_rule, dim);
			byte i; byte j;
			xmpl = new StringBuilder();
			xmpl.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
				"<ContentPage xmlns = \"http://xamarin.com/schemas/2014/forms\" " +
				"xmlns:x = \"http://schemas.microsoft.com/winfx/2009/xaml\" " +
				"x:Class = \"Shulte.MainPage\">");
			xmpl.Append("<Grid><Grid.RowDefinitions>");
			for (i = 0; i < dim; i++)
				xmpl.Append(@"<RowDefinition Height="" * ""/>");
			xmpl.Append("</Grid.RowDefinitions>");
			xmpl.Append("<Grid.ColumnDefinitions>");
			for (i = 0; i < dim; i++)
				xmpl.Append(@"<ColumnDefinition Width="" * ""/>");
			xmpl.Append("</Grid.ColumnDefinitions>");
			for (i = 0; i < dim; i++)
				for (j = 0; j < dim; j++)
					xmpl.Append(Cellscreator(en.arr[i, j].Drawvalue, en.arr[i, j].DoRed, i, j));
			xmpl.Append("</Grid></ContentPage>");
			return xmpl.ToString();
			
		}
	}
}
