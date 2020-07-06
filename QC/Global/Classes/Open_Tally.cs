using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QC
{
    class Open_Tally
    {
        public DataTable OpenFile(DataTable table, string path)
        {
            table.Columns.Clear();
            try
            {
                table.Clear();
                var fileContents = System.IO.File.ReadAllLines(path);               
                var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
                int maxLength = (from s in splitFileContents select s.Count()).Max();
                for (int i = 0; i < maxLength; i++)
                {
                    try
                    {
                        
                        table.Columns.Add(splitFileContents[0][i].ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Blad1");
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
                MessageBox.Show("Blad2");
            }


            return table;

        }
    }
}
