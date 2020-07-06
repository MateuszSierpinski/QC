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
    public partial class Analyzers_Manager : Form
    {
   
        List<string> Names_of_Nodes_PRE = new List<string>();
        List<string> Names_of_Nodes_JOB = new List<string>();
        List<string> Names_of_Nodes_OUT = new List<string>();

        //void checkProcentage(string row, int i )
        //{
        //    if (row == "MEDIA_ID")
        //    {
        //        Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

        //        var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
        //        var proc_dec = Convert.ToDecimal(proc_txt);

        //        if (proc_dec == 100)
        //        {
        //            Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
        //        }
        //        else
        //        {
        //            Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
        //            Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
        //        }
        //    }
        //}
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

        void Non_Sort(DataGridView cos)
        {
            foreach (DataGridViewColumn column in cos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        public Analyzers_Manager()
        {

            InitializeComponent();

            tabControl1.Visible = false;
            comboBox1.SelectedIndex = 0;

            Loading();

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (Analyzer_Panel.Visible && treeView1.SelectedNode != null)
            {
                TabPage tab = new TabPage();
                tab.BackColor = Color.FromArgb(50, 50, 50);
                tab.BorderStyle = BorderStyle.None;


                DataGridView My_data = new DataGridView();
                My_data.BackgroundColor = Color.FromArgb(50, 50, 50);
                My_data.ReadOnly= true;
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

                List<string> Names_of_Tabs = new List<string>();

                for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                {

                    if (e.Node.Text == Analyzers_Input.Name_List[i])
                    {
                        DataView dataView = new DataView(Analyzers_Input.Analyzers_List[i]);
                        My_data.DataSource = dataView;
                        tab.Text = Analyzers_Input.Name_List[i];
                        tab.Controls.Add(My_data);
                    }
                }

                for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                {

                    if (e.Node.Text == Analyzers_Job.Name_List[i])
                    {
                        DataView dataView = new DataView(Analyzers_Job.Analyzers_List[i]);
                        My_data.DataSource = dataView;
                        tab.Text = Analyzers_Job.Name_List[i];
                        tab.Controls.Add(My_data);
                    }

                }

                for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                {

                    if (e.Node.Text == Analyzers_Out.Name_List[i])
                    {
                        DataView dataView = new DataView(Analyzers_Out.Analyzers_List[i]);
                        My_data.DataSource = dataView;
                        tab.Text = Analyzers_Out.Name_List[i];
                        tab.Controls.Add(My_data);
                    }

                }

                if (e.Node.Text == "PRE-JOB" || e.Node.Text == "JOB" || e.Node.Text == "OUT")
                {
                    My_data = null;
                }

                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    Names_of_Tabs.Add(tabControl1.TabPages[i].Text);
                }

                if (My_data != null)
                {
                    if (!Names_of_Tabs.Contains(tab.Text))
                    {
                        tabControl1.TabPages.Add(tab);
                        Non_Sort(My_data);
                        tabControl1.Visible = true;
                    }

                    My_data.ClearSelection();
                }
            }
        }

        public void Loading()
        {
            treeView1.Nodes[0].Nodes.Clear();

            foreach (TreeNode nodes in treeView1.Nodes[0].Nodes)
            {
                Names_of_Nodes_PRE.Add(nodes.Text);
            }

            if (Analyzers_Input.Name_List.Any())
            {
                foreach (var name in Analyzers_Input.Name_List)
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

            if (Analyzers_Job.Name_List.Any())
            {
                foreach (var name in Analyzers_Job.Name_List)
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

            if (Analyzers_Out.Name_List.Any())
            {
                foreach (var name in Analyzers_Out.Name_List)
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

        private void Analyzers_Manager_Shown(object sender, EventArgs e)
        {
            PRE_JOB_Control.close = true;
            JOB_Control.close = true;
            FINAL_OUTPUT_Control.close = true;
            SECOND_QC_Control.close = true;
        }

        private void Analyzers_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            PRE_JOB_Control.close = false;
            JOB_Control.close = false;
            FINAL_OUTPUT_Control.close = false;
            SECOND_QC_Control.close = false;
            e.Cancel = true;
            this.Hide();
        }


        private void Analyzers_Label_Click(object sender, EventArgs e)
        {
            Analyzers_Label.ForeColor = Color.White;
            Compare_Label.ForeColor = Color.DimGray;

            Compare_Hi_Panel.Visible = false;
            Analyzers_Hi_Panel.Visible = true;

            Compare_Panel.Visible = false;
            Analyzer_Panel.Visible = true;           

        }

        private void Analyzers_Label_MouseEnter(object sender, EventArgs e)
        {
            Analyzers_Label.ForeColor = Color.White;
            Analyzers_Hi_Panel.Visible = true;
        }

        private void Analyzers_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Analyzer_Panel.Visible)
            {
                Analyzers_Label.ForeColor = Color.White;
                Analyzers_Hi_Panel.Visible = true;
            }
            else
            {
                Analyzers_Label.ForeColor = Color.DimGray;
                Analyzers_Hi_Panel.Visible = false;
            }
        }

        private void Compare_Label_Click(object sender, EventArgs e)
        {
            Analyzers_Label.ForeColor = Color.DimGray;
            Compare_Label.ForeColor = Color.White;

            Compare_Hi_Panel.Visible = true;
            Analyzers_Hi_Panel.Visible = false;

            Compare_Panel.Visible = true;
            Analyzer_Panel.Visible = false;
        }

        private void Compare_Label_MouseEnter(object sender, EventArgs e)
        {
            Compare_Hi_Panel.Visible = true;
            Compare_Label.ForeColor = Color.White;
        }

        private void Compare_Label_MouseLeave(object sender, EventArgs e)
        {
            if (Compare_Panel.Visible)
            {
                Compare_Hi_Panel.Visible = true;
                Compare_Label.ForeColor = Color.White;
            }
            else
            {
                Compare_Hi_Panel.Visible = false;
                Compare_Label.ForeColor = Color.DimGray;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ListBox_Of_Anlyzers_Input.Items.Clear();
                ListBox_Of_Anlyzers_Input.Location = new Point(100, 300);
                ListBox_Of_Anlyzers_Input.Size = new Size(265, 19);
                Clear_1.Location = new Point(175, 355);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                ListBox_Of_Anlyzers_Input.Items.Clear();
                ListBox_Of_Anlyzers_Input.Location = new Point(100, 240);
                ListBox_Of_Anlyzers_Input.Size = new Size(265, 152);
                Clear_1.Location = new Point(175, 407);
            }
        }

        private void Clear_1_Click(object sender, EventArgs e)
        {
            ListBox_Of_Anlyzers_Input.Items.Clear();
        }

        private void Clear_2_Click(object sender, EventArgs e)
        {
            ListBox_Of_Anlyzers_Output.Items.Clear();
        }

        private void ListBox_Of_Anlyzers_Output_DragDrop(object sender, DragEventArgs e)
        {
            ListBox_Of_Anlyzers_Output.Items.Clear();
            ListBox_Of_Anlyzers_Output.Items.Add(e.Data.GetData(DataFormats.Text));
        }

        private void ListBox_Of_Anlyzers_Output_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBox_Of_Anlyzers_Input_DragDrop(object sender, DragEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ListBox_Of_Anlyzers_Input.Items.Clear();
                ListBox_Of_Anlyzers_Input.Items.Add(e.Data.GetData(DataFormats.Text));
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (!ListBox_Of_Anlyzers_Input.Items.Contains(e.Data.GetData(DataFormats.Text)))
                {
                    ListBox_Of_Anlyzers_Input.Items.Add(e.Data.GetData(DataFormats.Text));
                }
            }
        }

        private void ListBox_Of_Anlyzers_Input_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListBox_Of_Anlyzers_Input.DoDragDrop(treeView1.SelectedNode.Text.ToString(), DragDropEffects.Copy);
        }

        private void Compare_Button_Click(object sender, EventArgs e)
        {
            DataTable Table_Input = new DataTable();
            DataTable Table_Output = new DataTable();
            List<DataTable> Table_Input_List = new List<DataTable>();

            if (ListBox_Of_Anlyzers_Input.Items.Count == 1 && ListBox_Of_Anlyzers_Output.Items.Count == 1)
            {
                if (Analyzers_Input.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Input.Items[0].ToString() == Analyzers_Input.Name_List[i])
                        {
                            Table_Input = Analyzers_Input.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Job.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Input.Items[0].ToString() == Analyzers_Job.Name_List[i])
                        {
                            Table_Input = Analyzers_Job.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Out.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Input.Items[0].ToString() == Analyzers_Out.Name_List[i])
                        {
                            Table_Input = Analyzers_Out.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Input.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Input.Name_List[i])
                        {
                            Table_Output = Analyzers_Input.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Job.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Job.Name_List[i])
                        {
                            Table_Output = Analyzers_Job.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Out.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Out.Name_List[i])
                        {
                            Table_Output = Analyzers_Out.Analyzers_List[i];
                        }
                    }
                }

                Table_Input_List = null;
                Compare_View CV = new Compare_View(Table_Input, Table_Output, Table_Input_List);
                CV.Show();
            }

            if (ListBox_Of_Anlyzers_Input.Items.Count > 1 && ListBox_Of_Anlyzers_Output.Items.Count == 1)
            {
                if (Analyzers_Input.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                    {
                        for (int j = 0; j < ListBox_Of_Anlyzers_Input.Items.Count; j++)
                        {
                            if (ListBox_Of_Anlyzers_Input.Items[j].ToString() == Analyzers_Input.Name_List[i])
                            {
                                Table_Input_List.Add(Analyzers_Input.Analyzers_List[i]);
                            }
                        }
                    }
                }

                if (Analyzers_Job.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                    {
                        for (int j = 0; j < ListBox_Of_Anlyzers_Input.Items.Count; j++)
                        {
                            if (ListBox_Of_Anlyzers_Input.Items[j].ToString() == Analyzers_Job.Name_List[i])
                            {
                                Table_Input_List.Add(Analyzers_Input.Analyzers_List[i]);
                            }
                        }
                    }
                }

                if (Analyzers_Out.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                    {
                        for (int j = 0; j < ListBox_Of_Anlyzers_Input.Items.Count; j++)
                        {
                            if (ListBox_Of_Anlyzers_Input.Items[j].ToString() == Analyzers_Out.Name_List[i])
                            {
                                Table_Input_List.Add(Analyzers_Input.Analyzers_List[i]);
                            }
                        }
                    }
                }


                if (Analyzers_Input.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Input.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Input.Name_List[i])
                        {
                            Table_Output = Analyzers_Input.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Job.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Job.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Job.Name_List[i])
                        {
                            Table_Output = Analyzers_Job.Analyzers_List[i];
                        }
                    }
                }

                if (Analyzers_Out.Name_List.Any())
                {
                    for (int i = 0; i < Analyzers_Out.Name_List.Count; i++)
                    {
                        if (ListBox_Of_Anlyzers_Output.Items[0].ToString() == Analyzers_Out.Name_List[i])
                        {
                            Table_Output = Analyzers_Out.Analyzers_List[i];
                        }
                    }
                }

                Compare_View CV = new Compare_View(Table_Input, Table_Output, Table_Input_List);
                CV.Show();
            }
        }

        private void Check_Button_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabCount > 0)
            {
                var grd = tabControl1.SelectedTab.Controls.Cast<Control>()
                           .FirstOrDefault(x => x is DataGridView);
                var Mygrid = (DataGridView)grd;

                if (comboBox2.SelectedIndex == 0)
                {
                    for (int i = 0; i < Mygrid.RowCount;  i++)
                    {
                        string row = Mygrid.Rows[i].Cells[0].Value.ToString();
                        if (row == "ZIP")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                            if (Mygrid.Rows[i].Cells[1].Value.ToString() == "5")
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[1].Style.ForeColor = Color.White;
                            }
                            if (Mygrid.Rows[i].Cells[2].Value.ToString() == "5")
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[2].Style.ForeColor = Color.White;
                            }
                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);
                            if (proc_dec > 98)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }

                        }

                        if (row == "ZIP4")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                            if (Mygrid.Rows[i].Cells[1].Value.ToString() == "4")
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[1].Style.ForeColor = Color.White;
                            }
                            if (Mygrid.Rows[i].Cells[2].Value.ToString() == "4")
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[2].Style.ForeColor = Color.White;
                            }
                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);
                            if (proc_dec > 80)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }

                        }

                        if (row == "DPBC")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                            if (Mygrid.Rows[i].Cells[1].Value.ToString() == "2"
                                || Mygrid.Rows[i].Cells[1].Value.ToString() == "3")
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[1].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[1].Style.ForeColor = Color.White;
                            }
                            if (Mygrid.Rows[i].Cells[2].Value.ToString() == "2"
                                || Mygrid.Rows[i].Cells[1].Value.ToString() == "3")
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[2].Style.ForeColor = Color.White;
                            }
                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);
                            if (proc_dec > 80)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }

                        }
                        if (row == "LINE_1")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            if(proc_dec >= 80 && proc_dec < 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                            

                        if (row == "CITY")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }

                        if (row == "STATE")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                        if (row == "MEDIA_ID")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                        if (row == "RecordID")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                        if (row == "IMB_SERVICE_TYPE")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                        if (row == "IMB_MAILER_ID")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                        if (row == "VERSION_CRITERIA")
                        {
                            Mygrid.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;

                            var proc_txt = Mygrid.Rows[i].Cells[6].Value.ToString().Replace("%", "").Trim();
                            var proc_dec = Convert.ToDecimal(proc_txt);

                            if (proc_dec == 100)
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.LimeGreen;
                            }
                            else
                            {
                                Mygrid.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                Mygrid.Rows[i].Cells[6].Style.ForeColor = Color.White;
                            }
                        }
                            
                    }
                }

                if(comboBox2.SelectedIndex == 1)
                {

                }
            }
        }

        
    }
}




