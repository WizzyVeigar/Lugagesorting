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
        private DateTime _departureTime;

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

        public DateTime DepartureTime
        {
            get { return _departureTime; }
            set { _departureTime = value; }
        }

        public FlightPlan(string planeNumber, int gateNumber, Destination destination, DateTime departureTime)
        {
            PlaneNumber = planeNumber;
            GateNumber = gateNumber;
            destinations = destination;
            DepartureTime = departureTime;
        }
    }
}
