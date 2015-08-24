using System;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace Mp3Player
{
	public partial class MainForm : Form
	{
		private bool _isPlay;
		private ListViewLoader _listViewLoadr;
		private WaveOut _waveOut;
		
		public MainForm()
		{
			InitializeComponent();

			_isPlay = false;
			listViewMusicCollection.View = View.Details;
			listViewMusicCollection.AllowColumnReorder = true;
			listViewMusicCollection.GridLines = false;
			listViewMusicCollection.Columns.Add("№");
			listViewMusicCollection.Columns.Add("Name");
			listViewMusicCollection.Columns.Add("Extension");

			_listViewLoadr = new ListViewLoader(listViewMusicCollection);
			_listViewLoadr.DirectoryPath = @"example\";
			_listViewLoadr.GetItemToWrite = new ListViewLoader.GetItemDelegat( (fileInfo) => {
				return new object[]{fileInfo.Name, fileInfo.Extension}; });
			_listViewLoadr.Load();

			_waveOut = new WaveOut();
		}

		private void buttonPlayPause_Click(object sender, EventArgs e)
		{
			if (_isPlay)
			{
				buttonPlayPause.Text = "Start";
				_waveOut.Pause();
			}
			else
			{
				buttonPlayPause.Text = "Pause";
				_waveOut.Resume();				
			}
			_isPlay = !_isPlay;
		}
		private void PlayMp3(string fileName)
		{
			_waveOut.Init(new AudioFileReader(fileName));
			_waveOut.Play();
			_isPlay = true;
			buttonPlayPause.Text = "Pause";
		}
		private void listViewMusicCollection_DoubleClick(object sender, EventArgs e)
		{
			var coll = listViewMusicCollection.SelectedIndices.GetEnumerator();
			if (coll.MoveNext())
			{
				int i = (int)coll.Current;
				var fileName = (listViewMusicCollection.Items[i].Tag as FileInfo).FullName;
				PlayMp3(fileName);
			} 
		}

	}
}
