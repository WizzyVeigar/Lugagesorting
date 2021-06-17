using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lugagesorting
{
    class Gate
    {
        private int _gateNumber;
        private bool _open = false;
        private Lugage[] _gateBuffer = new Lugage[15];
        private Thread _t;

        public int GateNumber
        {
            get { return _gateNumber; }
            set { _gateNumber = value; }
        }
        
        public bool Open
        {
            get { return _open; }
            set { _open = value; }
        }
        
        public Lugage[] GateBuffer
        {
            get { return _gateBuffer; }
            set { _gateBuffer = value; }
        }

        public Thread T
        {
            get { return _t; }
            set { _t = value; }
        }

        public Gate(int gateNumber)
        {
            GateNumber = gateNumber;
            T = new Thread(Worker);
            T.Start();
        }

        public void Worker()
        {
            while (true)
            {

            }
        }
    }
}
