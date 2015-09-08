using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;

namespace PluginForm
{

	/// <summary>
	/// Логика взаимодействия для PluginWindow.xaml
	/// </summary>
	public partial class PluginWindow : Window
	{
		private Plugins _plugins;

		public PluginWindow()
		{
			InitializeComponent();
			_plugins = new Plugins();
			var gridView = new GridView();
			listViewPlugins.View = gridView;

			gridView.Columns.Add(new GridViewColumn
			{
				Header = "Name",
				DisplayMemberBinding = new Binding("Name")
			});
			gridView.Columns.Add(new GridViewColumn
			{
				Header = "Status",
				DisplayMemberBinding = new Binding("Status")
			});
			gridView.Columns.Add(new GridViewColumn
			{
				Header = "EventStart",
				DisplayMemberBinding = new Binding("EventStart")
			});
			foreach (var item in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
			{
				listViewPlugins.Items.Add(new  { Name = "plugin " + item.ToString(), EventStart = "onLoad", Status = "Enable" });
			}
		}

		private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
			ofd.DefaultExt = ".js";
			ofd.Filter = "JavaScript File (*.js)|*.js";
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == true)
			{
				foreach (var item in ofd.FileNames)
				{
					_plugins.AddNewPlugin(new Plugin() { FilePath = item});
				}
			}
		}

		private void MenuItemPlay_Click(object sender, RoutedEventArgs e)
		{

		}
		private void MenuItemPause_Click(object sender, RoutedEventArgs e)
		{

		}

		private void MenuItemClear_Click(object sender, RoutedEventArgs e)
		{

		}

	}
}
