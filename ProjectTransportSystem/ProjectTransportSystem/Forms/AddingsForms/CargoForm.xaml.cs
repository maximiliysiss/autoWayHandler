﻿using ProjectTransportSystem.Forms.FormGenerator;
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
    /// Interaction logic for CargoForm.xaml
    /// </summary>
    public partial class CargoForm : Window
    {
        public CargoForm(WayBill wayBill)
        {
            InitializeComponent();
            var formBuilder = DictionaryBuilder.GetDictionaryBuilder("Cargoes");
            formBuilder.ActionsType = ActionsType.Select;
            formBuilder.Actions.Add(new KeyValuePair<string, DictionaryAction>("select", new DictionaryAction
            {
                IsShow = false,
                EventHandler = ((s, e) =>
                {
                    if (((e as MouseButtonEventArgs).Source as DataGridRow).DataContext is Cargo cargo)
                        wayBill.Cargos.Add(cargo);
                    GetWindow(s as DependencyObject).Close();
                })
            }));
            CargoListGrid.Children.Add(DictionaryList.InitDictionary(formBuilder,
            GlobalStaticContext.MainDbContext.Cargoes));
        }
    }
}
