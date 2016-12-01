using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace App11.Model
{
    class FællesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FællesViewmodel()
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

