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
    public partial class Edit_Flow_Name : Form
    {
        ListBox List = null;
        DataGridView dataGridView = null;
        int j;
        public Edit_Flow_Name(ListBox list, DataGridView datagridview)
        {
            InitializeComponent();
            List = list;
            dataGridView = datagridview;

            j = List.SelectedIndex;
            string sel_string = List.Items[j].ToString();
            textBox1.Text = sel_string;
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List.Items[j] = textBox1.Text.Trim();
            dataGridView.Rows[j].Cells[0].Value = textBox1.Text.Trim();
            VALUES_FROM_CAFE.FLOW_NAMES[j] = textBox1.Text.Trim();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List.Items[j] = textBox1.Text.Trim();
                dataGridView.Rows[j].Cells[0].Value = textBox1.Text.Trim();
                VALUES_FROM_CAFE.FLOW_NAMES[j] = textBox1.Text.Trim();
            }
        }
    }
}
