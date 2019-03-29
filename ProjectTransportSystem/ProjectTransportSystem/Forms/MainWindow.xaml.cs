using Microsoft.Extensions.Logging;
using ProjectTransportSystem.Forms.FormGenerator;
using ProjectTransportSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

        BackgroundWorker backgroundWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                foreach (var item in Dictionary.Items.Cast<TabItem>())
                {
                    item.Dispatcher.Invoke(() =>
                    {
                        item.Content = DictionaryList.InitDictionary(DictionaryBuilder.GetDictionaryBuilder(item.Name),
                                        GlobalStaticContext.MainDbContext.GetContext(item.Name));
                    });
                }

                WayBills.Dispatcher.Invoke(() =>
                {
                    WayBills.Content = DictionaryList.InitDictionary(DictionaryBuilder.GetDictionaryBuilder(WayBills.Name),
                                                               GlobalStaticContext.MainDbContext.GetContext(WayBills.Name));
                });

                WayLists.Dispatcher.Invoke(() =>
                {
                    WayLists.Content = DictionaryList.InitDictionary(DictionaryBuilder.GetDictionaryBuilder(WayLists.Name),
                                                                GlobalStaticContext.MainDbContext.GetContext(WayLists.Name));
                });

                MainControl.Dispatcher.Invoke(() =>
                {
                    MainControl.IsEnabled = true;
                    Loading.Visibility = Visibility.Hidden;
                });
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Error, ex, ex.InnerException.Message);
            }
        }
    }
}
