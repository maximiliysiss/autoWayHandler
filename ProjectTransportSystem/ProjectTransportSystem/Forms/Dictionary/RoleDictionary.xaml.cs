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

namespace ProjectTransportSystem.Forms.Dictionary
{
    /// <summary>
    /// Interaction logic for RoleDictionary.xaml
    /// </summary>
    public partial class RoleDictionary : Window
    {
        public RoleDictionary()
        {
            InitializeComponent();
            this.DataContext = new Role();
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()));
        }

        public RoleDictionary(Role role)
        {
            InitializeComponent();
            this.DataContext = role;
            StaticDictionaryActions.InitializeComponent(Action, new Action(() => Close()), true);
        }
    }
}
