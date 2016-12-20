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
        public DeltagerList _mandagsliste;
        public DeltagerList _tirsdagsliste;
        public DeltagerList _onsdagsliste;
        public DeltagerList _torsdagsliste;
        public ArbejdsOpgaveListe _arbejdsListe;
        public double KuverterMandag;
        public double KuverterTirsdag;
        public double KuverterTorsdag;
        public double KuverterOnsdag;
        public double KuverterOmUgen;
        private Deltagere selectedDeltager;
        StorageFolder localfolder = null;
        private readonly string filnavnTilmeldingMandag = "Mandag.json";
        private readonly string filnavnTilmeldingTirsdag = "Tirsdag.json";
        private readonly string filnavnTilmeldingOnsdag = "Onsdag.json";
        private readonly string filnavnTilmeldingTorsdag = "Torsdag.json";
        private readonly string filnavnArbejdsopgaver = "Arbejdsopgaver.json";

        public ObservableCollection<string> Prislist { get; set; }

        public double _prisIalt;
        public string _dagensRetMandag;
        public string _dagensRetTirsdag;
        public string _dagensRetOnsdag;
        public string _dagensRetTorsdag;
        public int _husNr;
        public int _antalUnge;
        public int _antalVoksne;
        public int _antalSmåBørn;
        public int _antalStoreBørn;


        public string _arbejdsOpgave;
        public string _navn;
        public string _dag;

        public DeltagerList Mandagsliste { get { return _mandagsliste; } }
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



        public List<string> Combobox { get; set; }

        public Deltagere SelectedDeltager
        {
            get { return selectedDeltager; }
            set
            {
                selectedDeltager = value;
                OnPropertyChanged(nameof(SelectedDeltager));
            }
        }

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
                OnPropertyChanged(nameof(antalUnge));
            }
        }
        public double gangeForUnge { get; set; }
        public int antalSmåBørn
        {
            get
            {
                return this._antalSmåBørn;
            }
            set
            {
                this._antalSmåBørn = value;
                OnPropertyChanged(nameof(antalSmåBørn));
            }
        }


        public int antalStoreBørn
        {
            get
            {
                return this._antalStoreBørn;
            }
            set
            {
                this._antalStoreBørn = value;
                OnPropertyChanged(nameof(antalStoreBørn));
            }
        }
        public Relaycommand DeleteDeltager { get; }
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

        public string ArbejdsOpgave
        {
            get { return this._arbejdsOpgave; }
            set
            {
                this._arbejdsOpgave = value;
                OnPropertyChanged(nameof(ArbejdsOpgave));
            }
        }

        public string Dag
        {
            get { return this._dag; }
            set
            {
                this._dag = value;
                OnPropertyChanged(nameof(Dag));
            }
        }

        public string Navn
        {
            get { return this._navn; }
            set
            {
                this._navn = value;
                OnPropertyChanged(nameof(Navn));
            }
        }
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
        private Dictionary<int, double> Prisdict2;

        public FællesViewmodel()
        {
            Prisdict2 = new Dictionary<int, double>();
            Prisdict = new Dictionary<int, double>();
            TilføjNyArbejdsOpgave = new Relaycommand(TilføjMetode, null);
            Prislist = new ObservableCollection<string>();
            TilføjDeltager = new Relaycommand(TilføjDeltagerMetode, null);
            BeregnNu = new Relaycommand(BeregnNuMetode, null);
            TilføjDeltager = new Relaycommand(TilføjDeltagerMetode, null);
            DeleteDeltager = new Relaycommand(DeleteDeltagerMetode, null);
            _mandagsliste = new DeltagerList();
            _tirsdagsliste = new DeltagerList();
            _onsdagsliste = new DeltagerList();
            _torsdagsliste = new DeltagerList();
            _arbejdsListe = new ArbejdsOpgaveListe();
            Combobox = new List<string>();
            Combobox.Add("Mandag");
            Combobox.Add("Tirsdag");
            Combobox.Add("Onsdag");
            Combobox.Add("Torsdag");
            localfolder = ApplicationData.Current.LocalFolder;
            HentdataFraDiskAsyncMandag();
            HentdataFraDiskAsyncTirsdag();
            HentdataFraDiskAsyncOnsdag();
            HentdataFraDiskAsyncTorsdag();
            //  HentdataFraDiskAsyncArbejdsopgaver();
        }

        private void DeleteDeltagerMetode()
        {
            _mandagsliste.Remove(selectedDeltager);
            _tirsdagsliste.Remove(selectedDeltager);
            _onsdagsliste.Remove(selectedDeltager);
            _torsdagsliste.Remove(selectedDeltager);

            GemDataTilDiskAsyncMandag(GetJsonMandag());
            GemDataTilDiskAsyncTirsdag(GetJsonTirsdag());
            GemDataTilDiskAsyncOnsdag(GetJsonOnsdag());
            GemDataTilDiskAsyncTorsdag(GetJsonTorsdag());
        }

        //Json
        public string GetJsonMandag()
        {
            string json = JsonConvert.SerializeObject(_mandagsliste);
            return json;
        }

        public string GetJsonTirsdag()
        {
            string json = JsonConvert.SerializeObject(_tirsdagsliste);
            return json;
        }

        public string GetJsonOnsdag()
        {
            string json = JsonConvert.SerializeObject(_onsdagsliste);
            return json;
        }

        public string GetJsonTorsdag()
        {
            string json = JsonConvert.SerializeObject(_torsdagsliste);
            return json;
        }

        public string GetJsonArbejdsopgaver()
        {
            string json = JsonConvert.SerializeObject(_arbejdsListe);
            return json;
        }


        public void IndsætJsonMandag(string jsonText)
        {
            DeltagerList nyListe = JsonConvert.DeserializeObject<DeltagerList>(jsonText);
            _mandagsliste.Clear();
            foreach (var item in nyListe)
            {
                _mandagsliste.Add(item);
            }
        }


        public void IndsætJsonTirsdag(string jsonText)
        {
            DeltagerList nyListe = JsonConvert.DeserializeObject<DeltagerList>(jsonText);
            _tirsdagsliste.Clear();
            foreach (var item in nyListe)
            {
                _tirsdagsliste.Add(item);
            }
        }


        public void IndsætJsonOnsdag(string jsonText)
        {
            DeltagerList nyListe = JsonConvert.DeserializeObject<DeltagerList>(jsonText);
            _onsdagsliste.Clear();
            foreach (var item in nyListe)
            {
                _onsdagsliste.Add(item);
            }
        }


        public void IndsætJsonTorsdag(string jsonText)
        {
            DeltagerList nyListe = JsonConvert.DeserializeObject<DeltagerList>(jsonText);
            _torsdagsliste.Clear();
            foreach (var item in nyListe)
            {
                _torsdagsliste.Add(item);
            }
        }


        public void IndsætJsonArbejdsopgaver(string jsonText)
        {
            ArbejdsOpgaveListe nyliste = JsonConvert.DeserializeObject<ArbejdsOpgaveListe>(jsonText);
            _arbejdsListe.Clear();
            foreach (var item in nyliste)
            {
                _arbejdsListe.Add(item);
            }
        }

        /*
        const String FileNameTilmelding = "saveTilmeling.json";
        public ObservableCollection<Deltagere> Tilmeldsliste { get; set; }
        */
        public async void HentdataFraDiskAsyncMandag()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavnTilmeldingMandag);
            string jsonText = await FileIO.ReadTextAsync(file);
            IndsætJsonMandag(jsonText);
        }


        public async void HentdataFraDiskAsyncTirsdag()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavnTilmeldingTirsdag);
            string jsonText = await FileIO.ReadTextAsync(file);
            IndsætJsonTirsdag(jsonText);
        }


        public async void HentdataFraDiskAsyncOnsdag()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavnTilmeldingOnsdag);
            string jsonText = await FileIO.ReadTextAsync(file);
            IndsætJsonOnsdag(jsonText);
        }


        public async void HentdataFraDiskAsyncTorsdag()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavnTilmeldingTorsdag);
            string jsonText = await FileIO.ReadTextAsync(file);
            IndsætJsonTorsdag(jsonText);
        }


        /*    public async void HentdataFraDiskAsyncArbejdsopgaver()
            {
                StorageFile file = await localfolder.GetFileAsync(filnavnArbejdsopgaver);
                string jsonText = await FileIO.ReadTextAsync(file);
                IndsætJsonArbejdsopgaver(jsonText);
            }*/


        public async void GemDataTilDiskAsyncMandag(string JsonText)
        {
            StorageFile file = await localfolder.CreateFileAsync(filnavnTilmeldingMandag, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        public async void GemDataTilDiskAsyncTirsdag(string JsonText)
        {
            StorageFile file = await localfolder.CreateFileAsync(filnavnTilmeldingTirsdag, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        public async void GemDataTilDiskAsyncOnsdag(string JsonText)
        {
            StorageFile file = await localfolder.CreateFileAsync(filnavnTilmeldingOnsdag, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        public async void GemDataTilDiskAsyncTorsdag(string JsonText)
        {
            StorageFile file = await localfolder.CreateFileAsync(filnavnTilmeldingTorsdag, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        public async void GemDataTilDiskAsyncArbejdsopgaver(string JsonText)
        {
            StorageFile file = await localfolder.CreateFileAsync(filnavnArbejdsopgaver, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }


        public void TilføjDeltagerMetode()
        {
            if (this.Dag == this.Combobox[0])
            {
                _mandagsliste.Add(new Deltagere()
                {
                    husNr = husNr,
                    antalVoksne = antalVoksne,
                    antalUnge = antalUnge,
                    antalStoreBørn = antalStoreBørn,
                    antalSmåBørn = antalSmåBørn

                });
            }

            if (this.Dag == this.Combobox[1])
            {
                _tirsdagsliste.Add(new Deltagere()
                {
                    husNr = husNr,
                    antalVoksne = antalVoksne,
                    antalUnge = antalUnge,
                    antalStoreBørn = antalStoreBørn,
                    antalSmåBørn = antalSmåBørn
                });
            }

            if (this.Dag == this.Combobox[2])
            {
                _onsdagsliste.Add(new Deltagere()
                {
                    husNr = husNr,
                    antalVoksne = antalVoksne,
                    antalUnge = antalUnge,
                    antalStoreBørn = antalStoreBørn,
                    antalSmåBørn = antalSmåBørn
                });
            }

            if (Dag == this.Combobox[3])
            {
                _torsdagsliste.Add(new Deltagere()
                {
                    husNr = husNr,
                    antalVoksne = antalVoksne,
                    antalUnge = antalUnge,
                    antalStoreBørn = antalStoreBørn,
                    antalSmåBørn = antalSmåBørn
                });
            }

            else
            {
                MessageDialog showDialog = new MessageDialog("Denne dag eksistere desværre ikke");
            }

            GemDataTilDiskAsyncMandag(GetJsonMandag());
            GemDataTilDiskAsyncTirsdag(GetJsonTirsdag());
            GemDataTilDiskAsyncOnsdag(GetJsonOnsdag());
            GemDataTilDiskAsyncTorsdag(GetJsonTorsdag());

        }

        private void TilføjMetode()
        {

            _arbejdsListe.Add(new ArbejdsOpgaver()
            {
                ArbejdsOpgave = ArbejdsOpgave,
                Dag = Dag,
                Navn = Navn

            });

            GemDataTilDiskAsyncArbejdsopgaver(GetJsonArbejdsopgaver());

        }

        private void BeregnKurverter()
        {


            foreach (Deltagere deltager in Mandagsliste)
            {
                KuverterMandag = KuverterMandag + (deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn);

            }

            foreach (Deltagere deltager in Tirsdagsliste)
            {
                KuverterTirsdag = KuverterTirsdag +
                   (deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn);
            }


            foreach (Deltagere deltager in Onsdagsliste)
            {
                KuverterOnsdag = KuverterOnsdag + (deltager.antalVoksne * deltager.gangeForVoksne +
                       deltager.antalUnge * deltager.gangeForUnge +
                       deltager.antalStoreBørn * deltager.gangeForStoreBørn);
            }


            foreach (Deltagere deltager in Torsdagsliste)
            {
                KuverterTorsdag = KuverterTorsdag + (deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn);
            }


            KuverterOmUgen = KuverterMandag + KuverterTirsdag + KuverterOnsdag + KuverterTorsdag;

        }


        public void PrisPrHustand()
        {

            BeregnKurverter();

            foreach (Deltagere deltager in Mandagsliste)
            {
                deltager.PrisPrFamilie = (_prisIalt / KuverterMandag) *
                    ((deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn));
            }



            foreach (Deltagere deltager in Tirsdagsliste)
            {
                deltager.PrisPrFamilie = (_prisIalt / KuverterTirsdag) *
                                ((deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn));
            }

            foreach (Deltagere deltager in Onsdagsliste)
            {
                deltager.PrisPrFamilie = (_prisIalt / KuverterOnsdag) *
                ((deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn));

            }

            foreach (Deltagere deltager in Torsdagsliste)
            {
                deltager.PrisPrFamilie = (_prisIalt / KuverterTorsdag) *
                                      ((deltager.antalVoksne * deltager.gangeForVoksne +
                    deltager.antalUnge * deltager.gangeForUnge +
                    deltager.antalStoreBørn * deltager.gangeForStoreBørn));



            }



        }


        public void VisResultat()
        {


            foreach (var liste in Prisdict2)
            {
                Prislist.Add($"Hus Nr {liste.Key} skal betale {liste.Value}");
            }


        }



        private void BeregnNuMetode()
        {
            BeregnKurverter();
            {
                foreach (Deltagere deltager in Mandagsliste)
                {
                    deltager.GangMedDette = ((deltager.antalVoksne * deltager.gangeForVoksne +
                   deltager.antalUnge * deltager.gangeForUnge +
                   deltager.antalStoreBørn * deltager.gangeForStoreBørn));

                    if (!Prisdict.ContainsKey(deltager.husNr))

                    {
                        Prisdict.Add(deltager.husNr, deltager.GangMedDette);
                    }

                    else
                    {

                        Prisdict[husNr] = deltager.GangMedDette + deltager.GangMedDette;
                    }
                }

            }

            foreach (Deltagere deltager in Tirsdagsliste)

            {

                deltager.GangMedDette = ((deltager.antalVoksne * deltager.gangeForVoksne +
               deltager.antalUnge * deltager.gangeForUnge +
               deltager.antalStoreBørn * deltager.gangeForStoreBørn));

                if (!Prisdict.ContainsKey(deltager.husNr))
                {
                    Prisdict.Add(deltager.husNr, deltager.GangMedDette = deltager.GangMedDette + deltager.GangMedDette);
                }

                else
                {
                    Prisdict[husNr] = deltager.GangMedDette + deltager.GangMedDette;
                }
            }


            foreach (Deltagere deltager in Onsdagsliste)

            {


                deltager.GangMedDette = ((deltager.antalVoksne * deltager.gangeForVoksne +
               deltager.antalUnge * deltager.gangeForUnge +
               deltager.antalStoreBørn * deltager.gangeForStoreBørn));

                if (!Prisdict.ContainsKey(deltager.husNr))
                {
                    Prisdict.Add(deltager.husNr, deltager.GangMedDette = deltager.GangMedDette + deltager.gangeForSmåBørn);
                }

                else
                {

                    Prisdict[husNr] = deltager.GangMedDette + deltager.GangMedDette;
                }
            }

            foreach (Deltagere deltager in Torsdagsliste)

            {

                deltager.GangMedDette = ((deltager.antalVoksne * deltager.gangeForVoksne +
               deltager.antalUnge * deltager.gangeForUnge +
               deltager.antalStoreBørn * deltager.gangeForStoreBørn));

                if (!Prisdict.ContainsKey(deltager.husNr))
                {
                    Prisdict.Add(deltager.husNr, deltager.GangMedDette = deltager.GangMedDette + deltager.GangMedDette);
                }

                else
                {
                    Prisdict[husNr] = deltager.GangMedDette + deltager.GangMedDette;
                }


                foreach (var pris in Prisdict)
                {
                    deltager.PrisPrFamilie = pris.Value * (_prisIalt / KuverterOmUgen);

                    Prisdict2.Add(deltager.husNr, deltager.PrisPrFamilie);
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
