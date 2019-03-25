﻿using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTransportSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in Dictionary.Items.Cast<TabItem>())
                item.Content = DictionaryList.InitDictionary(DictionaryBuilder.GetDictionaryBuilder(item.Name),
                              GlobalStaticContext.MainDbContext.GetContext(item.Name));
            MainControl.IsEnabled = true;
            Loading.Visibility = Visibility.Hidden;
        }
    }
}
