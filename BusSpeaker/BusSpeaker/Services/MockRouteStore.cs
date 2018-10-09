using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;

namespace BusSpeaker.Services
{
    public class MockRouteStore : IRouteStore
    {
        List<Rout> items;

        public MockRouteStore()
        {
            items = new List<Rout>();
            var mockItems = new List<Rout>
            {
                new Rout
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "88",
                    Description ="This is an item description.",
                    IsDirectDirection = true,
                    DirectDirectionPoints = new List<Point>
                    {
                        new Point
                        {
                            ID = 1,
                            Name = "Point B",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            ID = 2,
                            Name = "Point S",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            ID = 3,
                            Name = "Point D",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            ID = 4,
                            Name = "Point C",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        }
                    },
                    //ReverseDirectionPoints = new List<Point>
                    //{
                    //    new Point
                    //    {
                    //        Id = Guid.NewGuid().ToString(),
                    //        Name = "Point C",
                    //        IsVisited = false,
                    //        Latitude = 0.0,
                    //        Longitude = 0.0
                    //    },
                    //    new Point
                    //    {
                    //        Id = Guid.NewGuid().ToString(),
                    //        Name = "Point D",
                    //        IsVisited = false,
                    //        Latitude = 0.0,
                    //        Longitude = 0.0
                    //    },
                    //    new Point
                    //    {
                    //        Id = Guid.NewGuid().ToString(),
                    //        Name = "Point S",
                    //        IsVisited = false,
                    //        Latitude = 0.0,
                    //        Longitude = 0.0
                    //    },
                    //    new Point
                    //    {
                    //        Id = Guid.NewGuid().ToString(),
                    //        Name = "Point B",
                    //        IsVisited = false,
                    //        Latitude = 0.0,
                    //        Longitude = 0.0
                    //    },
                    //},

                },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<Rout> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Rout>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}