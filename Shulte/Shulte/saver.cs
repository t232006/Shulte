using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shulte
{
	public class saver
	{
		public DateTime datetime { get; set; }
		public byte dimention { get; set; }
		public string totaltime { get; set; }
		public string count { get; set; }
		public byte mistakes { get; set; }
	}
	public class save_load_XML
	{
		public ObservableCollection<saver> allRec { get; set; }
		public ICommand Delete { get; protected set; } 
		XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<saver>));
		
		public save_load_XML()
		{
			Delete = new Command(del);
			try
			{
				load();
			}
			catch(FileNotFoundException)
			{
			}
		}

		string getFile()
		{
			string inuse = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			return Path.Combine(inuse, "achivements.xml");
		}

		private void del(object item)
		{
			saver s = item as saver;
			if (s == null) return;
			allRec.Remove(s);
		}

		public void save()
		{
			
			using (FileStream fs = new FileStream(getFile(),FileMode.OpenOrCreate, FileAccess.Write))
			{
				ser.Serialize(fs, allRec);
			}
		} 
		public void load()
		{
			using (FileStream fs = new FileStream(getFile(), FileMode.Open, FileAccess.Read))
			{
				try
				{
					allRec = (ObservableCollection<saver>)ser.Deserialize(fs);
				}
				catch { }
				
			}
		}
	}
}
