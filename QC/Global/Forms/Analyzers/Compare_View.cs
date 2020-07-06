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
    public partial class Compare_View : Form
    {
        DataTable Table_Input = null;
        DataTable Table_Output = null;
        List<DataTable> Table_Input_List = null;

        void Non_Sort(DataGridView cos)
        {
            foreach (DataGridViewColumn column in cos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public Compare_View(DataTable table_input, DataTable table_output, List<DataTable> table_input_list)
        {
            InitializeComponent();

            Table_Input = table_input;
            Table_Output = table_output;
            Table_Input_List = table_input_list;           

        }

        private void Compare_View_Load(object sender, EventArgs e)
        {
            Input_Data_Grid_View.BackgroundColor = Color.FromArgb(50, 50, 50);
            Input_Data_Grid_View.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 158, 220);
            Input_Data_Grid_View.ColumnHeadersHeight = 50;
            Input_Data_Grid_View.BorderStyle = BorderStyle.None;
            Input_Data_Grid_View.RowHeadersVisible = false;
            Input_Data_Grid_View.AllowUserToAddRows = false;
            Input_Data_Grid_View.AllowUserToDeleteRows = false;
            Input_Data_Grid_View.EnableHeadersVisualStyles = false;
            Input_Data_Grid_View.Width = (this.Width / 2) - 20;
            Input_Data_Grid_View.Location = new Point(10, 10);

            Output_Data_Grid_View.BackgroundColor = Color.FromArgb(50, 50, 50);
            Output_Data_Grid_View.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 158, 220);
            Output_Data_Grid_View.ColumnHeadersHeight = 50;
            Output_Data_Grid_View.BorderStyle = BorderStyle.None;
            Output_Data_Grid_View.RowHeadersVisible = false;
            Output_Data_Grid_View.AllowUserToAddRows = false;
            Output_Data_Grid_View.AllowUserToDeleteRows = false;
            Output_Data_Grid_View.EnableHeadersVisualStyles = false;
            Output_Data_Grid_View.Location = new Point((this.Width / 2), 10);
            Output_Data_Grid_View.Width = (this.Width / 2) - 30;

            if (Table_Input_List == null)
            {
                DataView InputdataView = new DataView(Table_Input);
                DataView OutputdataView = new DataView(Table_Output);

                Input_Data_Grid_View.DataSource = InputdataView;
                Output_Data_Grid_View.DataSource = OutputdataView;

                for (int i = Input_Data_Grid_View.RowCount - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Output_Data_Grid_View.RowCount; j++)
                    {
                        string row = Output_Data_Grid_View.Rows[j].Cells[0].Value.ToString();
                        string row2 = Input_Data_Grid_View.Rows[i].Cells[0].Value.ToString();

                        if (row == row2)
                        {
                            for (int z = 0; z < Input_Data_Grid_View.Columns.Count; z++)
                            {
                                string cell = Output_Data_Grid_View.Rows[j].Cells[z].Value.ToString();
                                string cell2 = Input_Data_Grid_View.Rows[i].Cells[z].Value.ToString();

                                if (cell == cell2)
                                {
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.BackColor = Color.Lime;
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.ForeColor = Color.Black;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.BackColor = Color.Lime;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.ForeColor = Color.Black;
                                }
                                else
                                {
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.BackColor = Color.Red;
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.ForeColor = Color.White;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.BackColor = Color.Red;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.ForeColor = Color.White;
                                }
                            }

                            //break;
                        }
                        else
                        {
                            Input_Data_Grid_View.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            Output_Data_Grid_View.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            }

            else
            {

                var MyData = Table_Input_List[0].Copy();

                DataTable table = new DataTable();

                for (int z = 1; z < Table_Input_List.Count; z++) 
                {

                    var cos = Table_Input_List[z].AsEnumerable().Where(
                              r => !MyData.AsEnumerable().Select(x => x["FIELD_NAME"]).Contains(r["FIELD_NAME"]));

                    if (cos.Any())
                    {
                        MyData.Merge(cos.CopyToDataTable());
                    }


                    for (int i = MyData.Rows.Count - 1; i >= 0; i--)
                    {
                        var blank_count = Convert.ToInt32(MyData.Rows[i][3]);
                        var field_count = Convert.ToInt32(MyData.Rows[i][4]);
                        var total_count = Convert.ToInt32(MyData.Rows[i][5]);



                        for (int j = 0; j < Table_Input_List[z].Rows.Count; j++)
                        {
                            string row = Table_Input_List[z].Rows[j][0].ToString();
                            string row2 = MyData.Rows[i][0].ToString();

                            if (row == row2)
                            {

                                var maxlenght = Convert.ToInt32(MyData.Rows[i][1]);
                                var maxlenght2 = Convert.ToInt32(Table_Input_List[z].Rows[j][1]);

                                if (maxlenght2 > maxlenght) MyData.Rows[i][1] = Table_Input_List[z].Rows[j][1];

                                var minlenght = Convert.ToInt32(MyData.Rows[i][2]);
                                var minlenght2 = Convert.ToInt32(Table_Input_List[z].Rows[j][2]);

                                if (minlenght2 < minlenght && minlenght2 > 0 || minlenght == 0 ) MyData.Rows[i][2] = Table_Input_List[z].Rows[j][2];

                                blank_count += Convert.ToInt32(Table_Input_List[z].Rows[j][3]);
                                MyData.Rows[i][3] = blank_count;

                                field_count += Convert.ToInt32(Table_Input_List[z].Rows[j][4]);
                                MyData.Rows[i][4] = field_count;

                                total_count += Convert.ToInt32(Table_Input_List[z].Rows[j][5]);
                                MyData.Rows[i][5] = total_count;

                                double percentage = (((double)field_count * 100)/(double)total_count)-0.0047;
                                string percentage_txt = string.Format("{0:0.00}", percentage) + " %";
                                MyData.Rows[i][6] = percentage_txt;

                            }
                        }
                    }
                }



                DataView InputdataView = new DataView(MyData);
                DataView OutputdataView = new DataView(Table_Output);

                Input_Data_Grid_View.DataSource = InputdataView;
                Output_Data_Grid_View.DataSource = OutputdataView;

                for (int i = Input_Data_Grid_View.RowCount - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Output_Data_Grid_View.RowCount; j++)
                    {
                        string row = Output_Data_Grid_View.Rows[j].Cells[0].Value.ToString();
                        string row2 = Input_Data_Grid_View.Rows[i].Cells[0].Value.ToString();

                        if (row == row2)
                        {
                            for (int z = 0; z < Input_Data_Grid_View.Columns.Count; z++)
                            {
                                string cell = Output_Data_Grid_View.Rows[j].Cells[z].Value.ToString();
                                string cell2 = Input_Data_Grid_View.Rows[i].Cells[z].Value.ToString();

                                if (cell == cell2)
                                {
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.BackColor = Color.Lime;
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.ForeColor = Color.Black;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.BackColor = Color.Lime;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.ForeColor = Color.Black;
                                }
                                else
                                {
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.BackColor = Color.Red;
                                    Input_Data_Grid_View.Rows[i].Cells[z].Style.ForeColor = Color.White;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.BackColor = Color.Red;
                                    Output_Data_Grid_View.Rows[j].Cells[z].Style.ForeColor = Color.White;
                                }
                            }

                            //break;
                        }
                        else
                        {
                            Input_Data_Grid_View.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            Output_Data_Grid_View.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }

            }

                Non_Sort(Input_Data_Grid_View);
                Non_Sort(Output_Data_Grid_View);
                Input_Data_Grid_View.ClearSelection();
                Output_Data_Grid_View.ClearSelection();
            
        }

        private void Compare_View_SizeChanged(object sender, EventArgs e)
        {
            Output_Data_Grid_View.Location = new Point((this.Width / 2), 10);
            Output_Data_Grid_View.Width = (this.Width / 2) - 30;

            Input_Data_Grid_View.Width = (this.Width/2) - 20;
        }
    }

}
