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
        Counter counter = new Counter();
        LugageProducer lugageProducer = new LugageProducer();

        //Setup all conveyor belts (CounterConveyorbelt, GateConveyorbelt, gates, and counters
        static FlightPlan[] flightPlans = new FlightPlan[50];
        static Lugage[] counterBuffer = new Lugage[100];
        static Lugage[] gateBuffer = new Lugage[15];
        static Lugage[] queueLugages = new Lugage[50];
        static Gate[] gates = new Gate[5];
        static Counter[] counters = new Counter[10];

        public void GenerateFlights()
        {
            Random random = new Random();

            for (int i = 0; i < flightPlans.Length; i++)
            {
                int planeNumber = random.Next(0, 100);
                int gateNumber = random.Next(0, 5);

                Console.WriteLine(planeNumber + " " + gateNumber);

                FlightPlan flightPlan = new FlightPlan(planeNumber, gateNumber, (Destination)random.Next(0, 2), DateTime.Now, DateTime.Now);
                flightPlans[i] = flightPlan;
            }

            for (int i = 0; i < flightPlans.Length; i++)
            {
                Console.WriteLine($"Fly {flightPlans[i].PlaneNumber} er nu i gate {flightPlans[i].GateNumber}. Gaten er åben fra {flightPlans[i].GateOpen} til {flightPlans[i].GateClose}");

            }
        }

        public void SimulationStart()
        {
            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            //while (Thread.CurrentThread.IsAlive)
            //{
            GenerateFlights();
            //Create queue
            Thread queueLugagesThread = new Thread(lugageProducer.CreateLugage);
            queueLugagesThread.Start();

            //Create Counter
            Thread counterThread = new Thread(counter.OpenCounter);
            counterThread.Start();

            //Create Sorter
            //Thread sorterThread = new Thread();
            //sorterThread.Start();

            //Create Gate

            //Thread thread = new Thread();
            //If theres a long que (longer than x) open a new thread

            //Every gate is a thread, every counter is a thread.
            //}
        }
    }
}



