﻿using App11.Commands;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        public MainPage()
        {
            this.InitializeComponent();
        }
     



        
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                    }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(App11.MainPage3));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(App11.MainPage2));
        }

        private void gridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           
        }

        private void gridView_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void gridView_Copy2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
