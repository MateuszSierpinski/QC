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

namespace QC.Controls
{

    public partial class FINAL_OUTPUT_Control : UserControl
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

        void CheckBoxYes(CheckBox Yes, CheckBox No)
        {
            if (Yes.Checked == true)
            {
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

        public void Open_QC()
        {
            //Counts

            Drop_counts_label.Visible = false;

            if (Open_Counts_Output.SUM_ADD != 0)
            {
                add_label_count.Visible = true;
                add_label_desc.Visible = true;
                add_label_count.Text = Open_Counts_Output.SUM_ADD.ToString("N0");
            }

            if (Open_Counts_Output.SUM_CSV != 0)
            {
                csv_label_count.Visible = true;
                csv_label_desc.Visible = true;
                csv_label_count.Text = Open_Counts_Output.SUM_CSV.ToString("N0");
            }

            if (Open_Counts_Output.SUM_UNQ != 0)
            {
                unq_label_count.Visible = true;
                unq_label_desc.Visible = true;
                unq_label_count.Text = Open_Counts_Output.SUM_UNQ.ToString("N0");
            }

            MAN_label.Visible = true;
            Csv_Correction_label_desc.Visible = true;
            Add_Correction_label_desc.Visible = true;
            add_box_count.Visible = true;
            csv_box_count.Visible = true;

            add_box_count.Text = Open_Counts_Output.SUM_ADD_CORRECTIONS.ToString("N0");
            csv_box_count.Text = Open_Counts_Output.SUM_CSV_CORRECTIONS.ToString("N0");

            ALL_C_M.CM.loading();

            //Tallies
            if (Open_Tally_Out.Tallies_Names.Any())
            {
                Drop_tally_label.Visible = false;

                foreach (var name in Open_Tally_Out.Tallies_Names)
                    if (!ListBox_Of_Tallies_Out.Items.Contains(name)) ListBox_Of_Tallies_Out.Items.Add(name);

                ALL_T_M.TM.load();
            }

            //Analyzers
            if (Analyzers_Out.Name_List.Any())
            {
                Drop_analyzers_label.Visible = false;

                foreach (var name in Analyzers_Out.Name_List)
                    if (!ListBox_Of_Anlyzers_Out.Items.Contains(name)) ListBox_Of_Anlyzers_Out.Items.Add(name);

                ALL_A_M.AM.Loading();
            }

            //Comments
            Comment(All_Coments_Storage.Comment_OUT_0, Comment_OUT_0);
            Comment(All_Coments_Storage.Comment_OUT_1, Comment_OUT_1);
            Comment(All_Coments_Storage.Comment_OUT_2, Comment_OUT_2);
            Comment(All_Coments_Storage.Comment_OUT_3, Comment_OUT_3);
            Comment(All_Coments_Storage.Comment_OUT_4, Comment_OUT_4);
            Comment(All_Coments_Storage.Comment_OUT_5, Comment_OUT_5);
            Comment(All_Coments_Storage.Comment_OUT_6, Comment_OUT_6);
            Comment(All_Coments_Storage.Comment_OUT_7, Comment_OUT_7);
            Comment(All_Coments_Storage.Comment_OUT_8, Comment_OUT_8);
            Comment(All_Coments_Storage.Comment_OUT_9, Comment_OUT_9);
            Comment(All_Coments_Storage.Comment_OUT_10, Comment_OUT_10);
            Comment(All_Coments_Storage.Comment_OUT_11, Comment_OUT_11);
        }

        #endregion

        #region JOB CONTROL

        public FINAL_OUTPUT_Control()
        {
            InitializeComponent();
        }

        #endregion

        #region CHECKBOXES

        private void Check_Boxes_Label_Click(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                Check_Boxes_Label.ForeColor = Color.DimGray;
                Check_Box_Hi_Panel.Visible = false;
                Check_Box_Panel.Visible = false;
                Check_Box_Panel.Visible = false;
                tabControl1.Location = new Point(18, 55);
                tabControl1.Height = Drag_Panel_Counts_Out.Size.Height;
            }
            else
            {
                Check_Boxes_Label.ForeColor = Color.White;
                Check_Box_Hi_Panel.Visible = true;
                Check_Box_Panel.Visible = true;
                tabControl1.Location = new Point(18, 551);
                tabControl1.Height = Drag_Panel_Counts_Out.Size.Height;
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

        private void checkBox_OUT_YES_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_OUT_YES_ALL.Checked == true)
            //{
            //    checkBox_OUT_YES_1.Checked = true;
            //    checkBox_OUT_YES_2.Checked = true;
            //    checkBox_OUT_YES_3.Checked = true;
            //    checkBox_OUT_YES_4.Checked = true;
            //    checkBox_OUT_YES_5.Checked = true;
            //    checkBox_OUT_YES_6.Checked = true;
            //    checkBox_OUT_YES_7.Checked = true;
            //    checkBox_OUT_YES_8.Checked = true;
            //    checkBox_OUT_YES_9.Checked = true;
            //    checkBox_OUT_YES_10.Checked = true;
            //    checkBox_OUT_YES_11.Checked = true;
            //    checkBox_OUT_YES_12.Checked = true;
            //    checkBox_OUT_YES_13.Checked = true;
            //    checkBox_OUT_YES_14.Checked = true;
            //    checkBox_OUT_YES_15.Checked = true;
            //    checkBox_OUT_YES_16.Checked = true;
            //    checkBox_OUT_YES_17.Checked = true;
            //    checkBox_OUT_YES_18.Checked = true;
            //    checkBox_OUT_YES_19.Checked = true;
            //    checkBox_OUT_YES_20.Checked = true;
            //    checkBox_OUT_YES_21.Checked = true;
            //    checkBox_OUT_YES_22.Checked = true;
            //    checkBox_OUT_YES_23.Checked = true;
            //    checkBox_OUT_YES_24.Checked = true;

            //    checkBox_OUT_NO_1.Checked = false;
            //    checkBox_OUT_NO_2.Checked = false;
            //    checkBox_OUT_NO_3.Checked = false;
            //    checkBox_OUT_NO_4.Checked = false;
            //    checkBox_OUT_NO_5.Checked = false;
            //    checkBox_OUT_NO_6.Checked = false;
            //    checkBox_OUT_NO_7.Checked = false;
            //    checkBox_OUT_NO_8.Checked = false;
            //    checkBox_OUT_NO_9.Checked = false;
            //    checkBox_OUT_NO_10.Checked = false;
            //    checkBox_OUT_NO_11.Checked = false;
            //    checkBox_OUT_NO_12.Checked = false;
            //    checkBox_OUT_NO_13.Checked = false;
            //    checkBox_OUT_NO_14.Checked = false;
            //    checkBox_OUT_NO_15.Checked = false;
            //    checkBox_OUT_NO_16.Checked = false;
            //    checkBox_OUT_NO_17.Checked = false;
            //    checkBox_OUT_NO_18.Checked = false;
            //    checkBox_OUT_NO_19.Checked = false;
            //    checkBox_OUT_NO_20.Checked = false;
            //    checkBox_OUT_NO_21.Checked = false;
            //    checkBox_OUT_NO_22.Checked = false;
            //    checkBox_OUT_NO_23.Checked = false;
            //    checkBox_OUT_NO_24.Checked = false;
            //    checkBox_OUT_NO_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_OUT_YES_1.Checked = false;
            //    checkBox_OUT_YES_2.Checked = false;
            //    checkBox_OUT_YES_3.Checked = false;
            //    checkBox_OUT_YES_4.Checked = false;
            //    checkBox_OUT_YES_5.Checked = false;
            //    checkBox_OUT_YES_6.Checked = false;
            //    checkBox_OUT_YES_7.Checked = false;
            //    checkBox_OUT_YES_8.Checked = false;
            //    checkBox_OUT_YES_9.Checked = false;
            //    checkBox_OUT_YES_10.Checked = false;
            //    checkBox_OUT_YES_11.Checked = false;
            //    checkBox_OUT_YES_12.Checked = false;
            //    checkBox_OUT_YES_13.Checked = false;
            //    checkBox_OUT_YES_14.Checked = false;
            //    checkBox_OUT_YES_15.Checked = false;
            //    checkBox_OUT_YES_16.Checked = false;
            //    checkBox_OUT_YES_17.Checked = false;
            //    checkBox_OUT_YES_18.Checked = false;
            //    checkBox_OUT_YES_19.Checked = false;
            //    checkBox_OUT_YES_20.Checked = false;
            //    checkBox_OUT_YES_21.Checked = false;
            //    checkBox_OUT_YES_22.Checked = false;
            //    checkBox_OUT_YES_23.Checked = false;
            //    checkBox_OUT_YES_24.Checked = false;
            //}
        }

        private void checkBox_OUT_NO_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_OUT_NO_ALL.Checked == true)
            //{
            //    checkBox_OUT_NO_1.Checked = true;
            //    checkBox_OUT_NO_2.Checked = true;
            //    checkBox_OUT_NO_3.Checked = true;
            //    checkBox_OUT_NO_4.Checked = true;
            //    checkBox_OUT_NO_5.Checked = true;
            //    checkBox_OUT_NO_6.Checked = false;
            //    checkBox_OUT_NO_7.Checked = true;
            //    checkBox_OUT_NO_8.Checked = true;
            //    checkBox_OUT_NO_9.Checked = true;
            //    checkBox_OUT_NO_10.Checked = true;
            //    checkBox_OUT_NO_11.Checked = true;
            //    checkBox_OUT_NO_12.Checked = true;
            //    checkBox_OUT_NO_13.Checked = true;
            //    checkBox_OUT_NO_14.Checked = true;
            //    checkBox_OUT_NO_15.Checked = true;
            //    checkBox_OUT_NO_16.Checked = true;
            //    checkBox_OUT_NO_17.Checked = true;
            //    checkBox_OUT_NO_18.Checked = true;
            //    checkBox_OUT_NO_19.Checked = true;
            //    checkBox_OUT_NO_20.Checked = true;
            //    checkBox_OUT_NO_21.Checked = true;
            //    checkBox_OUT_NO_22.Checked = true;
            //    checkBox_OUT_NO_23.Checked = true;
            //    checkBox_OUT_NO_24.Checked = true;

