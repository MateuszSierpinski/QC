using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC
{
    public partial class SECOND_QC_Control : UserControl
    {

        public static bool close = false;
        public static bool close_counts = false;
        public static bool close_tally = false;

        public SECOND_QC_Control()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersHeight = 50;

        }

        private void SECOND_QC_Control_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            userName = userName.Replace("QG\\", "").Trim();

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Sign_Processor")
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value == null
                        || dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Trim() == "")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = userName;
                    }

                    else
                    {
                        if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Contains(userName) &&
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Trim() != "")

                        {
                            var inside = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = inside + " , " + userName;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[e.ColumnIndex-1].Value == null
                            || row.Cells[e.ColumnIndex-1].Value.ToString().Trim() == "")
                        {
                            row.Cells[e.ColumnIndex-1].Value = userName;
                        }
                        else
                        {
                            if (!row.Cells[e.ColumnIndex - 1].Value.ToString().Contains(userName) &&
                                row.Cells[e.ColumnIndex - 1].Value.ToString().Trim() != "")
                            {
                                var inside = row.Cells[e.ColumnIndex - 1].Value.ToString();
                                row.Cells[e.ColumnIndex - 1].Value = inside + " , " + userName;
                            }
                        }

                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Sign_Checker")
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value == null
                    || dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Trim() == "")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = userName;
                    }

                    else
                    {
                        if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Contains(userName) &&
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Trim() != "")

                        {
                            var inside = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = inside + " , " + userName;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[e.ColumnIndex - 1].Value == null
                            || row.Cells[e.ColumnIndex - 1].Value.ToString().Trim() == "")
                        {
                            row.Cells[e.ColumnIndex - 1].Value = userName;
                        }
                        else
                        {
                            if (!row.Cells[e.ColumnIndex - 1].Value.ToString().Contains(userName) &&
                                row.Cells[e.ColumnIndex - 1].Value.ToString().Trim() != "")
                            {
                                var inside = row.Cells[e.ColumnIndex - 1].Value.ToString();
                                row.Cells[e.ColumnIndex - 1].Value = inside + " , " + userName;
                            }
                        }

                    }
                }
            }
        }

        private void Analyzers_Manager_Bttn_Click(object sender, EventArgs e)
        {
            if (close == false)
            {
                ALL_A_M.AM.Show();
                close = true;
            }
            else
            {
                ALL_A_M.AM.BringToFront();
            }
        }

        private void Tallies_Manager_Bttn_Click(object sender, EventArgs e)
        {
            if (close_tally == false)
            {
                ALL_T_M.TM.Show();
                close_tally = true;
            }

            else
            {
                ALL_T_M.TM.BringToFront();
            }
        }

        private void Counts_Manager_Bttn_Click(object sender, EventArgs e)
        {
            if (close_counts == false)
            {
                ALL_C_M.CM.Show();
                close_counts = true;
            }
            else
            {
                ALL_C_M.CM.BringToFront();
            }
        }

        private void SECOND_QC_Control_Load(object sender, EventArgs e)
        {

            DataGridViewCellStyle style_proc = new DataGridViewCellStyle();           
            style_proc.Font = new Font("Century Gothic", 12f, FontStyle.Bold);
            style_proc.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style_proc.ForeColor = Color.DimGray;            
            dataGridView1.Columns[2].HeaderCell.Style = style_proc;

            DataGridViewCellStyle style_check = new DataGridViewCellStyle();
            style_check.Font = new Font("Century Gothic", 12f, FontStyle.Bold);
            style_check.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style_check.ForeColor = Color.DimGray;
            dataGridView1.Columns[4].HeaderCell.Style = style_check;
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 2)
            {
                if (e.RowIndex == -1)
                {
                    dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.White;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Index == 4)
            {
                if (e.RowIndex == -1)
                {
                    dataGridView1.Columns[4].HeaderCell.Style.ForeColor = Color.White;
                }
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "Sign_Processor")
            //{
                //if (e.RowIndex != -1)
                //{
                    dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.DimGray;
                    dataGridView1.Columns[4].HeaderCell.Style.ForeColor = Color.DimGray;
                //}
            //}
        }
    }
}
