using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Mp3Player.UI;

namespace Mp3Player
{
	/// <summary>
	/// Loader for loading data from 
	/// </summary>
	public class ListViewLoader: IDisposable, ILoader
	{
		private ListView _listViewLoaded;		
		private Thread _threadLoadAsinc;
		private string _directoryPath;

		public delegate void LoadEventHandler(object sender, EventArgs e);
		public event LoadEventHandler Loaded;

		private long _countAdded;//amount of added items
		//public delegate void WriteProviderDelegate(params object[] obj);
		//public WriteProviderDelegate _writeProvide;

		public delegate object[] GetItemDelegat(FileInfo fileInfo);
		private GetItemDelegat _getItemToWrite;

		public GetItemDelegat GetItemToWrite
		{
			get { return _getItemToWrite; }
			set { _getItemToWrite = value; }
		}

		public ListViewLoader()
		{
			_listViewLoaded = new ListView();
			_getItemToWrite = Dummy;
		}
		public ListViewLoader(ListView listView)
		{
			_listViewLoaded = listView;
		}

		public ListViewItem ItemWriter(params object[] obj)
		{
			ListViewItem lvi = new ListViewItem(_countAdded++.ToString());
			//check null value
			foreach (var item in obj)
			{
				lvi.SubItems.Add(item.ToString());				
			}
			return lvi;
		}
		public void Load()
		{
			LogWriter.WriteLog("start to load a data");
			try
			{	
				foreach (var item in Directory.GetFiles(_directoryPath))
				{
					var fi = new FileInfo(item);
					var lvItem = ItemWriter(_getItemToWrite(fi));
					lvItem.Tag = fi;
					_listViewLoaded.Items.Add(lvItem);
				}
				//return _listViewLoaded;
			}
			catch (Exception ex)
			{
				LogWriter.WriteError(ex, "ListView data Load error");
				throw;
			}			
		}
		//public virtual void OnLoaded(object sender, EventArgs e)
		//{
		//}
		public string DirectoryPath
		{
			get { return _directoryPath; }
			set { _directoryPath = value; }
		}
		public ListView ListViewLoaded
		{
			get { return _listViewLoaded; }
			set { _listViewLoaded = value; }
		}
		public void LoadAsinc()
		{
			LogWriter.WriteLog("start to async load data");
			_threadLoadAsinc = new Thread(() =>
			{
				try
				{
					//i don't know should i write that via sync method
					Load();
				}
				catch (Exception ex)
				{
					LogWriter.WriteError(ex, "ListView LoadAsinc data error");
				}
				LogWriter.WriteLog("end asinc load");
				//raise event
			});
			_threadLoadAsinc.Start();
		}

		public void Dispose()
		{
			if (_threadLoadAsinc != null && _threadLoadAsinc.IsAlive)
				_threadLoadAsinc.Abort();			
		}
		private object[] Dummy(FileInfo fileInfo)
		{
			return new object[] { fileInfo.Name };
		}
	}
}
