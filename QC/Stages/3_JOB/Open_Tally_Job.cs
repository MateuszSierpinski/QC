using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC
{
    class Open_Tally_Job
    {
        static public List<DataTable> Tallies = new List <DataTable>();
        static public List<string> Tallies_Names = new List<string>();

        static public List<DataTable> Excels = new List<DataTable>();
        static public List<string> Excels_Names = new List<string>();

        public void Open_Tally(string path)
        {
            DataTable Tally = new DataTable();
            string Tally_Name;

            Tally_Name = Path.GetFileNameWithoutExtension(path);
            Open_Tally op = new Open_Tally();

            op.OpenFile(Tally, path);

            Tallies.Add(Tally);
            Tally.TableName = Tally_Name;
            Tallies_Names.Add(Tally_Name);
        }

        public void Open_Excel(string path)
        {
            DataSet Excel = new DataSet();
            string Excel_Name;

            Open_Excel oe = new Open_Excel();
            Excel = oe.Import(path, true);

            Excel_Name = Path.GetFileNameWithoutExtension(path);

            foreach (DataTable table in Excel.Tables)
            {
                Excels.Add(table);
                table.TableName = Excel_Name + "[" + table.TableName + "]";
                Excels_Names.Add(Excel_Name + "[" +table.TableName + "]");
            }
        }
    }
}
