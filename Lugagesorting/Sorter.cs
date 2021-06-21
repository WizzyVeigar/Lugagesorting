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
                if (Monitor.TryEnter(Manager.sorterConveyorbelt))
                {
                    while (Manager.sorterConveyorbelt[99] == null)
                    {
                        Monitor.Wait(Manager.sorterConveyorbelt, 2000);
                        Console.WriteLine("Sorter buffer is empty. (waiting for new lugage)");
                    }

                    if (true)
                    {

                    }
                    Monitor.Wait(Manager.sorterConveyorbelt, 2000);
                    Monitor.PulseAll(Manager.sorterConveyorbelt);
                }
            }
        }
    }
}
