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
    public class MapPageModel : FreshBasePageModel
    {
        private IStopPointsService _stopPointsService;

        public MapPageModel(IStopPointsService stopPointsService)
        {
            _stopPointsService = stopPointsService;
        }
        public ObservableCollection<StopPoint> StopPoints
        {
            get
            {
                return _stopPointsService.StopPoints;
            }
        }
    }
}