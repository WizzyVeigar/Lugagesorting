using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter : IOpenClose
    {
        Random random = new Random();
        private int _counterNumber;
        private bool _isOpen = false;
        public Lugage[] _counterLugageQueue = new Lugage[15];
        private int _arrayIndex = 0;
        private Thread _t;

        public int CounterNumber
        {
            get { return _counterNumber; }
            set { _counterNumber = value; }
        }

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
            while (Thread.CurrentThread.IsAlive)
            {
                //While the counter is open, do the following
                while (IsOpen)
                {
                    //Try and enter a thread using the lugage que as a lock
                    if (Monitor.TryEnter(CounterLugageQueue))
                    {
                        //If the counter is open
                        if (IsOpen)
                        {
                            //And the lugageu queue is empty
                            while (AmountInCounterArray() == 0)
                            {
                                //tell the thread to wait for 2 seconds.
                                Console.WriteLine($"Counter {CounterNumber} is waiting for luggage");
                                Monitor.Wait(CounterLugageQueue, 2000);
                            }
                        }
                        //Start checking in lugage.
                        CheckLugageIn();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lugage"></param>
        /// <returns></returns>
        public bool AddToCheckinCounterQueue(Lugage lugage)
        {
            for (int i = 0; i < CounterLugageQueue.Length; i++)
            {
                if (CounterLugageQueue[i] == null)
                {
                    CounterLugageQueue[i] = lugage;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Lugage RetrieveFromCounterQueue()
        {
            for (int i = 0; i < CounterLugageQueue.Length; i++)
            {
                if (CounterLugageQueue[i] != null)
                {
                    Lugage d = CounterLugageQueue[i];
                    CounterLugageQueue[i] = null;
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int AmountInCounterArray()
        {
            int AmountInArray = 0;
            for (int i = 0; i < CounterLugageQueue.Length; i++)
            {
                if (CounterLugageQueue[i] != null)
                {
                    AmountInArray += 1;
                }
            }
            return AmountInArray;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckLugageIn()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (Monitor.TryEnter(CounterLugageQueue))
                {
                    if (AmountInCounterArray() == 0)
                    {
                        Console.WriteLine($"Counter {CounterNumber} queue is empty");
                        Thread.Sleep(2000);
                    }

                    for (int i = 0; i < Manager.sorterConveyorbelt.Length; i++)
                    {
                        if (Manager.sorterConveyorbelt[i] == null)
                        {
                            Lugage tempLugage = RetrieveFromCounterQueue();
                            if (tempLugage != null)
                            {
                                DateTime currentTime = DateTime.Now;
                                tempLugage.TimeStampCheckin = currentTime;
                                Manager.sorterConveyorbelt[i] = tempLugage;
                                Console.WriteLine($"{tempLugage.LugageNumber} has now been added to spot {i} on the conveyorbelt, with timestamp {tempLugage.TimeStampCheckin}");
                                Thread.Sleep(random.Next(0, 5000));
                            }
                        }
                    }
                    Monitor.PulseAll(CounterLugageQueue);
                    Monitor.Exit(CounterLugageQueue);
                }
            }
        }
    }
}
