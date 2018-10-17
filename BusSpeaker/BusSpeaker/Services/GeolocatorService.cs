using BusSpeaker.Services.Intefaces;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BusSpeaker.Services
{
    public class GeolocatorService : IGeolocatorService
    {
        public event EventHandler<PositionEventArgs> BusPositionChanged;
        public async Task StartListening()
        {
            var hasPermission = await Utils.Utils.CheckPermissions(Permission.Location);
            if (!hasPermission)
                return;

            if (CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 5, true);

            CrossGeolocator.Current.PositionChanged += PositionChanged;
            
            CrossGeolocator.Current.PositionError += PositionError;
        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {
            BusPositionChanged?.Invoke(this, e);
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
