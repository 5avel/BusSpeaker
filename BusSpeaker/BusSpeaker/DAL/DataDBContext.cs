using BusSpeaker.Models;
using BusSpeaker.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusSpeaker.DAL
{
    public class DataDBContext : DbContext
    {
        private readonly string dbName = "BusSpeaker.db3";
     
        private string _databasePath;

        public DataDBContext()
        {
            _databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(dbName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rout>().HasData(
                new Rout { Id = 1, Name = "B2C", Description = "Test and smocking rout))" },
                new Rout { Id = 2, Name = "88", Description = "Rout Dnipro 88" }
                );

            modelBuilder.Entity<StopPoint>().HasData(
                 new StopPoint { Id = 1, RoutId = 1, IsDirectDirection = true, Number = 1, Name = "Point B", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 2, RoutId = 1, IsDirectDirection = true, Number = 2, Name = "Point S", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 3, RoutId = 1, IsDirectDirection = true, Number = 3, Name = "Point D", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 4, RoutId = 1, IsDirectDirection = true, Number = 4, Name = "Point C", Sound = "", Latitude = 0.0, Longitude = 0.0 },

                 new StopPoint { Id = 5, RoutId = 1, IsDirectDirection = false, Number = 1, Name = "Point C", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 6, RoutId = 1, IsDirectDirection = false, Number = 2, Name = "Point D", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 7, RoutId = 1, IsDirectDirection = false, Number = 3, Name = "Point S", Sound = "", Latitude = 0.0, Longitude = 0.0 },
                 new StopPoint { Id = 8, RoutId = 1, IsDirectDirection = false, Number = 4, Name = "Point B", Sound = "", Latitude = 0.0, Longitude = 0.0 }
                );
        }




        public DbSet<Rout> Routs { get; set; }
        public DbSet<StopPoint> StopPoints { get; set; }
    }
}
