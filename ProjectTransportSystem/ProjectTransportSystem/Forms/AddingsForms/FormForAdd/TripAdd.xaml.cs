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

namespace ProjectTransportSystem.Forms.AddingsForms.FormForAdd
{
    /// <summary>
    /// Interaction logic for TripAdd.xaml
    /// </summary>
    public partial class TripAdd : Window
    {
        public TripAdd()
        {
            InitializeComponent();
            DataContext = new Trip();
            StaticDictionaryActions.InitializeComponent(Action, new System.Action(this.Close));
        }

        public TripAdd(Trip trip)
        {
            InitializeComponent();
            DataContext = trip;
            StaticDictionaryActions.InitializeComponent(Action, new Action(this.Close));
        }
    }
}
