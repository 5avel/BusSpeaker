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

namespace BusSpeaker.PageModels
{
    public class MapPageModel : FreshBasePageModel
    {
        private readonly IStopPointsService _stopPointsService;
        private readonly IGeolocatorService _geolocator;

        // TODO Add directionChanged event and clean Pins collection

        public MapPageModel(IStopPointsService stopPointsService, IGeolocatorService geolocator)
        {
            _stopPointsService = stopPointsService;
            _geolocator = geolocator;
            _geolocator.BusPositionChanged += _geolocator_BusPositionChanged;
        }

        void _geolocator_BusPositionChanged(object sender, PositionEventArgs e)
        {
            if(Pins.Count == 0)
            {
                foreach(var point in _stopPointsService.StopPoints)
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
        }


        private ObservableCollection<Pin> _pins = new ObservableCollection<Pin>();

        public ObservableCollection<Pin> Pins { 
            set{
                _pins = value;
            }
            get
            {
           
                return _pins;
            }
        }

      
    }
}