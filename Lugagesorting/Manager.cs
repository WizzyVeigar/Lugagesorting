using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    /// <summary>
    /// Manages all the classes used in the projekt
    /// </summary>
    class Manager
    {

        //Everything needs to run in here while the thread is alive. (While the program runs, this needs to run)
        //       while (thread.isalive)
        //{

        static Lugage[] checkinBuffer = new Lugage[100];
        static Lugage[] gateBuffer = new Lugage[15];
        static Gate[] gates = new Gate[15];
        static Checkin[] checkins = new Checkin[30];

        //}

        //Create a method which creates a new thread for all our threads to run in (manager thread), so it dosn't interfere with the main thread.

        //If theres a long que (longer than x) open a new thread

        //Every gate is a thread, every counter is a thread.
    }
}
