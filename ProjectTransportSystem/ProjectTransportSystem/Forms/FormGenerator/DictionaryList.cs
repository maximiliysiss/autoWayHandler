using ProjectTransportSystem.Extensions;
using ProjectTransportSystem.Forms.Dictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ProjectTransportSystem.Forms.FormGenerator
{

    public class DictionaryList
    {
        public static DockPanel InitDictionary(DictionaryBuilder actionAdd, IEnumerable data)
        {
            DockPanel dockPanel = new DockPanel
            {
                LastChildFill = true
            };
            Grid grid = new Grid();
            foreach (var action in actionAdd.Actions.Where(x => x.Value.IsShow).Select((e, x) => new { Index = x, Value = e }))
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.SetValue(DockPanel.DockProperty, Dock.Bottom);
                Button button = new Button();
                button.SetValue(Grid.ColumnProperty, action.Index);
                button.Content = action.Value.Key;
                button.Click += new RoutedEventHandler(action.Value.Value.EventHandler);
                grid.Children.Add(button);
            }
            dockPanel.Children.Add(grid);

            DataGrid dataGrid = new DataGrid();
            dataGrid.SetValue(DockPanel.DockProperty, Dock.Top);
            dataGrid.ItemsSource = new ObservableCollection<object>(data.Cast<object>().ToList());
            dataGrid.IsReadOnly = true;
            dataGrid.Name = $"{actionAdd.DictionaryType.ToString()}Dict";
            dockPanel.Children.Add(dataGrid);

            dataGrid.LoadingRow += (s, e) =>
            {
                var action = actionAdd.Actions.FirstOrDefault(x => x.Key.ToLower() == "open");
                if (action.Value != null)
                {
                    e.Row.MouseDoubleClick -= new MouseButtonEventHandler(action.Value.EventHandler);
                    e.Row.MouseDoubleClick += new MouseButtonEventHandler(action.Value.EventHandler);
                }
            };

            return dockPanel;
        }
    }
}
