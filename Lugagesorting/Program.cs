using System;
using System.Threading;

namespace Lugagesorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of our manager
            Manager manager = new Manager();

            //Create our manager thread
            Thread managerThread = new Thread(manager.SimulationStart);
            managerThread.Start();

            Manager.PrintEvent += PrintDataEvent;
        }

        private static void PrintDataEvent(DataPrinter printer)
        {
            switch (printer.dataTypePrint)
            {
                case DataPrinter.DataTypePrint.BaggageData:
                    break;
                case DataPrinter.DataTypePrint.ManagerData:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(printer.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
        }
    }
    
    class DataPrinter
    {
        //Chooses the datatype, you want to return
        public enum DataTypePrint
        {
            BaggageData,
            ManagerData
        }

        //Creates a string with the message.
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public DataTypePrint dataTypePrint;

        //Creates our dataprinter constructer, which takes a string which is our message, and our 
        public DataPrinter(string message, DataTypePrint dateTypePrint)
        {
            this.Message = message;
            this.dataTypePrint = dateTypePrint;
        }
    }
}
