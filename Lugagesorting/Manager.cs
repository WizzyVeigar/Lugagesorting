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
        Random random = new Random();
        Counter counter = new Counter();
        LugageProducer lugageProducer = new LugageProducer();

        //Setup all conveyor belts (CounterConveyorbelt, GateConveyorbelt, gates, and counters
        static FlightPlan[] flightPlans = new FlightPlan[50];
        static Lugage[] counterBuffer = new Lugage[100];
        static Lugage[] gateBuffer = new Lugage[15];
        static Lugage[] queueLugages = new Lugage[500];
        static Gate[] gates = new Gate[5];
        static Counter[] counters = new Counter[10];

        public void GenerateFlights()
        {
            for (int i = 0; i < flightPlans.Length; i++)
            {
                FlightPlan flightPlan = new FlightPlan(random.Next(0, 300), random.Next(0, 5), (Destination)random.Next(0, 2), DateTime.Now, DateTime.Now);
                flightPlans[i] = flightPlan;
                Console.WriteLine($"Plane {flightPlans[i].PlaneNumber} skal til gate {flightPlans[i].GateNumber}. Flyet går til {flightPlans[i].destinations}. Gaten er åben fra {flightPlans[i].GateOpen} til {flightPlans[i].GateClose}");
            }
        }

        public void GenerateBagage()
        {
            for (int i = 0; i < queueLugages.Length; i++)
            {
                Lugage lugage = new Lugage(random.Next(0,20), random.Next(0,40), flightPlans[random.Next(0,50)].PlaneNumber);
                queueLugages[i] = lugage;
                Console.WriteLine($"Luggage {queueLugages[i].LugageNumber} is owned by passenger {queueLugages[i].PassengerNumber} and is going on flight {queueLugages[i].FlightNumber}");

                if (true)
                {

                }
            }
        }

        public void GenerateGate()
        {

        }

        public void SimulationStart()
        {
            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            //while (Thread.CurrentThread.IsAlive)
            //{
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
            //Thread gateThread = new Thread();
            //gateThread.Start();

            //Thread thread = new Thread();
            //If theres a long que (longer than x) open a new thread

            //Every gate is a thread, every counter is a thread.
            //}
        }
    }
}



