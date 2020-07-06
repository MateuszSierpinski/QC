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
    public partial class Edit_MEDIA_ID : Form
    {
        ListBox List = null;
        int j;
        public Edit_MEDIA_ID(ListBox list)
        {            
            InitializeComponent();
            List = list;
            j = List.SelectedIndex;
            string sel_string = List.Items[j].ToString();
            textBox1.Text = sel_string;
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.Select();
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Any()) List.Items[j] = textBox1.Text.Trim();
            if(textBox1.Text.Trim().Any()) VALUES_FROM_CAFE.MEDIA_ID_LIST[j] = textBox1.Text.Trim();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Trim().Any()) List.Items[j] = textBox1.Text.Trim();
                if (textBox1.Text.Trim().Any()) VALUES_FROM_CAFE.MEDIA_ID_LIST[j] = textBox1.Text.Trim();
            }
        }
    }
}
