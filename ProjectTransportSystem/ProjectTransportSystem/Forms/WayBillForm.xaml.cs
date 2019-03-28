using ProjectTransportSystem.Forms.AddingsForms;
using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var wayBill = new WayBill();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
            DataContext = wayBill;
            InitWayBill(wayBill);
        }

        public WayBillForm(WayBill wayBill)
        {
            InitializeComponent();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
            DataContext = wayBill;
            InitWayBill(wayBill);
        }

        private void InitWayBill(WayBill wayBill)
        {
        }

        private void AddCargo(object sender, RoutedEventArgs e)
        {
            new ContractForm(DataContext as WayBill).ShowDialog();
        }
    }
}
