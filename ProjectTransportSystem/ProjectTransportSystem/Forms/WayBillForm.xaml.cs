using ProjectTransportSystem.Extensions;
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
            Init(wayBill);
            LoadingWayBill(wayBill);
        }

        public WayBillForm(WayBill wayBill)
        {
            InitializeComponent();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
            DataContext = wayBill;
            Init(wayBill);
            LoadingWayBill(wayBill);
        }

        private void Init(WayBill wayBill)
        {
            CargoBlock.Children.Add(DictionaryList.GetDataGridRemovable("CargoGrid", wayBill.Cargos, (s, e) =>
            {
                var obj = (e.Source as MenuItem).DataContext as Cargo;
                wayBill.Cargos.Remove(obj);
                LoadingWayBill(wayBill);
            }, new Dictionary<DependencyProperty, object> { { Grid.RowProperty, 1 }, { DataGrid.IsReadOnlyProperty, true } }));
        }

        private void LoadingWayBill(WayBill wayBill)
        {
            DataGrid dataGrid = CargoBlock.FindVisualChildByName<DataGrid>("CargoGrid");
            dataGrid.ItemsSource = new ObservableCollection<Cargo>(wayBill.Cargos);
        }

        private void AddCargo(object sender, RoutedEventArgs e)
        {
            new CargoForm(DataContext as WayBill).ShowDialog();
            LoadingWayBill(DataContext as WayBill);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalOperations(DataContext as WayBill, (DataContext as WayBill).Loading.AdditionalOperations)
                .ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AdditionalOperations(DataContext as WayBill, (DataContext as WayBill).Uploading.AdditionalOperations)
                .ShowDialog();
        }
    }
}
