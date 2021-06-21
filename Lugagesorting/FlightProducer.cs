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
                if (Monitor.TryEnter(Manager.flightPlans))
                {

                    while (Manager.flightPlans[9] != null)
                    {
                        Monitor.Wait(Manager.flightPlans);
                    }

                    for (int i = 0; i < Manager.flightPlans.Length; i++)
                    {
                        int destination = random.Next(0, 3);
                        string destinationNumber = ((Destination)destination).ToString().ToUpper();
                        string planeNumber = destinationNumber[0].ToString() + destinationNumber[1].ToString() + (random.Next(0, 300)).ToString();

                        int gateNumber = random.Next(0, Manager.gates.Length);

                        if (Monitor.TryEnter(Manager.gates[gateNumber]))
                        {
                            if (Manager.gates[gateNumber].FlightPlan == null)
                            {
                                Manager.gates[gateNumber].FlightPlan = new FlightPlan(planeNumber, gateNumber, (Destination)destination, DateTime.Now.AddSeconds(random.Next(0, 60)));
                                Manager.flightPlans[i] = Manager.gates[gateNumber].FlightPlan;
                                Console.WriteLine($"Flight {Manager.gates[gateNumber].FlightPlan.PlaneNumber} is going to gate {gateNumber}, and is departing at {Manager.gates[gateNumber].FlightPlan.DepartureTime} to {Manager.gates[gateNumber].FlightPlan.destinations}");
                            }
                        }
                    }

                    Monitor.PulseAll(Manager.flightPlans);
                    Monitor.Exit(Manager.flightPlans);
                }
            }
        }
    }
}
