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
            Controller controller = new Controller();
            controller.Start();
        }
    }
}
