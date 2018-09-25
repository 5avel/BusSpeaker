using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusSpeaker.Models;

namespace BusSpeaker.Services
{
    public class MockDataStore : IDataStore<Rout>
    {
        List<Rout> items;

        public MockDataStore()
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
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point B",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point S",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point D",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point C",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        }
                    },
                    ReverseDirectionPoints = new List<Point>
                    {
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point C",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point D",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point S",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                        new Point
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Point B",
                            IsVisited = false,
                            Latitude = 0.0,
                            Longitude = 0.0
                        },
                    },

                },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Rout item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Rout item)
        {
            var oldItem = items.Where((Rout arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Rout arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
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