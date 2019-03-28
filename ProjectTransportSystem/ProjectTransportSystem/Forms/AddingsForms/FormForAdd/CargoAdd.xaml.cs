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

namespace ProjectTransportSystem.Forms.AddingsForms.FormForAdd
{
    /// <summary>
    /// Interaction logic for CargoAdd.xaml
    /// </summary>
    public partial class CargoAdd : Window
    {
        public CargoAdd()
        {
            InitializeComponent();
            DataContext = new Cargo()
        }

        public CargoAdd(Cargo cargo)
        {
            InitializeComponent();
            DataContext = cargo;
        }
    }
}
