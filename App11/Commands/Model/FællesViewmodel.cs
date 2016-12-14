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
using Newtonsoft.Json;

namespace App11.Model
{
    public class FællesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Instance fields
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

        public Relaycommand TilføjDeltager { get; set; }
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
        private Dictionary<int, Double> Prisdict;

        public FællesViewmodel()
        {
            TilføjNyArbejdsOpgave = new Relaycommand(TilføjMetode, null);
            Prislist = new ObservableCollection<string>();

            BeregnNu = new Relaycommand(BeregnNuMetode, null);
            TilføjDeltager = new Relaycommand(TilføjDeltagerMetode, null);
            _mandagsliste = new DeltagerList();
            _mandagsliste.Add(1, new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _mandagsliste.Add(2, new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _mandagsliste.Add(3, new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _tirsdagsliste = new DeltagerList();
            _tirsdagsliste.Add(1, new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _tirsdagsliste.Add(2, new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _tirsdagsliste.Add(3, new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _onsdagsliste = new DeltagerList();
            _onsdagsliste.Add(1, new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _onsdagsliste.Add(2, new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _onsdagsliste.Add(3, new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _torsdagsliste = new DeltagerList();
            _torsdagsliste.Add(1, new Deltagere() { husNr = 1, antalVoksne = 2, antalUnge = 1, antalSmåBørn = 0, antalStoreBørn = 1 });
            _torsdagsliste.Add(2, new Deltagere() { husNr = 2, antalVoksne = 1, antalUnge = 2, antalSmåBørn = 1, antalStoreBørn = 0 });
            _torsdagsliste.Add(3, new Deltagere() { husNr = 3, antalVoksne = 2, antalUnge = 0 });
            _arbejdsListe = new ArbejdsOpgaveListe();

        }

        //Json
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Deltagere> nyListe = JsonConvert.DeserializeObject<List<Deltagere>>(jsonText);
        }


        private void TilføjDeltagerMetode()
        {
           // Deltagere  = new Deltagere()
 
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


            foreach (KeyValuePair<int,Deltagere> deltager in Mandagsliste)
            {
                KuverterMandag = KuverterMandag + (deltager.Value.antalVoksne * deltager.Value.gangeForVoksne + 
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn);

            }

            foreach (KeyValuePair<int, Deltagere> deltager in Tirsdagsliste)
            {
                KuverterTirsdag = KuverterTirsdag +
                   (deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn);
            }


                foreach (KeyValuePair<int, Deltagere> deltager in Onsdagsliste)
            {
             KuverterOnsdag = KuverterOnsdag + (deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn);
                }


            foreach (KeyValuePair<int, Deltagere> deltager in Torsdagsliste)
            {
                KuverterTorsdag = KuverterTorsdag +
               (deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn);
                }


            KuverterOmUgen = KuverterMandag + KuverterTirsdag + KuverterOnsdag + KuverterTorsdag; 

        }


        public void PrisPrHustand()
        {

            BeregnKurverter();
            
            foreach (KeyValuePair<int, Deltagere> deltager in Mandagsliste)
            {
                deltager.Value.PrisPrFamilie = (_prisIalt / KuverterMandag) *
                    ((deltager.Value.antalVoksne * deltager.Value.gangeForVoksne + 
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn)); 
              

            }
            foreach (KeyValuePair<int, Deltagere> deltager in Tirsdagsliste)
            {
                deltager.Value.PrisPrFamilie = (_prisIalt / KuverterTirsdag) *
                    ((deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn)); ;

            }

            foreach (KeyValuePair<int, Deltagere> deltager in Onsdagsliste)
            {
                deltager.Value.PrisPrFamilie = (_prisIalt / KuverterOnsdag) *
                    ((deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn)); ;

            }

            foreach (KeyValuePair<int, Deltagere> deltager in Torsdagsliste)
            {
                deltager.Value.PrisPrFamilie = (_prisIalt / KuverterTorsdag) *
                    ((deltager.Value.antalVoksne * deltager.Value.gangeForVoksne +
                    deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                    deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn)); ;

                
    
            }
            
           
            
        } 
            

        public void VisResultat()
        {
            

            foreach (KeyValuePair<int, Deltagere> deltager in Mandagsliste)
            {
                Prislist.Add($"Hus Nr {deltager.Key} skal betale {deltager.Value.PrisPrFamilie}");
            }

           
        }



        private void BeregnNuMetode()
        {
            BeregnKurverter();
            {
                foreach (KeyValuePair<int, Deltagere> deltager in Mandagsliste)
                {
                    deltager.Value.PrisPrFamilie = (_prisIalt / KuverterMandag) * 
                        ((deltager.Value.antalVoksne * deltager.Value.gangeForVoksne + 
                        deltager.Value.antalUnge * deltager.Value.gangeForUnge +
                        deltager.Value.antalStoreBørn * deltager.Value.gangeForStoreBørn)); ;
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

