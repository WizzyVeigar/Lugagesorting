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
                counters[i] = new Thread(CheckLugageQueue);
                counters[i].Name = "WhateverName" + i;
                Console.WriteLine($"Counter {counters[i].CounterNumber} er nu oprettet, og er (open)?: {counters[i].CounterOpen}");
            }
            Console.WriteLine();
        }
        public void CheckLugageQueue()
        {
            if (Manager.queueLugages[10] != null)
            {
                OpenCounter();
            }
        }

        public void OpenCounter()
        {
            if (Thread.CurrentThread.IsAlive)
            {
                CounterOpen = true;
            }
        }
    }
}
