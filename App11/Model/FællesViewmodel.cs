using System;
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
using System.Collections.ObjectModel;

namespace App11.Model
{
    public class FællesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DeltagerList _mandagsliste;
        private DeltagerList _tirsdagsliste;
        private DeltagerList _onsdagsliste;
        private DeltagerList _torsdagsliste;
        private ArbejdsOpgaveListe _arbejdsListe;
        public double KuverterMandag;
        public double KuverterTirsdag;
        public double KuverterTorsdag;
        public double KuverterOnsdag;
        public double KuverterOmUgen;
        public double PrisPrFamilie { get; set; }
        public ObservableCollection<string> Prislist { get; set; }

        public double _prisIalt;
        public string _dagensRetMandag;
        public string _dagensRetTirsdag;
        public string _dagensRetOnsdag;
        public string _dagensRetTorsdag;

        public string _arbejdsOpgave;
        public string _navn;
        public string _dag;

        public DeltagerList Mandagsliste
        { get { return _mandagsliste; } }
        public DeltagerList Tirsdagsliste { get { return _tirsdagsliste; } }
        public DeltagerList Onsdagsliste { get { return _onsdagsliste; } }
        public DeltagerList Torsdagsliste { get { return _torsdagsliste; } }

        public ArbejdsOpgaveListe ArbejdsListe { get { return _arbejdsListe; } }


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

        public Relaycommand BeregnNu { get; set; }

        public Relaycommand TilføjNyArbejdsOpgave { get; set; }

        public string DagensRetMandag
        {
            get
            {
                return this._dagensRetMandag;
            }
            set
            {
                this._dagensRetMandag = value;
                OnPropertyChanged(nameof(DagensRetMandag));
            }
        }

        public string ArbejdsOpgave { get { return this._arbejdsOpgave; }
            set { this._arbejdsOpgave = value;
                OnPropertyChanged(nameof(ArbejdsOpgave)); } }

        public string Dag { get { return this._dag; }
            set { this._dag = value;
                OnPropertyChanged(nameof(Dag));
            } }

        public string Navn { get { return this._navn; }
            set { this._navn = value;
                OnPropertyChanged(nameof(Navn));
            } }
        public string DagensRetTirsdag
        {
            get
            {
                return this._dagensRetTirsdag;
            }
            set
            {
                this._dagensRetTirsdag = value;
                OnPropertyChanged(nameof(DagensRetTirsdag));
            }
        }

        public string DagensRetOnsdag
        {
            get
            {
                return this._dagensRetOnsdag;
            }
            set
            {
                this._dagensRetOnsdag = value;
                OnPropertyChanged(nameof(DagensRetOnsdag));
            }
        }

        public string DagensRetTorsdag
        {
            get
            {
                return this._dagensRetTorsdag;
            }
            set
            {
                this._dagensRetTorsdag = value;
                OnPropertyChanged(nameof(DagensRetTorsdag));
            }
        }
        public double IaltPris
        {
            get { return this._prisIalt; }
            set
            {
                this._prisIalt = value;
                OnPropertyChanged(nameof(IaltPris));

            }
        }

        public FællesViewmodel()
        {
            TilføjNyArbejdsOpgave = new Relaycommand(TilføjMetode, null);
            Prislist = new ObservableCollection<string>();
            BeregnNu = new Relaycommand(BeregnNuMetode, null);
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
            _arbejdsListe = new ArbejdsOpgaveListe();



        }

        private void TilføjMetode()
        {

            _arbejdsListe.Add(new ArbejdsOpgaver()
            {
                ArbejdsOpgave = ArbejdsOpgave,
        Dag = Dag,
            Navn = Navn
        
            });
          

           
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

            foreach (Deltagere deltagere in Onsdagsliste)
            {
             KuverterOnsdag = KuverterOnsdag + deltagere.KuverterPrHus;
            }


            foreach (Deltagere deltagere in Torsdagsliste)
            {
                KuverterTorsdag = KuverterTorsdag + deltagere.KuverterPrHus;
            }


            KuverterOmUgen = KuverterMandag + KuverterTirsdag + KuverterOnsdag + KuverterTorsdag; 

        }


        public void PrisPrHustand()
        {

            BeregnKurverter();

            foreach (Deltagere deltagere in Mandagsliste)
            {
                PrisPrFamilie = (_prisIalt / KuverterOmUgen) * deltagere.KuverterPrHus;

            }
        } 
            

        public void VisResultat()
        {
            

            foreach (Deltagere deltagere in Mandagsliste)
            {
                Prislist.Add($"Hus Nr {deltagere.husNr} skal betale {PrisPrFamilie}");
            }

           
        }



        private void BeregnNuMetode()
        {
            {
                foreach (Deltagere deltagere in Mandagsliste)
                {
                    PrisPrFamilie = (_prisIalt / KuverterMandag) * deltagere.KuverterPrHus;
                }
                

            }
            VisResultat();
            

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

