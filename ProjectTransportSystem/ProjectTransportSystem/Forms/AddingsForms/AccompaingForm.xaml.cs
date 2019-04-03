using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
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

namespace ProjectTransportSystem.Forms.AddingsForms
{
    /// <summary>
    /// Interaction logic for AccompaingForm.xaml
    /// </summary>
    public partial class AccompaingForm : Window
    {

        public AccompaingForm(WayList wayList)
        {
            InitializeComponent();
            var formBuilder = DictionaryBuilder.GetDictionaryBuilder(DictionaryType.DriverAccompanyings);
            formBuilder.ActionsType = ActionsType.Select;
            formBuilder.Actions.Add(new KeyValuePair<string, DictionaryAction>("select", new DictionaryAction
            {
                IsShow = false,
                EventHandler = ((s, e) =>
                {
                    if (((e as MouseButtonEventArgs).Source as DataGridRow).DataContext is DriverAccompanying cars)
                        wayList.DriverAccompanyings.Add(cars);
                    GetWindow(s as DependencyObject).Close();
                })
            }));
            Block.Children.Add(DictionaryList.InitDictionary(formBuilder,
                        GlobalStaticContext.MainDbContext.DriverAccompanyings));
        }
    }
}
