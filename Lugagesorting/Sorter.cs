using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Sorter
    {
        public void SortBagage()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                if (Monitor.TryEnter(Manager.mainConveyorBelt))
                {
                    while (Manager.mainConveyorBelt[99] == null)
                    {
                        Monitor.Wait(Manager.mainConveyorBelt, 2000);
                        Console.WriteLine("Sorter buffer is empty. (waiting for new lugage)");
                    }

                    if (true)
                    {

                    }
                }
            }
        }
    }
}
