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

    public partial class Counts_Manager : Form
    {
        List<string> NAMES_COUNTS_JOB = new List<string>();

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
        public Counts_Manager()
        {
            InitializeComponent();
        }


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Text == Open_Counts_Input.My_File_Name)
            {
                Counts_View CV = new Counts_View("PRE",0, Open_Counts_Input.My_File_Name);
                CV.Show();
            }

            for (int i = 0; i < Open_Counts_Job.My_File_Names.Count; i++)
            {
                if (e.Node.Text == Open_Counts_Job.My_File_Names[i])
                {
                    Counts_View CV = new Counts_View("JOB",i, Open_Counts_Job.My_File_Names[i]);
                    CV.Show();
                }
            }

            if (e.Node.Text == Open_Counts_Output.My_File_Name)
            {
                Counts_View CV = new Counts_View("OUT",0, Open_Counts_Output.My_File_Name);
                CV.Show();
            }
        }

        public void loading()
        {

            #region Input Counts

            int My_Input;

            treeView1.Nodes[0].Nodes.Clear();

            if (Open_Counts_Input.My_File_Name != "")
            {               
                treeView1.Nodes[0].Nodes.Add(Open_Counts_Input.My_File_Name);
            }

            if (Open_Counts_Input.SUM_ORG == Open_Counts_Input.SUM_FILTR)
            {
                Input_label.Text = Open_Counts_Input.SUM_ORG.ToString("N0");
                My_Input = Open_Counts_Input.SUM_ORG - Open_Counts_Input.SUM_DROP;
            }
            else
            {
                Input_label.Text = Open_Counts_Input.SUM_FILTR.ToString("N0");
                My_Input = Open_Counts_Input.SUM_FILTR - Open_Counts_Input.SUM_DROP;
            }

            Output_Input_label.Text = Open_Counts_Input.SUM_OUT.ToString("N0");
            Output_Input_check_label.Text = My_Input.ToString("N0");

            if (Open_Counts_Input.SUM_OUT == My_Input && Open_Counts_Input.SUM_OUT != 0)
            {
                Output_Input_label.ForeColor = Color.Lime;
            }
            else if(Open_Counts_Input.SUM_OUT != My_Input && Open_Counts_Input.SUM_OUT != 0)
            {
                Output_Input_label.ForeColor = Color.Red;
            }

            Drop_Input_label.Text = Open_Counts_Input.SUM_DROP.ToString("N0");
            Header_Input_label.Text = Open_Counts_Input.SUM_HEADER.ToString("N0");

            #endregion

            #region Job Counts

            int My_Pre;

            treeView1.Nodes[1].Nodes.Clear();

            foreach (TreeNode nodes in treeView1.Nodes[1].Nodes)
            {
                NAMES_COUNTS_JOB.Add(nodes.Text);
            }

            if (Open_Counts_Job.My_File_Names.Any())
            {

                foreach (var name in Open_Counts_Job.My_File_Names)
                {
                    if (!NAMES_COUNTS_JOB.Contains(name))
                    {
                        treeView1.Nodes[1].Nodes.Add(name);
                    }
                }
            }
            
            My_Pre = My_Input - Open_Counts_Input.SUM_HEADER - Open_Counts_Job.SUM_DROP_FROM_COUNTS 
                     - Open_Counts_Job.SUM_DROP - Open_Counts_Job.SUM_FOREIGN + Open_Counts_Job.SUM_SEEDS;

            Pre_check_label.Text = My_Pre.ToString("N0");
            Pre_label.Text = Open_Counts_Job.SUM_PRE.ToString("N0");
            Ncoa_label.Text = Open_Counts_Job.SUM_NCOA_PRE.ToString("N0");
            Dsf_label.Text = Open_Counts_Job.SUM_PRE_DSF.ToString("N0");
            Mp_label.Text = Open_Counts_Job.SUM_MP.ToString("N0");
            Variable_label.Text = Open_Counts_Job.SUM_VARIABLE.ToString("N0");
            Drop_Job_label.Text = (Open_Counts_Job.SUM_DROP_FROM_COUNTS + Open_Counts_Job.SUM_DROP).ToString("N0");
            Foreign_label.Text = Open_Counts_Job.SUM_FOREIGN.ToString("N0");
            Seeds_label.Text = Open_Counts_Job.SUM_SEEDS.ToString("N0");

            if (Open_Counts_Job.SUM_PRE == My_Pre && Open_Counts_Job.SUM_PRE != 0)
            {
                Pre_label.ForeColor = Color.Lime;
            }
            else if(Open_Counts_Job.SUM_PRE != My_Pre && Open_Counts_Job.SUM_PRE != 0)
            {
                Pre_label.ForeColor = Color.Red;
            }

            #endregion

            #region Output Counts

            int My_Out;

            treeView1.Nodes[2].Nodes.Clear();

            if (Open_Counts_Output.My_File_Name != "")
            {                
                treeView1.Nodes[2].Nodes.Add(Open_Counts_Output.My_File_Name);
            }

            My_Out = My_Pre - Open_Counts_Output.SUM_UNQ + Open_Counts_Job.SUM_FOREIGN;

            Add_check_label.Text = My_Out.ToString("N0");
            Add_label.Text = Open_Counts_Output.SUM_ADD.ToString("N0");
            Csv_label.Text = Open_Counts_Output.SUM_CSV.ToString("N0");
            Unq_label.Text = Open_Counts_Output.SUM_UNQ.ToString("N0");
            Open_Counts_Output.SUM_ADD_CORRECTIONS.ToString("N0");
            Open_Counts_Output.SUM_CSV_CORRECTIONS.ToString("N0");
            Csv_Header_label.Text = Open_Counts_Output.SUM_CSV_HEADER.ToString("N0");


            if (Open_Counts_Output.SUM_ADD == My_Out && Open_Counts_Output.SUM_ADD != 0)
            {
                Add_label.ForeColor = Color.Lime;
            }
            else if(Open_Counts_Output.SUM_ADD != My_Out && Open_Counts_Output.SUM_ADD != 0)
            {
                Add_label.ForeColor = Color.Red;
            }

            #endregion

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                ColorChild(treeView1.Nodes[i]);
            }

            treeView1.ExpandAll();
        }

        private void Counts_Manager_Shown(object sender, EventArgs e)
        {
            PRE_JOB_Control.close_counts = true;
            JOB_Control.close_counts = true;
            FINAL_OUTPUT_Control.close_counts = true;
            SECOND_QC_Control.close_counts = true;
        }

        private void Counts_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            PRE_JOB_Control.close_counts = false;
            JOB_Control.close_counts = false;
            FINAL_OUTPUT_Control.close_counts = false;
            SECOND_QC_Control.close_counts = false;
            e.Cancel = true;
            this.Hide();
        }
    }
}

