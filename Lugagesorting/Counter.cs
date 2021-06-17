using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter
    {
        static Counter[] counters = new Counter[10];

        private int _counterNumber;
        private bool _counterOpen;
        private string _counterGateConnection;

        public int CounterNumber
        {
            get { return _counterNumber; }
            set { _counterNumber = value; }
        }

        public bool CounterOpen
        {
            get { return _counterOpen; }
            set { _counterOpen = value; }
        }

        public string CounterGateConnection
        {
            get { return _counterGateConnection; }
            set { _counterGateConnection = value; }
        }

        public Counter()
        {

        }

        public Counter(int counterNumber, bool counterOpen)
        {
            CounterNumber = counterNumber;
            CounterOpen = counterOpen;
        }

        public void generateCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                Counter counter = new Counter(i + 1, false);
                counters[i] = counter;
                Thread t = new Thread(CheckLugageQueue);
                int counterThreadNumber = i + 1;
                t.Name = "Counter" + counterThreadNumber + "Thread";
                t.Start();
                Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet, og er (open)?: {counters[i].CounterOpen}. Counteren har thread: {t.Name}");

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
                CounterOpen = true;
                Console.WriteLine($"Counter: {CounterNumber} is now open");
            }
        }

        public void CheckLugageIn()
        {

        }
    }
}
