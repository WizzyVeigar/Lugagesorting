using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Counter: IOpenClose
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
                            while (CounterLugageQueue[0] == null)
                            {
                                //tell the thread to wait for 2 seconds.
                                Monitor.Wait(CounterLugageQueue, 2000);
                            }
                        }

                        //Start checking in lugage.

                    }
                }
            }
        }
        /// <summary>
        /// Adds lugages to our counter's lugage queue, if the counter is open.
        /// </summary>
        /// <param name="lugage">used to make an arrayindex into a piece of lugage</param>
        /// <returns>true or false wether theres room for lugage</returns>
        public bool AddToCheckinQueue(Lugage lugage)
        {
            if (_arrayIndex >= CounterLugageQueue.Length)
            {
                return false;
            }

            CounterLugageQueue[_arrayIndex] = lugage;
            _arrayIndex++;
            return true;
        }

        /// <summary>
        /// Retrieves the lugage from the queue so it can be chekced in.
        /// </summary>
        /// <returns>Either null or the temp lugage from array index 1, so that it consumes from the array as a queue.</returns>
        public Lugage RetrieveFromQueue()
        {
            if (CounterLugageQueue[0] == null)
            {
                return null;
            }

            Lugage tempLugage = CounterLugageQueue[0];

            for (int i = 1; i < _arrayIndex; i++)
            {
                CounterLugageQueue[i - 1] = CounterLugageQueue[i];
            }

            CounterLugageQueue[_arrayIndex - 1] = null;
            _arrayIndex--;

            return tempLugage;
        }
    }
}
