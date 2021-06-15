using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    /// <summary>
    /// Manages all the classes used in the projekt
    /// </summary>
    class Manager
    {
        //Setup all conveyor belts (CounterConveyorbelt, GateConveyorbelt, gates, and counters
        static Lugage[] counterBuffer = new Lugage[100];
        static Lugage[] gateBuffer = new Lugage[15];
        static Gate[] gates = new Gate[5];
        static Counter[] counters = new Counter[10];

        public void SimulationStart()
        {
            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            while (Thread.CurrentThread.IsAlive)
            {
                //If theres a long que (longer than x) open a new thread

                //Every gate is a thread, every counter is a thread.
            }
        }
    }
}



