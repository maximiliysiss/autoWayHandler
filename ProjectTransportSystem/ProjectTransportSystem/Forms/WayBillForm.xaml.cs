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

namespace ProjectTransportSystem.Forms
{
    /// <summary>
    /// Interaction logic for WayBill.xaml
    /// </summary>
    public partial class WayBillForm : Window
    {
        public WayBillForm()
        {
            InitializeComponent();
            DataContext = new WayBill();
        }

        public WayBillForm(WayBill wayBill)
        {
            InitializeComponent();
            StaticDictionaryActions.InitializeComponent(null, new Action(() => Close()));
            DataContext = wayBill;
        }
    }
}
