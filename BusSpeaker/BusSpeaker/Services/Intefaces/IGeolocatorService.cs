using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;

namespace BusSpeaker.Services.Intefaces
{
    public interface IGeolocatorService
    {
        event EventHandler<PositionEventArgs> MyPositionChanged;
        Task StartListening();
        Task StopListening();
    }
}
