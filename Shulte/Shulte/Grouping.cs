using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Shulte
{
	public class Grouping<S, T> : ObservableCollection<T>
	{
		public S Name { get; set; }
		public Grouping(S name, IEnumerable<T> items)
		{
			Name = name;
			foreach (T item in items)
				Items.Add(item);
		}
	}
}
