using ProjectTransportSystem.Extensions;
using ProjectTransportSystem.Models;
using ProjectTransportSystem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTransportSystem.Forms.FormGenerator
{
    public class StaticDictionaryActions
    {
        public static void OnCreate(object sender, RoutedEventArgs routedEvent)
        {
            var obj = (sender as Button).DataContext;
            GlobalStaticContext.MainDbContext.Add(obj);
            GlobalStaticContext.MainDbContext.SaveChanges();
        }

        public static void OnEdit(object sender, RoutedEventArgs routedEvent)
        {
            var obj = (sender as Button).DataContext;
            GlobalStaticContext.MainDbContext.Update(obj);
            GlobalStaticContext.MainDbContext.SaveChanges();
        }

        private static void OnAddButton<T, D>(object sender, EventArgs e)
            where T : Window, new()
            where D : IDictionaryType, new()
        {
            var dictType = new D().DictionaryType.ToString();
            new T().ShowDialog();
            MainWindow window = (MainWindow)Window.GetWindow(sender as Button);
            DataGrid grid = window.FindVisualChildByName<DataGrid>($"{dictType}Dict");
            grid.ItemsSource = GlobalStaticContext.MainDbContext.GetContext(dictType).Cast<object>().ToList();
        }

        public static KeyValuePair<string, DictionaryAction> Add<T, D>()
            where T : Window, new()
            where D : IDictionaryType, new()
        {
            return new KeyValuePair<string, DictionaryAction>(Resources.Add, new DictionaryAction
            {
                EventHandler = OnAddButton<T, D>
            });
        }

        private static void OnOpenRow<W, T>(object sender, EventArgs e)
            where W : IDictionaryFormBuilder<T>, new()
            where T : class
        {
            var obj = ((e as MouseButtonEventArgs).Source as DataGridRow).DataContext;
            new W().GetWindow((T)obj).ShowDialog();
        }

        public static KeyValuePair<string, DictionaryAction> Open<W, T>()
            where W : IDictionaryFormBuilder<T>, new()
            where T : class
        {
            return new KeyValuePair<string, DictionaryAction>("Open", new DictionaryAction
            {
                EventHandler = OnOpenRow<W, T>,
                IsShow = false
            });
        }

        public static void InitializeComponent(Button action, Action closeEvent, bool isEdit = false)
        {
            if (action == null)
                return;
            action.Content = isEdit ? Resources.Edit : Resources.Create;
            if (isEdit)
                action.Click += OnEdit;
            else
                action.Click += OnCreate;
            action.Click += (o, e) => closeEvent();
        }

        public static void DeleteDictionary(object sender, RoutedEventArgs e)
        {
            GlobalStaticContext.MainDbContext.Remove((e.Source as MenuItem).DataContext);
            GlobalStaticContext.MainDbContext.SaveChanges();
        }
    }
}
