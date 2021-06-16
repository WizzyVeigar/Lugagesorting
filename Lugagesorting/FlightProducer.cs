using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class FlightProducer
    {
        Random random = new Random();

        public void GenerateFlights()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Monitor.TryEnter(Manager.flightPlans)

            while (Manager.flightPlans[50] != null)
                {
                    Monitor.Wait(Manager.flightPlans);
                }
                for (int i = 0; i < Manager.flightPlans.Length; i++)
                {
                    int destination = random.Next(0, 3);
                    string destinationNumber = ((Destination)destination).ToString().ToUpper();
                    string planeNumber = destinationNumber[0].ToString() + destinationNumber[1].ToString() + (random.Next(0, 300)).ToString();
                    int gateNumber = random.Next(0, 5);

                    FlightPlan flightPlan = new FlightPlan(planeNumber, gateNumber, (Destination)destination, DateTime.Now, DateTime.Now);
                    Manager.flightPlans[i] = flightPlan;
                    Console.WriteLine($"Plane {Manager.flightPlans[i].PlaneNumber} skal til gate {Manager.flightPlans[i].GateNumber}. Flyet går til {Manager.flightPlans[i].destinations}. Gaten er åben fra {Manager.flightPlans[i].GateOpen} til {Manager.flightPlans[i].GateClose}");
                }
                Console.WriteLine();

                Monitor.Exit(Manager.flightPlans);
            }
        }
    }
}
