using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Shulte
{
	public struct Cell
	{
		byte drawvalue;
		public string Drawvalue
		{
			get { return drawvalue.ToString(); }

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
		int amount;
		public int Amount { set => amount = value; }
		byte realvalue;
		
		public byte Realvalue
		{
			set 
			{
				realvalue = value;
				if (DoRed) drawvalue = (byte)(amount+1 - realvalue);
				else drawvalue = realvalue;
			}
			get => realvalue;
		}
	}
	public class engine
	{
		public Cell[,] arr;
		byte curnum;
		public byte Curnum { get => curnum; }
		readonly DateTime start;
		TimeSpan elapse;
		bool timeRestr;
		//bool finish;
		
		/*public byte Elapse 
		{
			set 
			{
				elapse = new TimeSpan(0, value, 0);
			} 
		}*/

		public string CheckTime(byte mistakes) 
		{ 
			//get
			//{
			DateTime now = DateTime.Now;
			now = now.AddSeconds(mistakes * 5);
			TimeSpan ts = now.Subtract(start);
			if (timeRestr)
				ts = elapse.Subtract(ts);
			return String.Format("{0:00} : {1:00}", ts.Minutes, ts.Seconds);
			//} 
		}
		bool RedRule { get; set; }
		byte dim;
		int amount;
		public string CheckAnsw (byte answer)
		{
			if (curnum == amount)
			{
				return "finish";
			}
			int Amount = amount % 2 == 0 ? amount : amount + 1;
			if (RedRule)
			{
				if (curnum % 2 == 0)
				{
					if (Amount / 2 + (curnum / 2) == answer) { curnum++; return "true"; } 
				}
				else
				{
					if (curnum / 2 + 1 == answer) { curnum++; return "true"; }
				}
			}
			else if (answer == curnum) { curnum++; return "true"; }
			return "false";
		}
		public engine(bool _redRule, byte _dim, bool _timeRestr,  byte _gameTime)
		{
			dim = _dim;
			amount = dim * dim;
			arr = new Cell[dim, dim];
			RedRule = _redRule;
			start = DateTime.Now;
			elapse = new TimeSpan(0, _gameTime, 0);
			//finish = fasle;
			timeRestr = _timeRestr;
			curnum = 1;
			List<byte> cont = new List<byte>();
			Random k = new Random();
			byte K; int i;
			int lim = (amount % 2 == 0) ? amount / 2 : amount / 2 + 1;
			for (i = 0; i < amount; i++)
			{
				do
				{
					K = (byte)k.Next(1, amount+1);
				}

				while (cont.Contains(K));
				cont.Add(K);
			}
			for (i = 0; i < amount; i++)
			{
				int ii = i / dim;
				int jj = i % dim;
				arr[ii, jj].Amount = amount;
				if (_redRule && (cont[i] > lim))
					arr[ii, jj].DoRed = true;
				else
					arr[ii, jj].DoRed = false;
				arr[ii, jj].Realvalue = cont[i];
			}
		}
	}
}
