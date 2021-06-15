using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter
    {
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

        public void OpenCounter()
        {
            if (Thread.CurrentThread.IsAlive)
            {
                //Console.WriteLine("Skranke " + CounterNumber + " er nu åben");
            }
        }
    }
}
