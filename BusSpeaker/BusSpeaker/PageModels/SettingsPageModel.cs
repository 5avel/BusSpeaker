using BusSpeaker.Services;
using System;
using System.Windows.Input;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xamarin.Forms;
using FreshMvvm;

namespace BusSpeaker.PageModels
{
    public class SettingsPageModel : FreshBasePageModel
    {

        private double DelphinLat = 48.4601;
        private double DelphinLon = 35.039755;


        private IGeolocatorService _geolocatorService;
        public SettingsPageModel(IGeolocatorService geolocatorService)
        {
            _geolocatorService = geolocatorService;
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
                    RaisePropertyChanged();
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
                    RaisePropertyChanged();
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
                    RaisePropertyChanged();
                }
            }
        }
    }
}