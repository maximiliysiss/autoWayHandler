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
    /// Interaction logic for AdditionalOperationAdd.xaml
    /// </summary>
    public partial class AdditionalOperationAdd : Window
    {
        public AdditionalOperationAdd()
        {
            InitializeComponent();
            DataContext = new AdditionalOperation();
            StaticDictionaryActions.InitializeComponent(Action, new System.Action(this.Close));
        }

        public AdditionalOperationAdd(AdditionalOperation additional)
        {
            InitializeComponent();
            DataContext = additional;
            StaticDictionaryActions.InitializeComponent(Action, new System.Action(this.Close), true);
        }
    }
}
