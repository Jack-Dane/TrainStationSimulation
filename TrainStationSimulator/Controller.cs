using System;
using System.Collections.Generic;
using System.Linq;
using TrainStationSimulator.Models;
using TrainStationSimulator.DAL;

namespace TrainStationSimulator
{
    public class Controller
    {
        public Controller() { }

        public void Start()
        {
            using var db = new TrainStationContext();

            Route firstRoute = db.Routes.Where(route => route.RouteId == 1).First();
            RouteStation currentRouteStation = firstRoute.RouteStations.OrderBy(routeStation => routeStation.Sequence).First();

            // simulate going through the route
            int count = 0;
            while (count < 10)
            {
                RouteStation nextRouteStation = currentRouteStation.NextRouteStation;
                Console.WriteLine(nextRouteStation.RouteStationId);

                currentRouteStation = nextRouteStation;
                count++;
            }

            PrintAllData();
            Console.ReadKey();
        }

        public void PrintAllData()
        {
            using var db = new TrainStationContext();

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
        }
    }
}
