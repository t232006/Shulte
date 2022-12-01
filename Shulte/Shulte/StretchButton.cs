using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Shulte
{
	
	public class StretchButton : ContentView
	{
		public event EventHandler pressed;
		Button button;
		public Style style
		{
			set { button.Style = value; }
		}
		public string Text 
		{
			set { button.Text = value; }
		}
		bool toHide;
		public bool ToHide
		{
			set { toHide = value; }
		}
		public string RealValue { get; set; }
		public StretchButton()
		{
			button = new Button { };
			button.Clicked += (sender, e) =>
			{
				pressed?.Invoke(this, e);
				if (toHide)
				{
					button.BackgroundColor = Color.Gold;
					button.TextColor = Color.Gold;
				}
				
			};
			Content = button;
			button.SizeChanged += (sender, e) =>
			{
				button.FontSize = Height > Width ? Width / 3 : Height / 3;
				button.CornerRadius = (int)button.FontSize - 7;
			};
			
		}
	}
}