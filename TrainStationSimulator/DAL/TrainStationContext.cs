using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainStationSimulator.Models;

namespace TrainStationSimulator.DAL
{
    class TrainStationContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
            .UseLazyLoadingProxies()
            .UseSqlite(@"Data Source=C:\Users\44785\source\repos\TrainStationSimulator\TrainStationSimulator\trainstations.db");
    }
}
