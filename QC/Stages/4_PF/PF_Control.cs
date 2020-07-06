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
using System.Drawing.Drawing2D;

namespace QC
{

    public partial class PF_Control : UserControl
    {


        #region FUNCTIONS

        void Hide_Lables()
        {
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
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
            if (Prestort_Reports.My_File_Names.Any())
            {
                Aut_counts_label.Visible = true;
                Non_Aut_counts_label.Visible = true;
                Unq_counts_label.Visible = true;
                Aut_desc_label.Visible = true;
                Non_Aut_desc_label.Visible = true;
                Unq_desc_label.Visible = true;

                Drop_reports_label.Visible = false;

                foreach(var name in Prestort_Reports.My_File_Names)
                ListBox_Of_Reports.Items.Add(Path.GetFileNameWithoutExtension(name));

                double total = Prestort_Reports.SUM_TOTAL;
                double Non_Aut = Prestort_Reports.SUM_NON_AUTOMATION;
                double Aut = Prestort_Reports.SUM_AUTOMATION + Prestort_Reports.SUM_AUTOMATION_CAR;

                double Aut_Proc = (Aut * 100) / total;
                double Non_Aut_Proc = (Non_Aut * 100) / total;

                Aut_counts_label.Text = string.Format("{0:0.00}", Aut_Proc) + " %";
                Non_Aut_counts_label.Text = string.Format("{0:0.00}", Non_Aut_Proc) + " %";
                Unq_counts_label.Text = Prestort_Reports.SUM_INVALID.ToString();
            }

            //Comments
            Comment(All_Coments_Storage.Comment_PF_0, Comment_PF_0);
            Comment(All_Coments_Storage.Comment_PF_1, Comment_PF_1);
        }

       #endregion
            public PF_Control()
        {
            InitializeComponent();
        }

        private void Drag_Panel_Analyzers_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            var files = dropped.ToList();

            foreach (string drop in dropped)
            {
                if (Path.GetExtension(drop) == ".presort_report")
                {
                    Aut_counts_label.Visible = true;
                    Non_Aut_counts_label.Visible = true;
                    Unq_counts_label.Visible = true;
                    Aut_desc_label.Visible = true;
                    Non_Aut_desc_label.Visible = true;
                    Unq_desc_label.Visible = true;

                    Drop_reports_label.Visible = false;

                    Prestort_Reports PR = new Prestort_Reports();
                    PR.Open_Report(drop);

                    ListBox_Of_Reports.Items.Add(Path.GetFileNameWithoutExtension(drop));

                    double total = Prestort_Reports.SUM_TOTAL;
                    double Non_Aut = Prestort_Reports.SUM_NON_AUTOMATION;
                    double Aut = Prestort_Reports.SUM_AUTOMATION + Prestort_Reports.SUM_AUTOMATION_CAR;

                    double Aut_Proc = (Aut * 100) / total;
                    double Non_Aut_Proc = (Non_Aut * 100) / total;

                    Aut_counts_label.Text = string.Format("{0:0.00}", Aut_Proc) + " %";
                    Non_Aut_counts_label.Text = string.Format("{0:0.00}", Non_Aut_Proc) + " %";
                    Unq_counts_label.Text = Prestort_Reports.SUM_INVALID.ToString();
                }
            }

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


        private void ListBox_Of_Reports_DoubleClick(object sender, EventArgs e)
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

