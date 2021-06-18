using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    /// <summary>
    /// Manages all the classes used in the projekt
    /// </summary>
    class Manager
    {
        public static Gate[] gates = new Gate[5];
        public static Counter[] counters = new Counter[10];

        LugageProducer lugageProducer = new LugageProducer();
        FlightProducer flightProducer = new FlightProducer();

        public static FlightPlan[] flightPlans = new FlightPlan[10];
        public static Lugage[] queueLugages = new Lugage[100];

        static Lugage[] counterBuffer = new Lugage[100];

        public void SimulationStart()
        {
            for (int i = 0; i < gates.Length; i++)
            {
                gates[i] = new Gate(i);
                Console.WriteLine($"Gate: {gates[i].GateNumber} has been created");
            }

            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = new Counter(i);
                Console.WriteLine($"Counter: {counters[i].CounterNumber} has been created");
            }

            // ------DATA CREATERS------ //
            //CreateLuage
            Thread lugageCreaterThread = new Thread(lugageProducer.GenerateLugage);
            lugageCreaterThread.Start();

            //CreatePlanes
            Thread planeCreaterThread = new Thread(flightProducer.GenerateFlights);
            planeCreaterThread.Start();

            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            while (Thread.CurrentThread.IsAlive)
            {
                // ------DATA OPEN / CLOSE------ //

                //OpenCounter

                //Opengate

                //RunSorter
            }
        }
    }
}



