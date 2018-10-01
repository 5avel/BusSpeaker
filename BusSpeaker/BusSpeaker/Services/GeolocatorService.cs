﻿using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
            //If updating the UI, ensure you invoke on main thread
            //var position = e.Position;
            //var output = "Full: Lat: " + position.Latitude + " Long: " + position.Longitude;
            //output += "\n" + $"Time: {position.Timestamp}";
            //output += "\n" + $"Heading: {position.Heading}";
            //output += "\n" + $"Speed: {position.Speed}";
            //output += "\n" + $"Accuracy: {position.Accuracy}";
            //output += "\n" + $"Altitude: {position.Altitude}";
            //output += "\n" + $"Altitude Accuracy: {position.AltitudeAccuracy}";
            //Debug.WriteLine(output);
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