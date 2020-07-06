using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QC
{
    public partial class Comment : Form
    {
        string Stage;
        int Comment_index;
        Button Button_B = null;

        void Saving(ref string comment)
        {
            if (richTextBox1.Text.Any())
            {
                comment = richTextBox1.Rtf;
                Button_B.BackColor = Color.FromArgb(0, 160, 233);
                Button_B.ForeColor = Color.White;
            }
            else
            {
                comment = null;
                Button_B.BackColor = Color.FromArgb(60, 60, 60);
                Button_B.ForeColor = Color.White;
            }
        }

        void Opening(string comment)
        {
            if (comment != null)
            {
                richTextBox1.Rtf = comment;
            }
        }
        public Comment(string stage, int comment_index,Button button_b)
        {
            Stage = stage;
            Comment_index = comment_index;
            Button_B = button_b;
            InitializeComponent();
        }

        private void Comment_Load(object sender, EventArgs e)
        {
            if (Stage == "PRE")
            {
                if (Comment_index == 0) Opening(All_Coments_Storage.Comment_PRE_0);
                if (Comment_index == 1) Opening(All_Coments_Storage.Comment_PRE_1);
                if (Comment_index == 2) Opening(All_Coments_Storage.Comment_PRE_2);
                if (Comment_index == 3) Opening(All_Coments_Storage.Comment_PRE_3);
                if (Comment_index == 4) Opening(All_Coments_Storage.Comment_PRE_4);
                if (Comment_index == 5) Opening(All_Coments_Storage.Comment_PRE_5);
                if (Comment_index == 6) Opening(All_Coments_Storage.Comment_PRE_6);
            }

            if (Stage == "JOB")
            {
                if (Comment_index == 0) Opening(All_Coments_Storage.Comment_JOB_0);
                if (Comment_index == 1) Opening(All_Coments_Storage.Comment_JOB_1);
                if (Comment_index == 2) Opening(All_Coments_Storage.Comment_JOB_2);
                if (Comment_index == 3) Opening(All_Coments_Storage.Comment_JOB_3);
                if (Comment_index == 4) Opening(All_Coments_Storage.Comment_JOB_4);
                if (Comment_index == 5) Opening(All_Coments_Storage.Comment_JOB_5);
                if (Comment_index == 6) Opening(All_Coments_Storage.Comment_JOB_6);
                if (Comment_index == 7) Opening(All_Coments_Storage.Comment_JOB_7);
                if (Comment_index == 8) Opening(All_Coments_Storage.Comment_JOB_8);
            }

            if (Stage == "PF")
            {
                if (Comment_index == 0) Opening(All_Coments_Storage.Comment_PF_0);
                if (Comment_index == 1) Opening(All_Coments_Storage.Comment_PF_1);
            }

            if (Stage == "OUT")
            {
                if (Comment_index == 0) Opening(All_Coments_Storage.Comment_OUT_0);
                if (Comment_index == 1) Opening(All_Coments_Storage.Comment_OUT_1);
                if (Comment_index == 2) Opening(All_Coments_Storage.Comment_OUT_2);
                if (Comment_index == 3) Opening(All_Coments_Storage.Comment_OUT_3);
                if (Comment_index == 4) Opening(All_Coments_Storage.Comment_OUT_4);
                if (Comment_index == 5) Opening(All_Coments_Storage.Comment_OUT_5);
                if (Comment_index == 6) Opening(All_Coments_Storage.Comment_OUT_6);
                if (Comment_index == 7) Opening(All_Coments_Storage.Comment_OUT_7);
                if (Comment_index == 8) Opening(All_Coments_Storage.Comment_OUT_8);
                if (Comment_index == 9) Opening(All_Coments_Storage.Comment_OUT_9);
                if (Comment_index == 10) Opening(All_Coments_Storage.Comment_OUT_10);
                if (Comment_index == 11) Opening(All_Coments_Storage.Comment_OUT_11);
            }

        }

        private void Comment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Stage == "PRE")
            {
                if (Comment_index == 0) Saving(ref All_Coments_Storage.Comment_PRE_0);
                if (Comment_index == 1) Saving(ref All_Coments_Storage.Comment_PRE_1);
                if (Comment_index == 2) Saving(ref All_Coments_Storage.Comment_PRE_2);
                if (Comment_index == 3) Saving(ref All_Coments_Storage.Comment_PRE_3);
                if (Comment_index == 4) Saving(ref All_Coments_Storage.Comment_PRE_4);
                if (Comment_index == 5) Saving(ref All_Coments_Storage.Comment_PRE_5);
                if (Comment_index == 6) Saving(ref All_Coments_Storage.Comment_PRE_6);
            }

            if (Stage == "JOB")
            {
                if (Comment_index == 0) Saving(ref All_Coments_Storage.Comment_JOB_0);
                if (Comment_index == 1) Saving(ref All_Coments_Storage.Comment_JOB_1);
                if (Comment_index == 2) Saving(ref All_Coments_Storage.Comment_JOB_2);
                if (Comment_index == 3) Saving(ref All_Coments_Storage.Comment_JOB_3);
                if (Comment_index == 4) Saving(ref All_Coments_Storage.Comment_JOB_4);
                if (Comment_index == 5) Saving(ref All_Coments_Storage.Comment_JOB_5);
                if (Comment_index == 6) Saving(ref All_Coments_Storage.Comment_JOB_6);
                if (Comment_index == 7) Saving(ref All_Coments_Storage.Comment_JOB_7);
                if (Comment_index == 8) Saving(ref All_Coments_Storage.Comment_JOB_8);
            }

            if (Stage == "PF")
            {
                if(Comment_index == 0) Saving(ref All_Coments_Storage.Comment_PF_0);
                if(Comment_index == 1) Saving(ref All_Coments_Storage.Comment_PF_1);
            }

            if (Stage == "OUT")
            {
                if (Comment_index == 0) Saving(ref All_Coments_Storage.Comment_OUT_0);
                if (Comment_index == 1) Saving(ref All_Coments_Storage.Comment_OUT_1);
                if (Comment_index == 2) Saving(ref All_Coments_Storage.Comment_OUT_2);
                if (Comment_index == 3) Saving(ref All_Coments_Storage.Comment_OUT_3);
                if (Comment_index == 4) Saving(ref All_Coments_Storage.Comment_OUT_4);
                if (Comment_index == 5) Saving(ref All_Coments_Storage.Comment_OUT_5);
                if (Comment_index == 6) Saving(ref All_Coments_Storage.Comment_OUT_6);
                if (Comment_index == 7) Saving(ref All_Coments_Storage.Comment_OUT_7);
                if (Comment_index == 8) Saving(ref All_Coments_Storage.Comment_OUT_8);
                if (Comment_index == 9) Saving(ref All_Coments_Storage.Comment_OUT_9);
                if (Comment_index == 10) Saving(ref All_Coments_Storage.Comment_OUT_10);
                if (Comment_index == 11) Saving(ref All_Coments_Storage.Comment_OUT_11);
            }

        }


        private void X_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
