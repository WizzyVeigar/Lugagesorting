using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    public enum Destination
    {
        Germany,
        Holland,
        Finland
    }

    class FlightPlan
    {
        //FlyNr. , gatenr , Gateopen/close, 
        private string _flightNumber;
        private int _gateNumber;
        private DateTime _gateOpen;
        private DateTime _gateClose;

        public string FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public int GateNumber
        {
            get { return _gateNumber; }
            set { _gateNumber = value; }
        }

        public DateTime GateOpen
        {
            get { return _gateOpen; }
            set { _gateOpen = value; }
        }
        public DateTime GateClose
        {
            get { return _gateClose; }
            set { _gateClose = value; }
        }

        public FlightPlan(string flightNumber, int gateNumber, DateTime gateOpen, DateTime gateClose)
        {

        }
    }
}
