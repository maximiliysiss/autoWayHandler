using ProjectTransportSystem.Extensions;
using ProjectTransportSystem.Forms.AddingsForms;
using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models.Database;
using System;
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
    /// Interaction logic for WayListForm.xaml
    /// </summary>
    public partial class WayListForm : Window
    {
        WayList wayList;


        public WayListForm()
        {
            InitializeComponent();
            wayList = new WayList();
            DataContext = wayList;
            Init();
        }

        private void Init()
        {
            DriversBlock.Children.Add(DictionaryList.GetDataGridRemovable("DriversGrid", wayList.DriverAccompanyings, (s, e) =>
            {
                var obj = (e.Source as MenuItem).DataContext as DriverAccompanying;
                wayList.DriverAccompanyings.Remove(obj);
                LoadingData();
            }, new Dictionary<DependencyProperty, object> { { Grid.RowProperty, 1 }, { DataGrid.IsReadOnlyProperty, true } }));

            CarsBlock.Children.Add(DictionaryList.GetDataGridRemovable("CarsGrid", wayList.TrailerCars, (s, e) =>
            {
                var obj = (e.Source as MenuItem).DataContext as TrailerCar;
                wayList.TrailerCars.Remove(obj);
                LoadingData();
            }, new Dictionary<DependencyProperty, object> { { Grid.RowProperty, 1 }, { DataGrid.IsReadOnlyProperty, true } }));

            LoadingData();
        }

        private void LoadingData()
        {
            DataContext = wayList;
            CarsBlock.FindVisualChildByName<DataGrid>("CarsGrid").ItemsSource = new ObservableCollection<TrailerCar>(wayList.TrailerCars);
            DriversBlock.FindVisualChildByName<DataGrid>("DriversGrid").ItemsSource = new ObservableCollection<DriverAccompanying>(wayList.DriverAccompanyings);
            TripName.Text = wayList.Trip.ToString();
            TripDist.Text = wayList.Trip.Distance.ToString();
            this.UpdateLayout();
        }

        public WayListForm(WayList wayList)
        {
            InitializeComponent();
            StaticDictionaryActions.InitializeComponent(null, null);
            DataContext = wayList;
            Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TrailerForm(wayList).ShowDialog();
            LoadingData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AccompaingForm(wayList).ShowDialog();
            LoadingData();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new TripForm(wayList).ShowDialog();
            LoadingData();
        }
    }
}
