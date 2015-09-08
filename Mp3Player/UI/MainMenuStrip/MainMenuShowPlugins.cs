using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using PluginForm;


namespace Mp3Player.UI.MainMenuStrip
{
	class MainMenuShowPlugins: ToolStripMenuItem, IDisposable
	{
		PluginWindow _pluginWindow;
		public MainMenuShowPlugins()
			: base()
		{
			_pluginWindow = new PluginWindow();
		}
		protected override void OnClick(EventArgs e)
		{
			_pluginWindow.Show();
			base.OnClick(e);
		}

		public void Dispose()
		{
			_pluginWindow.Close();
		}

		
	}
}
