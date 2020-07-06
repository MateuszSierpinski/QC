using ADGV;
using QC.Controls;
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
    
    public partial class Tallies_Manager : Form
    {
        List<string> Names_of_Nodes_PRE = new List<string>();
        List<string> Names_of_Nodes_JOB = new List<string>();
        List<string> Names_of_Nodes_OUT = new List<string>();

        public void load()
        {
            List<string> NAMES_OF_TALLIES = new List<string>();


            treeView1.Nodes[0].Nodes.Clear();

            foreach (TreeNode nodes in treeView1.Nodes[0].Nodes)
            {
                Names_of_Nodes_PRE.Add(nodes.Text);
            }

            if (Open_Tally_Input.Tallies_Names.Any())
            {
                foreach (var name in Open_Tally_Input.Tallies_Names)
                {
                    if (!Names_of_Nodes_PRE.Contains(name))
                    {
                        treeView1.Nodes[0].Nodes.Add(name);
                    }
                }
            }

            treeView1.Nodes[1].Nodes.Clear();

            foreach (TreeNode nodes in treeView1.Nodes[1].Nodes)
            {
                Names_of_Nodes_JOB.Add(nodes.Text);
            }

            if (Open_Tally_Job.Tallies_Names.Any())
            {
                foreach (var name in Open_Tally_Job.Tallies_Names)
                {
                    if (!Names_of_Nodes_JOB.Contains(name))
                    {
                        treeView1.Nodes[1].Nodes.Add(name);
                    }
                }
            }

            treeView1.Nodes[2].Nodes.Clear();

            foreach (TreeNode nodes in treeView1.Nodes[2].Nodes)
            {
                Names_of_Nodes_OUT.Add(nodes.Text);
            }

            if (Open_Tally_Out.Tallies_Names.Any())
            {
                foreach (var name in Open_Tally_Out.Tallies_Names)
                {
                    if (!Names_of_Nodes_OUT.Contains(name))
                    {
                        treeView1.Nodes[2].Nodes.Add(name);
                    }
                }
            }

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                ColorChild(treeView1.Nodes[i]);
            }

            treeView1.ExpandAll();
        }

        public void ColorChild(TreeNode nodes)
        {
            var color = Color.FromArgb(254, 231, 2);
            var font = new Font("Century Gothic", 11.5F, FontStyle.Bold);

            foreach (TreeNode node_tmp in nodes.Nodes)
            {
                node_tmp.ForeColor = color;
                node_tmp.NodeFont = font;
            }
        }
        public Tallies_Manager()
        {
            InitializeComponent();

            load();

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //int AllRows = 0;

            //if (e.Node.Text == Open_Tally_Input.Tally_Name)
            //{

            //    for (int i = 0; i < Open_Tally_Input.Tally.Columns.Count; i++)

            //    {
            //        if (Open_Tally_Input.Tally.Columns[i].ColumnName == "GroupCount")
            //        {
            //            for (int j = 0; j < Open_Tally_Input.Tally.Rows.Count; j++)
            //            {
            //                AllRows += Convert.ToInt32(Open_Tally_Input.Tally.Rows[j].ItemArray[i]);
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < Open_Tally_Job.Tallies_Names.Count; i++)
            //{

            //    if (e.Node.Text == Open_Tally_Job.Tallies_Names[i])
            //    {

            //        for (int j = 0; j < Open_Tally_Job.Tallies[i].Columns.Count; j++)

            //        {
            //            if (Open_Tally_Job.Tallies[i].Columns[j].ColumnName == "GroupCount")
            //            {
            //                for (int k = 0; k < Open_Tally_Job.Tallies[i].Rows.Count; k++)
            //                {
            //                    AllRows += Convert.ToInt32(Open_Tally_Job.Tallies[i].Rows[k].ItemArray[j]);
            //                }
            //            }
            //        }
            //    }
            //}

            //Sum_count_label.Text = AllRows.ToString();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
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
                //advancedDataGridView1.SortStringChanged += AdvancedDataGridView1_SortStringChanged;
                //advancedDataGridView1.FilterStringChanged += AdvancedDataGridView1_FilterStringChanged;

                List<string> Names_of_Tabs = new List<string>();

                for (int i = 0; i < Open_Tally_Input.Tallies_Names.Count; i++)
                {
                    if (e.Node.Text == Open_Tally_Input.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Input.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Input.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }
                }

                for (int i = 0; i < Open_Tally_Job.Tallies_Names.Count; i++)
                {
                    if (e.Node.Text == Open_Tally_Job.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Job.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Job.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }
                }

                for (int i = 0; i < Open_Tally_Out.Tallies_Names.Count; i++)
                {
                    if (e.Node.Text == Open_Tally_Out.Tallies_Names[i])
                    {
                        dataView = new DataView(Open_Tally_Out.Tallies[i]);
                        advancedDataGridView1.DataSource = dataView;
                        tab.Text = Open_Tally_Out.Tallies_Names[i];
                        tab.Controls.Add(advancedDataGridView1);
                    }
                }

                if (e.Node.Text == "PRE-JOB" || e.Node.Text == "JOB" || e.Node.Text == "OUT")
                {
                    advancedDataGridView1 = null;
                }

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }

                    if (!Names_of_Tabs.Contains(tab.Text) && advancedDataGridView1 != null)
                    {
                        tabControl1.TabPages.Add(tab);
                        tabControl1.Visible = true;

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
            
        }



        private void Tallies_Manager_Shown(object sender, EventArgs e)
        {
            PRE_JOB_Control.close_tally = true;
            JOB_Control.close_tally = true;
            FINAL_OUTPUT_Control.close_tally = true;
        }
      

        private void Tallies_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            PRE_JOB_Control.close_tally = false;
            JOB_Control.close_tally = false;
            FINAL_OUTPUT_Control.close_tally = false;
            e.Cancel = true;
            this.Hide();
        }

        private void Check_Button_Click(object sender, EventArgs e)
        {

            if (tabControl1.TabCount > 0)
            {
                var grd = tabControl1.SelectedTab.Controls.Cast<Control>()
                                           .FirstOrDefault(x => x is DataGridView);
                var Mygrid = (DataGridView)grd;

                if (comboBox1.SelectedIndex == 0)
                {
                    if (VALUES_FROM_CAFE.MEDIA_ID_LIST.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "MEDIA_ID" || Mygrid.Columns[i].Name == "\"MEDIA_ID\"")
                            {
                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < VALUES_FROM_CAFE.MEDIA_ID_LIST.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null
                                            && Mygrid.Rows[j].Cells[i].Value.ToString().Replace("\"", "") == VALUES_FROM_CAFE.MEDIA_ID_LIST[z])
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            break;
                                        }
                                        else
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Add your media id's!!!");
                    }

                    if (Open_Counts_Input.Counts_INPUT_FILTR.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "GroupCount" || Mygrid.Columns[i].Name == "\"GroupCount\"")
                            {

                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < Open_Counts_Input.Counts_INPUT_FILTR.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null)
                                        {
                                            if (Mygrid.Rows[j].Cells[i].Value.ToString() == (Open_Counts_Input.Counts_INPUT_FILTR[z] - 1).ToString()
                                                || Mygrid.Rows[j].Cells[i].Value.ToString() == (Open_Counts_Input.Counts_INPUT_FILTR[z]).ToString())
                                            {
                                                Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                                Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                                break;
                                            }
                                            else
                                            {
                                                Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                                Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }

                    else
                    {
                        MessageBox.Show("Add your counts!!!");
                    }

                    if (Open_Counts_Input.SUM_OUT > 0)
                    {
                        var last = Mygrid.Columns.Count - 1;

                        for (int i = 0; i < Mygrid.Rows.Count; i++)
                        {
                            if (Mygrid.Rows[i].Cells[0].Value.ToString() == "TOTAL")
                            {
                                if (Mygrid.Rows[i].Cells[last].Value.ToString() ==
                                  (Open_Counts_Input.SUM_OUT - Open_Counts_Input.SUM_DROP + Open_Counts_Input.SUM_HEADER).ToString())
                                {
                                    Mygrid.Rows[i].Cells[last].Style.BackColor = Color.Green;
                                    Mygrid.Rows[i].Cells[0].Style.BackColor = Color.Green;
                                    break;
                                }
                                else
                                {
                                    Mygrid.Rows[i].Cells[last].Style.BackColor = Color.Red;
                                    Mygrid.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }

                if (comboBox1.SelectedIndex == 1)
                {

                    if (VALUES_FROM_CAFE.IMB_SERVICE.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "IMB_SERVICE_TYPE" || Mygrid.Columns[i].Name == "\"IMB_SERVICE_TYPE\"")
                            {
                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < VALUES_FROM_CAFE.IMB_SERVICE.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null
                                            && Mygrid.Rows[j].Cells[i].Value.ToString().Replace("\"", "") == VALUES_FROM_CAFE.IMB_SERVICE[z])
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            break;
                                        }
                                        else
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (VALUES_FROM_CAFE.MAIL_OWNER_MIDS.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "IMB_MAILER_ID" || Mygrid.Columns[i].Name == "\"IMB_MAILER_ID\"")
                            {
                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < VALUES_FROM_CAFE.MAIL_OWNER_MIDS.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null
                                            && Mygrid.Rows[j].Cells[i].Value.ToString().Replace("\"", "") == VALUES_FROM_CAFE.MAIL_OWNER_MIDS[z])
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            break;
                                        }
                                        else
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (VALUES_FROM_CAFE.BOOK_IDS.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "VERSION_CRITERIA" || Mygrid.Columns[i].Name == "\"VERSION_CRITERIA\"")
                            {
                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < VALUES_FROM_CAFE.BOOK_IDS.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null
                                            && Mygrid.Rows[j].Cells[i].Value.ToString().Replace("\"", "") == VALUES_FROM_CAFE.BOOK_IDS[z])
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            break;
                                        }
                                        else
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (VALUES_FROM_CAFE.MEDIA_ID_LIST.Count > 0)
                    {
                        for (int i = 0; i < Mygrid.Columns.Count; i++)
                        {
                            if (Mygrid.Columns[i].Name == "MEDIA_ID" || Mygrid.Columns[i].Name == "\"MEDIA_ID\"")
                            {
                                for (int j = 0; j < Mygrid.Rows.Count; j++)
                                {

                                    for (int z = 0; z < VALUES_FROM_CAFE.MEDIA_ID_LIST.Count; z++)
                                    {
                                        if (Mygrid.Rows[j].Cells[i].Value != null
                                            && Mygrid.Rows[j].Cells[i].Value.ToString().Replace("\"", "") == VALUES_FROM_CAFE.MEDIA_ID_LIST[z])
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                            break;
                                        }
                                        else
                                        {
                                            Mygrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                            Mygrid.Rows[j].Cells[i].Style.ForeColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

