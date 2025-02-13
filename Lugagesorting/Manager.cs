﻿using System;
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
        public static Gate[] gates = new Gate[3];
        public static Counter[] counters = new Counter[3];

        LugageProducer lugageProducer = new LugageProducer();
        FlightProducer flightProducer = new FlightProducer();

        public static FlightPlan[] flightPlans = new FlightPlan[3];
        public static Lugage[] sorterConveyorbelt = new Lugage[300];

        //Delegate is a way to send a class. We says that the print class needs a dataprinter, which we call printer. (It requires a string and the type of data it is. Either ManagerData or BagageData)
        public delegate void Print(DataPrinter printer);
        public static event Print PrintEvent;

        //static Lugage[] counterBuffer = new Lugage[100];

        public void SimulationStart()
        {
            for (int i = 0; i < gates.Length; i++)
            {
                gates[i] = new Gate(i);
                PrintEvent?.Invoke(new DataPrinter($"Gate: {gates[i].GateNumber} has been created", DataPrinter.DataTypePrint.ManagerData));
            }

            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = new Counter(i);
                PrintEvent?.Invoke(new DataPrinter($"Counter: {counters[i].CounterNumber} has been created", DataPrinter.DataTypePrint.ManagerData));
            }

            // ------DATA CREATERS------ //
            //CreatePlanes
            Thread planeCreaterThread = new Thread(flightProducer.GenerateFlights);
            planeCreaterThread.Start();

            //CreateLuage
            Thread lugageCreaterThread = new Thread(lugageProducer.GenerateLugage);
            lugageCreaterThread.Start();

            //everything needs to run in here while the thread is alive. (while the program runs, this needs to run)
            while (Thread.CurrentThread.IsAlive)
            {
                // ------DATA OPEN / CLOSE------ //

                //Opengate

                //RunSorter
            }
        }
    }
}



