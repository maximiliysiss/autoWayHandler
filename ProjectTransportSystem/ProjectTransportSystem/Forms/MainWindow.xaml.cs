using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTransportSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var dict in Dictionary.Items.Cast<TabItem>())
                try
                {
                    DictionaryList.InitDictionary(dict, DictionaryBuilder.GetDictionaryBuilder(dict.Name),
                        GlobalStaticContext.MainDbContext.GetContext(dict.Name));
                }
                catch (Exception ex)
                {

                }
        }
    }
}
