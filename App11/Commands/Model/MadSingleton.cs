using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;
using System.Diagnostics;

namespace App11.Commands.Model
{
    class MadSingleton : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
