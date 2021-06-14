using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    /// <summary>
    /// Lugage creater
    /// </summary>
    class Lugage
    {
        private int _lugageNumber;
        private int _passeengerNumber;
        private int _flightNumber;

        public int LuageNumber
        {
            get { return _lugageNumber; }
            set { _lugageNumber = value; }
        }

        public int PassengerNumber
        {
            get { return _passeengerNumber; }
            set { _passeengerNumber = value; }
        }

        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        private DateTime _timeStamp;

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }


        public Lugage(int lugageNumber, int passengerNumber, int flightNumber)
        {

        }
    }
}
