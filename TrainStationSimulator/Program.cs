using System;
using System.Collections.Generic;
using System.Linq;
using TrainStationSimulator.DAL;
using TrainStationSimulator.Models;

namespace TrainStationSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new TrainStationContext();

            /*
            List<RouteStation> routeStations = new List<RouteStation>()
            {
                new RouteStation()
                {
                    Route = db.Routes.Where(route => route.RouteId == 1).First(),
                    CurrentStation = db.Stations.Where(station => station.StationId == 1).First(),
                    ArrivalDateTime = new DateTime(2020, 10, 20),
                    Sequence = 0
                },
                new RouteStation()
                {
                    Route = db.Routes.Where(route => route.RouteId == 1).First(),
                    CurrentStation = db.Stations.Where(station => station.StationId == 2).First(),
                    ArrivalDateTime = new DateTime(2020, 11, 25),
                    Sequence = 1
                }, 
                new RouteStation()
                {
                    Route = db.Routes.Where(route => route.RouteId == 1).First(),
                    CurrentStation = db.Stations.Where(station => station.StationId == 3).First(),
                    ArrivalDateTime = new DateTime(2020, 4, 12),
                    Sequence = 2
                }
            };
            db.RouteStations.AddRange(routeStations);
            db.SaveChanges();
            
            RouteStation routeStation1 = db.RouteStations.Where(routeStation => routeStation.RouteStationId == 1).First();
            RouteStation routeStation2 = db.RouteStations.Where(routeStation => routeStation.RouteStationId == 2).First();
            RouteStation routeStation3 = db.RouteStations.Where(routeStation => routeStation.RouteStationId == 3).First();

            routeStation1.NextRouteStation = routeStation2;
            routeStation2.NextRouteStation = routeStation3;
            routeStation3.NextRouteStation = routeStation1;
            db.SaveChanges();
            */

            Route firstRoute = db.Routes.Where(route => route.RouteId == 1).First();
            List<RouteStation> routeStationsFromFirstRoute = firstRoute.RouteStations;

            foreach (RouteStation routeStationFromFirstRoute in routeStationsFromFirstRoute)
            {
                Console.WriteLine(routeStationFromFirstRoute.NextRouteStationId);
            }

            Console.WriteLine("Stations");
            List<Station> stations = db.Stations.ToList();
            foreach (Station station in stations)
            {
                Console.WriteLine(station.StationId);
                Console.WriteLine(station.StationName);
            }

            Console.WriteLine("Routes");
            List<Route> routes = db.Routes.ToList();
            foreach (Route route in routes)
            {
                Console.WriteLine(route.RouteId);
                Console.WriteLine(route.RouteName);
            }

            Console.WriteLine("RouteStations");
            List<RouteStation> routeStations = db.RouteStations.ToList();
            foreach (RouteStation routeStation in routeStations)
            {
                Console.WriteLine(routeStation.RouteStationId);
            }

            Console.ReadKey();
        }
    }
}
