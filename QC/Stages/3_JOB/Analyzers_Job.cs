using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC
{
    public class Analyzers_Job
    {
        DataTable A_table = new DataTable();

        static public List<string> Name_List = new List<string>();
        static public List<DataTable> Analyzers_List = new List<DataTable>();

        static public double ZIP = 0.00;
        static public double ZIP4 = 0.00;
        static public double DPBC = 0.00;

        public void My_Analyzers(string path)
        {
            Open_Analyzer oa = new Open_Analyzer();

            var name = Path.GetFileNameWithoutExtension(path);
            oa.OpenFile(A_table, path);

            if (!Name_List.Contains(name))
            {
                Name_List.Add(name);
                A_table.TableName = name;
                Analyzers_List.Add(A_table);
            }

            if (Path.GetFileNameWithoutExtension(path).Contains(VALUES_FROM_CAFE.Cafe)
                 && Path.GetFileNameWithoutExtension(path).ToUpper().Contains("PRE"))
            {
                ZIP = Convert.ToDouble(A_table.Rows[2][6].ToString().Replace("%",""));
                ZIP4 = Convert.ToDouble(A_table.Rows[4][6].ToString().Replace("%", ""));
                DPBC = Convert.ToDouble(A_table.Rows[5][6].ToString().Replace("%", ""));
            }


        }

    }
}

