using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models.Database;
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

namespace ProjectTransportSystem.Forms.Dictionary
{
    /// <summary>
    /// Interaction logic for DriverAccompanyingDictionary.xaml
    /// </summary>
    public partial class DriverAccompanyingDictionary : Window
    {
        public DriverAccompanyingDictionary()
        {
            InitializeComponent();
            DataContext = new DriverAccompanying();
            //StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public DriverAccompanyingDictionary(DriverAccompanying driverAccompanying)
        {
            InitializeComponent();
            DataContext = driverAccompanying;
            //StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }
    }
}
