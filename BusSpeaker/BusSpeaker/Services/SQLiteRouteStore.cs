using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using SQLite;
using Xamarin.Forms;

namespace BusSpeaker.Services
{
    public class SQLiteRouteStore : IRouteStore
    {
        static object locker = new object();
        readonly SQLiteAsyncConnection database;

        public SQLiteRouteStore()
        {   // "/data/user/0/com.companyname.BusSpeaker/files/.local/share/BusSpeaker.db3"
            // "/data/user/0/com.companyname.BusSpeaker/files/BusSpeaker.db3"
            var dbPath = DependencyService.Get<ISQLite>().GetDatabasePath("BusSpeaker.db3");
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Models.Point>().Wait();
           // database.CreateTableAsync<Rout>().Wait();
        }

        public async Task<Rout> GetItemAsync(string id)
        {
            return null; // await database.Table<Rout>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public  Task<IEnumerable<Rout>> GetItemsAsync(bool forceRefresh = false)
        {
            //var p =  database.Table<Models.Point>();

            Models.Point ppp = new Models.Point
            {
                Name = "Point C",
                Sound = "",
                IsVisited = false,
                Latitude = 0.0,
                Longitude = 0.0
            };

           
            database.InsertAsync(ppp);
            

            var p2 = database.Table<Models.Point>();
            var p3 = p2.ToListAsync().Result;

            return null;// await database.Table<Rout>().ToListAsync();
        }
    }
}
