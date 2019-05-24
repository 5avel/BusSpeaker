using BusSpeaker.DAL.Intefaces;
using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusSpeaker.Services
{
    public class StopPointsService : IStopPointsService
    {
        private readonly IRoutRepository _repository;
        private readonly ISettingsRepository _settings;
        private readonly IStopsSoundService _soundService;

        private Rout _currentRout;
        private bool _currentDirection;

        public event EventHandler<EventArgs> DirectionChanged;
        public ObservableCollection<StopPoint> StopPoints { get; set; }

        public StopPointsService(IRoutRepository repository, IGeolocatorService geolocator, ISettingsRepository settings, IStopsSoundService soundService)
        {
            _repository = repository;
            _settings = settings;
            _soundService = soundService;
            StopPoints = new ObservableCollection<StopPoint>();
            geolocator.BusPositionChanged += _geolocator_BusPositionChanged;
            LoadRout();
            ChangeDirection(true);
        }

        private void LoadRout()
        {
            _currentRout = _repository.GetRoutById(_settings.GetSettings().CurrentRoutId);
        }

        public void ChangeDirection(bool isDirectDirection)
        {
            _currentDirection = isDirectDirection;
            StopPoints.Clear();
            foreach (var item in _currentRout.StopPoints.Where(x => x.IsDirectDirection == _currentDirection))
            {
                item.State = 0;
                StopPoints.Add(item);
            }
        }

        private void _geolocator_BusPositionChanged(object sender, PositionEventArgs e)
        {
            if (StopPoints == null) return; // не задано направление

            for (int i = 0; i < StopPoints.Count; i++)
            {
                StopPoints[i].Distance = GeolocatorUtils.CalculateDistance(StopPoints[i].Latitude, StopPoints[i].Longitude, 
                                                                e.Position.Latitude, e.Position.Longitude, 
                                                                GeolocatorUtils.DistanceUnits.Kilometers);

                if (StopPoints[i].Distance < _settings.GetSettings().DinstanceToStopPoint)
                {
                    if(StopPoints[i].State.HasFlag(StopPointState.Visited) == false)
                    {
                        _soundService.PlaySound($"{_currentRout.Name}.{StopPoints[i].Sound}");
                    }

                    StopPoints[i].State = StopPointState.Visited | StopPointState.Current;
                    
                    if (StopPoints[i].IsLastStopPoint)
                    {
                        ChangeDirection(!StopPoints[i].IsDirectDirection); // Reload direction
                        DirectionChanged?.Invoke(this, new EventArgs());
                    }
                }
                else
                {
                    if (StopPoints[i].State.HasFlag(StopPointState.Current))
                    {
                        StopPoints[i].State ^= StopPointState.Current;
                    }
                }
            }

        }
    }
}
