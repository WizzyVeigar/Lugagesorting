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
        private bool _isOpen = true;
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
                            while (AmountInArray() == 0)
                            {
                                //tell the thread to wait for 2 seconds.
                                Console.WriteLine("Waiting for luggage");
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
        /// Adds lugages to our counter's lugage queue, if the counter is open.
        /// </summary>
        /// <param name="lugage">used to make an arrayindex into a piece of lugage</param>
        /// <returns>true or false wether theres room for lugage</returns>
        public bool AddToCheckinQueue(Lugage lugage)
        {
            for (int i = 0; i < CounterLugageQueue.Length; i++)
            {
                if (CounterLugageQueue[i] == null)
                {
                    CounterLugageQueue[i] = lugage; //We get our drink from our "Get Drink".

                    //Monitor.Pulse(drinks);
                    //Monitor.Exit(drinks); //If we dont have exit here, we wont be able to exit if it has an empty spot..
                    return true; //Returns true if we have added a drink (hence the bool)
                }
            }
            return false;
            //if (_arrayIndex >= CounterLugageQueue.Length)
            //{
            //    return false;
            //}

            //CounterLugageQueue[_arrayIndex] = lugage;
            //_arrayIndex++;
            //return true;
        }

        /// <summary>
        /// Retrieves the lugage from the queue so it can be chekced in.
        /// </summary>
        /// <returns>Either null or the temp lugage from array index 1, so that it consumes from the array as a queue.</returns>
        public Lugage RetrieveFromQueue()
        {
            for (int i = 0; i < CounterLugageQueue.Length; i++)
            {
                if (CounterLugageQueue[i] != null)
                {
                    Lugage d = CounterLugageQueue[i];
                    //if (delete == true) //Bool value set to true if we want to delete the item, and set to false if we want to check if there is an item in the array.
                    //{   //Since we are consuming the item se set it to true, so we set the i of drinks to null.
                    CounterLugageQueue[i] = null;
                    //}
                    return d; //Returns the drink we have "found" in our splitter array.
                }
            }
            return null; //Returns nothing since we have nothing in the array. Error message in splitter.

            //if (CounterLugageQueue[0] == null)
            //{
            //    return null;
            //}

            //Lugage tempLugage = CounterLugageQueue[0];

            //for (int i = 1; i < _arrayIndex; i++)
            //{
            //    CounterLugageQueue[i - 1] = CounterLugageQueue[i];
            //}

            //CounterLugageQueue[_arrayIndex - 1] = null;
            //_arrayIndex--;

            //return tempLugage;
        }

        public int AmountInArray()
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

        public void CheckLugageIn()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (Monitor.TryEnter(CounterLugageQueue))
                {
                    if (AmountInArray() == 0)
                    {
                        Console.WriteLine("Counter queue is empty");
                        Thread.Sleep(2000);
                    }

                    for (int i = 0; i < Manager.sorterConveyorbelt.Length; i++)
                    {
                        if (Manager.sorterConveyorbelt[i] == null)
                        {
                            Lugage tempLugage = RetrieveFromQueue();
                            if (tempLugage != null)
                            {
                                Manager.sorterConveyorbelt[i] = tempLugage;
                                Console.WriteLine($"{tempLugage.LugageNumber} has now been added to spot {i} on the conveyorbelt");
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
