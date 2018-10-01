using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Linq;

using BusSpeaker.Models;
using BusSpeaker.Views;
using Point = BusSpeaker.Models.Point;

namespace BusSpeaker.ViewModels
{
    public class RouteViewModel : BaseViewModel
    {
        public ObservableCollection<Point> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RouteViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Point>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Point>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Point;
            //    Items.Add(newItem);
            //    //await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var routs = await DataStore.GetItemsAsync(true);
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
                IsBusy = false;
            }
        }
    }
}