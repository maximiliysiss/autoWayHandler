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

        public static DataGrid GetDataGridRemovable(string name, IEnumerable data, RoutedEventHandler routedEvent,
            Dictionary<DependencyProperty, object> properties)
        {
            DataGrid dataGrid = new DataGrid();
            foreach (var prop in properties)
                dataGrid.SetValue(prop.Key, prop.Value);
            if (data != null)
                dataGrid.ItemsSource = new ObservableCollection<object>(data.Cast<object>().ToList());
            dataGrid.IsReadOnly = true;
            dataGrid.Name = name;
            dataGrid.LoadingRow += (s, e) =>
            {
                var contextMenu = new ContextMenu();
                var menuItem = new MenuItem { Header = "Delete", Name = $"{name}Delete" };
                menuItem.Click += routedEvent;
                contextMenu.Items.Add(menuItem);
                e.Row.ContextMenu = contextMenu;
            };
            return dataGrid;
        }

        public static DataGrid GetDataGridSelectable(string name, IEnumerable data, Dictionary<DependencyProperty, object> properties,
            MouseButtonEventHandler reaction)
        {
            DataGrid dataGrid = new DataGrid();
            foreach (var prop in properties)
                dataGrid.SetValue(prop.Key, prop.Value);
            dataGrid.ItemsSource = new ObservableCollection<object>(data.Cast<object>().ToList());
            dataGrid.IsReadOnly = true;
            dataGrid.Name = name;
            dataGrid.LoadingRow += (s, e) =>
            {
                e.Row.MouseDoubleClick += reaction;
            };
            return dataGrid;
        }

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
            var dataGrid = GetDataGridRemovable($"{actionAdd.DictionaryType.ToString()}Dict", data, StaticDictionaryActions.DeleteDictionary,
                new Dictionary<DependencyProperty, object> { { DockPanel.DockProperty, Dock.Top } });
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
