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
    public partial class Add_Flow_Name : Form
    {

        JOB_CONTROL_Control ownerForm = null;
        public Add_Flow_Name(JOB_CONTROL_Control ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flow_name = "";
            if (!VALUES_FROM_CAFE.FLOW_NAMES.Contains(textBox1.Text.Trim()))
            {
                    if (textBox1.Text.Any()) flow_name = textBox1.Text.Trim();
                    if (textBox1.Text.Any()) VALUES_FROM_CAFE.FLOW_NAMES.Add(flow_name);
                
                    if (textBox1.Text.Any())
                    {
                        this.ownerForm.Flows_List.Items.Add(flow_name);
                        this.ownerForm.dataGridView.Rows.Add(flow_name);                       
                        int count = this.ownerForm.Flows_List.Items.Count;
                        this.ownerForm.Flow_Count_ListBox.Items.Add(count + ".");
                    }

                    this.ownerForm.Flow_Empty_Label.Visible = false;               
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string flow_name = "";
                if (!VALUES_FROM_CAFE.FLOW_NAMES.Contains(textBox1.Text.Trim()))
                {
                    if (textBox1.Text.Any()) flow_name = textBox1.Text.Trim();
                    if (textBox1.Text.Any()) VALUES_FROM_CAFE.FLOW_NAMES.Add(flow_name);

                    if (textBox1.Text.Any())
                    {
                        this.ownerForm.Flows_List.Items.Add(flow_name);
                        this.ownerForm.dataGridView.Rows.Add(flow_name);
                        int count = this.ownerForm.Flows_List.Items.Count;
                        this.ownerForm.Flow_Count_ListBox.Items.Add(count + ".");
                    }

                    this.ownerForm.Flow_Empty_Label.Visible = false;
                }
            }
        }

        private void X_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void X_Button_MouseEnter(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.Red;
        }

        private void X_Button_MouseLeave(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.FromArgb(0, 160, 233);
        }
    }
}
