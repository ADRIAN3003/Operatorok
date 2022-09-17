using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    class Operatorok
    {
        private int elsoOperandus;

        public int ElsoOperandus
        {
            get { return elsoOperandus; }
            private set { elsoOperandus = value; }
        }

        private string karakter;

        public string Karakter
        {
            get { return karakter; }
            private set { karakter = value; }
        }

        private int masodikOperandus;

        public int MasodikOperandus
        {
            get { return masodikOperandus; }
            private set { masodikOperandus = value; }
        }

        private string egySor;

        public string EgySor
        {
            get { return egySor; }
            private set { egySor = value; }
        }

        public Operatorok(int elsoOperandus, string karakter, int masodikOperandus)
        {
            this.elsoOperandus = elsoOperandus;
            this.karakter = karakter;
            this.masodikOperandus = masodikOperandus;

            this.egySor = $"{elsoOperandus} {karakter} {masodikOperandus}";
        }
    }
}
