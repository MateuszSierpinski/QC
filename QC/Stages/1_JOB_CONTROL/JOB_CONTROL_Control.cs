using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Activities.Statements;
using System.Xaml;
using System.IO.Compression;

namespace QC
{
    public partial class JOB_CONTROL_Control : UserControl
    {
       public DataGridView dataGridView = null;
        public JOB_CONTROL_Control(DataGridView datagridview)
        {

            dataGridView = datagridview;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            userName = userName.Replace("QG\\", "").Trim();

            InitializeComponent();
            if (Users_comboBox.Items.Count <= 0)
            {

                Users_comboBox.Items.Add(userName);
                Users_comboBox.Items.Add("Add Me");
                Users_comboBox.SelectedIndex = 0;
            }
            if(Users_comboBox.Items.Count == 1)
            {

            }

            if(!VALUES_FROM_CAFE.PROCESSORS.Any())
            {
                VALUES_FROM_CAFE.PROCESSORS.Add(userName);
            }
        }


        private void listBox2_Click(object sender, EventArgs e)
        {
            if (Media_Id_List.Items.Count >= 1 && Media_Id_List.SelectedItem != null)
            {
                Clipboard.SetData(DataFormats.StringFormat, Media_Id_List.SelectedItem.ToString().Trim());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                VALUES_FROM_CAFE.Validation = true;
            }
            else
            {
                VALUES_FROM_CAFE.Validation = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                VALUES_FROM_CAFE.Quad_Seeds = true;
            }
            else
            {
                VALUES_FROM_CAFE.Quad_Seeds = false;
            }
        }


        private void JOB_CONTROL_Control_Click(object sender, EventArgs e)
        {
            Media_Id_List.ClearSelected();
            Flows_List.ClearSelected();
        }

