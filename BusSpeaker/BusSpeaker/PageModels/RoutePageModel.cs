using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Point = BusSpeaker.Models.Point;
using FreshMvvm;
using BusSpeaker.Services;
using BusSpeaker.Models;
using System.Linq;

namespace BusSpeaker.PageModels
{
    public class RoutePageModel : FreshBasePageModel
    {
        public ObservableCollection<Point> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private IRouteStore<Rout> _routeStore;

        public RoutePageModel(IRouteStore<Rout> routeStore)
        {
            _routeStore = routeStore;
            Items = new ObservableCollection<Point>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Point>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Point;
            //    Items.Add(newItem);
            //    //await DataStore.AddItemAsync(newItem);
            //});
        }

        public override void Init(object initData)
        {
            // TODO: Use settings to resolve current state
            Items = new ObservableCollection<Point>(_routeStore.GetItemsAsync(true).Result.First().DirectDirectionPoints);
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                var routs = await _routeStore.GetItemsAsync(true);
                var rout = routs.First();
                var items = rout.IsDirectDirection ? rout.DirectDirectionPoints : rout.ReverseDirectionPoints;
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
               
            }
        }
    }
}