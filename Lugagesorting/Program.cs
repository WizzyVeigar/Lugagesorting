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
            Gate gate = new Gate();
            Counter counter = new Counter();

            //Create our manager thread
            Thread managerThread = new Thread(manager.SimulationStart);
            managerThread.Start();

            counter.generateCounters();

            gate.GenerateGates();
            
            //manager.GenerateFlights();

            //manager.GenerateBagage();

            //manager.GenerateGate();

            //manager.generateCounter();
        }
    }
}
