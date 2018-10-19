using BusSpeaker.Services.Intefaces;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BusSpeaker.Services
{
    public class StopsSoundService : IStopsSoundService
    {
        private ISimpleAudioPlayer player;
        public StopsSoundService()
        {
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        }

        public void PlaySound(string soundName)
        {
            var stream = GetStreamFromFile(soundName);

            if (stream == null) return;

            player.Load(stream);
            player.Play();
        }

        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("BusSpeaker.StopSounds." + filename);
            return stream;
        }
    }
}
