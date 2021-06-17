using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter
    {
        private int _counterNumber;
        private bool _open;

        public int CounterNumber
        {
            get { return _counterNumber; }
            set { _counterNumber = value; }
        }

        private bool _counterOpen;

        public bool CounterOpen
        {
            get { return _counterOpen; }
            set { _counterOpen = value; }
        }


        public Counter()
        {

        }

        public Counter(int counterNumber, bool counterOpen)
        {
            CounterNumber = counterNumber;
            Open = counterOpen;
        }

        public void generateCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                Counter counter = new Counter(i + 1, false);
                counters[i] = counter;
                Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet");
            }
            Console.WriteLine();
        }
        public void CheckLugageQueue()
        {
            if (Monitor.TryEnter(counters))
            {
                if (Manager.queueLugages[0] != null)
                {
                    OpenCounter();
                }
            }
        }

        public void OpenCounter()
        {
            if (Thread.CurrentThread.IsAlive)
            {
                Open = true;
                Console.WriteLine($"Counter: {CounterNumber} is now open");
            }
        }

        public void CheckLugageIn()
        {
            if (Thread.CurrentThread.IsAlive)
            {
                //if gate is closed
                if (true)
                {
                    //Don't allow checkin
                }
                //if gate isn't closed
                else
                {
                    //Take lugage from que, add to counterBuffer (Big conveyorbelt)
                }
            }
        }
    }
}
