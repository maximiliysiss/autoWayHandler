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
    /// Interaction logic for WayListForm.xaml
    /// </summary>
    public partial class WayListForm : Window
    {
        public WayListForm()
        {
            InitializeComponent();
            DataContext = new WayList();
        }

        public WayListForm(WayList wayList)
        {
            InitializeComponent();
            StaticDictionaryActions.InitializeComponent(null, null);
            DataContext = wayList;
        }
    }
}
