﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using App11.Commands;
using Windows.Storage;
using Windows.UI.Popups;
using System.Windows.Input;

namespace App11.Model
{
    public class FællesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DeltagerList _mandagsliste;
        private DeltagerList _tirsdagsliste;
        private DeltagerList _onsdagsliste;
        private DeltagerList _torsdagsliste;
        public double KuverterMandag;
        public double KuverterTirsdag;
        public double KuverterTorsdag;
        public double KuverterOnsdag;
        public double KuverterOmUgen;
        public double PrisPrFamilie { get; set; }

        public double _prisIalt;


        public DeltagerList Mandagsliste
        { get { return _mandagsliste; } }
        public DeltagerList Tirsdagsliste { get { return _tirsdagsliste; } }
        public DeltagerList Onsdagsliste { get { return _onsdagsliste; } }
        public DeltagerList Torsdagsliste { get { return _torsdagsliste; } }


        /*
        public Relaycommand directCommand { get;private set; }

        public FællesViewmodel()
        {
            directCommand = new Relaycommand(directMethod, null);
        }

       private void directMethod()
        {
        }
        */

        public Relaycommand AddDeltagere { get; set; }

        public double IaltPris
        {
            get { return this.IaltPris; }
            set
            {
                this._prisIalt = value;
                this.OnPropertyChanged(nameof(IaltPris));
            }
        }

        public FællesViewmodel()
        {
            AddDeltagere = new Relaycommand(addDeltagerMetode, null);
      
            _mandagsliste = new DeltagerList();
            _mandagsliste.Add(new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _mandagsliste.Add(new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _mandagsliste.Add(new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _tirsdagsliste = new DeltagerList();
            _tirsdagsliste.Add(new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _tirsdagsliste.Add(new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _tirsdagsliste.Add(new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _onsdagsliste = new DeltagerList();
            _onsdagsliste.Add(new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _onsdagsliste.Add(new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _onsdagsliste.Add(new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _torsdagsliste = new DeltagerList();
            _torsdagsliste.Add(new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _torsdagsliste.Add(new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _torsdagsliste.Add(new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });




        }



        private void BeregnKurverter()
        {
            foreach (Deltagere deltagere in Mandagsliste)
            {
                KuverterMandag = KuverterMandag + deltagere.KuverterPrHus;
            }

            foreach (Deltagere deltagere in Tirsdagsliste)
            {
                KuverterTirsdag = KuverterTirsdag + deltagere.KuverterPrHus;
            }

            foreach (Deltagere deltagere in Tirsdagsliste)
            {
             KuverterOnsdag = KuverterOnsdag + deltagere.KuverterPrHus;
            }


            foreach (Deltagere deltagere in Tirsdagsliste)
            {
                KuverterTorsdag = KuverterTorsdag + deltagere.KuverterPrHus;
            }


            KuverterOmUgen = KuverterMandag + KuverterTirsdag + KuverterOnsdag + KuverterTorsdag; 

        }


        public string PrisPrHustand()
        {
            foreach (Deltagere deltagere in Mandagsliste)
            {
                PrisPrFamilie = (_prisIalt / KuverterMandag) * deltagere.KuverterPrHus;
                return $"Hus Nr {deltagere.husNr} skal betale {PrisPrFamilie}";
            }

            return "Godt måltid";
        }
    
       
        

        private void addDeltagerMetode()
        {

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



    /*protected virtual void onPropertyChanged (string propertyName)
           {
               if(PropertyChanged != null)
               {
                   PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
               }

      */

