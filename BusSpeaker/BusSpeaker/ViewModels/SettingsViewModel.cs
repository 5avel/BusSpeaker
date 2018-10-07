using BusSpeaker.Services;
using System;
using System.Windows.Input;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xamarin.Forms;

namespace BusSpeaker.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {

        private double DelphinLat = 48.4601;
        private double DelphinLon = 35.039755;


        private GeolocatorService _geolocatorService;
        public SettingsViewModel()
        {
            Title = "About";

            _geolocatorService = new GeolocatorService();
            _geolocatorService.MyPositionChanged += _geolocatorService_MyPositionChanged;


            StartNavigationCommand = new Command(async ()  => await _geolocatorService.StartListening());
            StopNavigationCommand = new Command(async () => await _geolocatorService.StopListening());
        }

        private void _geolocatorService_MyPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            DistaceToDelphin = GeolocatorUtils.CalculateDistance(DelphinLat, DelphinLon, e.Position.Latitude, e.Position.Longitude, GeolocatorUtils.DistanceUnits.Kilometers);
            Latitude = e.Position.Latitude;
            Longitude = e.Position.Longitude;
        }

        public ICommand StartNavigationCommand { get; }
        public ICommand StopNavigationCommand { get; }


        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    OnPropertyChanged();
                }
            }
        }
        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    OnPropertyChanged();
                }
            }
        }

        private double distaceToDelphin;
        public double DistaceToDelphin
        {
            get
            {
                return distaceToDelphin;
            }
            set
            {
                if (distaceToDelphin != value)
                {
                    distaceToDelphin = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}