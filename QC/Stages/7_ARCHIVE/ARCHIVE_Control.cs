using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;

namespace QC
{
    public partial class ARCHIVE_Control : UserControl
    {
        string Error = "";
        Timer timer = new Timer();

        public ARCHIVE_Control()
        {
            InitializeComponent();
            timer.Interval = 6000;
            timer.Tick += Timer_Tick;
        }

        private void Archive_Folder_Click(object sender, EventArgs e)
        {
            if (!Zip_backgroundWorker.IsBusy)
            {
                circularProgressBar1.Visible = true;
                Info_label.Visible = true;
                Info_label.Text = "Archiving";
                Zip_backgroundWorker.RunWorkerAsync();
            }
            
        }

        private void Zip_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string My_Folder = @"\\sxcorp2\QDIRECT_MDS\Data_Services\Titles\" + $"{VALUES_FROM_CAFE.TitleCode}" + @"\" + $"{VALUES_FROM_CAFE.Cafe}";
            string My_Zip = $@"\\sxcorp2\QDIRECT_MDS\Data_Services\Titles\" +
                            $"{VALUES_FROM_CAFE.TitleCode}" + @"\" + $"{ VALUES_FROM_CAFE.Cafe}" + ".zip";
            string Zip = @"\" + $"{ VALUES_FROM_CAFE.Cafe}" + ".zip";

            if (!File.Exists(My_Zip))
            {
                if (Directory.Exists(My_Folder))
                {
                    if (!File.Exists(My_Folder + Zip))
                    {
                        ZipFile.CreateFromDirectory(My_Folder, My_Zip);
                        File.Move(My_Zip, My_Folder + Zip);

                        Error = "";
                    }
                    else
                    {
                        Error = "Zip in Folder";
                    }
                }
                else
                {
                    Error = "Folder_1";
                }
            }
            else
            {
                Error = "Zip In Main";
            }
        }

        private void Zip_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            circularProgressBar1.Visible = false;
            Info_label.Visible = false;

            if(Error == "Zip in Folder")
            {
                
                Result_Label.Text = "You have Zip file in your Cafe folder";
                Result_Label.ForeColor = Color.Red;
                Result_Label.Visible = true;
                timer.Start();
                
            }

            if(Error == "Folder_1")
            {
                Result_Label.Visible = true;
                Result_Label.Text = "There is no Cafe folder to Zip";
                Result_Label.ForeColor = Color.Red;
                Result_Label.Visible = true;
                timer.Start();
            }

            if(Error == "Zip In Main")
            {
                Result_Label.Visible = true;
                Result_Label.Text = "You have Zip file in your Title Code folder";
                Result_Label.ForeColor = Color.Red;
                Result_Label.Visible = true;
                timer.Start();
            }

            if(Error == "")
            {
                Result_Label.Visible = true;
                Result_Label.Text = "Archiving is Done !!";
                Result_Label.ForeColor = Color.Lime;
                Result_Label.Visible = true;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Result_Label.Visible = false;
        }

        private void Clear_Folder_Click(object sender, EventArgs e)
        {
            if (!Clear_backgroundWorker.IsBusy)
            {
                circularProgressBar1.Visible = true;
                Info_label.Visible = true;
                Info_label.Text = "Clearing";
                Clear_backgroundWorker.RunWorkerAsync();
            }

        }

        private void Clear_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string My_Folder = @"\\sxcorp2\QDIRECT_MDS\Data_Services\Titles\" + $"{VALUES_FROM_CAFE.TitleCode}" + @"\" + $"{VALUES_FROM_CAFE.Cafe}";
            string My_Zip = $@"\\sxcorp2\QDIRECT_MDS\Data_Services\Titles\" +
                            $"{VALUES_FROM_CAFE.TitleCode}" + @"\" + $"{ VALUES_FROM_CAFE.Cafe}" + ".zip";
            string Zip = @"\" + $"{ VALUES_FROM_CAFE.Cafe}" + ".zip";

            if (File.Exists(My_Folder + Zip))
            {
                if (Directory.Exists(My_Folder))
                {
                    string[] filePath = Directory.GetFiles(My_Folder);
                    foreach (string file in filePath)
                        if (Path.GetExtension(file) != ".zip")
                        {
                            File.Delete(file);
                        }
                   
                    Error = "";
                }

                else
                {
                    Error = "Directory";
                }
            }

            else
            {
                Error = "Folder_2";
            }
        }

        private void Clear_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            circularProgressBar1.Visible = false;
            Info_label.Visible = false;

            if (Error == "Directory")
            {

                Result_Label.Text = "There is no such of directory to clear";
                Result_Label.ForeColor = Color.Red;
                Result_Label.Visible = true;
                timer.Start();

            }

            if (Error == "Folder_2")
            {
                Result_Label.Visible = true;
                Result_Label.Text = "There is no Zip in your folder";
                Result_Label.ForeColor = Color.Red;
                Result_Label.Visible = true;
                timer.Start();

            }

            if (Error == "")
            {
                Result_Label.Visible = true;
                Result_Label.Text = "Clearing is Done !!";
                Result_Label.ForeColor = Color.Lime;
                Result_Label.Visible = true;
                timer.Start();
            }
        }

        private void Drop_Zip_Click(object sender, EventArgs e)
        {
            var URL = "https://webapps23.qg.com/ListRequestDocumentManagerWeb/Home/Index/?requestNumber=" + $"{VALUES_FROM_CAFE.Cafe}";

            try
            {
                circularProgressBar1.Visible = true;
                Info_label.Visible = true;
                Info_label.Text = "Connecting";
                webBrowser1.Navigate(URL);
            }
            catch
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                string javascript =
                    "document.body.style.opacity = 0;" +
                    "document.body.style.backgroundColor = 'rgb(60, 60, 60)';" +
                    "if(document.getElementById(\"navbar-opener\"))" +
                    "{document.getElementById(\"navbar-opener\").style.opacity = 0;};" +
                    "var obj = document.createElement('h2');" +
                    "obj.style.color = 'white';" +
                    "obj.innerHTML= 'Drop here you Zip file';" +
                    "obj.style.position = 'absolute';" +
                    "obj.style.top = '43%';" +
                    "obj.style.left = '38%';" +
                    "document.body.insertAdjacentElement('afterend', obj);";

                if (!webBrowser1.IsBusy)
                {
                    webBrowser1.Document.InvokeScript("eval", new object[] { javascript });
                    circularProgressBar1.Visible = false;
                    Info_label.Visible = false;
                    webBrowser1.Visible = true;                    
                }

                string My_Folder = @"\\sxcorp2\QDIRECT_MDS\Data_Services\Titles\" + $"{VALUES_FROM_CAFE.TitleCode}" + @"\" + $"{VALUES_FROM_CAFE.Cafe}";

                if (Directory.Exists(My_Folder))
                {
                    Process.Start(My_Folder);
                }
                else
                {
                    Result_Label.Text = "Your Cafe folder do not exist";
                    Result_Label.Visible = true;
                    Result_Label.ForeColor = Color.Red;
                    Result_Label.Visible = true;
                }

            }
        }
    }
}
