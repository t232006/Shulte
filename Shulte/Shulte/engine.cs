using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Shulte
{
	struct Cell
	{
		public byte value;
	}
	class engine
	{
		public Cell[,] arr = new Cell[7, 7];
		public engine()
		{
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
				arr[i / 7, i % 7].value = cont[i];
			}

		}
	}
}
