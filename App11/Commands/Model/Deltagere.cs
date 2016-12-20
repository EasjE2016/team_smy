using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Model
{
    public class Deltagere
    {
      public  double KuverterPrHus;
        public int husNr { get; set; }
        public int antalUnge { get; set; }
        public double gangeForUnge { get; set; }    
        public int  antalSmåBørn { get; set; }
        public double gangeForSmåBørn { get; set; }
        public int antalStoreBørn { get; set; }
        public double gangeForStoreBørn { get; set; }
        public int antalVoksne { get; set; }
        public double gangeForVoksne { get; set; }
        public double PrisPrHus{ get; set; }
        public double PrisPrFamilie { get; set; }
        public string Dag { get; set; }
        public double GangMedDette { get; set; }
        public Deltagere()

        {
            this.gangeForSmåBørn = 0;
            this.gangeForStoreBørn = 0.25;
            this.gangeForUnge = 0.50;
            this.gangeForVoksne = 1;

        }

      


        public override string ToString()
        {
            return "Hus: " + husNr +

               "  Unge(7-15), Børn(3-6), Børn (0-3): "



               + antalUnge + ", " + antalStoreBørn + ", " + antalSmåBørn;




        }


    }
}
