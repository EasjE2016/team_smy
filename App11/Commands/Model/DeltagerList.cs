using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;


namespace App11.Model
{
    public class DeltagerList : ObservableCollection<Deltagere>
    {
        public DeltagerList()

        { }
            
               public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
        public void IndsætJson(string jsonText)
        {
            List<Deltagere> nyListe = JsonConvert.DeserializeObject<List<Deltagere>>(jsonText);

            foreach (var Deltagere in nyListe)
            {
                this.Add(Deltagere);
            } }
    }
    }
    