            //    checkBox_OUT_YES_1.Checked = false;
            //    checkBox_OUT_YES_2.Checked = false;
            //    checkBox_OUT_YES_3.Checked = false;
            //    checkBox_OUT_YES_4.Checked = false;
            //    checkBox_OUT_YES_5.Checked = false;
            //    checkBox_OUT_YES_6.Checked = false;
            //    checkBox_OUT_YES_7.Checked = false;
            //    checkBox_OUT_YES_8.Checked = false;
            //    checkBox_OUT_YES_9.Checked = false;
            //    checkBox_OUT_YES_10.Checked = false;
            //    checkBox_OUT_YES_11.Checked = false;
            //    checkBox_OUT_YES_12.Checked = false;
            //    checkBox_OUT_YES_13.Checked = false;
            //    checkBox_OUT_YES_14.Checked = false;
            //    checkBox_OUT_YES_15.Checked = false;
            //    checkBox_OUT_YES_16.Checked = false;
            //    checkBox_OUT_YES_17.Checked = false;
            //    checkBox_OUT_YES_18.Checked = false;
            //    checkBox_OUT_YES_19.Checked = false;
            //    checkBox_OUT_YES_20.Checked = false;
            //    checkBox_OUT_YES_21.Checked = false;
            //    checkBox_OUT_YES_22.Checked = false;
            //    checkBox_OUT_YES_23.Checked = false;
            //    checkBox_OUT_YES_24.Checked = false;
            //    checkBox_OUT_YES_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_OUT_NO_1.Checked = false;
            //    checkBox_OUT_NO_2.Checked = false;
            //    checkBox_OUT_NO_3.Checked = false;
            //    checkBox_OUT_NO_4.Checked = false;
            //    checkBox_OUT_NO_5.Checked = false;
            //    checkBox_OUT_NO_6.Checked = false;
            //    checkBox_OUT_NO_7.Checked = false;
            //    checkBox_OUT_NO_8.Checked = false;
            //    checkBox_OUT_NO_9.Checked = false;
            //    checkBox_OUT_NO_10.Checked = false;
            //    checkBox_OUT_NO_11.Checked = false;
            //    checkBox_OUT_NO_12.Checked = false;
            //    checkBox_OUT_NO_13.Checked = false;
            //    checkBox_OUT_NO_14.Checked = false;
            //    checkBox_OUT_NO_15.Checked = false;
            //    checkBox_OUT_NO_16.Checked = false;
            //    checkBox_OUT_NO_17.Checked = false;
            //    checkBox_OUT_NO_18.Checked = false;
            //    checkBox_OUT_NO_19.Checked = false;
            //    checkBox_OUT_NO_20.Checked = false;
            //    checkBox_OUT_NO_21.Checked = false;
            //    checkBox_OUT_NO_22.Checked = false;
            //    checkBox_OUT_NO_23.Checked = false;
            //    checkBox_OUT_NO_24.Checked = false;
            //}
        }

        private void checkBox_OUT_YES_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_1, checkBox_OUT_NO_1);
        }

        private void checkBox_OUT_YES_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_2, checkBox_OUT_NO_2);
        }

        private void checkBox_OUT_YES_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_3, checkBox_OUT_NO_3);
        }

        private void checkBox_OUT_YES_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_4, checkBox_OUT_NO_4);
        }

        private void checkBox_OUT_YES_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_5, checkBox_OUT_NO_5);
        }

        private void checkBox_OUT_YES_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_6, checkBox_OUT_NO_6);
        }

        private void checkBox_OUT_YES_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_7, checkBox_OUT_NO_7);
        }

        private void checkBox_OUT_YES_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_8, checkBox_OUT_NO_8);
        }

        private void checkBox_OUT_YES_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_9, checkBox_OUT_NO_9);
        }

        private void checkBox_OUT_YES_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_10, checkBox_OUT_NO_10);
        }

        private void checkBox_OUT_YES_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_11, checkBox_OUT_NO_11);
        }

        private void checkBox_OUT_YES_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_12, checkBox_OUT_NO_12);
        }

        private void checkBox_OUT_YES_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_13, checkBox_OUT_NO_13);
        }
        private void checkBox_OUT_YES_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_14, checkBox_OUT_NO_14);
        }

        private void checkBox_OUT_YES_15_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_15, checkBox_OUT_NO_15);
        }

        private void checkBox_OUT_YES_16_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_16, checkBox_OUT_NO_16);
        }

        private void checkBox_OUT_YES_17_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_17, checkBox_OUT_NO_17);
        }

        private void checkBox_OUT_YES_18_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_18, checkBox_OUT_NO_18);
        }

        private void checkBox_OUT_YES_19_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_19, checkBox_OUT_NO_19);
        }

        private void checkBox_OUT_YES_20_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_20, checkBox_OUT_NO_20);
        }

        private void checkBox_OUT_YES_21_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_21, checkBox_OUT_NO_21);
        }

        private void checkBox_OUT_YES_22_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_22, checkBox_OUT_NO_22);
        }

        private void checkBox_OUT_YES_23_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_23, checkBox_OUT_NO_23);
        }

        private void checkBox_OUT_YES_24_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_OUT_YES_24, checkBox_OUT_NO_24);
        }

        private void checkBox_OUT_NO_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_1, checkBox_OUT_NO_1);
        }

        private void checkBox_OUT_NO_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_2, checkBox_OUT_NO_2);
        }

        private void checkBox_OUT_NO_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_3, checkBox_OUT_NO_3);
        }

        private void checkBox_OUT_NO_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_4, checkBox_OUT_NO_4);
        }

        private void checkBox_OUT_NO_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_5, checkBox_OUT_NO_5);
        }

        private void checkBox_OUT_NO_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_6, checkBox_OUT_NO_6);
        }

        private void checkBox_OUT_NO_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_7, checkBox_OUT_NO_7);
        }

        private void checkBox_OUT_NO_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_8, checkBox_OUT_NO_8);
        }

        private void checkBox_OUT_NO_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_9, checkBox_OUT_NO_9);
        }

        private void checkBox_OUT_NO_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_10, checkBox_OUT_NO_10);
        }

        private void checkBox_OUT_NO_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_11, checkBox_OUT_NO_11);
        }

        private void checkBox_OUT_NO_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_12, checkBox_OUT_NO_12);
        }

        private void checkBox_OUT_NO_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_13, checkBox_OUT_NO_13);
        }

        private void checkBox_OUT_NO_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_14, checkBox_OUT_NO_14);
        }

        private void checkBox_OUT_NO_15_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_15, checkBox_OUT_NO_15);
        }

        private void checkBox_OUT_NO_16_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_16, checkBox_OUT_NO_16);
        }

        private void checkBox_OUT_NO_17_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_17, checkBox_OUT_NO_17);
        }

        private void checkBox_OUT_NO_18_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_18, checkBox_OUT_NO_18);
        }

        private void checkBox_OUT_NO_19_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_19, checkBox_OUT_NO_19);
        }

        private void checkBox_OUT_NO_20_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_20, checkBox_OUT_NO_20);
        }

        private void checkBox_OUT_NO_21_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_21, checkBox_OUT_NO_21);
        }

        private void checkBox_OUT_NO_22_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_22, checkBox_OUT_NO_22);
        }

        private void checkBox_OUT_NO_23_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_23, checkBox_OUT_NO_23);
        }

        private void checkBox_OUT_NO_24_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_OUT_YES_24, checkBox_OUT_NO_24);
        }

        private void Comment_OUT_0_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 0, Comment_OUT_0);
            comment.Show();
        }

        private void Comment_OUT_1_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 1, Comment_OUT_1);
            comment.Show();
        }

        private void Comment_OUT_2_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 2, Comment_OUT_2);
            comment.Show();
        }

        private void Comment_OUT_3_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 3, Comment_OUT_3);
            comment.Show();
        }

        private void Comment_OUT_4_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 4, Comment_OUT_4);
            comment.Show();
        }

        private void Comment_OUT_5_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 5, Comment_OUT_5);
            comment.Show();
        }

        private void Comment_OUT_6_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 6, Comment_OUT_6);
            comment.Show();
        }

        private void Comment_OUT_7_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 7, Comment_OUT_7);
            comment.Show();
        }

        private void Comment_OUT_8_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 8, Comment_OUT_8);
            comment.Show();
        }

        private void Comment_OUT_9_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 9, Comment_OUT_9);
            comment.Show();
        }

        private void Comment_OUT_10_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 10, Comment_OUT_10);
            comment.Show();
        }

        private void Comment_OUT_11_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("OUT", 11, Comment_OUT_11);
            comment.Show();
        }

        #endregion

        #region COUNTS OUT

        private void Drag_Panel_Counts_Input_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Path.GetExtension(fileList[0]) == ".txt")
            {

                Drop_counts_label.Visible = false;
                var Path_Out_Counts = fileList[0];
                Open_Counts_Output OCO = new Open_Counts_Output();
                OCO.OpenFile_Out(Path_Out_Counts);

                if (Open_Counts_Output.SUM_ADD != 0)
                {
                    add_label_count.Visible = true;
                    add_label_desc.Visible = true;
                    add_label_count.Text = Open_Counts_Output.SUM_ADD.ToString("N0");
                }

                if (Open_Counts_Output.SUM_CSV != 0)
                {
                    csv_label_count.Visible = true;
                    csv_label_desc.Visible = true;
                    csv_label_count.Text = Open_Counts_Output.SUM_CSV.ToString("N0");
                }

                if (Open_Counts_Output.SUM_UNQ != 0)
                {
                    unq_label_count.Visible = true;
                    unq_label_desc.Visible = true;
                    unq_label_count.Text = Open_Counts_Output.SUM_UNQ.ToString("N0");
                }

                MAN_label.Visible = true;
                Csv_Correction_label_desc.Visible = true;
                Add_Correction_label_desc.Visible = true;
                add_box_count.Visible = true;
                csv_box_count.Visible = true;

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

        private void Drag_Panel_Counts_Out_DoubleClick(object sender, EventArgs e)
        {
            if (Open_Counts_Input.My_File_Content != null)
            {
                TabPage tab = new TabPage();
                tab.BackColor = Color.FromArgb(60, 60, 60);
                tab.BorderStyle = BorderStyle.None;
                tab.Font = new Font("Century Gothic", 10.5f, FontStyle.Bold);

                RichTextBox richTextBox = new RichTextBox();
                richTextBox.BackColor = Color.FromArgb(60, 60, 60);
                richTextBox.ForeColor = Color.White;
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.BorderStyle = BorderStyle.None;
                richTextBox.ReadOnly = true;

                List<string> Names_of_Tabs = new List<string>();


                richTextBox.Lines = Open_Counts_Output.My_File_Content;
                tab.Text = Open_Counts_Output.My_File_Name;
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
        }


        private void Counts_Manager_Click(object sender, EventArgs e)
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

        private void Open_Bttn_JOB_Counts_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Counts File|*.txt";
                Open_Counts_Input OCI = new Open_Counts_Input();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Drop_counts_label.Visible = false;
                    var Path_Out_Counts = openFileDialog.FileName;
                    Open_Counts_Output OCO = new Open_Counts_Output();
                    OCO.OpenFile_Out(Path_Out_Counts);

                    if (Open_Counts_Output.SUM_ADD != 0)
                    {
                        add_label_count.Visible = true;
                        add_label_desc.Visible = true;
                        add_label_count.Text = Open_Counts_Output.SUM_ADD.ToString();
                    }

                    if (Open_Counts_Output.SUM_CSV != 0)
                    {
                        csv_label_count.Visible = true;
                        csv_label_desc.Visible = true;
                        csv_label_count.Text = Open_Counts_Output.SUM_CSV.ToString();
                    }

                    if (Open_Counts_Output.SUM_UNQ != 0)
                    {
                        unq_label_count.Visible = true;
                        unq_label_desc.Visible = true;
                        unq_label_count.Text = Open_Counts_Output.SUM_UNQ.ToString();
                    }

                    MAN_label.Visible = true;
                    Csv_Correction_label_desc.Visible = true;
                    Add_Correction_label_desc.Visible = true;
                    add_box_count.Visible = true;
                    csv_box_count.Visible = true;

                    
                }
            }
            ALL_C_M.CM.loading();
        }

        private void Counts_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.White;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = true;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Out.Visible = true;
            Drag_Panel_Analyzers_Out.Visible = false;
            Drag_Panel_Tally_Out.Visible = false;
        }

        private void Counts_Label_MouseEnter(object sender, EventArgs e)
        {
            Counts_Hi_Panel.Visible = true;
            Counts_Label.ForeColor = Color.White;
        }

        private void Counts_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Counts_Out.Visible)
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
                Open_Counts_Input OCI = new Open_Counts_Input();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Drop_counts_label.Visible = false;
                    var Path_Out_Counts = openFileDialog.FileName;
                    Open_Counts_Output OCO = new Open_Counts_Output();
                    OCO.OpenFile_Out(Path_Out_Counts);

                    if (Open_Counts_Output.SUM_ADD != 0)
                    {
                        add_label_count.Visible = true;
                        add_label_desc.Visible = true;
                        add_label_count.Text = Open_Counts_Output.SUM_ADD.ToString("N0");
                    }

                    if (Open_Counts_Output.SUM_CSV != 0)
                    {
                        csv_label_count.Visible = true;
                        csv_label_desc.Visible = true;
                        csv_label_count.Text = Open_Counts_Output.SUM_CSV.ToString("N0");
                    }

                    if (Open_Counts_Output.SUM_UNQ != 0)
                    {
                        unq_label_count.Visible = true;
                        unq_label_desc.Visible = true;
                        unq_label_count.Text = Open_Counts_Output.SUM_UNQ.ToString("N0");
                    }

                    MAN_label.Visible = true;
                    Csv_Correction_label_desc.Visible = true;
                    Add_Correction_label_desc.Visible = true;
                    add_box_count.Visible = true;
                    csv_box_count.Visible = true;


                }
            }
            ALL_C_M.CM.loading();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Counts_Output OCO = new Open_Counts_Output();
            OCO.Clear();
            Drop_counts_label.Visible = true;

            add_label_count.Visible = false;
            add_label_desc.Visible = false;
            csv_label_count.Visible = false;
            csv_label_desc.Visible = false;
            unq_label_count.Visible = false;
            unq_label_desc.Visible = false;
            MAN_label.Visible = false;
            Csv_Correction_label_desc.Visible = false;
            Add_Correction_label_desc.Visible = false;
            add_box_count.Visible = false;
            csv_box_count.Visible = false;

            ALL_C_M.CM.loading();
        }

        #endregion

        #region TALLIES OUT

        private void ListBox_Of_Tallies_Out_DoubleClick(object sender, EventArgs e)
        {
            if (ListBox_Of_Tallies_Out.Items.Count > 0 && ListBox_Of_Tallies_Out.SelectedItem != null)
            {
                List<string> Names_of_Tabs = new List<string>();

                TabPage tab = new TabPage();
                tab.BackColor = Color.FromArgb(60, 60, 60);
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

                string name = ListBox_Of_Tallies_Out.GetItemText(ListBox_Of_Tallies_Out.SelectedItem);

                for (int i = 0; i < Open_Tally_Out.Tallies_Names.Count; i++)
                {

                    if (name == Open_Tally_Out.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Out.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Out.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }

                }

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }

                if (!Names_of_Tabs.Contains(tab.Text))
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


        private void Tallies_Manager_Click(object sender, EventArgs e)
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

        private void Drag_Panel_Tally_Out_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();

            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".csv")
                {
                    Drop_tally_label.Visible = false;
                    Open_Tally_Out OTO = new Open_Tally_Out();

                    OTO.Open_Tally(drop);

                    ListBox_Of_Tallies_Out.Items.Add(Path.GetFileNameWithoutExtension(drop));
                }
            }

            ALL_T_M.TM.load();
        }

        private void Drag_Panel_Tally_Out_DragEnter(object sender, DragEventArgs e)
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

        private void Tallies_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.White;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = true;

            Drag_Panel_Counts_Out.Visible = false;
            Drag_Panel_Analyzers_Out.Visible = false;
            Drag_Panel_Tally_Out.Visible = true;
        }

        private void Tallies_Label_MouseEnter(object sender, EventArgs e)
        {
            Tallies_Hi_Panel.Visible = true;
            Tallies_Label.ForeColor = Color.White;
        }

        private void Tallies_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Tally_Out.Visible)
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

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tally File|*.csv|Excel File|*.xlsx";
                openFileDialog.Multiselect = true;
                Open_Tally_Job OTJ = new Open_Tally_Job();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string File in openFileDialog.FileNames)
                    {
                        if (Path.GetExtension(File) == ".csv")
                        {
                            Drop_tally_label.Visible = false;
                            Open_Tally_Out OTO = new Open_Tally_Out();

                            OTO.Open_Tally(File);

                            ListBox_Of_Tallies_Out.Items.Add(Path.GetFileNameWithoutExtension(File));
                        }
                    }
                }
            }

            ALL_T_M.TM.load();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Tallies_Out.Items.Count > 0 && ListBox_Of_Tallies_Out.SelectedItem != null)
            {
                int j = ListBox_Of_Tallies_Out.SelectedIndex;
                string sel_string = ListBox_Of_Tallies_Out.Items[j].ToString();

                for (int i = 0; i < Open_Tally_Out.Tallies_Names.Count; i++)
                {
                    if (sel_string == Open_Tally_Out.Tallies_Names[i])
                    {
                        ListBox_Of_Tallies_Out.Items.RemoveAt(j);
                        Open_Tally_Out.Tallies.RemoveAt(i);
                        Open_Tally_Out.Tallies_Names.RemoveAt(i);
                    }
                }
            }

            if (ListBox_Of_Tallies_Out.Items.Count == 0) Drop_tally_label.Visible = true;

            ALL_T_M.TM.load();
        }

        private void ListBox_Of_Tallies_Out_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Tallies_Out.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Tallies_Out.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Tallies_Out.ClearSelected();
                    ListBox_Of_Tallies_Out.SelectedIndex = item;
                }
            }
        }

        #endregion

        #region ANALYZERS OUT

        private void Drag_Panel_Counts_Analyzers_Job_DragDrop(object sender, DragEventArgs e)
        {
            Drop_analyzers_label.Visible = false;
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();

            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".fdr")
                {
                    Drop_analyzers_label.Visible = false;
                    Analyzers_Out AO = new Analyzers_Out();

                    AO.My_Analyzers(drop);
                    var name = Path.GetFileNameWithoutExtension(drop);

                    if (!ListBox_Of_Anlyzers_Out.Items.Contains(name))
                    {
                        ListBox_Of_Anlyzers_Out.Items.Add(name);
                    }

                    ALL_A_M.AM.Loading();
                }
            }
        }

        private void Drag_Panel_Counts_Analyzers_Job_DragEnter(object sender, DragEventArgs e)
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

        private void ListBox_Of_Anlyzers_Out_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBox_Of_Anlyzers_Out.Items.Count > 0 && ListBox_Of_Anlyzers_Out.SelectedItem != null)
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

                string lis = ListBox_Of_Anlyzers_Out.GetItemText(ListBox_Of_Anlyzers_Out.SelectedItem);

                List<string> Names_of_Tabs = new List<string>();

                for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                {

                    if (lis == Analyzers_Out.Name_List[i])
                    {
                        DataView dataView = new DataView(Analyzers_Out.Analyzers_List[i]);
                        My_data.DataSource = dataView;
                        tab.Text = Analyzers_Out.Name_List[i];
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

        private void Open_Bttn_OUT_Analyzers_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Analyzer File|*.fdr";
                openFileDialog.Multiselect = true;
                Analyzers_Input AI = new Analyzers_Input();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string File in openFileDialog.FileNames)
                    {
                        Drop_analyzers_label.Visible = false;
                        Analyzers_Out AO = new Analyzers_Out();

                        AO.My_Analyzers(File);
                        var name = Path.GetFileNameWithoutExtension(File);

                        if (!ListBox_Of_Anlyzers_Out.Items.Contains(name))
                        {
                            ListBox_Of_Anlyzers_Out.Items.Add(name);
                        }

                        
                    }
                }
            }

            ALL_A_M.AM.Loading();
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

        private void Analyzers_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.White;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = true;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Out.Visible = false;
            Drag_Panel_Analyzers_Out.Visible = true;
            Drag_Panel_Tally_Out.Visible = false;
        }

        private void Analyzers_Label_MouseEnter(object sender, EventArgs e)
        {
            Analyzers_Hi_Panel.Visible = true;
            Analyzers_Label.ForeColor = Color.White;
        }

        private void Analyzers_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Analyzers_Out.Visible)
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
                Analyzers_Input AI = new Analyzers_Input();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string File in openFileDialog.FileNames)
                    {
                        Drop_analyzers_label.Visible = false;
                        Analyzers_Out AO = new Analyzers_Out();

                        AO.My_Analyzers(File);
                        var name = Path.GetFileNameWithoutExtension(File);

                        if (!ListBox_Of_Anlyzers_Out.Items.Contains(name))
                        {
                            ListBox_Of_Anlyzers_Out.Items.Add(name);
                        }
                    }
                }
            }

            ALL_A_M.AM.Loading();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Anlyzers_Out.Items.Count > 0 && ListBox_Of_Anlyzers_Out.SelectedItem != null)
            {
                int j = ListBox_Of_Anlyzers_Out.SelectedIndex;
                string sel_string = ListBox_Of_Anlyzers_Out.Items[j].ToString();

                for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                {
                    if (sel_string == Analyzers_Out.Name_List[i])
                    {
                        ListBox_Of_Anlyzers_Out.Items.RemoveAt(j);
                        Analyzers_Out.Analyzers_List.RemoveAt(i);
                        Analyzers_Out.Name_List.RemoveAt(i);
                    }
                }
            }

            if (ListBox_Of_Anlyzers_Out.Items.Count == 0) Drop_analyzers_label.Visible = true;
            ALL_A_M.AM.Loading();
        }

        private void ListBox_Of_Anlyzers_Out_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Anlyzers_Out.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Anlyzers_Out.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Anlyzers_Out.ClearSelected();
                    ListBox_Of_Anlyzers_Out.SelectedIndex = item;
                }
            }
        }

        #endregion

    }
}

