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
		string date;
		string time;
		public string Time
		{
			get => time;
			set { time = value; }
		}
		public string Date
		{
			get => date;
			set { date = value; }
		}
		public DateTime Datetime
		{
			set
			{
				date = value.ToShortDateString();
				time = value.ToShortTimeString();
			}
		}
		public string rule { get; set; }
		public byte dimention { get; set; }
		public string totaltime { get; set; }
		public string count { get; set; }
		public byte mistakes { get; set; }
	}
	public class save_load_XML
	{
		public ObservableCollection<saver> allRec { get; set; }
		//public ICommand Delete { get; protected set; } 
		XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<saver>));
		
		public save_load_XML()
		{
			//Delete = new Command(del);
			try
			{
				load();
			}
			catch(FileNotFoundException)
			{
				 allRec = new ObservableCollection<saver>(); 
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
			//using (StreamReader fs = new StreamReader(getFile()))
			{
				try
				{
					//string s = fs.ReadToEnd();
					//File.Delete(getFile());
					allRec = (ObservableCollection<saver>)ser.Deserialize(fs);
				}
				catch 
				{
					File.Delete(getFile()); 
					allRec = new ObservableCollection<saver>(); 
				}

			}
		}
	}
}
