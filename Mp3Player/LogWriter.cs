/*finish writing:
 *	make a stream to write a bugs
 *	make a customizable via class constructor
 *	make 
 */
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mp3Player
{
	class LogWriter
	{
		private static string _errorMessage = "Error ";
		private static string _fileName = "Mp3Player.log";
		private static Encoding _encoding = Encoding.UTF8;
		public static bool WriteLog(string message)
		{
			lock (_fileName)
			{
				bool isExit = true;
				do
				{
					isExit = true;
					try
					{
						using (StreamWriter stw = new StreamWriter(_fileName, true, _encoding))
						{
							stw.WriteLine(DateTime.Now.ToString() + " " + message);
						}
						return true;
					}
					catch (Exception ex)
					{
						//var messResp = MessageBox.Show("LogWriter Error " + ex.Message + "\ntry again?", "Error", MessageBoxButtons.YesNo);
						//if (messResp == DialogResult.Yes) isExit = false;
					}
				} while (isExit);
				return false;			
			}			
		}

		public static bool WriteError(Exception ex, string message = "")
		{
			return LogWriter.WriteLog(message 
				+ "\n" 
				+ _errorMessage 
				+ LogWriter.ExceptionToString(ex));
		}
		private static string ExceptionToString(Exception ex)
		{
			return "\t" + ex.Message 
				+ "\n\t" + ex.Source 
				+ "\n\t" + ex.StackTrace;
		}
	}
}
