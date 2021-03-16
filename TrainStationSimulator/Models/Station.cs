using System;
using System.Collections.Generic;
using System.Text;

namespace TrainStationSimulator.Models
{
    public class Station
    {
        public int StationId { get; set; }

        public string StationName { get; set; }

        public virtual List<RouteStation> RouteStations { get; } = new List<RouteStation>();
    }
}
