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
        }

        public void generateCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                Counter counter = new Counter(i + 1, false);
                counters[i] = counter;
                Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet og er lukket: {counters[i].CounterOpen}");
            }
            Console.WriteLine();
        }

        public void OpenCounter()
        {
            if (Thread.CurrentThread.IsAlive)
            {
                //Console.WriteLine("Skranke " + CounterNumber + " er nu åben");
            }
        }
    }
}
