using System;
using System.Windows.Forms;
using Mp3Player.UI;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.IO;


namespace Mp3Player.UI.MainMenuStrip
{
	public class MainMenuLoader : ILoader, IDisposable
	{
		private MenuStrip _mainMenu;//contain MainMune bar
		private Stack<ToolStripMenuItem> _mainMenuItems; //stack for add a subitems in subitems 

		private delegate bool NodeHandlerDelegate(XmlReader xmlReader); //delegate for handle a node in XML
		private NodeHandlerDelegate _nodeHandler;//Node handler for XMl
		private Action<XmlReader> _nodeHandlerWrapper; // makes an appearance code better

		private string _currentItemName;//buffer variable for a name of current item

		public MainMenuLoader()
			: this(new MenuStrip())
		{ }
		public MainMenuLoader(MenuStrip mainMenu)
		{
			_mainMenu = mainMenu;

			_nodeHandler += NodeItems;
			_nodeHandler += NodeItem;
			_nodeHandler += NodeHandler;
			_nodeHandlerWrapper = (xmlReader) => {
				foreach (var item in _nodeHandler.GetInvocationList())
					if (((NodeHandlerDelegate)item)(xmlReader)) break;
			};

		}

		public MenuStrip MainMenu
		{
			get { return _mainMenu; }
		}

		public void Load()
		{
			try
			{
				string xml = Properties.Resources.MainMenu;
				using (var xmlReader = XmlReader.Create(new StringReader(xml)))
				{
					while (xmlReader.Read())
					{
						switch (xmlReader.NodeType)
						{
							case XmlNodeType.Element:
								_nodeHandlerWrapper(xmlReader);
								break;
							case XmlNodeType.EndElement:
								_nodeHandlerWrapper(xmlReader);
								break;
							default:
								break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogWriter.WriteError(ex);
				throw;
			}

		}

		#region nodeHandler

		//if true, break find an another node handler
		private bool NodeItems(XmlReader xmlReader)
		{
			if (xmlReader.Name == "Items")
			{
				_mainMenuItems = new Stack<ToolStripMenuItem>();
				return true;
			}
			return false;
		}
		private bool NodeItem(XmlReader xmlReader)
		{
			if (xmlReader.Name == "Item")
			{
				if (xmlReader.NodeType != XmlNodeType.EndElement)
				{
					_currentItemName = xmlReader.GetAttribute("name");
				}
				else _mainMenuItems.Pop();
				return true;
			}
			return false;
		}
		private bool NodeHandler(XmlReader xmlReader)
		{
			if (xmlReader.Name == "Handler")
			{
				var handlerName = xmlReader.GetAttribute("value");
				var type = xmlReader.GetAttribute("type");
				if (type == "cs")
				{
					var typeofMF = typeof(MainForm).AssemblyQualifiedName;
					var aqn = typeofMF.Substring(typeofMF.IndexOf(" ") - 1);
					if (xmlReader.GetAttribute("namespace") != null)
					{
						string atr = ", " + xmlReader.GetAttribute("namespace");
						aqn = atr;
						foreach (var item in new string[] { "version", "culture", "publickeytoken" })
						{
							atr = xmlReader.GetAttribute(item);
							if (atr != null)
								aqn += ", " + item + "=" + atr;
							else throw new Exception("can't find a " + item + "in xml MainMenu");
						}
					}
					Type classHandler = Type.GetType(handlerName + aqn);
					if (classHandler == null)
					{
						throw new Exception("can't load an assembly " + handlerName + aqn);
					}
					var menuItem = (ToolStripMenuItem)Activator.CreateInstance(classHandler);
					menuItem.Text = _currentItemName;
					if (_mainMenuItems.Count == 0)					
						_mainMenu.Items.Add(menuItem);			
					else					
						_mainMenuItems.Peek().DropDownItems.Add(menuItem);					
					_mainMenuItems.Push(menuItem);
				}
				else if (type == "js")
				{

				}
				else throw new Exception("unknown type");
				return true;
			}
			return false;
		}
		#endregion

		[Obsolete]
		public void LoadAsinc()
		{
			System.Threading.ThreadPool.QueueUserWorkItem((obj) => {
				Load();
			}, this);

		}
		public void Dispose()
		{
			_nodeHandler -= NodeItems;
			_nodeHandler -= NodeItem;
			_nodeHandler -= NodeHandler;

			_mainMenu.Dispose();
		}
	}
}
