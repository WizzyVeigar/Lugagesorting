using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    public enum Destination
    {
        Germany,
        Netherlands,
        Finland
    }

    class FlightPlan
    {
        private string _planeNumber;
        private int _gateNumber;
        private DateTime _gateOpen;
        private DateTime _gateClose;

        public Destination destinations;

        public string PlaneNumber
        {
            get { return _planeNumber; }
            set { _planeNumber = value; }
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

        public FlightPlan()
        {

        }

        public FlightPlan(string planeNumber, int gateNumber, Destination destination, DateTime gateOpen, DateTime gateClose)
        {
            PlaneNumber = planeNumber;
            GateNumber = gateNumber;
            destinations = destination;
            GateOpen = gateOpen;
            GateClose = gateClose;
        }
    }
}
