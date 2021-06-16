using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class LugageProducer
    {
        Random random = new Random();
        static Lugage[] queueLugages = new Lugage[100];

        //static Lugage[] queueLugages = new Lugage[500];
        public void GenerateLugage()
        {
            for (int i = 0; i < queueLugages.Length; i++)
            {
                string lugageNumber = FlightProducer.flightPlans[random.Next(0, 50)].PlaneNumber + random.Next(0, 50);

                Lugage lugage = new Lugage(lugageNumber, random.Next(0, 40), FlightProducer.flightPlans[random.Next(0, 50)].PlaneNumber);
                queueLugages[i] = lugage;
                Console.WriteLine($"Luggage {queueLugages[i].LugageNumber} is going on flight {queueLugages[i].FlightNumber} and is owned by passenger {queueLugages[i].PassengerNumber}");
            }
            Console.WriteLine();
        }

    }
}
