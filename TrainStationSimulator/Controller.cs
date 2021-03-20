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
            PrintAllData();

            // get the current station and destination from the user
            Console.WriteLine("What station are you at? ");
            string currentStationInput = Console.ReadLine();
            Console.WriteLine("What station would you like to go to? ");
            string destinationStationInput = Console.ReadLine();

            // search for the stations
            Station currentStation = db.Stations.Where(station => station.StationName == currentStationInput).First();
            Station destinationStation = db.Stations.Where(station => station.StationName == destinationStationInput).First();

            // assuming there is only one route
            Route currentRoute = db.Routes.Where(route => route.RouteId == 1).First();
            List<RouteStation> stationsOnRoute = db.RouteStations.Where(routeStation => routeStation.Route == currentRoute).ToList();
            RouteStation currentRouteStation = stationsOnRoute.Where(routeStation => routeStation.CurrentStation == currentStation).First();

            // simulate going through a route from current to destination
            bool found = false;
            while (!found)
            {
                Console.WriteLine("Station: ");
                Console.WriteLine(currentRouteStation.CurrentStation.StationName);

                if (currentRouteStation.CurrentStation == destinationStation)
                {
                    found = true;
                }
                else
                {
                    currentRouteStation = currentRouteStation.NextRouteStation;
                }
            }

            Console.ReadKey();
        }

        private void PrintAllData()
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
