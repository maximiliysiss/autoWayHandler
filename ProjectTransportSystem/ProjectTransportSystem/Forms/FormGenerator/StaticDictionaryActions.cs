using Microsoft.Extensions.Logging;
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
            try
            {
                var obj = (sender as Button).DataContext;
                GlobalStaticContext.Logger.Log(LogLevel.Information, $"On Create - {obj}");
                GlobalStaticContext.MainDbContext.Add(obj);
                GlobalStaticContext.MainDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Error, ex, ex.InnerException.Message);
            }
        }

        public static void OnEdit(object sender, RoutedEventArgs routedEvent)
        {
            try
            {
                var obj = (sender as Button).DataContext;
                GlobalStaticContext.Logger.Log(LogLevel.Information, $"On Edit - {obj}");
                GlobalStaticContext.MainDbContext.Update(obj);
                GlobalStaticContext.MainDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Error, ex, ex.InnerException.Message);
            }
        }

        private static void OnAddButton<T, D>(object sender, EventArgs e)
            where T : Window, new()
            where D : IDictionaryType, new()
        {
            var dictType = new D().DictionaryType.ToString();
            new T().ShowDialog();
            try
            {
                GlobalStaticContext.Logger.Log(LogLevel.Information, $"On Add - {dictType}");
                var window = Window.GetWindow(sender as Button);
                DataGrid grid = window.FindVisualChildByName<DataGrid>($"{dictType}Dict");
                grid.ItemsSource = GlobalStaticContext.MainDbContext.GetContext(dictType).Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Error, ex, ex.InnerException.Message);
            }
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
            GlobalStaticContext.Logger.Log(LogLevel.Information, $"On Open Row - {obj}");
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
            try
            {
                var obj = (e.Source as MenuItem).DataContext;
                GlobalStaticContext.MainDbContext.Remove(obj);
                GlobalStaticContext.MainDbContext.SaveChanges();
                GlobalStaticContext.Logger.Log(LogLevel.Information, $"On Delete - {obj}");
                MainWindow window = (MainWindow)Window.GetWindow(sender as MenuItem);
                var name = (sender as MenuItem).Name;
                name = name.Substring(0, name.IndexOf("Delete"));
                DataGrid grid = window.FindVisualChildByName<DataGrid>(name);
                grid.ItemsSource = GlobalStaticContext.MainDbContext.GetContext(name.Substring(0, name.IndexOf("Dict")))
                    .Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Error, ex, ex.InnerException.Message);
            }
        }
    }
}
