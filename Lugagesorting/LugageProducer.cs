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
                for (int i = 0; i < Manager.counters.Length; i++)
                {
                    Counter counter = Manager.counters[i];

                    if (counter.IsOpen)
                    {
                        if (Monitor.TryEnter(counter.CounterLugageQueue))
                        {

                            string lugageNumber = Manager.flightPlans[random.Next(0, 9)].PlaneNumber + Manager.flightPlans[random.Next(0, 9)].destinations;
                            Lugage lugage = new Lugage(lugageNumber, random.Next(1, 40), Manager.flightPlans[random.Next(0, 9)].PlaneNumber);
                            while (!counter.AddToCheckinQueue(lugage))
                            {
                                Monitor.Wait(counter.CounterLugageQueue, 2000);
                            }

                            Monitor.PulseAll(counter.CounterLugageQueue);
                            Monitor.Exit(counter.CounterLugageQueue);
                        }
                    }
                }
            }
        }
    }
}
