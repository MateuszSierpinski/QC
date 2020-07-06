using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    class Open_Counts_Job
    {

        void Remove(List<int> List_1, List<int> List_2)
        {
            for (int i = 0; i < List_1.Count; i++)
            {
                for (int j = 0; j < List_2.Count; j++)
                {
                    if (List_1[i] == List_2[j])
                    {
                        List_2.RemoveAt(j);
                    }
                }
            }
        }

        static public List<int> Counts_NCOA_PRE = new List<int>();
        static public int SUM_NCOA_PRE = 0;
        static public List<int> Counts_VARIABLE = new List<int>();
        static public int SUM_VARIABLE = 0;
        static public List<int> Counts_PRE = new List<int>();
        static public int SUM_PRE = 0;
        static public List<int> Counts_PRE_DSF = new List<int>();
        static public int SUM_PRE_DSF = 0;
        static public List<int> Counts_DROP = new List<int>();
        static public int SUM_DROP_FROM_COUNTS = 0;
        static public List<int> Counts_MP = new List<int>();
        static public int SUM_MP = 0;

        static public List<string> My_File_Names = new List<string>();
        static public List<string[]> My_File_Contents = new List<string[]>();

        static public List<List<int>> List_Of_Counts_List_NCOA_PRE = new List<List<int>>();
        static public List<List<int>> List_Of_Counts_List_Variable = new List<List<int>>();
        static public List<List<int>> List_Of_Counts_List_PRE = new List<List<int>>();
        static public List<List<int>> List_Of_Counts_List_DSF = new List<List<int>>();
        static public List<List<int>> List_Of_Counts_List_DROP_FROM_COUNTS = new List<List<int>>();
        static public List<List<int>> List_Of_Counts_List_MP = new List<List<int>>();

        static public int SUM_SEEDS = 0;
        static public int SUM_DROP = 0;
        static public int SUM_FOREIGN = 0;


        public void OpenFile_Job(string path)
        {

            int Counts;

            List<int> List_Of_Counts_NCOA_PRE = new List<int>();
            List<int> List_Of_Counts_Variable = new List<int>();
            List<int> List_Of_Counts_PRE = new List<int>();
            List<int> List_Of_Counts_DSF = new List<int>();
            List<int> List_Of_Counts_DROP_FROM_COUNTS = new List<int>();
            List<int> List_Of_Counts_MP = new List<int>();

            try
            {
                var fileContents = System.IO.File.ReadAllLines(path);
                var name = Path.GetFileNameWithoutExtension(path);

                if (!My_File_Names.Contains(name))
                {
                    My_File_Names.Add(name);
                    My_File_Contents.Add(fileContents);


                    foreach (var s in fileContents)
                    {

                        if (VALUES_FROM_CAFE.Cafe != "")
                        {
                            if (s.Contains(VALUES_FROM_CAFE.Cafe + ".ncoa") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_NCOA_PRE.Contains(Counts))
                                    {
                                        Counts_NCOA_PRE.Add(Counts);
                                        List_Of_Counts_NCOA_PRE.Add(Counts);
                                    }
                                }
                            }

                            if (s.Contains(VALUES_FROM_CAFE.Cafe + "_Variable.txt") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_VARIABLE.Contains(Counts))
                                    {
                                        Counts_VARIABLE.Add(Counts);
                                        List_Of_Counts_Variable.Add(Counts);
                                    }
                                }
                            }

                            if (s.Contains(VALUES_FROM_CAFE.Cafe + ".pre") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_PRE.Contains(Counts))
                                    {
                                        Counts_PRE.Add(Counts);
                                        List_Of_Counts_PRE.Add(Counts);
                                    }
                                }
                            }

                            if (s.Contains(VALUES_FROM_CAFE.Cafe + ".dsf") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_PRE_DSF.Contains(Counts))
                                    {
                                        Counts_PRE_DSF.Add(Counts);
                                        List_Of_Counts_DSF.Add(Counts);
                                    }
                                }
                            }

                            if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains("drop") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_DROP.Contains(Counts))
                                    {
                                        Counts_DROP.Add(Counts);
                                        List_Of_Counts_DROP_FROM_COUNTS.Add(Counts);
                                    }
                                }
                            }

                            if (s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains(".mp") && s.Contains("Encoding")
                                || s.Contains(VALUES_FROM_CAFE.Cafe) && s.ToLower().Contains(".to_mp") && s.Contains("Encoding"))
                            {
                                var table = s.Split(':');
                                var input = table[1].Replace("Encoding", "").Trim();

                                if (Int32.TryParse(input, out Counts))
                                {
                                    if (!Counts_MP.Contains(Counts))
                                    {
                                        Counts_MP.Add(Counts);
                                        List_Of_Counts_MP.Add(Counts);
                                    }
                                }
                            }
                        }
                    }

                    SUM_NCOA_PRE = Counts_NCOA_PRE.Sum();
                    SUM_VARIABLE = Counts_VARIABLE.Sum();
                    SUM_PRE = Counts_PRE.Sum();
                    SUM_PRE_DSF = Counts_PRE_DSF.Sum();
                    SUM_DROP_FROM_COUNTS = Counts_DROP.Sum();
                    SUM_MP = Counts_MP.Sum();

                    List_Of_Counts_List_NCOA_PRE.Add(List_Of_Counts_NCOA_PRE);
                    List_Of_Counts_List_Variable.Add(List_Of_Counts_Variable);
                    List_Of_Counts_List_PRE.Add(List_Of_Counts_PRE);
                    List_Of_Counts_List_DSF.Add(List_Of_Counts_DSF);
                    List_Of_Counts_List_DROP_FROM_COUNTS.Add(List_Of_Counts_DROP_FROM_COUNTS);
                    List_Of_Counts_List_MP.Add(List_Of_Counts_MP);

                }
            }
            catch
            {
                MessageBox.Show("Is opened in another program");
            }
        }

        public void Refresh(int index)
        {
            My_File_Names.RemoveAt(index);
            My_File_Contents.RemoveAt(index);

            var List_NCOA = List_Of_Counts_List_NCOA_PRE[index];
            var List_Variable = List_Of_Counts_List_Variable[index];
            var List_PRE = List_Of_Counts_List_PRE[index];
            var List_DSF = List_Of_Counts_List_DSF[index];
            var List_DROP = List_Of_Counts_List_DROP_FROM_COUNTS[index];
            var List_MP = List_Of_Counts_List_MP[index];

            Remove(List_NCOA, Counts_NCOA_PRE);

            Remove(List_Variable, Counts_VARIABLE);

            Remove(List_PRE, Counts_PRE);

            Remove(List_DSF, Counts_PRE_DSF);

            Remove(List_DROP, Counts_DROP);

            Remove(List_MP, Counts_MP);

            List_Of_Counts_List_NCOA_PRE.RemoveAt(index);
            List_Of_Counts_List_Variable.RemoveAt(index);
            List_Of_Counts_List_PRE.RemoveAt(index);
            List_Of_Counts_List_DSF.RemoveAt(index);
            List_Of_Counts_List_DROP_FROM_COUNTS.RemoveAt(index);
            List_Of_Counts_List_MP.RemoveAt(index);

            SUM_NCOA_PRE = Counts_NCOA_PRE.Sum();
            SUM_VARIABLE = Counts_VARIABLE.Sum();
            SUM_PRE = Counts_PRE.Sum();
            SUM_PRE_DSF = Counts_PRE_DSF.Sum();
            SUM_DROP_FROM_COUNTS = Counts_DROP.Sum();
            SUM_MP = Counts_MP.Sum();
        }
    }
}

