using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using BusSpeaker.Models;
using System.Linq;
using BusSpeaker.Services.Intefaces;
using BusSpeaker.DAL.Intefaces;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.GoogleMaps;
using Position = Xamarin.Forms.GoogleMaps.Position;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps.Bindings;

namespace BusSpeaker.PageModels
{
    public class MapPageModel : FreshBasePageModel
    {
        private readonly IStopPointsService _stopPointsService;
        private readonly IGeolocatorService _geolocator;

        public MapPageModel(IStopPointsService stopPointsService, IGeolocatorService geolocator)
        {
            _stopPointsService = stopPointsService;
            _geolocator = geolocator;
            _geolocator.BusPositionChanged += _geolocator_BusPositionChanged;
            _stopPointsService.DirectionChanged += _stopPointsService_DirectionChanged;
        }

        private void _stopPointsService_DirectionChanged(object sender, EventArgs e)
        {
            Pins.Clear();
        }

        void _geolocator_BusPositionChanged(object sender, PositionEventArgs e)
        {
            if (Pins.Count == 0)
            {
                foreach (var point in _stopPointsService.StopPoints)
                {
                    Pins.Add(
                        new Pin
                        {
                            Label = point.Name,
                            Position = new Position(point.Latitude, point.Longitude)

                        }
                    );
                }
            }
            MoveCameraRequest.MoveCamera(CameraUpdateFactory.NewCameraPosition(
                new CameraPosition(
                    new Position(e.Position.Latitude, e.Position.Longitude), 
                    17d, // zoom
                    45d, // bearing(rotation)
                    60d // tilt
                )));
        }

        public ObservableCollection<Pin> Pins { set; get; } = new ObservableCollection<Pin>();
        public MoveCameraRequest MoveCameraRequest { get; } = new MoveCameraRequest();


    }
}