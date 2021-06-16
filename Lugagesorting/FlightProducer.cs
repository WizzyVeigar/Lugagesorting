using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    class FlightProducer
    {
        Random random = new Random();
        public static FlightPlan[] flightPlans = new FlightPlan[50];

        public void GenerateFlights()
        {
            for (int i = 0; i < flightPlans.Length; i++)
            {
                int destination = random.Next(0, 3);
                string destinationNumber = ((Destination)destination).ToString().ToUpper();
                string planeNumber = destinationNumber[0].ToString() + destinationNumber[1].ToString() + (random.Next(0, 300)).ToString();
                int gateNumber = random.Next(0, 5);

                FlightPlan flightPlan = new FlightPlan(planeNumber, gateNumber, (Destination)destination, DateTime.Now, DateTime.Now);
                flightPlans[i] = flightPlan;
                Console.WriteLine($"Plane {flightPlans[i].PlaneNumber} skal til gate {flightPlans[i].GateNumber}. Flyet går til {flightPlans[i].destinations}. Gaten er åben fra {flightPlans[i].GateOpen} til {flightPlans[i].GateClose}");
            }
            Console.WriteLine();
        }
    }
}
