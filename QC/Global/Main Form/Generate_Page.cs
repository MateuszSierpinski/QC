using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public partial class Generate_Page : Form
    {
        Enter_CAFE Enter_CAFE = null;
        string Cafe;
        string URL;


        public Generate_Page(Enter_CAFE enter_CAFE)
        {
            InitializeComponent();
            Enter_CAFE = enter_CAFE;

            Cafe = Enter_CAFE.textBox1.Text.ToString().Trim();
            URL = "http://dmdata.qg.com/DataFlowInstructions/Report/JobExecutionReport?jobExecutionFlowId=" + $"{Cafe}";

            this.webBrowser1.ObjectForScripting = new MyScript();
        }

        private void Generate_Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
                webRequest.CookieContainer = new CookieContainer();
                webRequest.UseDefaultCredentials = true;
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException();
                }

                webBrowser1.Navigate(URL);
                this.Location = new Point(-1000, -1000);
            }
            catch
            {              
                MessageBox.Show("Coś poszło nie tak");
                this.Close();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Navigate("javascript: window.external.CallServerSideCode();");           
        }

        [ComVisible(true)]
        public class MyScript
        {
            public void CallServerSideCode()
            {
                var doc = ((Generate_Page)Application.OpenForms[2]).webBrowser1.Document;

                var content = doc.Body.OuterHtml;

                //((Generate_Page)Application.OpenForms[2]).richTextBox1.Text = content;
                          
                READ_CAFE RC = new READ_CAFE();
                RC.Read_cafe(content, ((Generate_Page)Application.OpenForms[2]).Cafe);

                ((Generate_Page)Application.OpenForms[2]).Close();                
            }
        }

        private void Generate_Page_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Generate_Page_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enter_CAFE.Close();
        }
    }
}
