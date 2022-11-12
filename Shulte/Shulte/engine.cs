﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Shulte
{
	public struct Cell
	{
		byte drawvalue;
		public byte Drawvalue
		{
			get { return drawvalue; }

		}
		Color color;
		public bool DoRed
		{
			set
			{
				if (value) color = Color.Red;
				else color = Color.Black;
			}
			get
			{
				if (color == Color.Red) return true;
				else return false;
			}
		}
		byte realvalue;
		
		public byte Realvalue
		{
			set 
			{
				realvalue = value;
				if (DoRed) drawvalue = (byte)(50 - realvalue);
				else drawvalue = realvalue;
			}
		}
	}
	public class engine
	{
		public Cell[,] arr = new Cell[7, 7];
		Byte curnum;
		readonly DateTime start;
		//DateTime finish;
		public DateTime Start { get => start; }
		//public DateTime Finish { get => finish; }
		bool RedRule { get; set; }
		public string CheckAnsw (byte answer)
		{
			if (curnum == 50)
			{
				DateTime finish = DateTime.Now;
				return finish.Subtract(start).ToString();
			}
			if (RedRule)
			{
				if (curnum % 2 == 0)
				{
					if (25 - (curnum / 2) == answer) { curnum++; return "true"; } 
				}
				else
				{
					if (curnum / 2 + 1 == answer) { curnum++; return "true"; }
				}
			}
			else if (answer == curnum) { curnum++; return "true"; }
			return "false";
		}
		public engine(bool _redRule)
		{
			RedRule = _redRule;
			start = DateTime.Now;
			curnum = 1;
			List<byte> cont = new List<byte>();
			Random k = new Random();
			byte K; int i;
			for (i = 0; i < 49; i++)
			{
				do
				{
					K = (byte)k.Next(1, 50);
				}

				while (cont.Contains(K));
				cont.Add(K);
			}
			for (i = 0; i < 49; i++)
			{
				if (_redRule && (cont[i] > 25))
					arr[i / 7, i % 7].DoRed = true;
				else
					arr[i / 7, i % 7].DoRed = false;
				arr[i / 7, i % 7].Realvalue = cont[i];
			}

		}
		
	}
}