        private void JOB_CONTROL_Control_VisibleChanged(object sender, EventArgs e)
        {
            if (VALUES_FROM_CAFE.Cafe != "")
            {
                if (!Cafe_comboBox.Items.Contains(VALUES_FROM_CAFE.Cafe))
                {
                    Cafe_comboBox.Items.Add(VALUES_FROM_CAFE.Cafe);
                    Cafe_comboBox.Items.Add("Add Cafe");
                }
                Cafe_comboBox.SelectedIndex = 0;
            }

            if (VALUES_FROM_CAFE.TitleCode != "") label5.Text = "Title Code: " + VALUES_FROM_CAFE.TitleCode;

            if (VALUES_FROM_CAFE.JobNumber != "") label4.Text = VALUES_FROM_CAFE.JobNumber;

            checkBox4.Checked = VALUES_FROM_CAFE.Quad_Seeds;

            checkBox2.Checked = VALUES_FROM_CAFE.Validation;

            checkbox1.Checked = VALUES_FROM_CAFE.Ncoa18;

            if (VALUES_FROM_CAFE.Ncoa18_Path != "") label10.Text = VALUES_FROM_CAFE.Ncoa18_Path;

            checkBox6.Checked = VALUES_FROM_CAFE.Ncoa48;

            checkBox7.Checked = VALUES_FROM_CAFE.Dsf;

            if (VALUES_FROM_CAFE.Dsf_Path != "") label12.Text = VALUES_FROM_CAFE.Dsf_Path;

            checkBox5.Checked = VALUES_FROM_CAFE.Merge_Purge;

            if (VALUES_FROM_CAFE.IMB != "") label3.Text = VALUES_FROM_CAFE.IMB;

            if (VALUES_FROM_CAFE.PresortType != "")
            {
                label2.Text = "Presort Type: " + VALUES_FROM_CAFE.PresortType + " - " + VALUES_FROM_CAFE.MailClass;
            }

            if (VALUES_FROM_CAFE.Pick_Up)
            {
                checkBox3.Visible = true;
                checkBox3.Checked = VALUES_FROM_CAFE.Pick_Up;
            }
            if (VALUES_FROM_CAFE.OutputTypeLaser != "")
            {
                Output_Type_Digital.Visible = true;
                Output_Type_Digital.Text = VALUES_FROM_CAFE.OutputTypeLaser;
            }
            if (VALUES_FROM_CAFE.OutputTypeInkjet != "")
            {
                Output_Type_Inkjet.Visible = true;
                Output_Type_Inkjet.Text = VALUES_FROM_CAFE.OutputTypeInkjet;
            }
            if (VALUES_FROM_CAFE.PrintLocationLaser != "")
            {
                Print_Location_Digital.Visible = true;
                Print_Location_Digital.Text = "Print Location: " + VALUES_FROM_CAFE.PrintLocationLaser;
            }
            if (VALUES_FROM_CAFE.PrintLocationInkjet != "")
            {
                Print_Location_Inkjet.Visible = true;
                Print_Location_Inkjet.Text = "Print Location: " + VALUES_FROM_CAFE.PrintLocationInkjet;
            }

            richTextBox1.Text = VALUES_FROM_CAFE.richText.Text;

            if (VALUES_FROM_CAFE.MEDIA_ID_LIST.Any())
            {

                foreach (var media in VALUES_FROM_CAFE.MEDIA_ID_LIST)
                {
                    if (!Media_Id_List.Items.Contains(media))
                    {
                        Media_Id_List.Items.Add(media);
                        int count = Media_Id_List.Items.Count;
                        Media_Count_ListBox.Items.Add(count + ".");
                    }
                }

                Media_Id_List.ClearSelected();
                Media_Id_Empty_label.Visible = false;
            }
            else
            {
                Media_Id_Empty_label.Visible = true;
            }

            if (VALUES_FROM_CAFE.FLOW_NAMES.Any())
            {

                foreach (var flow in VALUES_FROM_CAFE.FLOW_NAMES)
                {
                    if (!Flows_List.Items.Contains(flow))
                    {
                        Flows_List.Items.Add(flow);
                        int count = Flows_List.Items.Count;
                        Flow_Count_ListBox.Items.Add(count + ".");
                    }

                }

                Flows_List.ClearSelected();
                Flow_Empty_Label.Visible = false;
            }
            else
            {
                Flow_Empty_Label.Visible = true;
            }

        }



        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
               Add_Flow_Name AFN = new Add_Flow_Name(this);
               AFN.Show();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Flows_List.Items.Count > 0 && Flows_List.SelectedItem != null)
            {
                int j = Flows_List.SelectedIndex;
                Flows_List.Items.RemoveAt(j);
                VALUES_FROM_CAFE.FLOW_NAMES.RemoveAt(j);
                dataGridView.Rows.RemoveAt(j);
                Flow_Count_ListBox.Items.RemoveAt(Flow_Count_ListBox.Items.Count - 1);
                if (Flows_List.Items.Count == 0) Flow_Empty_Label.Visible = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Flows_List.Items.Count > 0 && Flows_List.SelectedItem != null)
            {
                Edit_Flow_Name EFN = new Edit_Flow_Name(Flows_List,dataGridView);
                EFN.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_MEDIA_ID AMI = new Add_MEDIA_ID(this);
            AMI.Show();
        }

