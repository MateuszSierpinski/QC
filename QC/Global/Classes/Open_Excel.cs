using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System;

namespace QC
{

    public class Open_Excel
    {
        public DataSet Import(string filename, bool headers = true)
        {
            var _xl = new Microsoft.Office.Interop.Excel.Application();
            var wb = _xl.Workbooks.Open(filename);
            var sheets = wb.Sheets;
            DataSet dataSet = null;
            if (sheets != null && sheets.Count != 0)
            {
                dataSet = new DataSet();
                foreach (var item in sheets)
                {
                    var sheet = (Microsoft.Office.Interop.Excel.Worksheet)item;
                    System.Data.DataTable dt = null;
                    if (sheet != null)
                    {
                        dt = new System.Data.DataTable();
                        var ColumnCount = ((Microsoft.Office.Interop.Excel.Range)sheet.UsedRange.Rows[1, Type.Missing]).Columns.Count;
                        var rowCount = ((Microsoft.Office.Interop.Excel.Range)sheet.UsedRange.Columns[1, Type.Missing]).Rows.Count;

                        for (int j = 0; j < ColumnCount; j++)
                        {
                            var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, j + 1];
                            var column = new DataColumn(headers ? cell.Value : string.Empty);
                            dt.Columns.Add(column);
                        }

                        for (int i = 0; i < rowCount; i++)
                        {
                            var r = dt.NewRow();
                            for (int j = 0; j < ColumnCount; j++)
                            {
                                var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[i + 1 + (headers ? 1 : 0), j + 1];
                                r[j] = cell.Value;
                            }
                            dt.Rows.Add(r);
                        }

                    }
                    dataSet.Tables.Add(dt);
                }
            }
            _xl.Quit();
            return dataSet;
        }
    }
}

