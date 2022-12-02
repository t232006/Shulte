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
		bool toHideThis;
		public bool ToHideThis { set { toHideThis = value; } } 
		public string RealValue { get; set; }
		public StretchButton()
		{
			button = new Button { };
			button.Clicked += (sender, e) =>
			{
				pressed?.Invoke(this, e);
				if (toHideThis)
				{
					button.BackgroundColor = Color.Gold;
					button.TextColor = Color.Gold;
				} else
				if (toHide) toHideThis = true; //if pressed wrong to return previous state
				
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