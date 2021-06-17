using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class LugageProducer
    {
        Random random = new Random();

        //static Lugage[] queueLugages = new Lugage[500];
        public void GenerateLugage()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (Monitor.TryEnter(Manager.queueLugages))
                {
                    while (Manager.queueLugages[4] != null || Manager.flightPlans[4] == null)
                    {
                        Monitor.Wait(Manager.queueLugages);
                    }

                    for (int i = 0; i < Manager.queueLugages.Length; i++)
                    {
                        string lugageNumber = Manager.flightPlans[random.Next(0, 4)].PlaneNumber + random.Next(0, 4);

                        Lugage lugage = new Lugage(lugageNumber, random.Next(0, 40), Manager.flightPlans[random.Next(0, 4)].PlaneNumber);
                        Manager.queueLugages[i] = lugage;
                        Console.WriteLine($"Luggage {Manager.queueLugages[i].LugageNumber} is going on flight {Manager.queueLugages[i].FlightNumber} and is owned by passenger {Manager.queueLugages[i].PassengerNumber}");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    Monitor.Exit(Manager.queueLugages);
                }
            }
        }
    }
}
