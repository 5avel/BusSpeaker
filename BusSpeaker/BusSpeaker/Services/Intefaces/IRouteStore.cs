using BusSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusSpeaker.Services.Intefaces
{
    public interface IRouteStore
    {
        Task<Rout> GetItemAsync(string id);
        Task<IEnumerable<Rout>> GetItemsAsync(bool forceRefresh = false);
    }
}
