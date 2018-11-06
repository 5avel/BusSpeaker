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

        private MapPageModel()
        {

        }

        public MapPageModel(IStopPointsService stopPointsService)
        {
            _stopPointsService = stopPointsService;
            Pins = new ObservableCollection<Pin>();

            Pins.Add(
                new Pin
                {
                    Label = "Test Point",
                    Position = new Position(48.4604083333333, 35.0405266666667),
                }
            );

            Pins.Add(
               new Pin
               {
                   Label = "Test Point",
                   Position = new Position(35.0405266666667, 48.4604083333333)
               }
           );
        }

        public ObservableCollection<Pin> Pins { get; set; }

        public Command<MapClickedEventArgs> MapClickedCommand =>
           new Command<MapClickedEventArgs>(args =>
           {
               Pins.Add(new Pin
               {
                   Label = $"Pin{Pins.Count}",
                   Position = args.Point
               });

               Pins.Add(
              new Pin
              {
                  Label = "Test Point",
                  Position = new Position(48.4604083333333, 35.0405266666667)
              }
          );
           });
    }
}