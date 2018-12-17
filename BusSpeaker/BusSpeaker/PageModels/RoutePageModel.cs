using System.Collections.ObjectModel;
using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using FreshMvvm;

namespace BusSpeaker.PageModels
{
    public class RoutePageModel : FreshBasePageModel
    {
        private IStopPointsService _stopPointsService;

        public RoutePageModel(IStopPointsService stopPointsService)
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