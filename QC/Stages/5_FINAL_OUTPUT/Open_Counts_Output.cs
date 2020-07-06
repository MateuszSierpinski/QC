using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    class Open_Counts_Output
    {
            static public List<int> Counts_ADD = new List<int>();
            static public int SUM_ADD = 0;
            static public List<int> Counts_CSV = new List<int>();
            static public int SUM_CSV = 0;
            static public List<int> Counts_UNQ = new List<int>();
            static public int SUM_UNQ = 0;
            static public List<int> Counts_CSV_HEADER = new List<int>();
            static public int SUM_CSV_HEADER = 0;

            static public string My_File_Name = "";
            static public string[] My_File_Content;

            static public int SUM_ADD_CORRECTIONS = 0;
            static public int SUM_CSV_CORRECTIONS = 0;

        public void OpenFile_Out(string path)
        {
            int Counts;

            Counts_ADD.Clear();
            Counts_CSV.Clear();
            Counts_UNQ.Clear();
            Counts_CSV_HEADER.Clear();

            try
                {
                    var fileContents = System.IO.File.ReadAllLines(path);
                    var name = Path.GetFileNameWithoutExtension(path);

                    My_File_Name = name;
                    My_File_Content = fileContents;

                    foreach (var s in fileContents)
                    {
                        if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains(".add") && s.Contains("Encoding"))
                        {
                            var table = s.Split(':');
                            var input = table[1].Replace("Encoding", "").Trim();

                            if (Int32.TryParse(input, out Counts))
                            {
                                Counts_ADD.Add(Counts);
                            }
                        }

                        if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains(".csv") && s.Contains("Encoding"))
                        {
                            var table = s.Split(':');
                            var input = table[1].Replace("Encoding", "").Trim();

                            if (Int32.TryParse(input, out Counts))
                            {
                                Counts_CSV.Add(Counts);
                                SUM_CSV_HEADER += 1;
                            }
                        }
                        if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains(".unq") && s.Contains("Encoding"))
                        {
                            var table = s.Split(':');
                            var input = table[1].Replace("Encoding", "").Trim();

                            if (Int32.TryParse(input, out Counts))
                            {
                                Counts_UNQ.Add(Counts);
                            }
                        }

                    }

                    SUM_ADD = Counts_ADD.Sum();
                    SUM_CSV = Counts_CSV.Sum();
                    SUM_UNQ = Counts_UNQ.Sum();
                }


                catch
                {
                    MessageBox.Show("Is opened in another program");
                }

        }

        public void Clear()
        {
            My_File_Name = "";
            My_File_Content = null;
            Counts_ADD.Clear();
            Counts_CSV.Clear();
            Counts_UNQ.Clear();
            Counts_CSV_HEADER.Clear();
            SUM_ADD = 0;
            SUM_CSV = 0;
            SUM_UNQ = 0;
            SUM_CSV_HEADER = 0;
        }
    }
 }


