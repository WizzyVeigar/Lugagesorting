using System;
using System.Collections.Generic;
using System.Text;

namespace Lugagesorting
{
    class Gate
    {
        Gate[] gates = new Gate[5];

        private int _gateNumber;

        public int GateNumber
        {
            get { return _gateNumber; }
            set { _gateNumber = value; }
        }

        public Gate()
        {

        }
        public Gate(int gateNumber)
        {
            GateNumber = gateNumber;
        }

        public void GenerateGates()
        {
            for (int i = 0; i < gates.Length; i++)
            {
                Gate gate = new Gate(i + 1);
                gates[i] = gate;
                Console.WriteLine($"Gate {gates[i].GateNumber} er nu oprettet");
            }
            Console.WriteLine();
        }
    }
}
