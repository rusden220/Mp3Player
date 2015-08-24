using System;
using NAudio;
using NAudio.Wave;

namespace Mp3Player
{
	class NAudioWrapper
	{
		private AudioFileReader _audioFileReader;
		private WaveOut _waveOut;
		public NAudioWrapper()
		{
 
		}
		public void PlayMp3(string fileName)
		{
			_audioFileReader = new AudioFileReader(fileName);
			_waveOut = new WaveOut();
			_waveOut.Init(_audioFileReader);
			_waveOut.Play();
		}
		public void Pause()
		{
 			
		}
	}
}
