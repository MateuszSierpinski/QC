using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC
{
    class Analyzers_Out
    {
        DataTable A_table = new DataTable();

        static public List<string> Name_List = new List<string>();
        static public List<DataTable> Analyzers_List = new List<DataTable>();

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
        }
    }
}