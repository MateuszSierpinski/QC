using QC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QC
{
    public partial class Form1 : Form
    {
        private readonly LeaderSequence _leaderSequence = new LeaderSequence();

        public Form1()
        {
            InitializeComponent();
            VALUES_FROM_CAFE.dodaj();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
            label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
        }

        //private const int cGrip = 16;
        //private const int cCaption = 31;
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x84)
        //    {
        //        Point pos = new Point(m.LParam.ToInt32());
        //        pos = this.PointToClient(pos);
        //        if (pos.Y < cCaption)
        //        {
        //            m.Result = (IntPtr)2;
        //            return;
        //        }
        //        if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
        //        {
        //            m.Result = (IntPtr)17;
        //            return;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}


        public void Job_Ctrl_bttn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            Job_Ctrl_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = true;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Job_Ctrl_bttn.Height;
            Yellow_panel.Top = Job_Ctrl_bttn.Top;
        }

        private void Pre_Job_bttn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;


            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = true;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Pre_Job_bttn.Height;
            Yellow_panel.Top = Pre_Job_bttn.Top;

        }

        private void Job_bttn_Click(object sender, EventArgs e)
        {

            label1.Visible = false;

            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(0, 126, 184);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = true;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Job_bttn.Height;
            Yellow_panel.Top = Job_bttn.Top;
        }


        private void PF_bttn_Click(object sender, EventArgs e)
        {

            label1.Visible = false;

            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = true;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = PF_bttn.Height;
            Yellow_panel.Top = PF_bttn.Top;
        }

        private void Final_Output_bttn_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = true;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Final_Output_bttn.Height;
            Yellow_panel.Top = Final_Output_bttn.Top;
        }

        private void Second_Qc_bttn_Click(object sender, EventArgs e)
        {
            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = true;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Second_Qc_bttn.Height;
            Yellow_panel.Top = Second_Qc_bttn.Top;
        }

        private void Archive_bttn_Click(object sender, EventArgs e)
        {
            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(0, 126, 184);
            Leaders_bttn.BackColor = Color.FromArgb(60, 60, 60);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = true;
            leaderS_Control1.Visible = false;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Archive_bttn.Height;
            Yellow_panel.Top = Archive_bttn.Top;
        }

        private void Leaders_bttn_Click(object sender, EventArgs e)
        {
            Job_Ctrl_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Pre_Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Job_bttn.BackColor = Color.FromArgb(60, 60, 60);
            PF_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Final_Output_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Second_Qc_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Archive_bttn.BackColor = Color.FromArgb(60, 60, 60);
            Leaders_bttn.BackColor = Color.FromArgb(0, 126, 184);

            joB_CONTROL_Control1.Visible = false;
            prE_JOB_Control1.Visible = false;
            joB_Control1.Visible = false;
            pF_Control1.Visible = false;
            finaL_OUTPUT_Control1.Visible = false;
            seconD_QC_Control1.Visible = false;
            archivE_Control1.Visible = false;
            leaderS_Control1.Visible = true;

            Yellow_panel.Visible = true;
            Yellow_panel.Height = Leaders_bttn.Height;
            Yellow_panel.Top = Leaders_bttn.Top;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void X_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Create_QC_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            label1.Visible = false;
            Stage_Panel.Visible = true;
            Enter_CAFE EC = new Enter_CAFE(this);
            EC.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
                label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
                label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
            }
        }

        private void MINIMIZE_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
            label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
        }

        private void X_Button_Enter(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.Red;
        }

        private void X_Button_Leave(object sender, EventArgs e)
        {
            X_Button.BackColor = Color.FromArgb(0, 160, 233);
        }

        private void PictureBox_MENU_Click(object sender, EventArgs e)
        {
            if (Stage_Panel.Visible)
            {
                Stage_Panel.Visible = false;

                joB_CONTROL_Control1.Location = new Point(0, 40);
                prE_JOB_Control1.Location = new Point(0, 40);
                joB_Control1.Location = new Point(0, 40);
                pF_Control1.Location = new Point(0, 40);
                finaL_OUTPUT_Control1.Location = new Point(0, 40);

                joB_CONTROL_Control1.Width = this.Width;
                prE_JOB_Control1.Width = this.Width;
                joB_Control1.Width = this.Width;
                pF_Control1.Width = this.Width;
                finaL_OUTPUT_Control1.Width = this.Width;

            }
            else
            {
                Stage_Panel.Visible = true;

                joB_CONTROL_Control1.Location = new Point(100, 40);
                prE_JOB_Control1.Location = new Point(100, 40);
                joB_Control1.Location = new Point(100, 40);
                pF_Control1.Location = new Point(100, 40);
                finaL_OUTPUT_Control1.Location = new Point(100, 40);

                joB_CONTROL_Control1.Width = this.Width - 100;
                prE_JOB_Control1.Width = this.Width - 100;
                joB_Control1.Width = this.Width - 100;
                pF_Control1.Width = this.Width - 100;
                finaL_OUTPUT_Control1.Width = this.Width - 100;
            }
        }

        private void Control_Panel_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
                label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                label1.Left = (label1.Parent.Width / 2) - (label1.Width / 2);
                label1.Top = (label1.Parent.Height / 2) - (label1.Height / 2);
            }
        }

        private void PictureBox_MENU_MouseEnter(object sender, EventArgs e)
        {
            PictureBox_MENU.Image = Resources.list_2_24;

        }

        private void PictureBox_MENU_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_MENU.Image = Resources.list_2_32;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_leaderSequence.IsCompletedBy(e.KeyCode))
                Leaders_bttn.Visible = true;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            //Put all data in qc

            string dir = @"C:\Users\MaSierpinski\Desktop\Potrzebne\" + $"{VALUES_FROM_CAFE.Cafe}" + @"\" + $"{VALUES_FROM_CAFE.Cafe}";

            string Val_from_cafe = dir + @"\" + @"\Values From Cafe\";

            string Pre_job = dir + @"\" + @"\Pre Job\";

            string Job = dir + @"\" + @"\Job\";

            string Pf = dir + @"\" + @"\Presort\";

            string Out = dir  + @"\" + @"\Output\";

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!Directory.Exists(Val_from_cafe)) Directory.CreateDirectory(Val_from_cafe);
            if (!Directory.Exists(Pre_job)) Directory.CreateDirectory(Pre_job);
            if (!Directory.Exists(Job)) Directory.CreateDirectory(Job);
            if (!Directory.Exists(Pf)) Directory.CreateDirectory(Pf);
            if (!Directory.Exists(Out)) Directory.CreateDirectory(Out);

            XmlSerializer serializer_int = new XmlSerializer(typeof(int));
            XmlSerializer serializer_bool = new XmlSerializer(typeof(bool));
            XmlSerializer serializer_double = new XmlSerializer(typeof(double));
            XmlSerializer serializer_string = new XmlSerializer(typeof(string));           
            XmlSerializer serializer_int_list = new XmlSerializer(typeof(List<int>));
            XmlSerializer serializer_string_list = new XmlSerializer(typeof(List<string>));
            XmlSerializer serializer_string_array = new XmlSerializer(typeof(string[]));
            XmlSerializer serializer_list_string_array = new XmlSerializer(typeof(List<string[]>)); 
            XmlSerializer serializer_datatable_list = new XmlSerializer(typeof(List<DataTable>));
            XmlSerializer serializer_list_int_list = new XmlSerializer(typeof(List<List<int>>));

            #region Values from Cafe Save

            XamlServices.Save(Val_from_cafe + "MEDIA_ID_LIST", VALUES_FROM_CAFE.MEDIA_ID_LIST);
            XamlServices.Save(Val_from_cafe + "FLOW_NAMES", VALUES_FROM_CAFE.FLOW_NAMES);
            XamlServices.Save(Val_from_cafe + "CAFES", VALUES_FROM_CAFE.CAFES);
            XamlServices.Save(Val_from_cafe + "IMB_SERVICE", VALUES_FROM_CAFE.IMB_SERVICE);
            XamlServices.Save(Val_from_cafe + "MAIL_OWNER_MIDS", VALUES_FROM_CAFE.MAIL_OWNER_MIDS);
            XamlServices.Save(Val_from_cafe + "BOOK_IDS", VALUES_FROM_CAFE.BOOK_IDS);
            XamlServices.Save(Val_from_cafe + "MPU_IDS", VALUES_FROM_CAFE.MPU_IDS);

            //SIE USUNIE
            XamlServices.Save(Val_from_cafe + "Cafe", VALUES_FROM_CAFE.Cafe);

            XamlServices.Save(Val_from_cafe + "TitleCode", VALUES_FROM_CAFE.TitleCode);
            XamlServices.Save(Val_from_cafe + "JobNumber", VALUES_FROM_CAFE.JobNumber);
            XamlServices.Save(Val_from_cafe + "Ncoa18_Path", VALUES_FROM_CAFE.Ncoa18_Path);
            XamlServices.Save(Val_from_cafe + "Dsf_Path", VALUES_FROM_CAFE.Dsf_Path);
            XamlServices.Save(Val_from_cafe + "MailClass", VALUES_FROM_CAFE.MailClass);
            XamlServices.Save(Val_from_cafe + "PresortType", VALUES_FROM_CAFE.PresortType);
            XamlServices.Save(Val_from_cafe + "IMB", VALUES_FROM_CAFE.IMB);
            XamlServices.Save(Val_from_cafe + "OutputTypeLaser", VALUES_FROM_CAFE.OutputTypeLaser);
            XamlServices.Save(Val_from_cafe + "PrintLocationLaser", VALUES_FROM_CAFE.PrintLocationLaser);
            XamlServices.Save(Val_from_cafe + "OutputTypeInkjet", VALUES_FROM_CAFE.OutputTypeInkjet);
            XamlServices.Save(Val_from_cafe + "PrintLocationInkjet", VALUES_FROM_CAFE.PrintLocationInkjet);

            XamlServices.Save(Val_from_cafe + "Validation", VALUES_FROM_CAFE.Validation);
            XamlServices.Save(Val_from_cafe + "Ncoa18", VALUES_FROM_CAFE.Ncoa18);
            XamlServices.Save(Val_from_cafe + "Ncoa48", VALUES_FROM_CAFE.Ncoa48);
            XamlServices.Save(Val_from_cafe + "Quad_Seeds", VALUES_FROM_CAFE.Quad_Seeds);
            XamlServices.Save(Val_from_cafe + "Dsf", VALUES_FROM_CAFE.Dsf);
            XamlServices.Save(Val_from_cafe + "Pick_Up", VALUES_FROM_CAFE.Pick_Up);
            XamlServices.Save(Val_from_cafe + "Merge_Purge", VALUES_FROM_CAFE.Merge_Purge);

            XamlServices.Save(Val_from_cafe + "richText", VALUES_FROM_CAFE.richText);
            VALUES_FROM_CAFE.Processing_Time = VALUES_FROM_CAFE.Processing_Time + VALUES_FROM_CAFE.Timer.Elapsed;
            VALUES_FROM_CAFE.Timer.Restart();
            XamlServices.Save(Val_from_cafe + "Time", VALUES_FROM_CAFE.Processing_Time);

            #endregion

            #region Pre Job Save

            //Analyzers Input
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Analyzers_Input.Name_List"))
                serializer_string_list.Serialize(streamwriter, Analyzers_Input.Name_List);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Analyzers_Input.Analyzers_List"))
                serializer_datatable_list.Serialize(streamwriter, Analyzers_Input.Analyzers_List);

            //Tallies Input
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Tally_Input.Tallies_Names"))
                serializer_string_list.Serialize(streamwriter, Open_Tally_Input.Tallies_Names);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Tally_Input.Tallies"))
                serializer_datatable_list.Serialize(streamwriter, Open_Tally_Input.Tallies);

            //Counts Input
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.Counts_INPUT_ORG"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Input.Counts_INPUT_ORG);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.SUM_ORG"))
                serializer_int.Serialize(streamwriter, Open_Counts_Input.SUM_ORG);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.Counts_INPUT_FILTR"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Input.Counts_INPUT_FILTR);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.SUM_FILTR"))
                serializer_int.Serialize(streamwriter, Open_Counts_Input.SUM_FILTR);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.Counts_INPUT_OUT"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Input.Counts_INPUT_OUT);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.SUM_OUT"))
                serializer_int.Serialize(streamwriter, Open_Counts_Input.SUM_OUT);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.SUM_HEADER"))
                serializer_int.Serialize(streamwriter, Open_Counts_Input.SUM_HEADER);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.SUM_DROP"))
                serializer_int.Serialize(streamwriter, Open_Counts_Input.SUM_DROP);

            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.My_File_Name"))
                serializer_string.Serialize(streamwriter, Open_Counts_Input.My_File_Name);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Input.My_File_Content"))
                serializer_string_array.Serialize(streamwriter, Open_Counts_Input.My_File_Content);

            //Comments input
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_0"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_0);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_1"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_1);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_2"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_2);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_3"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_3);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_4"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_4);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_5"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_5);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Comment_PRE_6"))             
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PRE_6);

            //Checkboxes input
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_1"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_2"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_3"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_4"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_5"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_6"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_7"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_8"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_9"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_10"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_11"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_12"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_13"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_YES_14"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_YES_14.Checked);

            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_1"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_2"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_3"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_4"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_5"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_6"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_7"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_8"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_9"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_10"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_11"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_12"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_13"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "checkBox_Pre_NO_14"))
                serializer_bool.Serialize(streamwriter, prE_JOB_Control1.checkBox_Pre_NO_14.Checked);

            #endregion

            #region Job Save
            //Analyzers job
            using (StreamWriter streamwriter = new StreamWriter(Job + "Analyzers_Job.Name_List"))
                serializer_string_list.Serialize(streamwriter, Analyzers_Job.Name_List);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Analyzers_Job.Analyzers_List"))
                serializer_datatable_list.Serialize(streamwriter, Analyzers_Job.Analyzers_List);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Analyzers_Job.ZIP"))
                serializer_double.Serialize(streamwriter, Analyzers_Job.ZIP);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Analyzers_Job.ZIP4"))
                serializer_double.Serialize(streamwriter, Analyzers_Job.ZIP4);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Analyzers_Job.DPBC"))
                serializer_double.Serialize(streamwriter, Analyzers_Job.DPBC);

            //Tallies Input
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Tally_Job.Tallies_Names"))
                serializer_string_list.Serialize(streamwriter, Open_Tally_Job.Tallies_Names);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Tally_Job.Tallies"))
                serializer_datatable_list.Serialize(streamwriter, Open_Tally_Job.Tallies);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Tally_Job.Excels_Names"))
                serializer_string_list.Serialize(streamwriter, Open_Tally_Job.Excels_Names);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Tally_Job.Excels"))
                serializer_datatable_list.Serialize(streamwriter, Open_Tally_Job.Excels);

            //Counts Input
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_NCOA_PRE"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_NCOA_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_NCOA_PRE"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_NCOA_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_VARIABLE"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_VARIABLE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_VARIABLE"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_VARIABLE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_PRE"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_PRE"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_PRE_DSF"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_PRE_DSF);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_PRE_DSF"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_PRE_DSF);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_DROP"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_DROP);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_DROP_FROM_COUNTS"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_DROP_FROM_COUNTS);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_DROP"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_DROP);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_DROP_FROM_COUNTS"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_DROP_FROM_COUNTS);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.Counts_MP"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Job.Counts_MP);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_MP"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_MP);

            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.My_File_Names"))
                serializer_string_list.Serialize(streamwriter, Open_Counts_Job.My_File_Names);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.My_File_Contents"))
                serializer_list_string_array.Serialize(streamwriter, Open_Counts_Job.My_File_Contents);

            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_NCOA_PRE"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_NCOA_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_Variable"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_Variable);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_PRE"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_PRE);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_DSF"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_DSF);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_DROP_FROM_COUNTS"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_DROP_FROM_COUNTS);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.List_Of_Counts_List_MP"))
                serializer_list_int_list.Serialize(streamwriter, Open_Counts_Job.List_Of_Counts_List_MP);

            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_SEEDS"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_SEEDS);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_DROP"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_DROP);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Open_Counts_Job.SUM_FOREIGN"))
                serializer_int.Serialize(streamwriter, Open_Counts_Job.SUM_FOREIGN);

            //Comments job
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_0"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_0);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_1"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_1);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_2"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_2);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_3"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_3);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_4"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_4);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_5"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_5);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_6"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_6);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_7"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_7);
            using (StreamWriter streamwriter = new StreamWriter(Job + "Comment_JOB_8"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_JOB_8);

            //Checkboxes job
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_1"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_2"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_2"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_3"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_4"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_5"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_6"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_7"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_8"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_9"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_10"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_11"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_12"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_13"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_14"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_14.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_15"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_15.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_16"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_16.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_17"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_17.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_18"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_18.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_19"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_19.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_YES_20"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_YES_20.Checked);

            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_1"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_2"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_3"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_4"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_5"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_6"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_7"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_8"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_9"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_10"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_11"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_12"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_13"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_14"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_14.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_15"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_15.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_16"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_16.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_17"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_17.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_18"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_18.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_19"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_19.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Job + "checkBox_JOB_NO_20"))
                serializer_bool.Serialize(streamwriter, joB_Control1.checkBox_JOB_NO_20.Checked);

            #endregion

            #region PF Save

            //Pf reports

            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.Counts_TOTAL"))
                serializer_int_list.Serialize(streamwriter, Prestort_Reports.Counts_TOTAL);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.SUM_TOTAL"))
                serializer_int.Serialize(streamwriter, Prestort_Reports.SUM_TOTAL);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.Counts_INVALID"))
                serializer_int_list.Serialize(streamwriter, Prestort_Reports.Counts_INVALID);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.SUM_INVALID"))
                serializer_int.Serialize(streamwriter, Prestort_Reports.SUM_INVALID);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.Counts_AUTOMATION"))
                serializer_int_list.Serialize(streamwriter, Prestort_Reports.Counts_AUTOMATION);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.SUM_AUTOMATION"))
                serializer_int.Serialize(streamwriter, Prestort_Reports.SUM_AUTOMATION);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.Counts_AUTOMATION_CAR"))
                serializer_int_list.Serialize(streamwriter, Prestort_Reports.Counts_AUTOMATION_CAR);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.SUM_AUTOMATION_CAR"))
                serializer_int.Serialize(streamwriter, Prestort_Reports.SUM_AUTOMATION_CAR);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.Counts_NON_AUTOMATION"))
                serializer_int_list.Serialize(streamwriter, Prestort_Reports.Counts_NON_AUTOMATION);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.SUM_NON_AUTOMATION"))
                serializer_int.Serialize(streamwriter, Prestort_Reports.SUM_NON_AUTOMATION);

            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.My_File_Names"))
                serializer_string_list.Serialize(streamwriter, Prestort_Reports.My_File_Names);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Prestort_Reports.My_File_Contents"))
                serializer_list_string_array.Serialize(streamwriter, Prestort_Reports.My_File_Contents);


            //Comments Pf
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Comment_PF_0"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PF_0);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "Comment_PF_1"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_PF_1);

            //Checkboxes Pf
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_YES_1"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_YES_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_YES_2"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_YES_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_YES_3"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_YES_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_YES_4"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_YES_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_YES_5"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_YES_5.Checked);

            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_NO_1"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_NO_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_NO_2"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_NO_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_NO_3"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_NO_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_NO_4"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_NO_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Pf + "checkBox_PF_NO_5"))
                serializer_bool.Serialize(streamwriter, pF_Control1.checkBox_PF_NO_5.Checked);

            #endregion

            #region Out Save

            //Analyzers Out
            using (StreamWriter streamwriter = new StreamWriter(Out + "Analyzers_Out.Name_List"))
                serializer_string_list.Serialize(streamwriter, Analyzers_Out.Name_List);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Analyzers_Out.Analyzers_List"))
                serializer_datatable_list.Serialize(streamwriter, Analyzers_Out.Analyzers_List);

            //Tallies Out
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Tally_Out.Tallies_Names"))
                serializer_string_list.Serialize(streamwriter, Open_Tally_Out.Tallies_Names);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Tally_Out.Tallies"))
                serializer_datatable_list.Serialize(streamwriter, Open_Tally_Out.Tallies);

            //Counts Out
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.Counts_ADD"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Output.Counts_ADD);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_ADD"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_ADD);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.Counts_CSV"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Output.Counts_CSV);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_CSV"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_CSV);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.Counts_UNQ"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Output.Counts_UNQ);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_UNQ"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_UNQ);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.Counts_CSV_HEADER"))
                serializer_int_list.Serialize(streamwriter, Open_Counts_Output.Counts_CSV_HEADER);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_CSV_HEADER"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_CSV_HEADER);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_ADD_CORRECTIONS"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_ADD_CORRECTIONS);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Open_Counts_Output.SUM_CSV_CORRECTIONS"))
                serializer_int.Serialize(streamwriter, Open_Counts_Output.SUM_CSV_CORRECTIONS);

            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Output.My_File_Name"))
                serializer_string.Serialize(streamwriter, Open_Counts_Output.My_File_Name);
            using (StreamWriter streamwriter = new StreamWriter(Pre_job + "Open_Counts_Output.My_File_Content"))
                serializer_string_array.Serialize(streamwriter, Open_Counts_Output.My_File_Content);

            //Comments Out
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_0"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_0);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_1"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_1);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_2"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_2);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_3"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_3);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_4"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_4);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_5"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_5);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_6"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_6);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_7"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_7);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_8"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_8);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_9"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_9);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_10"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_10);
            using (StreamWriter streamwriter = new StreamWriter(Out + "Comment_OUT_11"))
                serializer_string.Serialize(streamwriter, All_Coments_Storage.Comment_OUT_11);

            //Checkboxes Out
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_1"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_2"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_3"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_4"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_5"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_6"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_7"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_8"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_9"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_10"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_11"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_12"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_13"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_14"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_14.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_15"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_15.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_16"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_16.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_17"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_17.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_18"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_18.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_19"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_19.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_20"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_20.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_21"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_21.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_22"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_22.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_23"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_23.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_YES_24"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_YES_24.Checked);

            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_1"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_1.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_2"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_2.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_3"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_3.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_4"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_4.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_5"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_5.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_6"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_6.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_7"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_7.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_8"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_8.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_9"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_9.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_10"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_10.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_11"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_11.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_12"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_12.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_13"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_13.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_14"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_14.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_15"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_15.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_16"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_16.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_17"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_17.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_18"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_18.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_19"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_19.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_20"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_20.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_21"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_21.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_22"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_22.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_23"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_23.Checked);
            using (StreamWriter streamwriter = new StreamWriter(Out + "checkBox_OUT_NO_24"))
                serializer_bool.Serialize(streamwriter, finaL_OUTPUT_Control1.checkBox_OUT_NO_24.Checked);

            #endregion

            #region Second QC Save

            using (StreamWriter streamwriter = new StreamWriter(dir + @"\" + "seconD_QC_Control1.dataGridView1"))
            {

                DataTable dt = new DataTable();

                //Adding the Columns.
                foreach (DataGridViewColumn column in seconD_QC_Control1.dataGridView1.Columns)
                {
                    dt.Columns.Add(column.Name);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in seconD_QC_Control1.dataGridView1.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                        else 
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = " ";
                        }
                    }
                }

                DataSet dS = new DataSet();
                dt.TableName = "Second";
                dS.Tables.Add(dt);


                dS.WriteXml(streamwriter);

            }

            #endregion

            //Create QC FILE

            string My_Folder = dir;
            string My_Zip = $@"C:\Users\MaSierpinski\Desktop\Potrzebne\" + @"\" + $"{ VALUES_FROM_CAFE.Cafe}" + @"\" + $"{VALUES_FROM_CAFE.Cafe}" + ".qc";

            if (!File.Exists(My_Zip))
            {
                if (Directory.Exists(My_Folder))
                {
                    
                    ZipFile.CreateFromDirectory(My_Folder, My_Zip);
                }
            }
            else
            {
                if (Directory.Exists(My_Folder))
                {
                    File.Delete(My_Zip);
                    ZipFile.CreateFromDirectory(My_Folder, My_Zip);
                }
            }

            if(File.Exists(My_Zip))
            {
                Directory.Delete(My_Folder,true);
            }

        }

        private void Open_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Qc File|*.qc";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (ZipArchive zip = ZipFile.Open(openFileDialog.FileName, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            XmlSerializer serializer_int = new XmlSerializer(typeof(int));
                            XmlSerializer serializer_bool = new XmlSerializer(typeof(bool));
                            XmlSerializer serializer_double = new XmlSerializer(typeof(double));
                            XmlSerializer serializer_string = new XmlSerializer(typeof(string));
                            XmlSerializer serializer_int_list = new XmlSerializer(typeof(List<int>));
                            XmlSerializer serializer_string_list = new XmlSerializer(typeof(List<string>));
                            XmlSerializer serializer_string_array = new XmlSerializer(typeof(string[]));
                            XmlSerializer serializer_list_string_array = new XmlSerializer(typeof(List<string[]>));
                            XmlSerializer serializer_datatable_list = new XmlSerializer(typeof(List<DataTable>));
                            XmlSerializer serializer_list_int_list = new XmlSerializer(typeof(List<List<int>>));

                            #region Values from Cafe Open
                            if (entry.Name == "CAFES")
                                VALUES_FROM_CAFE.CAFES = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "FLOW_NAMES")
                                VALUES_FROM_CAFE.FLOW_NAMES = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "MEDIA_ID_LIST")
                                VALUES_FROM_CAFE.MEDIA_ID_LIST = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "IMB_SERVICE")
                                VALUES_FROM_CAFE.IMB_SERVICE = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "MAIL_OWNER_MIDS")
                                VALUES_FROM_CAFE.MAIL_OWNER_MIDS = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "BOOK_IDS")
                                VALUES_FROM_CAFE.BOOK_IDS = (List<string>)XamlServices.Load(entry.Open());
                            if (entry.Name == "MPU_IDS")
                                VALUES_FROM_CAFE.MPU_IDS = (List<string>)XamlServices.Load(entry.Open());

                            //SIE USUNIE
                            if (entry.Name == "Cafe")
                                VALUES_FROM_CAFE.Cafe = (string)XamlServices.Load(entry.Open());

                            if (entry.Name == "TitleCode")
                                VALUES_FROM_CAFE.TitleCode = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "JobNumber")
                                VALUES_FROM_CAFE.JobNumber = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "MailClass")
                                VALUES_FROM_CAFE.MailClass = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "Ncoa18_Path")
                                VALUES_FROM_CAFE.Ncoa18_Path = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "PresortType")
                                VALUES_FROM_CAFE.PresortType = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "IMB")
                                VALUES_FROM_CAFE.IMB = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "OutputTypeLaser")
                               VALUES_FROM_CAFE.OutputTypeLaser = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "PrintLocationLaser")
                                VALUES_FROM_CAFE.PrintLocationLaser = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "OutputTypeInkjet")
                                VALUES_FROM_CAFE.OutputTypeInkjet = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "PrintLocationInkjet")
                                VALUES_FROM_CAFE.PrintLocationInkjet = (string)XamlServices.Load(entry.Open());
                            if (entry.Name == "Dsf_Path")
                                VALUES_FROM_CAFE.Dsf_Path = (string)XamlServices.Load(entry.Open());

                            if (entry.Name == "Validation")
                                VALUES_FROM_CAFE.Validation = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Ncoa18")
                                VALUES_FROM_CAFE.Ncoa18 = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Quad_Seeds")
                                VALUES_FROM_CAFE.Quad_Seeds = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Ncoa48")
                                VALUES_FROM_CAFE.Ncoa48 = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Dsf")
                                VALUES_FROM_CAFE.Dsf = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Pick_Up")
                                VALUES_FROM_CAFE.Pick_Up = (bool)XamlServices.Load(entry.Open());
                            if (entry.Name == "Merge_Purge")
                                VALUES_FROM_CAFE.Merge_Purge = (bool)XamlServices.Load(entry.Open());

                            if (entry.Name == "richText")
                                VALUES_FROM_CAFE.richText = (RichTextBox)XamlServices.Load(entry.Open());
                            if (entry.Name == "Time")
                            {
                                VALUES_FROM_CAFE.Timer.Restart();
                                VALUES_FROM_CAFE.Processing_Time = (TimeSpan)XamlServices.Load(entry.Open());
                            }
                            #endregion

                            #region Pre Job Open

                            //Analyzers input
                            if (entry.Name == "Analyzers_Input.Name_List")                             
                                Analyzers_Input.Name_List = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Analyzers_Input.Analyzers_List")
                                Analyzers_Input.Analyzers_List = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Tallies input
                            if (entry.Name == "Open_Tally_Input.Tallies_Names")
                                Open_Tally_Input.Tallies_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Tally_Input.Tallies")
                                Open_Tally_Input.Tallies = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Counts input
                            if (entry.Name == "Open_Counts_Input.Counts_INPUT_ORG")
                                Open_Counts_Input.Counts_INPUT_ORG = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.SUM_ORG")
                                Open_Counts_Input.SUM_ORG = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.Counts_INPUT_FILTR")
                                Open_Counts_Input.Counts_INPUT_FILTR = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.SUM_FILTR")
                                Open_Counts_Input.SUM_FILTR = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.Counts_INPUT_OUT")
                                Open_Counts_Input.Counts_INPUT_OUT = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.SUM_OUT")
                                Open_Counts_Input.SUM_OUT = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.SUM_HEADER")
                                Open_Counts_Input.SUM_HEADER = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.SUM_DROP")
                                Open_Counts_Input.SUM_DROP = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.My_File_Name")
                                Open_Counts_Input.My_File_Name = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Input.My_File_Content")
                                Open_Counts_Input.My_File_Content = (string[])serializer_string_array.Deserialize(entry.Open());

                            //Comments input
                            if (entry.Name == "Comment_PRE_0")                               
                                All_Coments_Storage.Comment_PRE_0 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_1")
                                All_Coments_Storage.Comment_PRE_1 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_2")
                                All_Coments_Storage.Comment_PRE_2 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_3")
                                All_Coments_Storage.Comment_PRE_3 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_4")
                                All_Coments_Storage.Comment_PRE_4 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_5")
                                All_Coments_Storage.Comment_PRE_5 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PRE_6")
                                All_Coments_Storage.Comment_PRE_6 = (string)serializer_string.Deserialize(entry.Open());

                            //Checboxes input
                            if (entry.Name == "checkBox_Pre_YES_1")
                                prE_JOB_Control1.checkBox_Pre_YES_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_2")
                                prE_JOB_Control1.checkBox_Pre_YES_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_3")
                                prE_JOB_Control1.checkBox_Pre_YES_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_4")
                                prE_JOB_Control1.checkBox_Pre_YES_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_5")
                                prE_JOB_Control1.checkBox_Pre_YES_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_6")
                                prE_JOB_Control1.checkBox_Pre_YES_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_7")
                                prE_JOB_Control1.checkBox_Pre_YES_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_8")
                                prE_JOB_Control1.checkBox_Pre_YES_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_9")
                                prE_JOB_Control1.checkBox_Pre_YES_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_10")
                                prE_JOB_Control1.checkBox_Pre_YES_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_11")
                                prE_JOB_Control1.checkBox_Pre_YES_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_12")
                                prE_JOB_Control1.checkBox_Pre_YES_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_13")
                                prE_JOB_Control1.checkBox_Pre_YES_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_YES_14")
                                prE_JOB_Control1.checkBox_Pre_YES_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_1")
                                prE_JOB_Control1.checkBox_Pre_NO_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_2")
                                prE_JOB_Control1.checkBox_Pre_NO_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_3")
                                prE_JOB_Control1.checkBox_Pre_NO_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_4")
                                prE_JOB_Control1.checkBox_Pre_NO_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_5")
                                prE_JOB_Control1.checkBox_Pre_NO_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_6")
                                prE_JOB_Control1.checkBox_Pre_NO_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_7")
                                prE_JOB_Control1.checkBox_Pre_NO_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_8")
                                prE_JOB_Control1.checkBox_Pre_NO_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_9")
                                prE_JOB_Control1.checkBox_Pre_NO_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_10")
                                prE_JOB_Control1.checkBox_Pre_NO_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_11")
                                prE_JOB_Control1.checkBox_Pre_NO_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_12")
                                prE_JOB_Control1.checkBox_Pre_NO_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_13")
                                prE_JOB_Control1.checkBox_Pre_NO_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_Pre_NO_14")
                                prE_JOB_Control1.checkBox_Pre_NO_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            #endregion

                            #region Job open

                            //Analyzers job
                            if (entry.Name == "Analyzers_Job.Name_List")
                                Analyzers_Job.Name_List = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Analyzers_Job.Analyzers_List")
                                Analyzers_Job.Analyzers_List = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Tallies job
                            if (entry.Name == "Open_Tally_Job.Tallies_Names")
                                Open_Tally_Job.Tallies_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Tally_Job.Tallies")
                                Open_Tally_Job.Tallies = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Tally_Job.Excels_Names")
                                Open_Tally_Job.Excels_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Tally_Job.Excels")
                                Open_Tally_Job.Excels = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Counts Job
                            if (entry.Name == "Open_Counts_Job.Counts_NCOA_PRE")
                                Open_Counts_Job.Counts_NCOA_PRE = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_NCOA_PRE")
                                Open_Counts_Job.SUM_NCOA_PRE = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.Counts_VARIABLE")
                                Open_Counts_Job.Counts_VARIABLE = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_VARIABLE")
                                Open_Counts_Job.SUM_VARIABLE = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.Counts_PRE")
                                Open_Counts_Job.Counts_PRE = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_PRE")
                                Open_Counts_Job.SUM_PRE = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.Counts_PRE_DSF")
                                Open_Counts_Job.Counts_PRE_DSF = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_PRE_DSF")
                                Open_Counts_Job.SUM_PRE_DSF = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.Counts_DROP")
                                Open_Counts_Job.Counts_DROP = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_DROP_FROM_COUNTS")
                                Open_Counts_Job.SUM_DROP_FROM_COUNTS = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.Counts_MP")
                                Open_Counts_Job.Counts_MP = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_MP")
                                Open_Counts_Job.SUM_MP = (int)serializer_int.Deserialize(entry.Open());

                            if (entry.Name == "Open_Counts_Job.My_File_Names")
                                Open_Counts_Job.My_File_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.My_File_Contents")
                                Open_Counts_Job.My_File_Contents = (List<string[]>)serializer_list_string_array.Deserialize(entry.Open());

                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_NCOA_PRE")
                                Open_Counts_Job.List_Of_Counts_List_NCOA_PRE = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_Variable")
                                Open_Counts_Job.List_Of_Counts_List_Variable = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_PRE")
                                Open_Counts_Job.List_Of_Counts_List_PRE = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_DSF")
                                Open_Counts_Job.List_Of_Counts_List_DSF = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_DROP_FROM_COUNTS")
                                Open_Counts_Job.List_Of_Counts_List_DROP_FROM_COUNTS = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.List_Of_Counts_List_MP")
                                Open_Counts_Job.List_Of_Counts_List_MP = (List<List<int>>)serializer_list_int_list.Deserialize(entry.Open());

                            if (entry.Name == "Open_Counts_Job.SUM_SEEDS")
                                Open_Counts_Job.SUM_SEEDS = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_DROP")
                                Open_Counts_Job.SUM_DROP = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_FOREIGN")
                                Open_Counts_Job.SUM_FOREIGN = (int)serializer_int.Deserialize(entry.Open());

                            //Comments job
                            if (entry.Name == "Comment_JOB_0")
                                All_Coments_Storage.Comment_JOB_0 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_1")
                                All_Coments_Storage.Comment_JOB_1 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_2")
                                All_Coments_Storage.Comment_JOB_2 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_3")
                                All_Coments_Storage.Comment_JOB_3 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_4")
                                All_Coments_Storage.Comment_JOB_4 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_5")
                                All_Coments_Storage.Comment_JOB_5 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_6")
                                All_Coments_Storage.Comment_JOB_6 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_7")
                                All_Coments_Storage.Comment_JOB_7 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_JOB_8")
                                All_Coments_Storage.Comment_JOB_8 = (string)serializer_string.Deserialize(entry.Open());

                            //Checboxes job
                            if (entry.Name == "checkBox_JOB_YES_1")
                                joB_Control1.checkBox_JOB_YES_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_2")
                                joB_Control1.checkBox_JOB_YES_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_3")
                                joB_Control1.checkBox_JOB_YES_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_4")
                                joB_Control1.checkBox_JOB_YES_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_5")
                                joB_Control1.checkBox_JOB_YES_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_6")
                                joB_Control1.checkBox_JOB_YES_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_7")
                                joB_Control1.checkBox_JOB_YES_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_8")
                                joB_Control1.checkBox_JOB_YES_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_9")
                                joB_Control1.checkBox_JOB_YES_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_10")
                                joB_Control1.checkBox_JOB_YES_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_11")
                                joB_Control1.checkBox_JOB_YES_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_12")
                                joB_Control1.checkBox_JOB_YES_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_13")
                                joB_Control1.checkBox_JOB_YES_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_14")
                                joB_Control1.checkBox_JOB_YES_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_15")
                                joB_Control1.checkBox_JOB_YES_15.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_16")
                                joB_Control1.checkBox_JOB_YES_16.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_17")
                                joB_Control1.checkBox_JOB_YES_17.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_18")
                                joB_Control1.checkBox_JOB_YES_18.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_19")
                                joB_Control1.checkBox_JOB_YES_19.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_YES_20")
                                joB_Control1.checkBox_JOB_YES_20.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            if (entry.Name == "checkBox_JOB_NO_1")
                                joB_Control1.checkBox_JOB_NO_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_2")
                                joB_Control1.checkBox_JOB_NO_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_3")
                                joB_Control1.checkBox_JOB_NO_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_4")
                                joB_Control1.checkBox_JOB_NO_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_5")
                                joB_Control1.checkBox_JOB_NO_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_6")
                                joB_Control1.checkBox_JOB_NO_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_7")
                                joB_Control1.checkBox_JOB_NO_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_8")
                                joB_Control1.checkBox_JOB_NO_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_9")
                                joB_Control1.checkBox_JOB_NO_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_10")
                                joB_Control1.checkBox_JOB_NO_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_11")
                                joB_Control1.checkBox_JOB_NO_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_12")
                                joB_Control1.checkBox_JOB_NO_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_13")
                                joB_Control1.checkBox_JOB_NO_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_14")
                                joB_Control1.checkBox_JOB_NO_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_15")
                                joB_Control1.checkBox_JOB_NO_15.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_16")
                                joB_Control1.checkBox_JOB_NO_16.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_17")
                                joB_Control1.checkBox_JOB_NO_17.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_18")
                                joB_Control1.checkBox_JOB_NO_18.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_19")
                                joB_Control1.checkBox_JOB_NO_19.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_JOB_NO_20")
                                joB_Control1.checkBox_JOB_NO_20.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            #endregion

                            #region Pf open

                            //PF reports
                            if (entry.Name == "Prestort_Reports.Counts_TOTAL")
                                Prestort_Reports.Counts_TOTAL = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.SUM_TOTAL")
                                Prestort_Reports.SUM_TOTAL = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.Counts_INVALID")
                                Prestort_Reports.Counts_INVALID = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.SUM_INVALID")
                                Prestort_Reports.SUM_INVALID = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.Counts_AUTOMATION")
                                Prestort_Reports.Counts_AUTOMATION = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.SUM_AUTOMATION")
                                Prestort_Reports.SUM_AUTOMATION = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.Counts_AUTOMATION_CAR")
                                Prestort_Reports.Counts_AUTOMATION_CAR = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.SUM_AUTOMATION_CAR")
                                Prestort_Reports.SUM_AUTOMATION_CAR = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.Counts_NON_AUTOMATION")
                                Prestort_Reports.Counts_NON_AUTOMATION = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.SUM_NON_AUTOMATION")
                                Prestort_Reports.SUM_NON_AUTOMATION = (int)serializer_int.Deserialize(entry.Open());

                            if (entry.Name == "Prestort_Reports.My_File_Names")
                                Prestort_Reports.My_File_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Prestort_Reports.My_File_Contents")
                                Prestort_Reports.My_File_Contents = (List<string[]>)serializer_list_string_array.Deserialize(entry.Open());

                            //Comments job
                            if (entry.Name == "Comment_PF_0")
                                All_Coments_Storage.Comment_PF_0 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_PF_1")
                                All_Coments_Storage.Comment_PF_1 = (string)serializer_string.Deserialize(entry.Open());

                            //Checboxes job
                            if (entry.Name == "checkBox_PF_YES_1")
                                pF_Control1.checkBox_PF_YES_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_YES_2")
                                pF_Control1.checkBox_PF_YES_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_YES_3")
                                pF_Control1.checkBox_PF_YES_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_YES_4")
                                pF_Control1.checkBox_PF_YES_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_YES_5")
                                pF_Control1.checkBox_PF_YES_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            if (entry.Name == "checkBox_PF_NO_1")
                                pF_Control1.checkBox_PF_NO_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_NO_2")
                                pF_Control1.checkBox_PF_NO_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_NO_3")
                                pF_Control1.checkBox_PF_NO_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_NO_4")
                                pF_Control1.checkBox_PF_NO_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_PF_NO_5")
                                pF_Control1.checkBox_PF_NO_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            #endregion

                            #region Out open

                            //Analyzers out
                            if (entry.Name == "Analyzers_Out.Name_List")
                                Analyzers_Out.Name_List = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Analyzers_Out.Analyzers_List")
                                Analyzers_Out.Analyzers_List = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Tallies job
                            if (entry.Name == "Open_Tally_Out.Tallies_Names")
                                Open_Tally_Out.Tallies_Names = (List<string>)serializer_string_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Tally_Out.Tallies")
                                Open_Tally_Out.Tallies = (List<DataTable>)serializer_datatable_list.Deserialize(entry.Open());

                            //Counts Job
                            if (entry.Name == "Open_Counts_Output.Counts_ADD")
                                Open_Counts_Output.Counts_ADD = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_ADD")
                                Open_Counts_Output.SUM_ADD = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Output.Counts_CSV")
                                Open_Counts_Output.Counts_CSV = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_CSV")
                                Open_Counts_Output.SUM_CSV = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Output.Counts_UNQ")
                                Open_Counts_Output.Counts_UNQ = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_UNQ")
                                Open_Counts_Output.SUM_UNQ = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Output.Counts_CSV_HEADER")
                                Open_Counts_Output.Counts_CSV_HEADER = (List<int>)serializer_int_list.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_CSV_HEADER")
                                Open_Counts_Output.SUM_CSV_HEADER = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_ADD_CORRECTIONS")
                                Open_Counts_Output.SUM_ADD_CORRECTIONS = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Job.SUM_CSV_CORRECTIONS")
                                Open_Counts_Output.SUM_CSV_CORRECTIONS = (int)serializer_int.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Output.My_File_Name")
                                Open_Counts_Output.My_File_Name = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Open_Counts_Output.My_File_Content")
                                Open_Counts_Output.My_File_Content = (string[])serializer_string_array.Deserialize(entry.Open());

                            //Comments input
                            if (entry.Name == "Comment_OUT_0")
                                All_Coments_Storage.Comment_OUT_0 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_1")
                                All_Coments_Storage.Comment_OUT_1 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_2")
                                All_Coments_Storage.Comment_OUT_2 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_3")
                                All_Coments_Storage.Comment_OUT_3 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_4")
                                All_Coments_Storage.Comment_OUT_4 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_5")
                                All_Coments_Storage.Comment_OUT_5 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_6")
                                All_Coments_Storage.Comment_OUT_6 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_7")
                                All_Coments_Storage.Comment_OUT_7 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_8")
                                All_Coments_Storage.Comment_OUT_8 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_9")
                                All_Coments_Storage.Comment_OUT_9 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_10")
                                All_Coments_Storage.Comment_OUT_10 = (string)serializer_string.Deserialize(entry.Open());
                            if (entry.Name == "Comment_OUT_11")
                                All_Coments_Storage.Comment_OUT_11 = (string)serializer_string.Deserialize(entry.Open());

                            //Checkboxes Out
                            if (entry.Name == "checkBox_OUT_YES_1")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_2")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_3")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_4")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_5")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_6")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_7")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_8")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_9")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_10")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_11")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_12")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_13")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_14")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_15")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_15.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_16")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_16.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_17")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_17.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_18")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_18.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_19")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_19.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_20")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_20.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_21")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_21.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_22")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_22.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_23")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_23.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_YES_24")
                                finaL_OUTPUT_Control1.checkBox_OUT_YES_24.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            if (entry.Name == "checkBox_OUT_NO_1")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_1.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_2")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_2.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_3")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_3.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_4")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_4.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_5")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_5.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_6")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_6.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_7")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_7.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_8")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_8.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_9")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_9.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_10")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_10.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_11")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_11.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_12")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_12.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_13")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_13.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_14")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_14.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_15")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_15.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_16")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_16.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_17")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_17.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_18")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_18.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_19")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_19.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_20")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_20.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_21")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_21.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_22")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_22.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_23")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_23.Checked = (bool)serializer_bool.Deserialize(entry.Open());
                            if (entry.Name == "checkBox_OUT_NO_24")
                                finaL_OUTPUT_Control1.checkBox_OUT_NO_24.Checked = (bool)serializer_bool.Deserialize(entry.Open());

                            #endregion

                            #region Second QC Open

                            if (entry.Name == "seconD_QC_Control1.dataGridView1")
                            {
                                DataSet dataSet = new DataSet();
                                dataSet.ReadXml(entry.Open());
                                seconD_QC_Control1.dataGridView1.AutoGenerateColumns = false;
                                if (dataSet.Tables.Count == 1)
                                {
                                    foreach (DataRow row in dataSet.Tables[0].Rows)
                                    {
                                        seconD_QC_Control1.dataGridView1.Rows.Add(row[0], row[1], row[2], row[3]);
                                    }
                                }
                            }

                            #endregion
                        }

                        prE_JOB_Control1.Open_QC();
                        joB_Control1.Open_QC();
                        pF_Control1.Open_QC();
                        finaL_OUTPUT_Control1.Open_QC();
                    }
                }
            }                                
        }

    }
}

