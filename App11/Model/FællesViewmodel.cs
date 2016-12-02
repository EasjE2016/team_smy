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

namespace App11.Model
{
    class FællesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DeltagerList ListviewDeltager { get; set; }
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
        public FællesViewmodel()
        {
            AddDeltagere = new Relaycommand(addDeltagerMetode, null);
            this.ListviewDeltager = new DeltagerList();
            
        }

        private void addDeltagerMetode()
        {
            
        }

        private void GotoMainpage2_Button(object sender, RoutedEventArgs e)
        {

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

