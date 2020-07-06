using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public partial class Counts_View : Form
    {
        string[] To_View = null;
        string Name_View = null;
        string Stage = null;
        int Value;
        public Counts_View(string stage,int value, string name_view)
        {
            InitializeComponent();

            Name_View = name_view;
            this.Text = Name_View;

            Stage = stage;
            Value = value;

            if(Stage == "PRE") To_View = Open_Counts_Input.My_File_Content;
            if (Stage == "JOB") To_View = Open_Counts_Job.My_File_Contents[Value];
            if(Stage == "OUT") To_View = Open_Counts_Output.My_File_Content;



            richTextBox1.Lines = To_View;
        }

        private void Highlight_Counts_Click(object sender, EventArgs e)
        {
            List<string> search = new List<string>();

            search.Add(VALUES_FROM_CAFE.Cafe);

            foreach (var media in VALUES_FROM_CAFE.MEDIA_ID_LIST)
            {
                search.Add(media);
            }


            foreach (var word in search)
            {
                int startIndex = 0;
                while (startIndex < richTextBox1.TextLength)
                {
                    int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);
                    int currentline = richTextBox1.GetLineFromCharIndex(wordStartIndex);
                    string currentlinetext = richTextBox1.Lines[currentline];
                    if (wordStartIndex != -1)
                    {
                        //richTextBox1.SelectionStart = wordStartIndex;
                        //richTextBox1.SelectionLength = VALUES_FROM_CAFE.Cafe.Length;
                        richTextBox1.Select(wordStartIndex, currentlinetext.Length - 1);
                        richTextBox1.SelectionColor = Color.Green;
                    }
                    else
                    {
                        break;
                    }

                    startIndex += wordStartIndex + VALUES_FROM_CAFE.Cafe.Length;
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {

            List<string> finalLines = richTextBox1.Lines.ToList();

            //finalLines.RemoveAll(x => x.Contains(VALUES_FROM_CAFE.Cafe));
            string path = finalLines.Where(x => x.Contains("/data/files/")).FirstOrDefault(); 
            string total = finalLines.Where(x => x.Contains("Total Count:")).FirstOrDefault();

            foreach (var media in VALUES_FROM_CAFE.MEDIA_ID_LIST)
            {
                finalLines.RemoveAll(x => !x.Contains(media) && !x.Contains(VALUES_FROM_CAFE.Cafe));
            }
            finalLines.Insert(0, path);
            finalLines.Insert(1, "========================================");
            finalLines.Add("========================================");
            finalLines.Add(total);

            richTextBox1.Lines = finalLines.ToArray();

            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Stage == "PRE") Open_Counts_Input.My_File_Content = richTextBox1.Lines;
            if (Stage == "JOB") Open_Counts_Job.My_File_Contents[Value] = richTextBox1.Lines;
            if (Stage == "OUT") Open_Counts_Output.My_File_Content = richTextBox1.Lines;
        }
    }
}

