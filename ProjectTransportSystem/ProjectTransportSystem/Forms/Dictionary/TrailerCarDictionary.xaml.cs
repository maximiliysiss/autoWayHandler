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
using ProjectTransportSystem.Models.Database;

namespace ProjectTransportSystem.Forms.Dictionary
{
    /// <summary>
    /// Interaction logic for TrailerCar.xaml
    /// </summary>
    public partial class TrailerCarDictionary : Window
    {
        public TrailerCarDictionary()
        {
            InitializeComponent();
            DataContext = new TrailerCar();
        }

        public TrailerCarDictionary(TrailerCar obj)
        {
            InitializeComponent();
            DataContext = obj;
        }
    }
}
