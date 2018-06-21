using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace ProjectAutoSupplying
{
    interface IExcelConstractor<T>
    {
        string[] getColumnNames();
        string[] SerializeToString(T element);
    }

    class ExcelCreator<T>
    {

        public DataTable ToTable(List<T> list, IExcelConstractor<T> excelCreator)
        {
            string[] columnName = excelCreator.getColumnNames();
            DataTable dataTable = new DataTable();
            int columns = columnName.Length;
            for (int i = 0; i < columns; i++)
                dataTable.Columns.Add(columnName[i]);
            foreach (var obj in list)
                dataTable.Rows.Add(excelCreator.SerializeToString(obj));
            return dataTable;
        }

        public void EntityToExcelSheet(string excelFilePath, string sheetName, List<T> list, IExcelConstractor<T> excelConstractor)
        {
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRange;
            try
            {
                // Start Excel and get Application object.
                oXL = new Excel.Application();

                // Set some properties
                oXL.Visible = true;
                oXL.DisplayAlerts = false;

                // Get a new workbook. 
                oWB = oXL.Workbooks.Add(Missing.Value);

                // Get the active sheet 
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = sheetName;

                DataTable dt = ToTable(list, excelConstractor);

                int rowCount = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        if (rowCount == 2)
                            oSheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }

                // Resize the columns 
                oRange = oSheet.Range[oSheet.Cells[1, 1], oSheet.Cells[rowCount, dt.Columns.Count]];
                oRange.Columns.AutoFit();

                // Save the sheet and close 
                oSheet = null;
                oRange = null;
                oWB.SaveAs(excelFilePath, Excel.XlFileFormat.xlWorkbookNormal, Missing.Value,
                  Missing.Value, Missing.Value, Missing.Value,
                  Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value,
                  Missing.Value, Missing.Value, Missing.Value);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                oWB = null;
                oXL.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
