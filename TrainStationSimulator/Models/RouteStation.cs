using System;
using System.Collections.Generic;
using System.Text;

namespace TrainStationSimulator.Models
{
    public class RouteStation
    {
        public int RouteStationId { get; set; }

        public virtual RouteStation NextRouteStation { get; set; }
        public int NextRouteStationId { get; set; }

        public virtual Station CurrentStation { get; set; }
        public int CurrentStationId { get; set; }

        public virtual Route Route { get; set; }
        public int RouteId { get; set; }

        public DateTime ArrivalDateTime { get; set; }
        public int Sequence { get; set; }
    }
}
