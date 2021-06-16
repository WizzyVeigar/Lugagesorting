using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    class FlightProducer
    {
        //static FlightPlan[] flightPlans = new FlightPlan[50];

        //public FlightPlan GenerateFlights()
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < flightPlans.Length; i++)
        //    {
        //        int planeNumber = random.Next(0, 300);
        //        int gateNumber = random.Next(0, 5);

        //        //if (flightPlans[i].PlaneNumber == planeNumber)
        //        //{
        //        //    planeNumber = random.Next(0, 300);
        //        //}

        //        FlightPlan flightPlan = new FlightPlan(planeNumber, gateNumber, (Destination)random.Next(0, 2), DateTime.Now, DateTime.Now);
        //        flightPlans[i] = flightPlan;
        //        Console.WriteLine($"Plane {flightPlans[i].PlaneNumber} skal til gate {flightPlans[i].GateNumber}. Flyet går til {flightPlans[i].destinations}. Gaten er åben fra {flightPlans[i].GateOpen} til {flightPlans[i].GateClose}");
        //        return flightPlan;
        //    }
        //}
    }
}
