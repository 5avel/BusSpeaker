using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BusSpeaker.Services
{
    public class GeolocatorService
    {
        public event EventHandler<PositionEventArgs> MyPositionChanged;
        public async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 5, true);

            CrossGeolocator.Current.PositionChanged += PositionChanged;
            
            CrossGeolocator.Current.PositionError += PositionError;
        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {
            MyPositionChanged?.Invoke(this, e);
        }

        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            Debug.WriteLine(e.Error);
            //Handle event here for errors
        }

        public async Task StopListening()
        {
            if (!CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PositionError;
        }
    }
}
