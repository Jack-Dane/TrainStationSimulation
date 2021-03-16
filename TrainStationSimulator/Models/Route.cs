using System;
using System.Collections.Generic;
using System.Text;

namespace TrainStationSimulator.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public virtual List<RouteStation> RouteStations { get; set; } = new List<RouteStation>();
    }
}
