using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Model
{
    class Deltagere
    {
        public int husNr { get; set; }
        public int antalUnge { get; set; }
        public int  antalSmåBørn { get; set; }
        public int antalStoreBørn { get; set; }
        public int antalVoksne { get; set; }


        public override string ToString()
        {
            return "Hus nr: " + husNr +

               "Antal unge(7-15), store børn (3-6), små børn (0-3): "
               + antalUnge + ", " + antalStoreBørn + ", " + antalSmåBørn;


        }


    }
}