            if (ListBox_Of_Reports.Items.Count > 0 && ListBox_Of_Reports.SelectedItem != null)
            {
                int j = ListBox_Of_Reports.SelectedIndex;
                string sel_string = ListBox_Of_Reports.Items[j].ToString();

                for (int i = 0; i < Prestort_Reports.My_File_Names.Count; i++)
                {
                    if (sel_string == Prestort_Reports.My_File_Names[i])
                    {
                        richTextBox.Lines = Prestort_Reports.My_File_Contents[i];
                        tab.Text = Prestort_Reports.My_File_Names[i];
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

        private void ListBox_Of_Reports_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Reports.Items.Count > 0 && ListBox_Of_Reports.SelectedItem != null)
            {
                int j = ListBox_Of_Reports.SelectedIndex;
                string sel_string = ListBox_Of_Reports.Items[j].ToString();

                for (int i = 0; i < Prestort_Reports.My_File_Names.Count; i++)
                {
                    if (sel_string == Prestort_Reports.My_File_Names[i])
                    {
                        label13.Visible = true;
                        label14.Visible = true;
                        label15.Visible = true;
                        label16.Visible = true;
                        label17.Visible = true;
                        label18.Visible = true;

                        double total = Prestort_Reports.Counts_TOTAL[i];
                        double Non_Aut = Prestort_Reports.Counts_NON_AUTOMATION[i];
                        double Aut = Prestort_Reports.Counts_AUTOMATION[i] + Prestort_Reports.Counts_AUTOMATION_CAR[i];

                        double Aut_Proc = (Aut * 100) / total;
                        double Non_Aut_Proc = (Non_Aut * 100) / total;

                        label16.Text = string.Format("{0:0.00}", Aut_Proc) + " %";
                        label17.Text = string.Format("{0:0.00}", Non_Aut_Proc) + " %";
                        label18.Text = Prestort_Reports.SUM_INVALID.ToString();
                    }
                }

            }
            else
            {
                Hide_Lables();
            }
        }

        private void ListBox_Of_Reports_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = this.ListBox_Of_Reports.IndexFromPoint(e.Location);
                if (item >= 0 && ListBox_Of_Reports.SelectedIndices.Contains(item) == false)
                {
                    ListBox_Of_Reports.ClearSelected();
                    ListBox_Of_Reports.SelectedIndex = item;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListBox_Of_Reports.Items.Count > 0 && ListBox_Of_Reports.SelectedItem != null)
            {
                int j = ListBox_Of_Reports.SelectedIndex;
                string sel_string = ListBox_Of_Reports.Items[j].ToString();

                for (int i = 0; i < Prestort_Reports.My_File_Names.Count; i++)
                {
                    if (sel_string == Prestort_Reports.My_File_Names[i])
                    {

                        ListBox_Of_Reports.Items.RemoveAt(j);

                        if(ListBox_Of_Reports.Items.Count == 0)
                        {
                            Hide_Lables();
                            Prestort_Reports PR = new Prestort_Reports();
                            PR.Refresh(i);

                            Aut_counts_label.Text = "0" + " %";
                            Non_Aut_counts_label.Text = "0" + " %"; 
                            Unq_counts_label.Text = "0" + " %"; 
                        }
                        else
                        {
                            Prestort_Reports PR = new Prestort_Reports();
                            PR.Refresh(i);

                            double total = Prestort_Reports.SUM_TOTAL;
                            double Non_Aut = Prestort_Reports.SUM_NON_AUTOMATION;
                            double Aut = Prestort_Reports.SUM_AUTOMATION + Prestort_Reports.SUM_AUTOMATION_CAR;

                            double Aut_Proc = (Aut * 100) / total;
                            double Non_Aut_Proc = (Non_Aut * 100) / total;

                            Aut_counts_label.Text = string.Format("{0:0.00}", Aut_Proc) + " %";
                            Non_Aut_counts_label.Text = string.Format("{0:0.00}", Non_Aut_Proc) + " %";
                            Unq_counts_label.Text = Prestort_Reports.SUM_INVALID.ToString();
                        }
                    }
                }
            }
        }

        #region CHECKBOXES




