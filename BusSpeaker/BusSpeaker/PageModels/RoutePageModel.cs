using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using BusSpeaker.Models;
using System.Linq;
using BusSpeaker.Services.Intefaces;
using BusSpeaker.DAL.Intefaces;
using Plugin.Geolocator.Abstractions;

namespace BusSpeaker.PageModels
{
    public class RoutePageModel : FreshBasePageModel
    {
        public ObservableCollection<StopPoint> StopPoints { get; set; }

        private IRoutRepository _repository;
        private IGeolocatorService _geolocator;

        public RoutePageModel(IRoutRepository repository, IGeolocatorService geolocator)
        {
            _repository = repository;
            _geolocator = geolocator;
            _geolocator.MyPositionChanged += _geolocator_MyPositionChanged;
            StopPoints = new ObservableCollection<StopPoint>();
        }

        private void _geolocator_MyPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            for (int i = 0; i < StopPoints.Count; i++)
            {
                StopPoints[i].Distance = GeolocatorUtils.CalculateDistance(StopPoints[i].Latitude, StopPoints[i].Longitude, e.Position.Latitude, e.Position.Longitude, GeolocatorUtils.DistanceUnits.Kilometers);
            }
        }

        public override void Init(object initData)
        {
            // TODO: Use settings to resolve current state
            var rout = _repository.GetRoutById(1);

            if (rout != null)
            {
                StopPoints = new ObservableCollection<StopPoint>(rout.StopPoints.Where(p => p.IsDirectDirection == true));
            }
        }

    }
}