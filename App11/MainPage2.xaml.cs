using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App11.Model;
using App11.Commands;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage2 : Page
    {
        public MainPage2()
        {
            this.InitializeComponent();

            FællesViewmodel viewmodel = new FællesViewmodel
            {
                IaltPris = 1
            };

            this.DataContext = viewmodel;

            
        } 




        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(App11.MainPage));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
