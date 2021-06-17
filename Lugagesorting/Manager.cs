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
        LugageProducer lugageProducer = new LugageProducer();
        FlightProducer flightProducer = new FlightProducer();

        public static FlightPlan[] flightPlans = new FlightPlan[5];
        public static Lugage[] queueLugages = new Lugage[100];

        static Lugage[] counterBuffer = new Lugage[100];
        static Lugage[] gateBuffer = new Lugage[15];

        Gate gate = new Gate();
        Counter counter = new Counter();
        FlightPlan flightPlan = new FlightPlan();

        public void SimulationStart()
        {
            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            while (Thread.CurrentThread.IsAlive)
            {
                // ------DATA CREATERS------ //
                //CreateLuage
                Thread lugageCreaterThread = new Thread(flightProducer.GenerateFlights);
                lugageCreaterThread.Start();

                //CreatePlanes
                Thread planeCreaterThread = new Thread(lugageProducer.GenerateLugage);
                planeCreaterThread.Start();

                // ------DATA OPEN / CLOSE------ //

                ////OpenCounter
                //Thread counterCreaterThread = new Thread();
                //counterCreaterThread.Start();

                ////Opengate
                //Thread gateCreaterThread = new Thread();
                //gateCreaterThread.Start();

                ////RunSorter
                //Thread sorterThread = new Thread();
                //sorterThread.Start();
            }
        }
    }
}



