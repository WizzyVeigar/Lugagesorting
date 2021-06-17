using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    class Gate
    {
        Gate[] gates = new Gate[5];

        private int _gateNumber;
        private bool _open;
        private string _planeNumber;

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

        public string PlaneNumber
        {
            get { return _planeNumber; }
            set { _planeNumber = value; }
        }

        public Gate()
        {

        }
        public Gate(int gateNumber, bool gateOpen)
        {
            GateNumber = gateNumber;
            Open = gateOpen;
        }

        public void GenerateGates()
        {
            for (int i = 0; i < gates.Length; i++)
            {
                Gate gate = new Gate(i + 1, false);
                gates[i] = gate;
                Console.WriteLine($"Gate {gates[i].GateNumber} er nu oprettet, og er (open)?:{gates[i].Open}");
            }
            Console.WriteLine();
        }
    }
}
