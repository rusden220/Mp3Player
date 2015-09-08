using System;
using System.IO;

namespace PluginForm
{
	public enum Status
	{
		Enable,
		Disable
	}
	public enum LoadEvent
	{
		onClick,
		onLoad
	}
	[Serializable]
	public class Plugin
	{
		private string _name; //name of file		
		private string _filePath; // path to the plug-in
		private Status _status;  // status of plug-in, does allow to load or not;
		private LoadEvent _loadEvent; // when should load the plug-in
		[NonSerialized]
		private string _code; //code of the plug-in

		public Plugin()
		{
			_name = "";
			_filePath = "";
			_status = PluginForm.Status.Disable;
			_loadEvent = LoadEvent.onClick;
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string FilePath
		{
			get { return _filePath; }
			set
			{
				_filePath = value;
				if (_name == "" || _name == null)
				{
					_name = Path.GetFileName(_filePath);
				}
			}
		}
		public Status Status
		{
			get { return _status; }
			set { _status = value; }
		}
		public LoadEvent LoadEvent
		{
			get { return _loadEvent; }
			set { _loadEvent = value; }
		}
		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}
	}
}
