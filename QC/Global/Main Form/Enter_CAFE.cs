using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace QC
{

    public partial class Enter_CAFE : Form
    {
        Form1 ownerForm = null;

        public Enter_CAFE(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circularProgressBar1.Visible = true;
            label2.Visible = true;
            Application.DoEvents();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                circularProgressBar1.Visible = true;
                label2.Visible = true;
                Application.DoEvents();
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void Enter_CAFE_FormClosed(object sender, FormClosedEventArgs e)
        {
            VALUES_FROM_CAFE.Timer.Start();
            this.ownerForm.Show();
            this.ownerForm.Job_Ctrl_bttn.PerformClick();
        }

        private void X_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void X_Button_Enter(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.Red;
        }

        private void X_Button_Leave(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.FromArgb(0, 160, 233);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                Generate_Page generate_Page = new Generate_Page(this);
                generate_Page.Show();
            }));
            
        }
    }


}

