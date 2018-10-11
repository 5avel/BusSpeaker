using BusSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusSpeaker.Services.Intefaces
{
    public interface IStopPointsService
    {
        ObservableCollection<StopPoint> StopPoints { get; set; }

        void ChengeDirection(bool isDirectDirection);
    }
}
