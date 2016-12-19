using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App11.Model
{
    public sealed class ArbejdsOpgaver
    {
        public string Navn { get; set; }
        public string Dag { get; set; }
        public string ArbejdsOpgave { get; set; }

        public override string ToString()
        {
            return $"Navn: {Navn}, Dag: {Dag}, Arbejdsopgave: {ArbejdsOpgave}";
        }
    }
}
