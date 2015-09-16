using System;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Collections.Generic;

using Mp3Player.UI.MainMenuStrip;

namespace Mp3Player
{
	public partial class MainForm : Form
	{
		private bool _isPlay;
		private ListViewLoader _listViewLoadr;
		private WaveOut _waveOut;
		private MainMenuLoader _mainMenuLoader;		
		
		public MainForm()
		{
			var start = DateTime.Now.Millisecond;
			InitializeComponent();

			this.DoubleBuffered = true;
			
			_isPlay = false;
			listViewMusicCollection.View = View.Details;
			listViewMusicCollection.AllowColumnReorder = true;
			listViewMusicCollection.GridLines = false;
			//listViewMusicCollection.Columns.Add("№");
			listViewMusicCollection.Columns.Add("File Name");
			listViewMusicCollection.Columns.Add("Extension");
			listViewMusicCollection.Columns.Add("asd");
			listViewMusicCollection.Columns.Add("12423");			

			listViewMusicCollection.AllowDrop = true;
			listViewMusicCollection.DragDrop += listViewMusicCollection_DragDrop;
			listViewMusicCollection.DragEnter += listViewMusicCollection_DragEnter;

			
			_listViewLoadr = new ListViewLoader(listViewMusicCollection);
			_listViewLoadr.DirectoryPath = @"example\";
			_listViewLoadr.GetItemToWrite = new ListViewLoader.GetItemDelegat( (fileInfo) => {
				return new object[]{fileInfo.Name, fileInfo.Extension}; });
			_listViewLoadr.Load();

			_mainMenuLoader = new MainMenuLoader(this.MainMenu);
			_mainMenuLoader.Load();
			_waveOut = new WaveOut();
			var tt = DateTime.Now.Millisecond - start;
			System.Diagnostics.Debug.WriteLine(tt);
		}

		

		void listViewMusicCollection_DragEnter(object sender, DragEventArgs e)
		{
			 e.Effect = DragDropEffects.Link;
			//throw new NotImplementedException();
		}

		void listViewMusicCollection_DragDrop(object sender, DragEventArgs e)
		{
			object obj = e.Data.GetData("FileDrop");
			ListViewSetData((string[])obj);
		}
		private void ListViewSetData(string[] array)
		{
			ListViewItem[] lvi = new ListViewItem[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				lvi[i] = _listViewLoadr.ItemWriter(Path.GetFileName(array[i]), i.ToString());
			}
			listViewMusicCollection.Items.AddRange(lvi);
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
