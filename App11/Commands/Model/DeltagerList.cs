using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace App11.Model
{
  public  class DeltagerList : ObservableCollection<Deltagere>
    {
        public DeltagerList()
        { 

     
        
        }

        internal object GetJson()
        {
            throw new NotImplementedException();
        }
    }
}