        private void Media_Id_List_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = Media_Id_List.IndexFromPoint(e.Location);
                if (item >= 0 && Media_Id_List.SelectedIndices.Contains(item) == false)
                {
                    Media_Id_List.ClearSelected();
                    Media_Id_List.SelectedIndex = item;
                }
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Media_Id_List.Items.Count > 0 && Media_Id_List.SelectedItem != null)
            {
                Edit_MEDIA_ID EMI = new Edit_MEDIA_ID(Media_Id_List);
                EMI.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Media_Id_List.Items.Count > 0 && Media_Id_List.SelectedItem != null)
            {
                //string sel_string = Flows_List.Items[j].ToString();
                int j = Media_Id_List.SelectedIndex;
                Media_Id_List.Items.RemoveAt(j);
                Media_Count_ListBox.Items.RemoveAt(Media_Count_ListBox.Items.Count - 1);
                VALUES_FROM_CAFE.MEDIA_ID_LIST.RemoveAt(j);                
                if (Media_Id_List.Items.Count == 0) Media_Id_Empty_label.Visible = true;
            }
        }

        private void Media_Id_List_OnVerticalScroll_1(object sender, ScrollEventArgs e)
        {
            Media_Count_ListBox.TopIndex = Media_Id_List.TopIndex;
        }

        private void Media_Id_List_3_Click(object sender, EventArgs e)
        {
            if (Media_Id_List.Items.Count >= 1 && Media_Id_List.SelectedItem != null)
            {
                Clipboard.SetData(DataFormats.StringFormat, Media_Id_List.SelectedItem.ToString().Trim());
            }
        }

        private void Media_Id_List_3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = Media_Id_List.IndexFromPoint(e.Location);
                if (item >= 0 && Media_Id_List.SelectedIndices.Contains(item) == false)
                {
                    Media_Id_List.ClearSelected();
                    Media_Id_List.SelectedIndex = item;
                }
            }
        }


        private void Flows_List_DragDrop(object sender, DragEventArgs e)
        {
            Point point = Flows_List.PointToClient(new Point(e.X, e.Y));
            int index = this.Flows_List.IndexFromPoint(point);
            if (index < 0) index = this.Flows_List.Items.Count - 1;
            object data = Flows_List.SelectedItem;
            this.Flows_List.Items.Remove(data);
            this.Flows_List.Items.Insert(index, data);
        }

        private void Flows_List_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Flows_List_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    if (this.Flows_List.SelectedItem == null) return;
            //    this.Flows_List.DoDragDrop(this.Flows_List.SelectedItem, DragDropEffects.Move);

            //    if (Flows_List.Items.Count >= 1 && Flows_List.SelectedItem != null)
            //    {
            //        Clipboard.SetData(DataFormats.StringFormat, Flows_List.SelectedItem.ToString().Trim());
            //    }

            //}
        }

        private void Flows_List_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = Flows_List.IndexFromPoint(e.Location);

                if (item >= 0 && Flows_List.SelectedIndices.Contains(item) == false)
                {
                    Flows_List.ClearSelected();
                    Flows_List.SelectedIndex = item;
                }
            }
        }

        private void Users_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Users_comboBox.SelectedItem.ToString() == "Add Me")
            {

                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                userName = userName.Replace("QG\\", "").Trim();
                if (!Users_comboBox.Items.Contains(userName))
                {
                    Users_comboBox.Items.Insert(Users_comboBox.Items.Count - 2, userName);                    
                }
                Users_comboBox.SelectedIndex = 0;
            }
        }

        private void Cafe_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Cafe_comboBox.SelectedItem.ToString() == "Add Cafe")
            {
                MessageBox.Show("Dupa");
                Cafe_comboBox.SelectedIndex = 0;
            }
        }

        private void Flows_List_OnVerticalScroll(object sender, ScrollEventArgs e)
        {
            Flow_Count_ListBox.TopIndex = Flows_List.TopIndex;
        }

        private void addFromAnotherCafeToolStripMenuItem_Click(object sender, EventArgs e)
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
                            if (entry.Name == "FLOW_NAMES")
                                VALUES_FROM_CAFE.FLOW_NAMES = (List<string>)XamlServices.Load(entry.Open());

                            if (VALUES_FROM_CAFE.FLOW_NAMES.Any())
                            {

                                foreach (var flow in VALUES_FROM_CAFE.FLOW_NAMES)
                                {
                                    if (!Flows_List.Items.Contains(flow))
                                    {
                                        Flows_List.Items.Add(flow);
                                        int count = Flows_List.Items.Count;
                                        Flow_Count_ListBox.Items.Add(count + ".");
                                        dataGridView.Rows.Add(flow);
                                    }

                                }

                                Flows_List.ClearSelected();
                                Flow_Empty_Label.Visible = false;
                            }
                            else
                            {
                                Flow_Empty_Label.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
