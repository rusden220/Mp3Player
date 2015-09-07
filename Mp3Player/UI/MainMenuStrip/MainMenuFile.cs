using System;
using System.Windows.Forms;

namespace Mp3Player.UI.MainMenuStrip
{
	class MainMenuFile:ToolStripMenuItem
	{
		public MainMenuFile():base()
		{
			base.Text = "File";
		}		
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}
	}
}
