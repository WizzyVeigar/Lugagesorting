using System;
using System.Threading;

namespace Lugagesorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of our manager
            Manager manager = new Manager();
            FlightProducer flightProducer = new FlightProducer();
            LugageProducer lugageProducer = new LugageProducer();

            //Create our manager thread
            Thread managerThread = new Thread(manager.SimulationStart);
            managerThread.Start();

            //manager.GenerateFlights();

            //manager.GenerateBagage();

            //manager.GenerateGate();

            //manager.generateCounter();
        }
    }
}
