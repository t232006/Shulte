using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Shulte
{
	public class saver
	{
		public DateTime datetime;
		public byte dimention;
		public string totaltime;
		public string count;
		public byte mistakes;
	}
	public class save_load_XML
	{
		public ObservableCollection<saver> allRec = new ObservableCollection<saver>();
		XmlSerializer ser = new XmlSerializer(typeof(saver));
		
		public save_load_XML()
		{
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
				allRec = (ObservableCollection<saver>)ser.Deserialize(fs);
			}
		}
	}
}
