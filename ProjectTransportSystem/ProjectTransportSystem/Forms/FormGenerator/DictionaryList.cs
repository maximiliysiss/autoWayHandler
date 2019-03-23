using ProjectTransportSystem.Forms.Dictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectTransportSystem.Forms.FormGenerator
{
    public enum DictionaryType
    {
        DistanceOnRoadGroups,
        DriverAccompanyings,
        Fuels,
        LegalEntities,
        Operations,
        Roles,
        ShippingKinds,
        CarTrailers,
        TransportTypes
    }

    public class DictionaryBuilder
    {
        public Dictionary<string, RoutedEventHandler> Actions { get; set; } = new Dictionary<string, RoutedEventHandler>();

        public static DictionaryBuilder GetDictionaryBuilder(string name)
        {
            return GetDictionaryBuilder((DictionaryType)Enum.Parse(typeof(DictionaryType), name));
        }

        public static DictionaryBuilder GetDictionaryBuilder(DictionaryType dictionaryType)
        {
            DictionaryBuilder dictionaryBuilder = new DictionaryBuilder();
            switch (dictionaryType)
            {
                case DictionaryType.DistanceOnRoadGroups:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new DistanceOnRoadGroupDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.DriverAccompanyings:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new DriverAccompanyingDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.Fuels:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new FuelDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.LegalEntities:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new LegalEntityDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.Operations:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new OperationDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.Roles:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new RoleDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.ShippingKinds:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new ShippingKindDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.CarTrailers:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new TrailerCarDictionary().ShowDialog(); } },
                    };
                    break;
                case DictionaryType.TransportTypes:
                    dictionaryBuilder.Actions = new Dictionary<string, RoutedEventHandler>{
                        { "Add", (x,e)=>{ new TransportTypeDictionary().ShowDialog(); } },
                    };
                    break;
            }
            return dictionaryBuilder;
        }
    }

    public class DictionaryList
    {
        public static void InitDictionary(TabItem tabItem, DictionaryBuilder actionAdd, IEnumerable data)
        {
            DockPanel dockPanel = new DockPanel
            {
                LastChildFill = true
            };
            Grid grid = new Grid();
            foreach (var action in actionAdd.Actions.Select((e, x) => new { Index = x, Value = e }))
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.SetValue(DockPanel.DockProperty, Dock.Bottom);
                Button button = new Button();
                button.SetValue(Grid.ColumnProperty, action.Index);
                button.Content = action.Value.Key;
                button.Click += action.Value.Value;
                grid.Children.Add(button);
            }
            dockPanel.Children.Add(grid);

            DataGrid dataGrid = new DataGrid();
            dataGrid.SetValue(DockPanel.DockProperty, Dock.Top);
            dataGrid.ItemsSource = data.Cast<object>().ToList();
            dockPanel.Children.Add(dataGrid);

            tabItem.Content = dockPanel;
        }
    }
}
