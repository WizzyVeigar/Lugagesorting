using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    class Gate
    {
        private int _gateNumber;

        public int GateNumber
        {
            get { return _gateNumber; }
            set { _gateNumber = value; }
        }

        public Gate(int gateNumber)
        {
            GateNumber = gateNumber;
        }
    }
}
