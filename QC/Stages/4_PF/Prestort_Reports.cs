using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public class Prestort_Reports
    {
        static public List<int> Counts_TOTAL = new List<int>();
        static public int SUM_TOTAL = 0;

        static public List<int> Counts_INVALID = new List<int>();
        static public int SUM_INVALID = 0;

        static public List<int> Counts_AUTOMATION = new List<int>();
        static public int SUM_AUTOMATION = 0;

        static public List<int> Counts_AUTOMATION_CAR = new List<int>();
        static public int SUM_AUTOMATION_CAR = 0;

        static public List<int> Counts_NON_AUTOMATION = new List<int>();
        static public int SUM_NON_AUTOMATION = 0;

        static public List<string> My_File_Names = new List<string>();
        static public List<string[]> My_File_Contents = new List<string[]>();

        public void Open_Report(string path)
        {
            int Counts;

            try
            {
                var fileContents = System.IO.File.ReadAllLines(path);

                My_File_Names.Add(Path.GetFileNameWithoutExtension(path));
                My_File_Contents.Add(fileContents);


                foreach (var s in fileContents)
                {


                    if (s.Contains("Total Records:"))
                    {
                        var table = s.Split(':');
                        var input = table[1].Replace(",", "").Trim();

                        if (Int32.TryParse(input, out Counts))
                        {
                            Counts_TOTAL.Add(Counts);
                        }
                    }

                    if (s.Contains("Total Invalid Records:"))
                    {
                        var table = s.Split(':');
                        var input = table[1].Replace(",", "").Trim();

                        if (Int32.TryParse(input, out Counts))
                        {
                            Counts_INVALID.Add(Counts);
                        }
                    }

                    if (s.Contains("Enh. Car. Rt. Total:"))
                    {
                        var table = s.Split(':');
                        var input = table[1].Trim();

                        if (Int32.TryParse(input, out Counts))
                        {
                            Counts_AUTOMATION_CAR.Add(Counts);
                        }
                    }

                    if (!s.Contains("Non-Automation Total:") && s.Contains("Automation Total:"))
                    {
                        var table = s.Split(':');
                        var input = table[1].Trim();

                        if (Int32.TryParse(input, out Counts))
                        {
                            Counts_AUTOMATION.Add(Counts);
                        }
                    }

                    if (s.Contains("Non-Automation Total:"))
                    {
                        var table = s.Split(':');
                        var input = table[1].Trim();

                        if (Int32.TryParse(input, out Counts))
                        {
                            Counts_NON_AUTOMATION.Add(Counts);
                        }
                    }
                }

                if (!Counts_AUTOMATION_CAR.Any()) Counts_AUTOMATION_CAR.Add(0);
                if (!Counts_AUTOMATION.Any()) Counts_AUTOMATION.Add(0);
                if (!Counts_NON_AUTOMATION.Any()) Counts_NON_AUTOMATION.Add(0);

                SUM_TOTAL = Counts_TOTAL.Sum();
                SUM_INVALID = Counts_INVALID.Sum();
                SUM_AUTOMATION = Counts_AUTOMATION.Sum();
                SUM_NON_AUTOMATION = Counts_NON_AUTOMATION.Sum();
                SUM_AUTOMATION_CAR = Counts_AUTOMATION_CAR.Sum();
            }

            catch
            {
                MessageBox.Show("Is opened in another program");
            }
        }

        public void Refresh(int index)
        {
            Counts_TOTAL.RemoveAt(index);
            Counts_INVALID.RemoveAt(index);
            Counts_AUTOMATION.RemoveAt(index);
            Counts_NON_AUTOMATION.RemoveAt(index);
            Counts_AUTOMATION_CAR.RemoveAt(index);
            My_File_Names.RemoveAt(index);
            My_File_Contents.RemoveAt(index);

            SUM_TOTAL = Counts_TOTAL.Sum();
            SUM_INVALID = Counts_INVALID.Sum();
            SUM_AUTOMATION = Counts_AUTOMATION.Sum();
            SUM_NON_AUTOMATION = Counts_NON_AUTOMATION.Sum();
            SUM_AUTOMATION_CAR = Counts_AUTOMATION_CAR.Sum();
        }
    }
}

