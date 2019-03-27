﻿using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectTransportSystem.Forms.Dictionary
{
    /// <summary>
    /// Interaction logic for DistanceOnRoadGroup.xaml
    /// </summary>
    public partial class DistanceOnRoadGroupDictionary : Window
    {
        public DistanceOnRoadGroupDictionary()
        {
            InitializeComponent();
            DataContext = new DistanceOnRoadGroup();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public DistanceOnRoadGroupDictionary(DistanceOnRoadGroup distanceOnRoadGroup)
        {
            InitializeComponent();
            DataContext = distanceOnRoadGroup;
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}