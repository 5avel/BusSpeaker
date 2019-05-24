using BusSpeaker.Services.Intefaces;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace BusSpeaker.Services
{
    public class StopsSoundService : IStopsSoundService
    {
        private ISimpleAudioPlayer _player;
        public StopsSoundService(ISimpleAudioPlayer player)
        {
            _player = player;
        }

        public void PlaySound(string soundName)
        {
            var stream = GetStreamFromFile(soundName);

            if (stream == null) return;

            _player.Load(stream);
            _player.Play();
        }

        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("BusSpeaker.StopSounds." + filename);
            return stream;
        }
    }
}
