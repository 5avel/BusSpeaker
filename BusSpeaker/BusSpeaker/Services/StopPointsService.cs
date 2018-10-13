using BusSpeaker.DAL.Intefaces;
using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BusSpeaker.Services
{
    public class StopPointsService : IStopPointsService
    {
        private IRoutRepository _repository;
        private IGeolocatorService _geolocator;
        private ISettingsRepository _settings;

        private Rout currentRout;
        private bool currentDirection;

        public ObservableCollection<StopPoint> StopPoints { get; set; }

        public StopPointsService(IRoutRepository repository, IGeolocatorService geolocator, ISettingsRepository settings)
        {
            _repository = repository;
            _geolocator = geolocator;
            _settings = settings;
            StopPoints = new ObservableCollection<StopPoint>();
            _geolocator.BusPositionChanged += _geolocator_BusPositionChanged;
            LoadRout();
            ChengeDirection(true);
        }

        private void LoadRout()
        {
            currentRout = _repository.GetRoutById(_settings.GetSettings().CurrentRoutId);
        }

        public void ChengeDirection(bool isDirectDirection)
        {
            currentDirection = isDirectDirection;
            StopPoints.Clear();
            foreach (var item in currentRout.StopPoints.Where(x => x.IsDirectDirection == currentDirection))
            {
                StopPoints.Add(item);
            }
        }

        private void _geolocator_BusPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (StopPoints == null) return; // не задано направление

            for (int i = 0; i < StopPoints.Count; i++)
            {
                StopPoints[i].Distance = GeolocatorUtils.CalculateDistance(StopPoints[i].Latitude, StopPoints[i].Longitude, 
                                                                e.Position.Latitude, e.Position.Longitude, 
                                                                GeolocatorUtils.DistanceUnits.Kilometers);

                if (StopPoints[i].Distance < _settings.GetSettings().DinstanceToStopPoint)
                {
                    StopPoints[i].IsVisited = true;
                    StopPoints[i].IsCurrentStopPoint = true;
                    // TODO: Play StopsSound
                    if (StopPoints[i].IsLastStopPoint)
                    {
                        ChengeDirection(!StopPoints[i].IsDirectDirection); // Reload direction
                    }
                }
                else
                {
                    StopPoints[i].IsCurrentStopPoint = false;
                }
            }

        }
    }
}
