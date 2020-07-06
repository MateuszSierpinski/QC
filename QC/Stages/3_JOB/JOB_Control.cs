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
    public partial class JOB_Control : UserControl
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

            if (Open_Counts_Job.SUM_NCOA_PRE != 0)
            {
                ncoa_label_count.Visible = true;
                ncoa_label_desc.Visible = true;
                ncoa_label_count.Text = Open_Counts_Job.SUM_NCOA_PRE.ToString("N0");
            }

            if (Open_Counts_Job.SUM_VARIABLE != 0)
            {
                variable_label_count.Visible = true;
                variable_label_desc.Visible = true;
                variable_label_count.Text = Open_Counts_Job.SUM_VARIABLE.ToString("N0");
            }

            if (Open_Counts_Job.SUM_PRE != 0)
            {
                pre_label_count.Visible = true;
                pre_label_desc.Visible = true;
                pre_label_count.Text = Open_Counts_Job.SUM_PRE.ToString("N0");
            }

            if (Open_Counts_Job.SUM_PRE_DSF != 0)
            {
                dsf_label_count.Visible = true;
                dsf_label_desc.Visible = true;
                dsf_label_count.Text = Open_Counts_Job.SUM_PRE_DSF.ToString("N0");
            }

            if (Open_Counts_Job.SUM_DROP_FROM_COUNTS != 0)
            {
                drop_label_count.Visible = true;
                drop_label_desc.Visible = true;
                drop_label_count.Text = Open_Counts_Job.SUM_DROP_FROM_COUNTS.ToString("N0");
            }

            if (Open_Counts_Job.SUM_MP != 0)
            {
                mp_label_count.Visible = true;
                mp_label_desc.Visible = true;
                mp_label_count.Text = Open_Counts_Job.SUM_MP.ToString("N0");
            }

            Drop_box_count.Text = Open_Counts_Job.SUM_DROP.ToString("N0");
            Seeds_box_count.Text = Open_Counts_Job.SUM_SEEDS.ToString("N0");
            Foreign_box_count.Text = Open_Counts_Job.SUM_FOREIGN.ToString("N0");

            LIST_Label.Visible = true;
            MAN_label.Visible = true;
            Foreign_box_count.Visible = true;
            foreign_label_desc.Visible = true;
            Drop_box_count.Visible = true;
            other_drop_label_desc.Visible = true;
            Seeds_box_count.Visible = true;
            seeds_label_desc.Visible = true;

           if( Open_Counts_Job.My_File_Names.Any())
           {
                foreach (var name in Open_Counts_Job.My_File_Names)
                    if (!ListBox_Of_Counts_Job.Items.Contains(name)) ListBox_Of_Counts_Job.Items.Add(name);

            }

            ALL_C_M.CM.loading();


            //Tallies
            if (Open_Tally_Job.Tallies_Names.Any())
            {
                Drop_tally_label.Visible = false;

                foreach (var name in Open_Tally_Job.Tallies_Names)
                    if (!ListBox_Of_Tallies_Job.Items.Contains(name)) ListBox_Of_Tallies_Job.Items.Add(name);

                ALL_T_M.TM.load();
            }
            if (Open_Tally_Job.Excels_Names.Any())
            {
                Drop_tally_label.Visible = false;

                foreach (var name in Open_Tally_Job.Excels_Names)
                    if (!ListBox_Of_Tallies_Job.Items.Contains(name)) ListBox_Of_Tallies_Job.Items.Add(name);

                ALL_T_M.TM.load();
            }

            //Analyzers
            if (Analyzers_Job.Name_List.Any())
            {
                Drop_analyzers_label.Visible = false;

                foreach (var name in Analyzers_Job.Name_List)
                    if (!ListBox_Of_Anlyzers_Job.Items.Contains(name)) ListBox_Of_Anlyzers_Job.Items.Add(name);

                ALL_A_M.AM.Loading();

                if (Analyzers_Job.ZIP > 0)
                {
                    label29.Visible = true;
                    label30.Visible = true;
                    label31.Visible = true;
                    label34.Visible = true;
                    label33.Visible = true;
                    label32.Visible = true;
                }

                if (Analyzers_Job.ZIP > 98)
                {
                    label29.ForeColor = Color.Green;
                    label29.Text = Analyzers_Job.ZIP.ToString() + "    %";
                }
                else
                {
                    label29.ForeColor = Color.Red;
                    label29.Text = Analyzers_Job.ZIP.ToString() + "    %    AutoQC will fail";
                }

                if (Analyzers_Job.ZIP4 > 80)
                {
                    label30.ForeColor = Color.Green;
                    label30.Text = Analyzers_Job.ZIP4.ToString() + "    %";
                }
                else
                {
                    label30.ForeColor = Color.Red;
                    label30.Text = Analyzers_Job.ZIP4.ToString() + "    %   AutoQC will fail";
                }

                if (Analyzers_Job.DPBC > 80)
                {
                    label31.ForeColor = Color.Green;
                    label31.Text = Analyzers_Job.DPBC.ToString() + "    %";
                }
                else
                {
                    label31.ForeColor = Color.Red;
                    label31.Text = Analyzers_Job.DPBC.ToString() + "    %   AutoQC will fail";
                }

                ALL_A_M.AM.Loading();
            }

            //Comments
            Comment(All_Coments_Storage.Comment_JOB_0, Comment_JOB_0);
            Comment(All_Coments_Storage.Comment_JOB_1, Comment_JOB_1);
            Comment(All_Coments_Storage.Comment_JOB_2, Comment_JOB_2);
            Comment(All_Coments_Storage.Comment_JOB_3, Comment_JOB_3);
            Comment(All_Coments_Storage.Comment_JOB_4, Comment_JOB_4);
            Comment(All_Coments_Storage.Comment_JOB_5, Comment_JOB_5);
            Comment(All_Coments_Storage.Comment_JOB_6, Comment_JOB_6);
            Comment(All_Coments_Storage.Comment_JOB_7, Comment_JOB_7);
            Comment(All_Coments_Storage.Comment_JOB_8, Comment_JOB_8);

        }

        #endregion

        #region JOB CONTROL
        public JOB_Control()
        {
            InitializeComponent();
        }

        private void JOB_Control_Click(object sender, EventArgs e)
        {
            ListBox_Of_Tallies_Job.ClearSelected();
            ListBox_Of_Anlyzers_Job.ClearSelected();
        }

        private void JOB_Control_VisibleChanged(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                if (VALUES_FROM_CAFE.Validation && VALUES_FROM_CAFE.Quad_Seeds)
                {
                    Check_Box_Panel.Size = new Size(870, 450);
                    tabControl1.Location = new Point(18, 510);
                    tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;

                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    label15.Visible = true;

                    checkBox_JOB_YES_12.Visible = true;
                    checkBox_JOB_YES_13.Visible = true;
                    checkBox_JOB_YES_14.Visible = true;
                    checkBox_JOB_YES_15.Visible = true;
                    checkBox_JOB_YES_16.Visible = true;

                    checkBox_JOB_NO_12.Visible = true;
                    checkBox_JOB_NO_13.Visible = true;
                    checkBox_JOB_NO_14.Visible = true;
                    checkBox_JOB_NO_15.Visible = true;
                    checkBox_JOB_NO_16.Visible = true;

                    Comment_JOB_5.Visible = true;
                    Comment_JOB_6.Visible = true;

                    label16.Location = new Point(0, 350);
                    label17.Location = new Point(0, 370);
                    label18.Location = new Point(0, 390);
                    label19.Location = new Point(0, 410);
                    label20.Location = new Point(0, 430);

                    checkBox_JOB_YES_17.Location = new Point(670, 370);
                    checkBox_JOB_YES_18.Location = new Point(670, 390);
                    checkBox_JOB_YES_19.Location = new Point(670, 410);
                    checkBox_JOB_YES_20.Location = new Point(670, 430);

                    checkBox_JOB_NO_17.Location = new Point(728, 370);
                    checkBox_JOB_NO_18.Location = new Point(728, 390);
                    checkBox_JOB_NO_19.Location = new Point(728, 410);
                    checkBox_JOB_NO_20.Location = new Point(728, 430);

                    Comment_JOB_7.Location = new Point(776, 374);
                    Comment_JOB_8.Location = new Point(776, 414);

                }
                if (!VALUES_FROM_CAFE.Validation && !VALUES_FROM_CAFE.Quad_Seeds)
                {
                    Check_Box_Panel.Size = new Size(870, 230);
                    tabControl1.Location = new Point(18, 300);
                    tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;
                }

                if (VALUES_FROM_CAFE.Validation && !VALUES_FROM_CAFE.Quad_Seeds)
                {
                    Check_Box_Panel.Size = new Size(870, 350);
                    tabControl1.Location = new Point(18, 410);
                    tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;

                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    label15.Visible = true;

                    checkBox_JOB_YES_12.Visible = true;
                    checkBox_JOB_YES_13.Visible = true;
                    checkBox_JOB_YES_14.Visible = true;
                    checkBox_JOB_YES_15.Visible = true;
                    checkBox_JOB_YES_16.Visible = true;

                    checkBox_JOB_NO_12.Visible = true;
                    checkBox_JOB_NO_13.Visible = true;
                    checkBox_JOB_NO_14.Visible = true;
                    checkBox_JOB_NO_15.Visible = true;
                    checkBox_JOB_NO_16.Visible = true;

                    Comment_JOB_5.Visible = true;
                    Comment_JOB_6.Visible = true;

                    label16.Location = new Point(0, 350);
                    label17.Location = new Point(0, 370);
                    label18.Location = new Point(0, 390);
                    label19.Location = new Point(0, 410);
                    label20.Location = new Point(0, 430);

                    checkBox_JOB_YES_17.Location = new Point(670, 370);
                    checkBox_JOB_YES_18.Location = new Point(670, 390);
                    checkBox_JOB_YES_19.Location = new Point(670, 410);
                    checkBox_JOB_YES_20.Location = new Point(670, 430);

                    checkBox_JOB_NO_17.Location = new Point(728, 370);
                    checkBox_JOB_NO_18.Location = new Point(728, 390);
                    checkBox_JOB_NO_19.Location = new Point(728, 410);
                    checkBox_JOB_NO_20.Location = new Point(728, 430);

                    Comment_JOB_7.Location = new Point(776, 374);
                    Comment_JOB_8.Location = new Point(776, 414);

                }

                if (!VALUES_FROM_CAFE.Validation && VALUES_FROM_CAFE.Quad_Seeds)
                {

                    Check_Box_Panel.Size = new Size(870, 330);
                    tabControl1.Location = new Point(18, 390);
                    tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;

                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    checkBox_JOB_YES_12.Visible = false;
                    checkBox_JOB_YES_13.Visible = false;
                    checkBox_JOB_YES_14.Visible = false;
                    checkBox_JOB_YES_15.Visible = false;
                    checkBox_JOB_YES_16.Visible = false;
                    checkBox_JOB_NO_12.Visible = false;
                    checkBox_JOB_NO_13.Visible = false;
                    checkBox_JOB_NO_14.Visible = false;
                    checkBox_JOB_NO_15.Visible = false;
                    checkBox_JOB_NO_16.Visible = false;
                    Comment_JOB_5.Visible = false;
                    Comment_JOB_6.Visible = false;

                    label16.Location = new Point(0, 230);
                    label17.Location = new Point(0, 250);
                    label18.Location = new Point(0, 270);
                    label19.Location = new Point(0, 290);
                    label20.Location = new Point(0, 310);

                    checkBox_JOB_YES_17.Location = new Point(670, 250);
                    checkBox_JOB_YES_18.Location = new Point(670, 270);
                    checkBox_JOB_YES_19.Location = new Point(670, 290);
                    checkBox_JOB_YES_20.Location = new Point(670, 310);

                    checkBox_JOB_NO_17.Location = new Point(728, 250);
                    checkBox_JOB_NO_18.Location = new Point(728, 270);
                    checkBox_JOB_NO_19.Location = new Point(728, 290);
                    checkBox_JOB_NO_20.Location = new Point(728, 310);

                    Comment_JOB_7.Location = new Point(776, 254);
                    Comment_JOB_8.Location = new Point(776, 294);

                }
            }


        }

        private void JOB_Control_DragEnter(object sender, DragEventArgs e)
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

        #endregion

        #region CHECKBOXES

        private void Check_Boxes_Label_Click(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {

                Check_Boxes_Label.ForeColor = Color.DimGray;
                Check_Box_Panel.Visible = false;
                Check_Box_Hi_Panel.Visible = false;
                tabControl1.Location = new Point(18, 55);
                tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;
            }
            else
            {
                Check_Box_Panel.Visible = true;
                Check_Box_Hi_Panel.Visible = false;
                tabControl1.Height = Drag_Panel_Counts_Job.Size.Height;
                Check_Boxes_Label.ForeColor = Color.White;

                if (VALUES_FROM_CAFE.Validation && VALUES_FROM_CAFE.Quad_Seeds)
                {
                    tabControl1.Location = new Point(18, 510);
                }

                if (!VALUES_FROM_CAFE.Validation && !VALUES_FROM_CAFE.Quad_Seeds)
                {
                    tabControl1.Location = new Point(18, 300);
                }

                if (VALUES_FROM_CAFE.Validation && !VALUES_FROM_CAFE.Quad_Seeds)
                {
                    tabControl1.Location = new Point(18, 410);
                }

                if (!VALUES_FROM_CAFE.Validation && VALUES_FROM_CAFE.Quad_Seeds)
                {
                    tabControl1.Location = new Point(18, 390);
                }

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

        private void checkBox_JOB_YES_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_JOB_YES_ALL.Checked == true)
            //{
            //    checkBox_JOB_YES_1.Checked = true;
            //    checkBox_JOB_YES_2.Checked = true;
            //    checkBox_JOB_YES_3.Checked = true;
            //    checkBox_JOB_YES_4.Checked = true;
            //    checkBox_JOB_YES_5.Checked = true;
            //    checkBox_JOB_YES_6.Checked = true;
            //    checkBox_JOB_YES_7.Checked = true;
            //    checkBox_JOB_YES_8.Checked = true;
            //    checkBox_JOB_YES_9.Checked = true;
            //    checkBox_JOB_YES_10.Checked = true;
            //    checkBox_JOB_YES_11.Checked = true;
            //    checkBox_JOB_YES_12.Checked = true;
            //    checkBox_JOB_YES_13.Checked = true;
            //    checkBox_JOB_YES_14.Checked = true;
            //    checkBox_JOB_YES_15.Checked = true;
            //    checkBox_JOB_YES_16.Checked = true;
            //    checkBox_JOB_YES_17.Checked = true;
            //    checkBox_JOB_YES_18.Checked = true;
            //    checkBox_JOB_YES_19.Checked = true;
            //    checkBox_JOB_YES_20.Checked = true;
            //    checkBox_JOB_NO_1.Checked = false;
            //    checkBox_JOB_NO_2.Checked = false;
            //    checkBox_JOB_NO_3.Checked = false;
            //    checkBox_JOB_NO_4.Checked = false;
            //    checkBox_JOB_NO_5.Checked = false;
            //    checkBox_JOB_NO_6.Checked = false;
            //    checkBox_JOB_NO_7.Checked = false;
            //    checkBox_JOB_NO_8.Checked = false;
            //    checkBox_JOB_NO_9.Checked = false;
            //    checkBox_JOB_NO_10.Checked = false;
            //    checkBox_JOB_NO_11.Checked = false;
            //    checkBox_JOB_NO_12.Checked = false;
            //    checkBox_JOB_NO_13.Checked = false;
            //    checkBox_JOB_NO_14.Checked = false;
            //    checkBox_JOB_NO_15.Checked = false;
            //    checkBox_JOB_NO_16.Checked = false;
            //    checkBox_JOB_NO_17.Checked = false;
            //    checkBox_JOB_NO_18.Checked = false;
            //    checkBox_JOB_NO_19.Checked = false;
            //    checkBox_JOB_NO_20.Checked = false;
            //    checkBox_JOB_NO_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_JOB_YES_1.Checked = false;
            //    checkBox_JOB_YES_2.Checked = false;
            //    checkBox_JOB_YES_3.Checked = false;
            //    checkBox_JOB_YES_4.Checked = false;
            //    checkBox_JOB_YES_5.Checked = false;
            //    checkBox_JOB_YES_6.Checked = false;
            //    checkBox_JOB_YES_7.Checked = false;
            //    checkBox_JOB_YES_8.Checked = false;
            //    checkBox_JOB_YES_9.Checked = false;
            //    checkBox_JOB_YES_10.Checked = false;
            //    checkBox_JOB_YES_11.Checked = false;
            //    checkBox_JOB_YES_12.Checked = false;
            //    checkBox_JOB_YES_13.Checked = false;
            //    checkBox_JOB_YES_14.Checked = false;
            //    checkBox_JOB_YES_15.Checked = false;
            //    checkBox_JOB_YES_16.Checked = false;
            //    checkBox_JOB_YES_17.Checked = false;
            //    checkBox_JOB_YES_18.Checked = false;
            //    checkBox_JOB_YES_19.Checked = false;
            //    checkBox_JOB_YES_20.Checked = false;
            //}
        }

        private void checkBox_JOB_NO_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_JOB_NO_ALL.Checked == true)
            //{
            //    checkBox_JOB_NO_1.Checked = true;
            //    checkBox_JOB_NO_2.Checked = true;
            //    checkBox_JOB_NO_3.Checked = true;
            //    checkBox_JOB_NO_4.Checked = true;
            //    checkBox_JOB_NO_5.Checked = true;
            //    checkBox_JOB_NO_6.Checked = true;
            //    checkBox_JOB_NO_7.Checked = true;
            //    checkBox_JOB_NO_8.Checked = true;
            //    checkBox_JOB_NO_9.Checked = true;
            //    checkBox_JOB_NO_10.Checked = true;
            //    checkBox_JOB_NO_11.Checked = true;
            //    checkBox_JOB_NO_12.Checked = true;
            //    checkBox_JOB_NO_13.Checked = true;
            //    checkBox_JOB_NO_14.Checked = true;
            //    checkBox_JOB_NO_15.Checked = true;
            //    checkBox_JOB_NO_16.Checked = true;
            //    checkBox_JOB_NO_17.Checked = true;
            //    checkBox_JOB_NO_18.Checked = true;
            //    checkBox_JOB_NO_19.Checked = true;
            //    checkBox_JOB_NO_20.Checked = true;
            //    checkBox_JOB_YES_1.Checked = false;
            //    checkBox_JOB_YES_2.Checked = false;
            //    checkBox_JOB_YES_3.Checked = false;
            //    checkBox_JOB_YES_4.Checked = false;
            //    checkBox_JOB_YES_5.Checked = false;
            //    checkBox_JOB_YES_6.Checked = false;
            //    checkBox_JOB_YES_7.Checked = false;
            //    checkBox_JOB_YES_8.Checked = false;
            //    checkBox_JOB_YES_9.Checked = false;
            //    checkBox_JOB_YES_10.Checked = false;
            //    checkBox_JOB_YES_11.Checked = false;
            //    checkBox_JOB_YES_12.Checked = false;
            //    checkBox_JOB_YES_13.Checked = false;
            //    checkBox_JOB_YES_14.Checked = false;
            //    checkBox_JOB_YES_15.Checked = false;
            //    checkBox_JOB_YES_16.Checked = false;
            //    checkBox_JOB_YES_17.Checked = false;
            //    checkBox_JOB_YES_18.Checked = false;
            //    checkBox_JOB_YES_19.Checked = false;
            //    checkBox_JOB_YES_20.Checked = false;
            //    checkBox_JOB_YES_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_JOB_NO_1.Checked = false;
            //    checkBox_JOB_NO_2.Checked = false;
            //    checkBox_JOB_NO_3.Checked = false;
            //    checkBox_JOB_NO_4.Checked = false;
            //    checkBox_JOB_NO_5.Checked = false;
            //    checkBox_JOB_NO_6.Checked = false;
            //    checkBox_JOB_NO_7.Checked = false;
            //    checkBox_JOB_NO_8.Checked = false;
            //    checkBox_JOB_NO_9.Checked = false;
            //    checkBox_JOB_NO_10.Checked = false;
            //    checkBox_JOB_NO_11.Checked = false;
            //    checkBox_JOB_NO_12.Checked = false;
            //    checkBox_JOB_NO_13.Checked = false;
            //    checkBox_JOB_NO_14.Checked = false;
            //    checkBox_JOB_NO_15.Checked = false;
            //    checkBox_JOB_NO_16.Checked = false;
            //    checkBox_JOB_NO_17.Checked = false;
            //    checkBox_JOB_NO_18.Checked = false;
            //    checkBox_JOB_NO_19.Checked = false;
            //    checkBox_JOB_NO_20.Checked = false;
            //}
        }

        private void checkBox_JOB_YES_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_1, checkBox_JOB_NO_1);
        }

        private void checkBox_JOB_YES_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_2, checkBox_JOB_NO_2);
        }

        private void checkBox_JOB_YES_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_3, checkBox_JOB_NO_3);
        }

        private void checkBox_JOB_YES_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_4, checkBox_JOB_NO_4);
        }

        private void checkBox_JOB_YES_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_5, checkBox_JOB_NO_5);
        }

        private void checkBox_JOB_YES_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_6, checkBox_JOB_NO_6);
        }

        private void checkBox_JOB_YES_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_7, checkBox_JOB_NO_7);
        }

        private void checkBox_JOB_YES_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_8, checkBox_JOB_NO_8);
        }

        private void checkBox_JOB_YES_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_9, checkBox_JOB_NO_9);
        }

        private void checkBox_JOB_YES_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_10, checkBox_JOB_NO_10);
        }

        private void checkBox_JOB_YES_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_11, checkBox_JOB_NO_11);
        }

        private void checkBox_JOB_YES_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_12, checkBox_JOB_NO_12);
        }

        private void checkBox_JOB_YES_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_13, checkBox_JOB_NO_13);
        }

        private void checkBox_JOB_YES_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_14, checkBox_JOB_NO_14);
        }

        private void checkBox_JOB_YES_15_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_15, checkBox_JOB_NO_15);
        }

        private void checkBox_JOB_YES_16_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_16, checkBox_JOB_NO_16);
        }

        private void checkBox_JOB_YES_17_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_17, checkBox_JOB_NO_17);
        }

        private void checkBox_JOB_YES_18_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_18, checkBox_JOB_NO_18);
        }

        private void checkBox_JOB_YES_19_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_19, checkBox_JOB_NO_19);
        }

        private void checkBox_JOB_YES_20_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_JOB_YES_20, checkBox_JOB_NO_20);
        }

        private void checkBox_JOB_NO_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_1, checkBox_JOB_NO_1);
        }

        private void checkBox_JOB_NO_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_2, checkBox_JOB_NO_2);
        }

        private void checkBox_JOB_NO_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_3, checkBox_JOB_NO_3);
        }

        private void checkBox_JOB_NO_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_4, checkBox_JOB_NO_4);
        }

        private void checkBox_JOB_NO_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_5, checkBox_JOB_NO_5);
        }

        private void checkBox_JOB_NO_6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_6, checkBox_JOB_NO_6);
        }

        private void checkBox_JOB_NO_7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_7, checkBox_JOB_NO_7);
        }

        private void checkBox_JOB_NO_8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_8, checkBox_JOB_NO_8);
        }

        private void checkBox_JOB_NO_9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_9, checkBox_JOB_NO_9);
        }

        private void checkBox_JOB_NO_10_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_10, checkBox_JOB_NO_10);
        }

        private void checkBox_JOB_NO_11_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_11, checkBox_JOB_NO_11);
        }

        private void checkBox_JOB_NO_12_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_12, checkBox_JOB_NO_12);
        }

        private void checkBox_JOB_NO_13_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_13, checkBox_JOB_NO_13);
        }

        private void checkBox_JOB_NO_14_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_14, checkBox_JOB_NO_14);
        }

        private void checkBox_JOB_NO_15_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_15, checkBox_JOB_NO_15);
        }

        private void checkBox_JOB_NO_16_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_16, checkBox_JOB_NO_16);
        }

        private void checkBox_JOB_NO_17_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_17, checkBox_JOB_NO_17);
        }

        private void checkBox_JOB_NO_18_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_18, checkBox_JOB_NO_18);
        }

        private void checkBox_JOB_NO_19_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_19, checkBox_JOB_NO_19);
        }

        private void checkBox_JOB_NO_20_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_JOB_YES_20, checkBox_JOB_NO_20);
        }

        private void Comment_JOB_0_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 0, Comment_JOB_0);
            comment.Show();
        }

        private void Comment_JOB_1_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 1, Comment_JOB_1);
            comment.Show();
        }

        private void Comment_JOB_2_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 2, Comment_JOB_2);
            comment.Show();
        }

        private void Comment_JOB_3_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 3, Comment_JOB_3);
            comment.Show();
        }

        private void Comment_JOB_4_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 4, Comment_JOB_4);
            comment.Show();
        }

        private void Comment_JOB_5_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 5, Comment_JOB_5);
            comment.Show();
        }

        private void Comment_JOB_6_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 6, Comment_JOB_6);
            comment.Show();
        }

        private void Comment_JOB_7_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 7, Comment_JOB_7);
            comment.Show();
        }

        private void Comment_JOB_8_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("JOB", 8, Comment_JOB_8);
            comment.Show();
        }
        #endregion

        #region COUNTS JOB

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Counts_Job.Items.Count > 0 && ListBox_Of_Counts_Job.SelectedItem != null)
            {
                int j = ListBox_Of_Counts_Job.SelectedIndex;
                string sel_string = ListBox_Of_Counts_Job.Items[j].ToString();

                for (int i = 0; i < Open_Counts_Job.My_File_Names.Count; i++)
                {
                    if (sel_string == Open_Counts_Job.My_File_Names[i])
                    {

                        ListBox_Of_Counts_Job.Items.RemoveAt(j);

                        if (ListBox_Of_Counts_Job.Items.Count == 0)
                        {

                            Open_Counts_Job OC = new Open_Counts_Job();
                            OC.Refresh(i);

                            Drop_counts_label.Visible = true;

                            ncoa_label_count.Visible = false;
                            ncoa_label_desc.Visible = false;
                            variable_label_count.Visible = false;
                            variable_label_desc.Visible = false;
                            pre_label_count.Visible = false;
                            pre_label_desc.Visible = false;
                            dsf_label_count.Visible = false;
                            dsf_label_desc.Visible = false;
                            drop_label_count.Visible = false;
                            drop_label_desc.Visible = false;
                            mp_label_count.Visible = false;
                            mp_label_desc.Visible = false;
                            LIST_Label.Visible = false;
                            MAN_label.Visible = false;
                            Foreign_box_count.Visible = false;
                            foreign_label_desc.Visible = false;
                            Drop_box_count.Visible = false;
                            other_drop_label_desc.Visible = false;
                            Seeds_box_count.Visible = false;
                            seeds_label_desc.Visible = false;

                            ALL_C_M.CM.loading();

                        }
                        else
                        {
                            Open_Counts_Job OC = new Open_Counts_Job();
                            OC.Refresh(i);

                            ncoa_label_count.Text = Open_Counts_Job.SUM_NCOA_PRE.ToString("N0");
                            variable_label_count.Text = Open_Counts_Job.SUM_VARIABLE.ToString("N0");
                            pre_label_count.Text = Open_Counts_Job.SUM_PRE.ToString("N0");
                            dsf_label_count.Text = Open_Counts_Job.SUM_PRE_DSF.ToString("N0");
                            drop_label_count.Text = Open_Counts_Job.SUM_DROP_FROM_COUNTS.ToString("N0");
                            mp_label_count.Text = Open_Counts_Job.SUM_MP.ToString("N0");

                            ALL_C_M.CM.loading();
                        }
                    }
                }
            }
        }

        private void Drag_Panel_Counts_Job_DragEnter(object sender, DragEventArgs e)
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

        private void Drag_Panel_Counts_Job_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Path.GetExtension(fileList[0]) == ".txt")
            {
                Drop_counts_label.Visible = false;
                var Path_Job_Counts = fileList[0];
                Open_Counts_Job OCJ = new Open_Counts_Job();
                OCJ.OpenFile_Job(Path_Job_Counts);

                if (Open_Counts_Job.SUM_NCOA_PRE != 0)
                {
                    ncoa_label_count.Visible = true;
                    ncoa_label_desc.Visible = true;
                    ncoa_label_count.Text = Open_Counts_Job.SUM_NCOA_PRE.ToString("N0");
                }

                if (Open_Counts_Job.SUM_VARIABLE != 0)
                {
                    variable_label_count.Visible = true;
                    variable_label_desc.Visible = true;
                    variable_label_count.Text =  Open_Counts_Job.SUM_VARIABLE.ToString("N0");
                }

                if (Open_Counts_Job.SUM_PRE != 0)
                {
                    pre_label_count.Visible = true;
                    pre_label_desc.Visible = true;
                    pre_label_count.Text = Open_Counts_Job.SUM_PRE.ToString("N0");
                }

                if (Open_Counts_Job.SUM_PRE_DSF != 0)
                {
                    dsf_label_count.Visible = true;
                    dsf_label_desc.Visible = true;
                    dsf_label_count.Text = Open_Counts_Job.SUM_PRE_DSF.ToString("N0");
                }

                if (Open_Counts_Job.SUM_DROP_FROM_COUNTS != 0)
                {
                    drop_label_count.Visible = true;
                    drop_label_desc.Visible = true;
                    drop_label_count.Text = Open_Counts_Job.SUM_DROP_FROM_COUNTS.ToString("N0");
                }

                if (Open_Counts_Job.SUM_MP != 0)
                {
                    mp_label_count.Visible = true;
                    mp_label_desc.Visible = true;
                    mp_label_count.Text = Open_Counts_Job.SUM_MP.ToString("N0");
                }

                LIST_Label.Visible = true;
                MAN_label.Visible = true;
                Foreign_box_count.Visible = true;
                foreign_label_desc.Visible = true;
                Drop_box_count.Visible = true;
                other_drop_label_desc.Visible = true;
                Seeds_box_count.Visible = true;
                seeds_label_desc.Visible = true;

                ListBox_Of_Counts_Job.Items.Add(Path.GetFileNameWithoutExtension(Path_Job_Counts));

                ALL_C_M.CM.loading();

            }
        }

        private void Foreign_box_count_TextChanged(object sender, EventArgs e)
        {
            int Counts;

            if (Int32.TryParse(Foreign_box_count.Text, out Counts))
            {
                Open_Counts_Job.SUM_FOREIGN = Counts;
                ALL_C_M.CM.loading();
            }

        }

        private void Foreign_box_count_Leave(object sender, EventArgs e)
        {
            if (Foreign_box_count.Text.Trim() == "")
            {
                Open_Counts_Job.SUM_FOREIGN = 0;
                Foreign_box_count.Text = "0";
                ALL_C_M.CM.loading();
            }

        }

        private void Seeds_box_count_TextChanged(object sender, EventArgs e)
        {
            int Counts;
            if (Int32.TryParse(Seeds_box_count.Text, out Counts))
            {
                Open_Counts_Job.SUM_SEEDS = Counts;
                ALL_C_M.CM.loading();
            }
        }

        private void Seeds_box_count_Leave(object sender, EventArgs e)
        {
            if (Seeds_box_count.Text.Trim() == "")
            {
                Open_Counts_Job.SUM_SEEDS = 0;
                Seeds_box_count.Text = "0";
                ALL_C_M.CM.loading();
            }

        }

        private void Drop_box_count_TextChanged(object sender, EventArgs e)
        {
            int Counts;
            if (Int32.TryParse(Drop_box_count.Text, out Counts))
            {
                Open_Counts_Job.SUM_DROP = Counts;
                ALL_C_M.CM.loading();
            }

        }

        private void Drop_box_count_Leave(object sender, EventArgs e)
        {
            if (Drop_box_count.Text.Trim() == "")
            {
                Open_Counts_Job.SUM_DROP = 0;
                Drop_box_count.Text = "0";
                ALL_C_M.CM.loading();
            }

        }

        private void ListBox_Of_Counts_Job_DoubleClick(object sender, EventArgs e)
        {
            if (ListBox_Of_Counts_Job.Items.Count > 0 && ListBox_Of_Counts_Job.SelectedItem != null)
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

                string name = ListBox_Of_Counts_Job.GetItemText(ListBox_Of_Counts_Job.SelectedItem);

                for (int i = 0; i < Open_Counts_Job.My_File_Names.Count; i++)
                {
                    if (name == Open_Counts_Job.My_File_Names[i])
                    {
                        richTextBox.Lines = Open_Counts_Job.My_File_Contents[i];
                        tab.Text = Open_Counts_Job.My_File_Names[i];
                        tab.Controls.Add(richTextBox);
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

        private void Counts_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.White;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = true;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Job.Visible = true;
            Drag_Panel_Analyzers_Job.Visible = false;
            Drag_Panel_Tally_Job.Visible = false;
        }

        private void Counts_Label_MouseEnter(object sender, EventArgs e)
        {
            Counts_Hi_Panel.Visible = true;
            Counts_Label.ForeColor = Color.White;
        }

        private void Counts_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Counts_Job.Visible)
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
                    var Path_Job_Counts = openFileDialog.FileName;
                    Open_Counts_Job OCJ = new Open_Counts_Job();
                    OCJ.OpenFile_Job(Path_Job_Counts);

                    if (Open_Counts_Job.SUM_NCOA_PRE != 0)
                    {
                        ncoa_label_count.Visible = true;
                        ncoa_label_desc.Visible = true;
                        ncoa_label_count.Text = Open_Counts_Job.SUM_NCOA_PRE.ToString("N0");
                    }

                    if (Open_Counts_Job.SUM_VARIABLE != 0)
                    {
                        variable_label_count.Visible = true;
                        variable_label_desc.Visible = true;
                        variable_label_count.Text = Open_Counts_Job.SUM_VARIABLE.ToString("N0");
                    }

                    if (Open_Counts_Job.SUM_PRE != 0)
                    {
                        pre_label_count.Visible = true;
                        pre_label_desc.Visible = true;
                        pre_label_count.Text = Open_Counts_Job.SUM_PRE.ToString("N0");
                    }

                    if (Open_Counts_Job.SUM_PRE_DSF != 0)
                    {
                        dsf_label_count.Visible = true;
                        dsf_label_desc.Visible = true;
                        dsf_label_count.Text = Open_Counts_Job.SUM_PRE_DSF.ToString("N0");
                    }

                    if (Open_Counts_Job.SUM_DROP_FROM_COUNTS != 0)
                    {
                        drop_label_count.Visible = true;
                        drop_label_desc.Visible = true;
                        drop_label_count.Text = Open_Counts_Job.SUM_DROP_FROM_COUNTS.ToString("N0");
                    }

                    if (Open_Counts_Job.SUM_MP != 0)
                    {
                        mp_label_count.Visible = true;
                        mp_label_desc.Visible = true;
                        mp_label_count.Text = Open_Counts_Job.SUM_MP.ToString("N0");
                    }

                    LIST_Label.Visible = true;
                    MAN_label.Visible = true;
                    Foreign_box_count.Visible = true;
                    foreign_label_desc.Visible = true;
                    Drop_box_count.Visible = true;
                    other_drop_label_desc.Visible = true;
                    Seeds_box_count.Visible = true;
                    seeds_label_desc.Visible = true;

                    ListBox_Of_Counts_Job.Items.Add(Path.GetFileNameWithoutExtension(Path_Job_Counts));
                }

                ALL_C_M.CM.loading();
            }
        }

        #endregion

        #region TALLIES JOB

        private void ListBox_Of_Tallies_DoubleClick(object sender, EventArgs e)
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

            if (ListBox_Of_Tallies_Job.Items.Count > 0 && ListBox_Of_Tallies_Job.SelectedItem != null)
            {
                string name = ListBox_Of_Tallies_Job.GetItemText(ListBox_Of_Tallies_Job.SelectedItem);

                for (int i = 0; i < Open_Tally_Job.Tallies_Names.Count; i++)
                {

                    if (name == Open_Tally_Job.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Job.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Job.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }

                }

                for (int i = 0; i < Open_Tally_Job.Excels_Names.Count; i++)
                {

                    if (name == Open_Tally_Job.Excels_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Job.Excels[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Job.Excels_Names[i];
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

        private void Drag_Panel_Tally_Job_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();
            Open_Tally_Job OTJ = new Open_Tally_Job();

            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".csv")
                {
                    Drop_tally_label.Visible = false;


                    OTJ.Open_Tally(drop);

                    ListBox_Of_Tallies_Job.Items.Add(Path.GetFileNameWithoutExtension(drop));
                }

                if (Path.GetExtension(drop).ToLower() == ".xlsx")
                {
                    Drop_tally_label.Visible = false;

                    OTJ.Open_Excel(drop);
                    foreach (string name in Open_Tally_Job.Excels_Names)
                    {
                        ListBox_Of_Tallies_Job.Items.Add(name);
                    }
                }
            }

            ALL_T_M.TM.load();
        }

        private void Drag_Panel_Tally_Job_DragEnter(object sender, DragEventArgs e)
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
        
        private void Tallies_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.DimGray;
            Tallies_Label.ForeColor = Color.White;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = false;
            Tallies_Hi_Panel.Visible = true;

            Drag_Panel_Counts_Job.Visible = false;
            Drag_Panel_Analyzers_Job.Visible = false;
            Drag_Panel_Tally_Job.Visible = true;
        }

        private void Tallies_Label_MouseEnter(object sender, EventArgs e)
        {
            Tallies_Hi_Panel.Visible = true;
            Tallies_Label.ForeColor = Color.White;
        }

        private void Tallies_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Tally_Job.Visible)
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


                            OTJ.Open_Tally(File);

                            ListBox_Of_Tallies_Job.Items.Add(Path.GetFileNameWithoutExtension(File));
                        }

                        if (Path.GetExtension(File).ToLower() == ".xlsx")
                        {
                            Drop_tally_label.Visible = false;

                            OTJ.Open_Excel(File);
                            foreach (string name in Open_Tally_Job.Excels_Names)
                            {
                                ListBox_Of_Tallies_Job.Items.Add(name);
                            }
                        }
                    }
                }

                ALL_T_M.TM.load();
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Tallies_Job.Items.Count > 0 && ListBox_Of_Tallies_Job.SelectedItem != null)
            {
                int j = ListBox_Of_Tallies_Job.SelectedIndex;
                string sel_string = ListBox_Of_Tallies_Job.Items[j].ToString();

                for (int i = 0; i < Open_Tally_Job.Tallies_Names.Count; i++)
                {
                    if (sel_string == Open_Tally_Job.Tallies_Names[i])
                    {
                        ListBox_Of_Tallies_Job.Items.RemoveAt(j);
                        Open_Tally_Job.Tallies.RemoveAt(i);
                        Open_Tally_Job.Tallies_Names.RemoveAt(i);
                    }
                }
            }

            if (ListBox_Of_Tallies_Job.Items.Count == 0) Drop_tally_label.Visible = true;

            ALL_T_M.TM.load();
        }

        private void ListBox_Of_Tallies_Job_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Tallies_Job.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Tallies_Job.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Tallies_Job.ClearSelected();
                    ListBox_Of_Tallies_Job.SelectedIndex = item;
                }
            }
        }

        #endregion

        #region ANALYZERS JOB

        private void Analyzers_Label_Click(object sender, EventArgs e)
        {
            Counts_Label.ForeColor = Color.DimGray;
            Analyzers_Label.ForeColor = Color.White;
            Tallies_Label.ForeColor = Color.DimGray;

            Counts_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = true;
            Tallies_Hi_Panel.Visible = false;

            Drag_Panel_Counts_Job.Visible = false;
            Drag_Panel_Analyzers_Job.Visible = true;
            Drag_Panel_Tally_Job.Visible = false;
        }

        private void Analyzers_Label_MouseEnter(object sender, EventArgs e)
        {
            Analyzers_Hi_Panel.Visible = true;
            Analyzers_Label.ForeColor = Color.White;
        }

        private void Analyzers_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Drag_Panel_Analyzers_Job.Visible)
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

        private void Drag_Panel_Counts_Analyzers_Job_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();

            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".fdr")
                {
                    Drop_analyzers_label.Visible = false;
                    Analyzers_Job AJ = new Analyzers_Job();

                    AJ.My_Analyzers(drop);

                    if (Analyzers_Job.ZIP > 0)
                    {
                        label29.Visible = true;
                        label30.Visible = true;
                        label31.Visible = true;
                        label34.Visible = true;
                        label33.Visible = true;
                        label32.Visible = true;
                    }

                    if (Analyzers_Job.ZIP > 98)
                    {
                        label29.ForeColor = Color.Green;
                        label29.Text = Analyzers_Job.ZIP.ToString() + "    %";
                    }
                    else
                    {
                        label29.ForeColor = Color.Red;
                        label29.Text = Analyzers_Job.ZIP.ToString() + "    %    AutoQC will fail";
                    }

                    if (Analyzers_Job.ZIP4 > 80)
                    {
                        label30.ForeColor = Color.Green;
                        label30.Text = Analyzers_Job.ZIP4.ToString() + "    %";
                    }
                    else
                    {
                        label30.ForeColor = Color.Red;
                        label30.Text = Analyzers_Job.ZIP4.ToString() + "    %   AutoQC will fail";
                    }

                    if (Analyzers_Job.DPBC > 80)
                    {
                        label31.ForeColor = Color.Green;
                        label31.Text = Analyzers_Job.DPBC.ToString() + "    %";
                    }
                    else
                    {
                        label31.ForeColor = Color.Red;
                        label31.Text = Analyzers_Job.DPBC.ToString() + "    %   AutoQC will fail";
                    }

                    var name = Path.GetFileNameWithoutExtension(drop);

                    if (!ListBox_Of_Anlyzers_Job.Items.Contains(name))
                    {
                        ListBox_Of_Anlyzers_Job.Items.Add(name);
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

        private void ListBox_Of_Anlyzers_Job_DoubleClick(object sender, EventArgs e)
        {
            if (ListBox_Of_Anlyzers_Job.Items.Count > 0 && ListBox_Of_Anlyzers_Job.SelectedItem != null)
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

                string lis = ListBox_Of_Anlyzers_Job.GetItemText(ListBox_Of_Anlyzers_Job.SelectedItem);


                    List<string> Names_of_Tabs = new List<string>();

                    for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                    {

                        if (lis == Analyzers_Job.Name_List[i])
                        {
                            DataView dataView = new DataView(Analyzers_Job.Analyzers_List[i]);
                            My_data.DataSource = dataView;
                            tab.Text = Analyzers_Job.Name_List[i];
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
     
        private void Open_Bttn_JOB_Analyzers_Click(object sender, EventArgs e)
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
                        Analyzers_Job AJ = new Analyzers_Job();

                        AJ.My_Analyzers(File);

                        if (Analyzers_Job.ZIP > 0)
                        {
                            label29.Visible = true;
                            label30.Visible = true;
                            label31.Visible = true;
                            label34.Visible = true;
                            label33.Visible = true;
                            label32.Visible = true;
                        }

                        if (Analyzers_Job.ZIP > 98)
                        {
                            label29.ForeColor = Color.Green;
                            label29.Text = Analyzers_Job.ZIP.ToString() + "    %";
                        }
                        else
                        {
                            label29.ForeColor = Color.Red;
                            label29.Text = Analyzers_Job.ZIP.ToString() + "    %    AutoQC will fail";
                        }

                        if (Analyzers_Job.ZIP4 > 80)
                        {
                            label30.ForeColor = Color.Green;
                            label30.Text = Analyzers_Job.ZIP4.ToString() + "    %";
                        }
                        else
                        {
                            label30.ForeColor = Color.Red;
                            label30.Text = Analyzers_Job.ZIP4.ToString() + "    %   AutoQC will fail";
                        }

                        if (Analyzers_Job.DPBC > 80)
                        {
                            label31.ForeColor = Color.Green;
                            label31.Text = Analyzers_Job.DPBC.ToString() + "    %";
                        }
                        else
                        {
                            label31.ForeColor = Color.Red;
                            label31.Text = Analyzers_Job.DPBC.ToString() + "    %   AutoQC will fail";
                        }

                        var name = Path.GetFileNameWithoutExtension(File);

                        if (!ListBox_Of_Anlyzers_Job.Items.Contains(name))
                        {
                            ListBox_Of_Anlyzers_Job.Items.Add(name);
                        }

                        ALL_A_M.AM.Loading();
                    }
                }
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
                        Analyzers_Job AJ = new Analyzers_Job();

                        AJ.My_Analyzers(File);

                        if (Analyzers_Job.ZIP > 0)
                        {
                            label29.Visible = true;
                            label30.Visible = true;
                            label31.Visible = true;
                            label34.Visible = true;
                            label33.Visible = true;
                            label32.Visible = true;
                        }

                        if (Analyzers_Job.ZIP > 98)
                        {
                            label29.ForeColor = Color.Green;
                            label29.Text = Analyzers_Job.ZIP.ToString() + "    %";
                        }
                        else
                        {
                            label29.ForeColor = Color.Red;
                            label29.Text = Analyzers_Job.ZIP.ToString() + "    %    AutoQC will fail";
                        }

                        if (Analyzers_Job.ZIP4 > 80)
                        {
                            label30.ForeColor = Color.Green;
                            label30.Text = Analyzers_Job.ZIP4.ToString() + "    %";
                        }
                        else
                        {
                            label30.ForeColor = Color.Red;
                            label30.Text = Analyzers_Job.ZIP4.ToString() + "    %   AutoQC will fail";
                        }

                        if (Analyzers_Job.DPBC > 80)
                        {
                            label31.ForeColor = Color.Green;
                            label31.Text = Analyzers_Job.DPBC.ToString() + "    %";
                        }
                        else
                        {
                            label31.ForeColor = Color.Red;
                            label31.Text = Analyzers_Job.DPBC.ToString() + "    %   AutoQC will fail";
                        }

                        var name = Path.GetFileNameWithoutExtension(File);

                        if (!ListBox_Of_Anlyzers_Job.Items.Contains(name))
                        {
                            ListBox_Of_Anlyzers_Job.Items.Add(name);
                        }

                        ALL_A_M.AM.Loading();
                    }
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Anlyzers_Job.Items.Count > 0 && ListBox_Of_Anlyzers_Job.SelectedItem != null)
            {
                int j = ListBox_Of_Anlyzers_Job.SelectedIndex;
                string sel_string = ListBox_Of_Anlyzers_Job.Items[j].ToString();

                for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                {
                    if (sel_string == Analyzers_Job.Name_List[i])
                    {
                        ListBox_Of_Anlyzers_Job.Items.RemoveAt(j);
                        Analyzers_Job.Analyzers_List.RemoveAt(i);
                        Analyzers_Job.Name_List.RemoveAt(i);

                        if (sel_string.ToUpper().Contains("PRE"))
                        {
                            label29.Visible = false;
                            label30.Visible = false;
                            label31.Visible = false;
                            label34.Visible = false;
                            label33.Visible = false;
                            label32.Visible = false;
                        }
                    }
                }
            }

            if (ListBox_Of_Anlyzers_Job.Items.Count == 0) Drop_analyzers_label.Visible = true;
            ALL_A_M.AM.Loading();
        }

        private void ListBox_Of_Anlyzers_Job_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Anlyzers_Job.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Anlyzers_Job.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Anlyzers_Job.ClearSelected();
                    ListBox_Of_Anlyzers_Job.SelectedIndex = item;
                }
            }
        }


        #endregion

    }
}

