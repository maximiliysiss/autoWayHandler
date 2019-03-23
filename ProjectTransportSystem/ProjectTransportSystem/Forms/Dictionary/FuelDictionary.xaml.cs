using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models.Database;

namespace ProjectTransportSystem.Forms.Dictionary
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FuelDictionary : Window
    {
        public FuelDictionary()
        {
            InitializeComponent();
            DataContext = new Fuel();
            //StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public FuelDictionary(Fuel obj)
        {
            InitializeComponent();
            DataContext = obj;
            //StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }
    }
}
