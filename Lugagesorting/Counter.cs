using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter
    {
        private int _counterNumber;
        private bool _counterOpen;

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

        public Counter()
        {

        }

        public Counter(int counterNumber)
        {

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
