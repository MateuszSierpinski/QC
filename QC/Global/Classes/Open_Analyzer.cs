using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QC
{
    class Open_Analyzer
    {
        public DataTable OpenFile(DataTable table, string path)
        {

            try
            {
                var fileContents = System.IO.File.ReadAllLines(path);
                var splitFileContents = (from f in fileContents select f.Split('\t')).ToArray();
                int maxLength = (from s in splitFileContents select s.Count()).Max();
                for (int i = 0; i < maxLength; i++)
                {
                    try
                    {
                        table.Columns.Add(splitFileContents[0][i].ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Costam costam");
                    }
                }
                foreach (var line in splitFileContents)
                {
                    DataRow row = table.NewRow();
                    try
                    {
                        Application.DoEvents();
                        row.ItemArray = (object[])line;
                        table.Rows.Add(row);
                    }
                    catch
                    {
                        Console.WriteLine("Exception");
                    }
                }


                table.Rows.Remove(table.Rows[0]);

            }
            catch
            {
                MessageBox.Show("Costam costam");
            }

            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                table.Rows[i][6] = table.Rows[i][6].ToString().Replace(".", "").Insert(3, ".").TrimStart('0');
                if (table.Rows[i][6].ToString().Length == 3)
                {
                    table.Rows[i][6] = table.Rows[i][6].ToString().Insert(0, "0") + " %";
                }
                else
                {
                    table.Rows[i][6] = table.Rows[i][6].ToString() + " %";
                }
            }

            return table;

        }
    }
}
