using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectTransportSystem.Extensions
{
    public static class DataGridExtensions
    {
        public static IEnumerable<DataGridRow> GetDataGridRows(this DataGrid grid)
        {
            if (null == grid.ItemsSource as IEnumerable) yield return null;
            foreach (var item in grid.ItemsSource as IEnumerable)
                if (grid.ItemContainerGenerator.ContainerFromItem(item) is DataGridRow row)
                    yield return row;
        }
    }
}
