using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu;

namespace QC
{
    public partial class Add_MEDIA_ID : Form
    {
        JOB_CONTROL_Control ownerForm = null;
        public Add_MEDIA_ID(JOB_CONTROL_Control ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string media_id = "";
            if (!VALUES_FROM_CAFE.MEDIA_ID_LIST.Contains(textBox1.Text.Trim()))
            {
                if (textBox1.Text.Any()) media_id = textBox1.Text.Trim();
                if (textBox1.Text.Any()) VALUES_FROM_CAFE.MEDIA_ID_LIST.Add(media_id);
                if (textBox1.Text.Any())
                {
                    this.ownerForm.Media_Id_List.Items.Add(media_id);
                    int count = this.ownerForm.Media_Id_List.Items.Count;
                    this.ownerForm.Media_Count_ListBox.Items.Add(count + ".");
                }
                this.ownerForm.Media_Id_Empty_label.Visible = false;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string media_id = "";
                if (!VALUES_FROM_CAFE.MEDIA_ID_LIST.Contains(textBox1.Text.Trim()))
                {
                    if (textBox1.Text.Any()) media_id = textBox1.Text.Trim();
                    if (textBox1.Text.Any()) VALUES_FROM_CAFE.MEDIA_ID_LIST.Add(media_id);
                    if (textBox1.Text.Any()) 
                    {
                        this.ownerForm.Media_Id_List.Items.Add(media_id);
                        int count = this.ownerForm.Media_Id_List.Items.Count;
                        this.ownerForm.Media_Count_ListBox.Items.Add(count + ".");
                    }
                    this.ownerForm.Media_Id_Empty_label.Visible = false;
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

