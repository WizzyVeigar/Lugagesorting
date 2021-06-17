using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter: IOpenClose
    {
        private int _counterNumber;
        private bool _isOpen = false;
        private Lugage[] _counterLugageQueue = new Lugage[15];
        private Thread _t;

        public int CounterNumber
        {
            get { return _counterNumber; }
            set { _counterNumber = value; }
        }

        private bool _counterOpen;

        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; }
        }
        public Lugage[] CounterLugageQueue
        {
            get { return _counterLugageQueue; }
            set { _counterLugageQueue = value; }
        }

        public Thread T
        {
            get { return _t; }
            set { _t = value; }
        }

        public Counter(int counterNumber)
        {
            CounterNumber = counterNumber;
            T = new Thread(Worker);
            T.Start();
        }

        public void Worker()
        {
            while (true)
            {

            }
        }
        //public void generateCounters()
        //{
        //    for (int i = 0; i < counters.Length; i++)
        //    {
        //        Counter counter = new Counter(i + 1, false);
        //        counters[i] = counter;
        //        Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet");
        //    }
        //    Console.WriteLine();
        //}
        //public void CheckLugageQueue()
        //{
        //    if (Monitor.TryEnter(counters))
        //    {
        //        if (Manager.queueLugages[0] != null)
        //        {
        //            OpenCounter();
        //        }
        //    }
        //}

        //public void OpenCounter()
        //{
        //    if (Thread.CurrentThread.IsAlive)
        //    {
        //        Open = true;
        //        Console.WriteLine($"Counter: {CounterNumber} is now open");
        //    }
        //}

        //public void CheckLugageIn()
        //{
        //    if (Thread.CurrentThread.IsAlive)
        //    {
        //        //if gate is closed
        //        if (true)
        //        {
        //            //Don't allow checkin
        //        }
        //        //if gate isn't closed
        //        else
        //        {
        //            //Take lugage from que, add to counterBuffer (Big conveyorbelt)
        //        }
        //    }
        //}
    }
}
