using System;
using System.Windows.Forms;
using System.Reflection;

namespace Mp3Player.UI.MainMenuStrip
{
	class MainMenuAbout: ToolStripMenuItem
	{
		private readonly string _aboutText;
		private readonly string _aboutTitile;

		public MainMenuAbout()
			: base()
		{
			_aboutText = "This is simple mp3 player\nCreated by Surin.denis.k@gmail.com\nVersion: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			_aboutTitile = "About";
			base.Text = "About";
		}
		protected override void OnClick(EventArgs e)
		{
			MessageBox.Show(_aboutText, _aboutTitile, MessageBoxButtons.OK);
			base.OnClick(e);
		}
	}
}
