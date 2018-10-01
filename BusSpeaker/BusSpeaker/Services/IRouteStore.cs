using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusSpeaker.Services
{
    public interface IRouteStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
