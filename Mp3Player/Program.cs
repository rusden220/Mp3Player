using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mp3Player
{
	static class Program
	{
		private static MainForm _mainForm;

		public static MainForm MainForm
		{
			get { return Program._mainForm; }
		}
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{			
			_mainForm = new Mp3Player.MainForm();
			Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(_mainForm);
		}
	}
}
