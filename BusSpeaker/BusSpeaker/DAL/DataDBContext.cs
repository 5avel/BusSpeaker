using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusSpeaker.DAL
{
    public class DBContext : DbContext
    {
        private readonly string dbName = "BusSpeakerDB.db3";
     
        private readonly string _databasePath;

        public DBContext()
        {
            _databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(dbName);
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rout>().HasData(
                new Rout { Id = 1, Name = "BtoC", Description = "Test and smocking rout))" },
                new Rout { Id = 2, Name = "88", Description = "Rout Dnipro 88" }
                );

            modelBuilder.Entity<StopPoint>().HasData(
                 new StopPoint { Id = 1, RoutId = 1, IsDirectDirection = true, IsLastStopPoint = false, Number = 1, Name = "Point D", Sound = "", Latitude = 48.4604083333333, Longitude = 35.0405266666667 },
                 new StopPoint { Id = 2, RoutId = 1, IsDirectDirection = true, IsLastStopPoint = false, Number = 2, Name = "Point P", Sound = "", Latitude = 48.4601783333333, Longitude = 35.040885 },
                 new StopPoint { Id = 3, RoutId = 1, IsDirectDirection = true, IsLastStopPoint = false, Number = 3, Name = "Point S", Sound = "", Latitude = 48.4599933333333, Longitude = 35.041395 },
                 new StopPoint { Id = 4, RoutId = 1, IsDirectDirection = true, IsLastStopPoint = true, Number = 4, Name = "Point M", Sound = "", Latitude = 48.46007, Longitude = 35.0416216666667 },

                 new StopPoint { Id = 5, RoutId = 1, IsDirectDirection = false, IsLastStopPoint = false, Number = 1, Name = "Point M", Sound = "", Latitude = 48.46007, Longitude = 35.0416216666667 },
                 new StopPoint { Id = 6, RoutId = 1, IsDirectDirection = false, IsLastStopPoint = false, Number = 2, Name = "Point S", Sound = "", Latitude = 48.4599933333333, Longitude = 35.041395 },
                 new StopPoint { Id = 7, RoutId = 1, IsDirectDirection = false, IsLastStopPoint = false, Number = 3, Name = "Point P", Sound = "", Latitude = 48.4601783333333, Longitude = 35.040885 },
                 new StopPoint { Id = 8, RoutId = 1, IsDirectDirection = false, IsLastStopPoint = true, Number = 4, Name = "Point D", Sound = "", Latitude = 48.4604083333333, Longitude = 35.0405266666667 }
                );
        }


        public DbSet<Rout> Routs { get; set; }
        public DbSet<StopPoint> StopPoints { get; set; }
    }
}
