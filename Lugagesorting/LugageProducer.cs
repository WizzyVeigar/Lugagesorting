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
                Monitor.TryEnter(Manager.queueLugages);

                while (Manager.queueLugages[50] != null || Manager.flightPlans[50] == null)
                {
                    Monitor.Wait(Manager.queueLugages);
                }

                for (int i = 0; i < Manager.queueLugages.Length; i++)
                {
                    string lugageNumber = Manager.flightPlans[random.Next(0, 50)].PlaneNumber + random.Next(0, 50);

                    Lugage lugage = new Lugage(lugageNumber, random.Next(0, 40), Manager.flightPlans[random.Next(0, 50)].PlaneNumber);
                    Manager.queueLugages[i] = lugage;
                    Console.WriteLine($"Luggage {Manager.queueLugages[i].LugageNumber} is going on flight {Manager.queueLugages[i].FlightNumber} and is owned by passenger {Manager.queueLugages[i].PassengerNumber}");
                }
                Console.WriteLine();

                Monitor.Exit(Manager.queueLugages);
            }
        }
    }
}
