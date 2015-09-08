using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;

namespace PluginForm
{
	public class Plugins
	{
		private Encoding _fileEncoding;
		private string _pathToPluginsFile;
		//private Plugin[] _arrayPlugin;
		private List<Plugin> _listPlugin;
		public Plugins()
		{
			_fileEncoding = Encoding.UTF8;
			_pathToPluginsFile = @"Plugins\plugins.xml";
			LoadPluginsFromFile(_pathToPluginsFile);
		}
		public void LoadPlugins()
		{
			LoadPluginsFromFile(_pathToPluginsFile);
		}
		public void LoadPluginsFromFile(string path)
		{
			using (StreamReader str = new StreamReader(path, _fileEncoding))
			{
				var xs = new XmlSerializer(typeof(Plugin[]));
				_listPlugin = new List<Plugin>((IEnumerable<Plugin>)xs.Deserialize(str));
			}
		}
		public Plugin[] PluginsArray
		{
			get { return _listPlugin.ToArray(); }
		}
		public Encoding FileEncoding
		{
			get { return _fileEncoding; }
			set { _fileEncoding = value; }
		}
		public void AddNewPlugin(Plugin plugin)
		{
			if (isExist(plugin))
			{
				_listPlugin.Add(plugin);
				SavePlugins();
			}
		}
		public bool isExist(Plugin plugin)
		{
			foreach (var item in _listPlugin)
			{
				if (item.FilePath == plugin.FilePath)
					return false;
			}
			return true;
		}
		public void SavePlugins()
		{
			using (var str = new StreamWriter(_pathToPluginsFile, false, _fileEncoding))
			{
				var xs = new XmlSerializer(typeof(Plugin[]));
				xs.Serialize(str, (object)_listPlugin.ToArray());					
			}

		}
	}	
}
