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
    /// Interaction logic for ShippingKind.xaml
    /// </summary>
    public partial class ShippingKindDictionary : Window
    {
        public ShippingKindDictionary()
        {
            InitializeComponent();
            DataContext = new ShippingKind();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public ShippingKindDictionary(ShippingKind obj)
        {
            InitializeComponent();
            DataContext = obj;
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
        }
    }
}
