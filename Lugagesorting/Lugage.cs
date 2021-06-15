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
        private DateTime _timeStampCheckin;
        private DateTime _timeStampSortingIn;
        private DateTime _timeStampSoritingOut;
        private DateTime _timeStampGate;

        public int LugageNumber
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

        public DateTime TimeStampCheckin
        {
            get { return _timeStampCheckin; }
            set { _timeStampCheckin = value; }
        }

        public DateTime TimeStampSortingIn
        {
            get { return _timeStampSortingIn; }
            set { _timeStampSortingIn = value; }
        }

        public DateTime TimeStampSortingOut
        {
            get { return _timeStampSoritingOut; }
            set { _timeStampSoritingOut = value; }
        }

        public DateTime TimeStampGate
        {
            get { return _timeStampGate; }
            set { _timeStampGate = value; }
        }


        public Lugage(int lugageNumber, int passengerNumber, int flightNumber)
        {
            LugageNumber = lugageNumber;
            PassengerNumber = passengerNumber;
            FlightNumber = flightNumber;
        }
    }
}
