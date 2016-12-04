using App11.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Model
{
    class Beregning : INotifyPropertyChanged
    {
   
        public event PropertyChangedEventHandler PropertyChanged;

        private int prisIAlt;
        public Relaycommand PrisBeregning { get; set; }

        public Beregning()
        {
            this.PrisBeregning = new Relaycommand(prisberegningmetode, null);
        }

        private void prisberegningmetode()
        {

        }
    }
}
