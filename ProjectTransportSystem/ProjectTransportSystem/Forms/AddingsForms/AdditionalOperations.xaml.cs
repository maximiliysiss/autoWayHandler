using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections;
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

namespace ProjectTransportSystem.Forms.AddingsForms
{
    /// <summary>
    /// Interaction logic for AdditionalOperations.xaml
    /// </summary>
    public partial class AdditionalOperations : Window
    {
        public AdditionalOperations(WayBill wayBill, IEnumerable data)
        {
            InitializeComponent();
            var builder = DictionaryBuilder.GetDictionaryBuilder(DictionaryType.AdditionalOperations);
            builder.ActionsType = ActionsType.Add;
            Block.Children.Add(DictionaryList.InitDictionary(builder, data));
        }
    }
}
