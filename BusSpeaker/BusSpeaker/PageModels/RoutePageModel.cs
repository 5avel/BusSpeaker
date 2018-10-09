using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using BusSpeaker.Models;
using System.Linq;
using BusSpeaker.Services.Intefaces;

namespace BusSpeaker.PageModels
{
    public class RoutePageModel : FreshBasePageModel
    {
        public ObservableCollection<Point> Items { get; set; }

        private IRouteStore _routeStore;

        public RoutePageModel(IRouteStore routeStore)
        {
            _routeStore = routeStore;
            Items = new ObservableCollection<Point>();
        }

        public override void Init(object initData)
        {
            // TODO: Use settings to resolve current state
            var routes = _routeStore.GetItemsAsync(true).Result?.FirstOrDefault();
            if (routes != null && routes.DirectDirectionPoints != null)
            {
                Items = new ObservableCollection<Point>(routes.DirectDirectionPoints);
            }

            //Items = new ObservableCollection<Point>(_routeStore.GetItemsAsync(true).Result.First().DirectDirectionPoints);
        }

    }
}