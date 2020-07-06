using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public class Open_Counts_Input
    {
        static public List<int> Counts_INPUT_ORG = new List<int>();
        static public int SUM_ORG = 0;
        static public List<int> Counts_INPUT_FILTR = new List<int>();
        static public int SUM_FILTR = 0;
        static public List<int> Counts_INPUT_MALF = new List<int>();
        static public int SUM_MALF = 0;
        static public List<int> Counts_INPUT_OUT = new List<int>();
        static public int SUM_OUT = 0;
        static public string My_File_Name = "";
        static public string[] My_File_Content;
        static public int SUM_HEADER = 0;
        static public int SUM_DROP = 0;


        public void OpenFile_Input(string path)
        {
            int Counts;

            Counts_INPUT_OUT.Clear();
            Counts_INPUT_ORG.Clear();
            Counts_INPUT_FILTR.Clear();
            Counts_INPUT_MALF.Clear();
            
            try
            {
                
                var name = Path.GetFileNameWithoutExtension(path);
                var fileContents = System.IO.File.ReadAllLines(path);

                My_File_Name = name;
                My_File_Content = fileContents;


                foreach (var s in fileContents)
                {
                    if (VALUES_FROM_CAFE.MEDIA_ID_LIST.Count > 0)
                    {
                        for (int i = 0; i < VALUES_FROM_CAFE.MEDIA_ID_LIST.Count; i++)
                        {

                            if (s.Contains(VALUES_FROM_CAFE.MEDIA_ID_LIST[i] + ".txt_filtered") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    Counts_INPUT_FILTR.Add(Counts);
                                }

                            }

                            if (s.Contains(VALUES_FROM_CAFE.MEDIA_ID_LIST[i] + ".txt_original") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))

                                {
                                    Counts_INPUT_ORG.Add(Counts);
                                }

                            }
                        }
                    }

                    if (VALUES_FROM_CAFE.Cafe != "")
                    {
                        if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.Contains("Encoding"))
                        {
                            var table = s.Split(':');
                            var input = table[1].Replace("Encoding", "").Trim();

                            if (Int32.TryParse(input, out Counts))
                            {
                                Counts_INPUT_OUT.Add(Counts);
                            }
                        }
                    }


                }

                SUM_FILTR = Counts_INPUT_FILTR.Sum();
                SUM_ORG = Counts_INPUT_ORG.Sum();
                SUM_OUT = Counts_INPUT_OUT.Sum();

                if (VALUES_FROM_CAFE.MEDIA_ID_LIST.Count == 0) MessageBox.Show("Please add MEDIA ID", "ADD MEDIA ID");

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
            Counts_INPUT_OUT.Clear();
            Counts_INPUT_ORG.Clear();
            Counts_INPUT_FILTR.Clear();
            Counts_INPUT_MALF.Clear();
            SUM_FILTR = 0;
            SUM_ORG = 0;
            SUM_OUT = 0;
            SUM_HEADER = 0;
            SUM_DROP = 0;
        }
    }
}

