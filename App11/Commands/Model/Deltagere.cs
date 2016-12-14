using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Model
{
    public class Deltagere : INotifyPropertyChanged
    {
      public  double KuverterPrHus;
       public int _antalVoksne;
        public int _husNr;
        public int _antalUnge;

        public event PropertyChangedEventHandler PropertyChanged;

        public int husNr
        {
            get
            {
                return this._husNr;
            }
            set
            {
                this._husNr = value;
                OnPropertyChanged(nameof(husNr));
            }
        }
        public int antalUnge
        {
            get
            {
                return this._antalUnge;
            }
            set
            {
                this._antalUnge = value;
                OnPropertyChanged(nameof(antalVoksne));
            }
        }
        public double gangeForUnge { get; set; }    
        public int  antalSmåBørn { get; set; }
        public double gangeForSmåBørn { get; set; }
        public int antalStoreBørn { get; set; }
        public double gangeForStoreBørn { get; set; }
        public int antalVoksne
        {
            get
            {
                return this._antalVoksne;
            }
            set
            {
                this._antalVoksne = value;
                OnPropertyChanged(nameof(antalVoksne));
            }
        }
        public double gangeForVoksne { get; set; }
        public double PrisPrHus{ get; set; }
        public double PrisPrFamilie { get; set; }
        public Deltagere()

        {
            this.gangeForSmåBørn = 0;
            this.gangeForStoreBørn = 0.25;
            this.gangeForUnge = 0.50;
            this.gangeForVoksne = 1;

        }




        public override string ToString()
        {
            return "Hus nr: " + husNr +

               "  Antal unge(7-15), store børn (3-6), små børn (0-3): "



               + antalUnge + ", " + antalStoreBørn + ", " + antalSmåBørn;
        }

            protected virtual void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }


        



    }


    }
}
