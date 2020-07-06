using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC
{
    class Open_Tally_Out
    {
        static public List<DataTable> Tallies = new List<DataTable>();
        static public List<string> Tallies_Names = new List<string>();

        public void Open_Tally(string path)
        {
            DataTable Tally = new DataTable();
            string Tally_Name;

            Tally_Name = Path.GetFileNameWithoutExtension(path);
            Open_Tally op = new Open_Tally();

            op.OpenFile(Tally, path);

            Tallies_Names.Add(Tally_Name);

            Tally.TableName = Tally_Name;
            Tallies.Add(Tally);
            
        }
    }
}
