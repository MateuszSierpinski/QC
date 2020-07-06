using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ADGV;

namespace QC
{

    public partial class PRE_JOB_Control : UserControl
    {

        #region VARIABLES

        public static bool close = false;
        public static bool close_counts = false;
        public static bool close_tally = false;        
       
        #endregion

        #region FUNCTIONS
        void Non_Sort(DataGridView cos)
        {
            foreach (DataGridViewColumn column in cos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        void CheckBoxYes(CheckBox Yes,CheckBox No)
        {
            if (Yes.Checked == true)
            {
                //Yes.ForeColor = Color.FromArgb(0, 160, 233);
                Yes.ForeColor = Color.Lime;
                No.Checked = false;
                No.ForeColor = Color.White;
            }
            else
            {
                Yes.ForeColor = Color.White;
            }
        }

        void CheckBoxNo(CheckBox Yes, CheckBox No)
        {
            if (No.Checked == true)
            {
                //No.ForeColor = Color.FromArgb(0, 160, 233);
                No.ForeColor = Color.Red;
                Yes.Checked = false;
                Yes.ForeColor = Color.White;
            }
            else
            {
                No.ForeColor = Color.White;
            }
        }

        void Comment(string comment, Button button)
        {
            if (comment != null)
            {
                button.BackColor = Color.FromArgb(0, 160, 233);
                button.ForeColor = Color.White;
            }
            else 
            {
                button.BackColor = Color.FromArgb(60, 60, 60);
                button.ForeColor = Color.White;
            }
        }

        public void  Open_QC()
        {
            //Counts
            Drop_counts_label.Visible = false;

            Filtered_label_desc.Visible = true;
            Original_label_desc.Visible = true;
            Output_label_desc.Visible = true;
            Filtered_label_count.Visible = true;
            Original_label_count.Visible = true;
            Output_label_count.Visible = true;
            MAN_label.Visible = true;
            Drop_label_desc.Visible = true;
            Header_label_desc.Visible = true;
            Header_box_count.Visible = true;
            Drop_box_count.Visible = true;

            Filtered_label_count.Text = Open_Counts_Input.SUM_ORG.ToString("N0");
            Original_label_count.Text = Open_Counts_Input.SUM_FILTR.ToString("N0");
            Output_label_count.Text = Open_Counts_Input.SUM_OUT.ToString("N0");
            Drop_box_count.Text = Open_Counts_Input.SUM_DROP.ToString("N0");
            Header_box_count.Text = Open_Counts_Input.SUM_HEADER.ToString("N0");

            ALL_C_M.CM.loading();

            //Tallies
            if (Open_Tally_Input.Tallies_Names.Any()) 
            {
                Drop_tally_label.Visible = false;

                foreach(var name in Open_Tally_Input.Tallies_Names)
                if (!ListBox_Of_Tallies_Input.Items.Contains(name)) ListBox_Of_Tallies_Input.Items.Add(name);

                ALL_T_M.TM.load();
            }
         
            //Analyzers
            if(Analyzers_Input.Name_List.Any())
            {
                Drop_analyzers_label.Visible = false;

                foreach(var name in Analyzers_Input.Name_List)
                if(!ListBox_Of_Anlyzers.Items.Contains(name)) ListBox_Of_Anlyzers.Items.Add(name);

                ALL_A_M.AM.Loading();
            }

            //Comments
            Comment(All_Coments_Storage.Comment_PRE_0, Comment_PRE_0);
            Comment(All_Coments_Storage.Comment_PRE_1, Comment_PRE_1);
            Comment(All_Coments_Storage.Comment_PRE_2, Comment_PRE_2);
            Comment(All_Coments_Storage.Comment_PRE_3, Comment_PRE_3);
            Comment(All_Coments_Storage.Comment_PRE_4, Comment_PRE_4);
            Comment(All_Coments_Storage.Comment_PRE_5, Comment_PRE_5);
            Comment(All_Coments_Storage.Comment_PRE_6, Comment_PRE_6);

        }

        #endregion

        #region PRE_JOB CONTROL
        public PRE_JOB_Control()
        {
            InitializeComponent();
        }

        private void PRE_JOB_Control_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PRE_JOB_Control_Click(object sender, EventArgs e)
        {
            ListBox_Of_Anlyzers.ClearSelected();
        }

        private void PRE_JOB_Control_VisibleChanged(object sender, EventArgs e)
        {
            ListBox_Of_Anlyzers.ClearSelected();
        }

        #endregion

        #region CHECKBOXES

        private void Check_Boxes_Label_Click(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                Check_Box_Hi_Panel.Visible = false;
                Check_Box_Panel.Visible = false;
                tabControl1.Location = new Point(18, 60);
                tabControl1.Height = Drag_Panel_Counts_Input.Size.Height;
                Check_Boxes_Label.ForeColor = Color.DimGray;
            }

            else
            {
                Check_Box_Hi_Panel.Visible = true;
                Check_Box_Panel.Visible = true;
                tabControl1.Location = new Point(18, 357);
                tabControl1.Height = Drag_Panel_Counts_Input.Size.Height;
                Check_Boxes_Label.ForeColor = Color.White;
            }
        }

        private void Check_Boxes_Label_MouseEnter(object sender, EventArgs e)
        {
            Check_Box_Hi_Panel.Visible = true;
            Check_Boxes_Label.ForeColor = Color.White;
        }

        private void Check_Boxes_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                Check_Box_Hi_Panel.Visible = true;
                Check_Boxes_Label.ForeColor = Color.White;
            }
            else
            {
                Check_Box_Hi_Panel.Visible = false;
                Check_Boxes_Label.ForeColor = Color.DimGray;
            }
        }
        private void checkBox_Pre_YES_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_Pre_YES_ALL.Checked == true)
            //{
            //    checkBox_Pre_YES_1.Checked = true;
            //    checkBox_Pre_YES_2.Checked = true;
            //    checkBox_Pre_YES_3.Checked = true;
            //    checkBox_Pre_YES_4.Checked = true;
            //    checkBox_Pre_YES_5.Checked = true;
            //    checkBox_Pre_YES_6.Checked = true;
            //    checkBox_Pre_YES_7.Checked = true;
            //    checkBox_Pre_YES_8.Checked = true;
            //    checkBox_Pre_YES_9.Checked = true;
            //    checkBox_Pre_YES_10.Checked = true;
            //    checkBox_Pre_YES_11.Checked = true;
            //    checkBox_Pre_YES_12.Checked = true;
            //    checkBox_Pre_YES_13.Checked = true;
            //    checkBox_Pre_YES_14.Checked = true;
            //    checkBox_Pre_NO_1.Checked = false;
            //    checkBox_Pre_NO_2.Checked = false;
            //    checkBox_Pre_NO_3.Checked = false;
            //    checkBox_Pre_NO_4.Checked = false;
            //    checkBox_Pre_NO_5.Checked = false;
            //    checkBox_Pre_NO_6.Checked = false;
            //    checkBox_Pre_NO_7.Checked = false;
            //    checkBox_Pre_NO_8.Checked = false;
            //    checkBox_Pre_NO_9.Checked = false;
            //    checkBox_Pre_NO_10.Checked = false;
            //    checkBox_Pre_NO_11.Checked = false;
            //    checkBox_Pre_NO_12.Checked = false;
            //    checkBox_Pre_NO_13.Checked = false;
            //    checkBox_Pre_NO_14.Checked = false;
            //    checkBox_Pre_NO_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_Pre_YES_1.Checked = false;
            //    checkBox_Pre_YES_2.Checked = false;
            //    checkBox_Pre_YES_3.Checked = false;
            //    checkBox_Pre_YES_4.Checked = false;
            //    checkBox_Pre_YES_5.Checked = false;
            //    checkBox_Pre_YES_6.Checked = false;
            //    checkBox_Pre_YES_7.Checked = false;
            //    checkBox_Pre_YES_8.Checked = false;
            //    checkBox_Pre_YES_9.Checked = false;
            //    checkBox_Pre_YES_10.Checked = false;
            //    checkBox_Pre_YES_11.Checked = false;
            //    checkBox_Pre_YES_12.Checked = false;
            //    checkBox_Pre_YES_13.Checked = false;
            //    checkBox_Pre_YES_14.Checked = false;
            //}
        }

        private void checkBox_Pre_NO_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_Pre_NO_ALL.Checked == true)
            //{
            //    checkBox_Pre_NO_1.Checked = true;
            //    checkBox_Pre_NO_2.Checked = true;
            //    checkBox_Pre_NO_3.Checked = true;
            //    checkBox_Pre_NO_4.Checked = true;
            //    checkBox_Pre_NO_5.Checked = true;
            //    checkBox_Pre_NO_6.Checked = true;
            //    checkBox_Pre_NO_7.Checked = true;
            //    checkBox_Pre_NO_8.Checked = true;
            //    checkBox_Pre_NO_9.Checked = true;
            //    checkBox_Pre_NO_10.Checked = true;
            //    checkBox_Pre_NO_11.Checked = true;
            //    checkBox_Pre_NO_12.Checked = true;
            //    checkBox_Pre_NO_13.Checked = true;
            //    checkBox_Pre_NO_14.Checked = true;
            //    checkBox_Pre_YES_1.Checked = false;
            //    checkBox_Pre_YES_2.Checked = false;
            //    checkBox_Pre_YES_3.Checked = false;
            //    checkBox_Pre_YES_4.Checked = false;
            //    checkBox_Pre_YES_5.Checked = false;
            //    checkBox_Pre_YES_6.Checked = false;
            //    checkBox_Pre_YES_7.Checked = false;
            //    checkBox_Pre_YES_8.Checked = false;
            //    checkBox_Pre_YES_9.Checked = false;
            //    checkBox_Pre_YES_10.Checked = false;
            //    checkBox_Pre_YES_11.Checked = false;
            //    checkBox_Pre_YES_12.Checked = false;
            //    checkBox_Pre_YES_13.Checked = false;
            //    checkBox_Pre_YES_14.Checked = false;
            //    checkBox_Pre_YES_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_Pre_NO_1.Checked = false;
            //    checkBox_Pre_NO_2.Checked = false;
            //    checkBox_Pre_NO_3.Checked = false;
            //    checkBox_Pre_NO_4.Checked = false;
            //    checkBox_Pre_NO_5.Checked = false;
            //    checkBox_Pre_NO_6.Checked = false;
            //    checkBox_Pre_NO_7.Checked = false;
            //    checkBox_Pre_NO_8.Checked = false;
            //    checkBox_Pre_NO_9.Checked = false;
            //    checkBox_Pre_NO_10.Checked = false;
            //    checkBox_Pre_NO_11.Checked = false;
            //    checkBox_Pre_NO_12.Checked = false;
            //    checkBox_Pre_NO_13.Checked = false;
            //    checkBox_Pre_NO_14.Checked = false;
            //}
        }

        private void checkBox_Pre_YES_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_1, checkBox_Pre_NO_1);
        }

        private void checkBox_Pre_YES_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_2, checkBox_Pre_NO_2);
        }

        private void checkBox_Pre_YES_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_3, checkBox_Pre_NO_3);
        }

        private void checkBox_Pre_YES_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_4, checkBox_Pre_NO_4);
        }

        private void checkBox_Pre_YES_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_5, checkBox_Pre_NO_5);
        }

        private void checkBox_Pre_YES_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_6, checkBox_Pre_NO_6);
        }

        private void checkBox_Pre_YES_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_7, checkBox_Pre_NO_7);
        }

        private void checkBox_Pre_YES_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_8, checkBox_Pre_NO_8);
        }

        private void checkBox_Pre_YES_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_9, checkBox_Pre_NO_9);
        }

        private void checkBox_Pre_YES_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_10, checkBox_Pre_NO_10);
        }
        private void checkBox_Pre_YES_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_11, checkBox_Pre_NO_11);
        }
        private void checkBox_Pre_YES_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_12, checkBox_Pre_NO_12);
        }

        private void checkBox_Pre_YES_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_13, checkBox_Pre_NO_13);
        }

        private void checkBox_Pre_YES_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_Pre_YES_14, checkBox_Pre_NO_14);
        }

        private void checkBox_Pre_NO_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_1, checkBox_Pre_NO_1);
        }

        private void checkBox_Pre_NO_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_2, checkBox_Pre_NO_2);
        }

        private void checkBox_Pre_NO_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_3, checkBox_Pre_NO_3);
        }

        private void checkBox_Pre_NO_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_4, checkBox_Pre_NO_4);
        }

        private void checkBox_Pre_NO_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_5, checkBox_Pre_NO_5);
        }

        private void checkBox_Pre_NO_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_6, checkBox_Pre_NO_6);
        }

        private void checkBox_Pre_NO_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_7, checkBox_Pre_NO_7);
        }

        private void checkBox_Pre_NO_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_8, checkBox_Pre_NO_8);
        }

        private void checkBox_Pre_NO_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_9, checkBox_Pre_NO_9);
        }

        private void checkBox_Pre_NO_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_10, checkBox_Pre_NO_10);
        }

        private void checkBox_Pre_NO_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_11, checkBox_Pre_NO_11);
        }
        private void checkBox_Pre_NO_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_12, checkBox_Pre_NO_12);
        }

        private void checkBox_Pre_NO_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_13, checkBox_Pre_NO_13);
        }

        private void checkBox_Pre_NO_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_Pre_YES_14, checkBox_Pre_NO_14);
        }

        private void Comment_PRE_0_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 0, Comment_PRE_0);
            comment.Show();
        }

        private void Comment_PRE_1_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 1, Comment_PRE_1);
            comment.Show();
        }

        private void Comment_PRE_2_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 2, Comment_PRE_2);
            comment.Show();
        }

        private void Comment_PRE_3_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 3, Comment_PRE_3);
            comment.Show();
        }

        private void Comment_PRE_4_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 4, Comment_PRE_4);
            comment.Show();
        }

        private void Comment_PRE_5_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 5, Comment_PRE_5);
            comment.Show();
        }

        private void Comment_PRE_6_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PRE", 6, Comment_PRE_6);
            comment.Show();
        }

        #endregion

        #region COUNTS INPUT

        private void Counts_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.White;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = true;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Input.Visible = true;
            Drag_Panel_Analyzers_Input.Visible = false;
            Drag_Panel_Tally_Input.Visible = false;
        }
        private void Counts_Label_MouseEnter(object sender, EventArgs e)
        {
            Counts_Hi_Panel.Visible = true;
            Counts_Label.ForeColor = Color.White;
        }

        private void Counts_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Counts_Input.Visible)
            {
                Counts_Hi_Panel.Visible = true;
                Counts_Label.ForeColor = Color.White;
            }
            else
            {
                Counts_Hi_Panel.Visible = false;
                Counts_Label.ForeColor = Color.DimGray;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Counts File|*.txt";
                string Path_Input_Counts = "";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Open_Counts_Input OCI = new Open_Counts_Input();

                    Drop_counts_label.Visible = false;
                    Path_Input_Counts = openFileDialog.FileName;

                    OCI.OpenFile_Input(Path_Input_Counts);

                    Filtered_label_desc.Visible = true;
                    Original_label_desc.Visible = true;
                    Output_label_desc.Visible = true;
                    Filtered_label_count.Visible = true;
                    Original_label_count.Visible = true;
                    Output_label_count.Visible = true;
                    MAN_label.Visible = true;
                    Drop_label_desc.Visible = true;
                    Header_label_desc.Visible = true;
                    Header_box_count.Visible = true;
                    Drop_box_count.Visible = true;

                    Filtered_label_count.Text = Open_Counts_Input.SUM_ORG.ToString("N0");
                    Original_label_count.Text = Open_Counts_Input.SUM_FILTR.ToString("N0");
                    Output_label_count.Text = Open_Counts_Input.SUM_OUT.ToString("N0");

                    ALL_C_M.CM.loading();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Counts_Input OCI = new Open_Counts_Input();
            OCI.Clear();
            Drop_counts_label.Visible = true;

            Filtered_label_desc.Visible = false;
            Original_label_desc.Visible = false;
            Output_label_desc.Visible = false;
            Filtered_label_count.Visible = false;
            Original_label_count.Visible = false;
            Output_label_count.Visible = false;
            MAN_label.Visible = false;
            Drop_label_desc.Visible = false;
            Header_label_desc.Visible = false;
            Header_box_count.Visible = false;
            Drop_box_count.Visible = false;

            ALL_C_M.CM.loading();
        }

        private void Drag_Panel_Counts_Input_DoubleClick(object sender, EventArgs e)
        {

            TabPage tab = new TabPage();
            tab.BackColor = Color.FromArgb(50, 50, 50);
            tab.BorderStyle = BorderStyle.None;
            tab.Font = new Font("Century Gothic", 10.5f, FontStyle.Bold);

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.BackColor = Color.FromArgb(50, 50, 50);
            richTextBox.ForeColor = Color.White;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.ReadOnly = true;

            List<string> Names_of_Tabs = new List<string>();

            if (Open_Counts_Input.My_File_Content != null)
            {
                richTextBox.Lines = Open_Counts_Input.My_File_Content;
                tab.Text = Open_Counts_Input.My_File_Name;
                tab.Controls.Add(richTextBox);

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }


                if (!Names_of_Tabs.Contains(tab.Text))
                {
                    tabControl1.TabPages.Add(tab);
                    tabControl1.Visible = true;
                }
            }

            ALL_C_M.CM.loading();
        }

        private void Drag_Panel_Counts_Input_DragDrop(object sender, DragEventArgs e)
        {
            string Path_Input_Counts = "";
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (Path.GetExtension(fileList[0]) == ".txt")
            {

                Drop_counts_label.Visible = false;
                Path_Input_Counts = fileList[0];
                Open_Counts_Input OCI = new Open_Counts_Input();
                OCI.OpenFile_Input(Path_Input_Counts);

                Filtered_label_desc.Visible = true;
                Original_label_desc.Visible = true;
                Output_label_desc.Visible = true;
                Filtered_label_count.Visible = true;
                Original_label_count.Visible = true;
                Output_label_count.Visible = true;
                MAN_label.Visible = true;
                Drop_label_desc.Visible = true;
                Header_label_desc.Visible = true;
                Header_box_count.Visible = true;
                Drop_box_count.Visible = true;

                Filtered_label_count.Text = Open_Counts_Input.SUM_ORG.ToString("N0");
                Original_label_count.Text = Open_Counts_Input.SUM_FILTR.ToString("N0");
                Output_label_count.Text = Open_Counts_Input.SUM_OUT.ToString("N0");

                ALL_C_M.CM.loading();
            }

        }

        private void Drag_Panel_Counts_Input_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Drop_box_count_TextChanged(object sender, EventArgs e)
        {
            int Counts;

            if (Int32.TryParse(Drop_box_count.Text, out Counts))
            {
                Open_Counts_Input.SUM_DROP = Counts;
                ALL_C_M.CM.loading();
            }

        }

        private void Header_box_count_TextChanged(object sender, EventArgs e)
        {
            int Counts;
            if (Int32.TryParse(Header_box_count.Text, out Counts))
            {
                Open_Counts_Input.SUM_HEADER = Counts;
                ALL_C_M.CM.loading();
            }
         
        }

        private void Drop_box_count_Leave(object sender, EventArgs e)
        {
            if (Drop_box_count.Text.Trim() == "")
            {
                Open_Counts_Input.SUM_DROP = 0;
                Drop_box_count.Text = "0";
                ALL_C_M.CM.loading();
            }
        }

        private void Header_box_count_Leave(object sender, EventArgs e)
        {
            if (Header_box_count.Text.Trim() == "")
            {
                Open_Counts_Input.SUM_HEADER = 0;
                Header_box_count.Text = "0";
                ALL_C_M.CM.loading();
            }
        }

        private void Counts_Manager_Click_1(object sender, EventArgs e)
        {
            if (close_counts == false)
            {
                ALL_C_M.CM.Show();
                close_counts = true;
            }

            else
            {
                ALL_C_M.CM.BringToFront();
            }
        }

        #endregion

        #region TALLIES INPUT

        private void Tallies_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.White;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = true;

            Drag_Panel_Counts_Input.Visible = false;
            Drag_Panel_Analyzers_Input.Visible = false;
            Drag_Panel_Tally_Input.Visible = true;
        }

        private void Tallies_Label_MouseEnter(object sender, EventArgs e)
        {
            Tallies_Hi_Panel.Visible = true;
            Tallies_Label.ForeColor = Color.White;
        }

        private void Tallies_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Tally_Input.Visible)
            {
                Tallies_Hi_Panel.Visible = true;
                Tallies_Label.ForeColor = Color.White;
            }
            else
            {
                Tallies_Hi_Panel.Visible = false;
                Tallies_Label.ForeColor = Color.DimGray;
            }
        }
        private void Drag_Panel_Tally_Input_DragDrop(object sender, DragEventArgs e)
        {

            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();
            Open_Tally_Input OTI = new Open_Tally_Input();
            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".csv")
                {
                    Drop_tally_label.Visible = false;
                    
                    OTI.Open_Tally(drop);

                    ListBox_Of_Tallies_Input.Items.Add(Path.GetFileNameWithoutExtension(drop));
                }

                //if (Path.GetExtension(drop).ToLower() == ".xlsx")
                //{
                //    Drop_tally_label.Visible = false;

                //    OTI.Open_Excel(drop);
                //    foreach (string name in Open_Tally_Job.Excels_Names)
                //    {
                //        ListBox_Of_Tallies_Input.Items.Add(name);
                //    }
                //}
            }

            ALL_T_M.TM.load();
        }


        private void Drag_Panel_Tally_Input_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tally File|*.csv";
                openFileDialog.Multiselect = true;
                Open_Tally_Input OTI = new Open_Tally_Input();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        if (Path.GetExtension(file) == ".csv")
                        {
                            Drop_tally_label.Visible = false;

                            OTI.Open_Tally(file);

                            ListBox_Of_Tallies_Input.Items.Add(Path.GetFileNameWithoutExtension(file));
                        }

                        //if (Path.GetExtension(File).ToLower() == ".xlsx")
                        //{
                        //    Drop_tally_label.Visible = false;

                        //    OTJ.Open_Excel(File);
                        //    foreach (string name in Open_Tally_Job.Excels_Names)
                        //    {
                        //        ListBox_Of_Tallies_Job.Items.Add(name);
                        //    }
                        //}
                    }
                }

                ALL_T_M.TM.load();
            }
        }

        private void ListBox_Of_Tallies_Input_DoubleClick(object sender, EventArgs e)
        {
            List<string> Names_of_Tabs = new List<string>();

            TabPage tab = new TabPage();
            tab.BackColor = Color.FromArgb(50, 50, 50);
            tab.BorderStyle = BorderStyle.None;

            DataView dataView = new DataView();
            AdvancedDataGridView advancedDataGridView1 = new AdvancedDataGridView();
            advancedDataGridView1.ForeColor = Color.Black;
            advancedDataGridView1.ReadOnly = true;
            advancedDataGridView1.BorderStyle = BorderStyle.None;
            advancedDataGridView1.Dock = DockStyle.Fill;
            advancedDataGridView1.RowHeadersVisible = false;
            advancedDataGridView1.EnableHeadersVisualStyles = false;
            advancedDataGridView1.AllowUserToAddRows = false;
            advancedDataGridView1.AllowUserToDeleteRows = false;
            advancedDataGridView1.BorderStyle = BorderStyle.None;
            advancedDataGridView1.BackgroundColor = Color.FromArgb(50, 50, 50);
            advancedDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(79, 129, 189);
            advancedDataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            advancedDataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(184, 204, 228);
            advancedDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);
            advancedDataGridView1.SortStringChanged += AdvancedDataGridView1_SortStringChanged;
            advancedDataGridView1.FilterStringChanged += AdvancedDataGridView1_FilterStringChanged;



            if (ListBox_Of_Tallies_Input.Items.Count > 0 && ListBox_Of_Tallies_Input.SelectedItem != null)
            {
                string name = ListBox_Of_Tallies_Input.GetItemText(ListBox_Of_Tallies_Input.SelectedItem);

                for (int i = 0; i < Open_Tally_Input.Tallies_Names.Count; i++)
                {

                    if (name == Open_Tally_Input.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Input.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Input.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);

                    }
                }

                for (int i = 0; i < Open_Tally_Input.Excels_Names.Count; i++)
                {

                    if (name == Open_Tally_Input.Excels_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Input.Excels[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Input.Excels_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }

                }

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }

                if (!Names_of_Tabs.Contains(tab.Text) && advancedDataGridView1 != null)
                {
                    tabControl1.TabPages.Add(tab);
                    tabControl1.Visible = true;
                }


                int AllRows = 0;

                for (int j = 0; j < advancedDataGridView1.ColumnCount; j++)
                {
                    if (advancedDataGridView1.Rows.Count > 1)
                    {
                        if (advancedDataGridView1.Columns[j].Name == "GroupCount" || advancedDataGridView1.Columns[j].Name == "\"GroupCount\"")
                        {
                            for (int k = 0; k < advancedDataGridView1.Rows.Count; k++)
                            {
                                AllRows += Convert.ToInt32(advancedDataGridView1.Rows[k].Cells[j].Value);
                            }
                        }
                    }
                }

                var row = dataView.Table.Rows[dataView.Table.Rows.Count - 1];

                if (AllRows > 0)
                {
                    if (row[0].ToString() != "TOTAL")
                    {
                        foreach (DataColumn dc in dataView.Table.Columns)
                        {
                            if (dc.ColumnName == "\"GroupCount\"")
                            {
                                DataRowView drToAdd = dataView.AddNew();
                                drToAdd[0] = "TOTAL";
                                drToAdd["\"GroupCount\""] = AllRows;
                                drToAdd.EndEdit();
                            }

                            if (dc.ColumnName == "GroupCount")
                            {
                                DataRowView drToAdd = dataView.AddNew();
                                drToAdd[0] = "TOTAL";
                                drToAdd["GroupCount"] = AllRows;
                                drToAdd.EndEdit();
                            }
                        }

                    }
                }

                var row2 = dataView.Table.Rows[dataView.Table.Rows.Count - 1];

                if (advancedDataGridView1.RowCount > 1 && row2[0].ToString() == "TOTAL")
                {
                    advancedDataGridView1.Rows[advancedDataGridView1.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(79, 129, 189);
                    advancedDataGridView1.Rows[advancedDataGridView1.RowCount - 1].DefaultCellStyle.ForeColor = Color.White;
                }

                advancedDataGridView1.ClearSelection();
            }
        }

        private void AdvancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
             
            //dataView.RowFilter = advancedDataGridView1.FilterString;

            //dataView.Delete(dataView.Count - 1);

            //    int AllRows = 0;

            //    for (int j = 0; j < advancedDataGridView1.ColumnCount; j++)
            //    {

            //        if (advancedDataGridView1.Rows.Count > 1)
            //        {
            //            if (advancedDataGridView1.Columns[j].Name == "GroupCount" || advancedDataGridView1.Columns[j].Name == "\"GroupCount\"")
            //            {
            //                for (int k = 0; k < advancedDataGridView1.Rows.Count; k++)
            //                {
            //                    AllRows += Convert.ToInt32(advancedDataGridView1.Rows[k].Cells[j].Value);
            //                }
            //            }
            //        }
            //    }
            //if (advancedDataGridView1.FilterString != "")
            //{ 
            //if (AllRows > 0)
            //        {
            //            dataView.Delete(dataView.Count - 1);
            //            DataRowView drToAdd = dataView.AddNew();
            //            var row = dataView.RowFilter.ToString().Split(']');
            //            var Myrow = row[0].Replace("[", "").Replace("(", "").Trim();
            //            var MyValue = row[1].Split('\'');
            //            var Value = MyValue[1];
            //            drToAdd[Myrow] = Value;
            //            drToAdd["GroupCount"] = AllRows;
            //            drToAdd.EndEdit();
            //        }
            //}

        }

        private void AdvancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            //DataView dataView = new DataView(Open_Tally_Input.Tally);
            //dataView.Sort = advancedDataGridView1.SortString;         
        }

        private void Tally_Manager_Click(object sender, EventArgs e)
        {
            if (close_tally == false)
            {
                ALL_T_M.TM.Show();
                close_tally = true;
            }

            else
            {
                ALL_T_M.TM.BringToFront();
            }

        }

        private void ListBox_Of_Tallies_Input_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Tallies_Input.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Tallies_Input.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Tallies_Input.ClearSelected();
                    ListBox_Of_Tallies_Input.SelectedIndex = item;
                }
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Tallies_Input.Items.Count > 0 && ListBox_Of_Tallies_Input.SelectedItem != null)
            {
                int j = ListBox_Of_Tallies_Input.SelectedIndex;
                string sel_string = ListBox_Of_Tallies_Input.Items[j].ToString();

                for (int i = 0; i < Open_Tally_Input.Tallies_Names.Count; i++)
                {
                    if (sel_string == Open_Tally_Input.Tallies_Names[i])
                    {
                        ListBox_Of_Tallies_Input.Items.RemoveAt(j);
                        Open_Tally_Input.Tallies.RemoveAt(i);
                        Open_Tally_Input.Tallies_Names.RemoveAt(i);
                    }
                }
            }

            if (ListBox_Of_Tallies_Input.Items.Count == 0) Drop_tally_label.Visible = true;
            ALL_T_M.TM.load();
        }

        #endregion

        #region ANALYZERS INPUT

        private void Analyzers_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.White;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = true;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Input.Visible = false;
            Drag_Panel_Analyzers_Input.Visible = true;
            Drag_Panel_Tally_Input.Visible = false;
        }

        private void Analyzers_Label_MouseEnter(object sender, EventArgs e)
        {
            Analyzers_Hi_Panel.Visible = true;
            Analyzers_Label.ForeColor = Color.White;
        }

        private void Analyzers_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Analyzers_Input.Visible)
            {
                Analyzers_Hi_Panel.Visible = true;
                Analyzers_Label.ForeColor = Color.White;
            }
            else
            {
                Analyzers_Hi_Panel.Visible = false;
                Analyzers_Label.ForeColor = Color.DimGray;
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Analyzer File|*.fdr";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        if (Path.GetExtension(file) == ".fdr")
                        {
                            Drop_analyzers_label.Visible = false;

                            Analyzers_Input AI = new Analyzers_Input();
                            AI.My_Analyzers(file);
                            var name = Path.GetFileNameWithoutExtension(file);

                            if (!ListBox_Of_Anlyzers.Items.Contains(name))
                            {
                                ListBox_Of_Anlyzers.Items.Add(name);
                            }
                        }
                    }
                    ALL_A_M.AM.Loading();
                }
            }
        }

        private void ListBox_Of_Anlyzers_DoubleClick(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.BackColor = Color.FromArgb(50, 50, 50);
            tab.BorderStyle = BorderStyle.None;
            

            DataGridView My_data = new DataGridView();
            My_data.BackgroundColor = Color.FromArgb(50, 50, 50);
            My_data.ForeColor = Color.Black;
            My_data.Dock = DockStyle.Fill;
            My_data.RowHeadersVisible = false;
            My_data.EnableHeadersVisualStyles = false;
            My_data.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 158, 220);
            My_data.ColumnHeadersHeight = 50;
            My_data.RowsDefaultCellStyle.BackColor = Color.White;
            My_data.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(192, 192, 192);
            My_data.AllowUserToAddRows = false;
            My_data.AllowUserToDeleteRows = false;
            My_data.BorderStyle = BorderStyle.None;

            string lis = ListBox_Of_Anlyzers.GetItemText(ListBox_Of_Anlyzers.SelectedItem);

            if (ListBox_Of_Anlyzers.Items.Count > 0 && ListBox_Of_Anlyzers.SelectedItem != null)
            {

                List<string> Names_of_Tabs = new List<string>();

                for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                {

                    if (lis == Analyzers_Input.Name_List[i])
                    {
                        DataView dataView = new DataView(Analyzers_Input.Analyzers_List[i]);
                        My_data.DataSource = dataView;
                        tab.Text = Analyzers_Input.Name_List[i];
                        tab.Controls.Add(My_data);
                    }
                }

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }


                if (!Names_of_Tabs.Contains(tab.Text) && My_data != null)
                {
                    tabControl1.TabPages.Add(tab);
                    Non_Sort(My_data);
                    tabControl1.Visible = true;
                }

                My_data.ClearSelection();
            }

            
        }

        private void Drag_Panel_Analyzers_DragDrop(object sender, DragEventArgs e)
        {

            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();
            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".fdr")
                {
                    Drop_analyzers_label.Visible = false;

                    Analyzers_Input AI = new Analyzers_Input();
                    AI.My_Analyzers(drop);
                    var name = Path.GetFileNameWithoutExtension(drop);

                    if (!ListBox_Of_Anlyzers.Items.Contains(name))
                    {
                        ListBox_Of_Anlyzers.Items.Add(name);
                    }                   
                }
            }

            ALL_A_M.AM.Loading();
        }

        private void Drag_Panel_Analyzers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Analyzers_Manager_Click(object sender, EventArgs e)
        {
            if (close == false)
            {
                ALL_A_M.AM.Show();
                close = true;
            }
            else
            {
                ALL_A_M.AM.BringToFront();
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Anlyzers.Items.Count > 0 && ListBox_Of_Anlyzers.SelectedItem != null)
            {
                int j = ListBox_Of_Anlyzers.SelectedIndex;
                string sel_string = ListBox_Of_Anlyzers.Items[j].ToString();

                for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                {
                    if (sel_string == Analyzers_Input.Name_List[i])
                    {
                        ListBox_Of_Anlyzers.Items.RemoveAt(j);
                        Analyzers_Input.Analyzers_List.RemoveAt(i);
                        Analyzers_Input.Name_List.RemoveAt(i);
                    }
                }
            }

            if (ListBox_Of_Anlyzers.Items.Count == 0) Drop_analyzers_label.Visible = true;
            ALL_A_M.AM.Loading();
        }

        private void ListBox_Of_Anlyzers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Anlyzers.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Anlyzers.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Anlyzers.ClearSelected();
                    ListBox_Of_Anlyzers.SelectedIndex = item;
                }
            }
        }

        #endregion

    }
}
