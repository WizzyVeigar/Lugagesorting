using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class LugageProducer
    {
        Random random = new Random();

        public void GenerateLugage()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (Manager.flightPlans[9] != null)
                {
                    for (int i = 0; i < Manager.counters.Length; i++)
                    {
                        Counter counter = Manager.counters[random.Next(0, 9)];

                        for (int j = 0; j < Manager.counters[i].CounterLugageQueue.Length; j++)
                        {
                            if (Monitor.TryEnter(counter.CounterLugageQueue))
                            {
                                string lugageNumber = Manager.flightPlans[random.Next(0, 9)].PlaneNumber.ToString() + random.Next(0, 50).ToString();
                                Lugage lugage = new Lugage(lugageNumber, random.Next(1, 10000), Manager.flightPlans[random.Next(0, 9)].PlaneNumber);

                                Console.WriteLine($"Lugage {lugage.LugageNumber} has bene created in counter {counter.CounterNumber}");

                                while (!counter.AddToCheckinQueue(lugage))
                                {
                                    Monitor.Wait(counter.CounterLugageQueue, 2000);
                                }

                                Thread.Sleep(1000);

                                Monitor.PulseAll(counter.CounterLugageQueue);
                                Monitor.Exit(counter.CounterLugageQueue);
                            }
                        }
                    }
                }
            }
        }
    }
}