        private void checkBox_PF_YES_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_PF_YES_ALL.Checked == true)
            //{
            //    checkBox_PF_YES_1.Checked = true;
            //    checkBox_PF_YES_2.Checked = true;
            //    checkBox_PF_YES_3.Checked = true;
            //    checkBox_PF_YES_4.Checked = true;
            //    checkBox_PF_YES_5.Checked = true;
            //    checkBox_PF_NO_1.Checked = false;
            //    checkBox_PF_NO_2.Checked = false;
            //    checkBox_PF_NO_3.Checked = false;
            //    checkBox_PF_NO_4.Checked = false;
            //    checkBox_PF_NO_5.Checked = false;
            //    checkBox_PF_NO_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_PF_YES_1.Checked = false;
            //    checkBox_PF_YES_2.Checked = false;
            //    checkBox_PF_YES_3.Checked = false;
            //    checkBox_PF_YES_4.Checked = false;
            //    checkBox_PF_YES_5.Checked = false;
            //}
        }

        private void checkBox_PF_NO_ALL_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_PF_NO_ALL.Checked == true)
            //{
            //    checkBox_PF_NO_1.Checked = true;
            //    checkBox_PF_NO_2.Checked = true;
            //    checkBox_PF_NO_3.Checked = true;
            //    checkBox_PF_NO_4.Checked = true;
            //    checkBox_PF_NO_5.Checked = true;
            //    checkBox_PF_YES_1.Checked = false;
            //    checkBox_PF_YES_2.Checked = false;
            //    checkBox_PF_YES_3.Checked = false;
            //    checkBox_PF_YES_4.Checked = false;
            //    checkBox_PF_YES_5.Checked = false;
            //    checkBox_PF_YES_ALL.Checked = false;
            //}
            //else
            //{
            //    checkBox_PF_NO_1.Checked = false;
            //    checkBox_PF_NO_2.Checked = false;
            //    checkBox_PF_NO_3.Checked = false;
            //    checkBox_PF_NO_4.Checked = false;
            //    checkBox_PF_NO_5.Checked = false;
            //}
        }

        private void checkBox_PF_YES_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_PF_YES_1, checkBox_PF_NO_1);
        }

        private void checkBox_PF_YES_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_PF_YES_2, checkBox_PF_NO_2);
        }

        private void checkBox_PF_YES_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_PF_YES_3, checkBox_PF_NO_3);
        }

        private void checkBox_PF_YES_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_PF_YES_4, checkBox_PF_NO_4);
        }

        private void checkBox_PF_YES_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxYes(checkBox_PF_YES_5, checkBox_PF_NO_5);
        }

        private void checkBox_PF_NO_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_PF_YES_1, checkBox_PF_NO_1);
        }

        private void checkBox_PF_NO_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_PF_YES_2, checkBox_PF_NO_2);
        }

        private void checkBox_PF_NO_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_PF_YES_3, checkBox_PF_NO_3);
        }

        private void checkBox_PF_NO_4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_PF_YES_4, checkBox_PF_NO_4);
        }

        private void checkBox_PF_NO_5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxNo(checkBox_PF_YES_5, checkBox_PF_NO_5);
        }

        private void Comment_PF_0_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PF", 0, Comment_PF_0);
            comment.Show();
        }

        private void Comment_PF_1_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment("PF", 1, Comment_PF_1);
            comment.Show();
        }

        #endregion

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Presort reports|*.presort_report";
                openFileDialog.Multiselect = true;
                Prestort_Reports PR = new Prestort_Reports();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string File in openFileDialog.FileNames)
                    {
                        PR.Open_Report(File);

                        ListBox_Of_Reports.Items.Add(Path.GetFileNameWithoutExtension(File));
                    }

                    Aut_counts_label.Visible = true;
                    Non_Aut_counts_label.Visible = true;
                    Unq_counts_label.Visible = true;
                    Aut_desc_label.Visible = true;
                    Non_Aut_desc_label.Visible = true;
                    Unq_desc_label.Visible = true;

                    Drop_reports_label.Visible = false;

                    double total = Prestort_Reports.SUM_TOTAL;
                    double Non_Aut = Prestort_Reports.SUM_NON_AUTOMATION;
                    double Aut = Prestort_Reports.SUM_AUTOMATION + Prestort_Reports.SUM_AUTOMATION_CAR;

                    double Aut_Proc = (Aut * 100) / total;
                    double Non_Aut_Proc = (Non_Aut * 100) / total;

                    Aut_counts_label.Text = string.Format("{0:0.00}", Aut_Proc) + " %";
                    Non_Aut_counts_label.Text = string.Format("{0:0.00}", Non_Aut_Proc) + " %";
                    Unq_counts_label.Text = Prestort_Reports.SUM_INVALID.ToString();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                Check_Box_Label.ForeColor = Color.DimGray;
                panel2.Visible = false;
                Check_Box_Panel.Visible = false;
                tabControl1.Location = new Point(18, 90);
                tabControl1.Height = Drag_Panel_Reports.Size.Height;
                Aut_desc_label.Location = new Point(18, 60);
                Aut_counts_label.Location = new Point(171, 60);
                Non_Aut_desc_label.Location = new Point(248, 60);
                Non_Aut_counts_label.Location = new Point(446, 60);
                Unq_desc_label.Location = new Point(550, 60);
                Unq_counts_label.Location = new Point(663, 60);
            }
            else
            {
                Check_Box_Label.ForeColor = Color.White;
                Check_Box_Panel.Visible = true;
                panel2.Visible = true;
                tabControl1.Location = new Point(18, 238);
                tabControl1.Height = Drag_Panel_Reports.Size.Height;
                Aut_desc_label.Location = new Point(18, 204);
                Aut_counts_label.Location = new Point(171, 204);
                Non_Aut_desc_label.Location = new Point(248, 204);
                Non_Aut_counts_label.Location = new Point(446, 204);
                Unq_desc_label.Location = new Point(550, 204);
                Unq_counts_label.Location = new Point(663, 204);
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            panel2.Visible = true;
            Check_Box_Label.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            if (Check_Box_Panel.Visible)
            {
                panel2.Visible = true;
                Check_Box_Label.ForeColor = Color.White;
            }
            else 
            {
                panel2.Visible = false;
                Check_Box_Label.ForeColor = Color.DimGray;
            }
        }
    }
}


