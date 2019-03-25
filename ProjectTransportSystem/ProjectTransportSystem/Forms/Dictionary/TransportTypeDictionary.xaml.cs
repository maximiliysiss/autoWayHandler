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
    /// Interaction logic for TransportType.xaml
    /// </summary>
    public partial class TransportTypeDictionary : Window
    {
        public TransportTypeDictionary()
        {
            InitializeComponent();
            DataContext = new TransportType();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public TransportTypeDictionary(TransportType obj)
        {
            InitializeComponent();
            DataContext = obj;
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
        }
    }
}
