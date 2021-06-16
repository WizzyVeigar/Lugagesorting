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

        public Counter()
        {

        }

        public Counter(int counterNumber)
        {
            CounterNumber = counterNumber;
        }

        public void generateCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                Counter counter = new Counter(i + 1);
                counters[i] = counter;
                Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet");
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
