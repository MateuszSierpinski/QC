using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace QC
{
    public partial class LEADERS_Control : UserControl
    {
        string ConnectionString = "Server=localhost; Port=5432; User Id=postgres; Password=root; Database=TEST;";
        public LEADERS_Control()
        {
            InitializeComponent();
            try
            {
                NpgsqlConnection sqlCon = new NpgsqlConnection(ConnectionString);

                sqlCon.Open();

                NpgsqlDataAdapter MyDA = new NpgsqlDataAdapter();
                string sqlSelectAll = "SELECT * FROM public.\"TESTOWA\"";
                MyDA.SelectCommand = new NpgsqlCommand(sqlSelectAll, sqlCon);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                //dataGridView1.Columns.
                dataGridView1.DataSource = bSource;
                dataGridView1.ClearSelection();
            }
            catch 
            { 

            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection sqlCon = new NpgsqlConnection(ConnectionString);

                sqlCon.Open();

                NpgsqlDataAdapter MyDA = new NpgsqlDataAdapter();

                if (Choice_comboBox.SelectedIndex == 0)
                {

                    string sqlSelectAll = "SELECT * FROM public.\"TESTOWA\" where \"TITLE_CODE\" like \'%" + $"{Search_box.Text.Trim().ToUpper()}" + "%\'";
                    MyDA.SelectCommand = new NpgsqlCommand(sqlSelectAll, sqlCon);

                    DataTable table = new DataTable();
                    MyDA.Fill(table);

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    dataGridView1.DataSource = bSource;

                }

                if (Choice_comboBox.SelectedIndex == 1)
                {
                    string sqlSelectAll = "SELECT * FROM public.\"TESTOWA\" where \"JOB_NUMBER\" like \'%" + $"{Search_box.Text.Trim().ToUpper()}" + "%\'";
                    MyDA.SelectCommand = new NpgsqlCommand(sqlSelectAll, sqlCon);

                    DataTable table = new DataTable();
                    MyDA.Fill(table);

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    dataGridView1.DataSource = bSource;

                }

                if (Choice_comboBox.SelectedIndex == 2)
                {
                    string sqlSelectAll = "SELECT * FROM public.\"TESTOWA\" where \"CAFE\" like \'%" + $"{Search_box.Text.Trim().ToUpper()}" + "%\'";
                    MyDA.SelectCommand = new NpgsqlCommand(sqlSelectAll, sqlCon);

                    DataTable table = new DataTable();
                    MyDA.Fill(table);

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    dataGridView1.DataSource = bSource;

                }

                if (Choice_comboBox.SelectedIndex == 3)
                {
                    string sqlSelectAll = "SELECT * FROM public.\"TESTOWA\" where \"PROCESSOR\" like \'%" + $"{Search_box.Text.Trim().ToUpper()}" + "%\'";
                    MyDA.SelectCommand = new NpgsqlCommand(sqlSelectAll, sqlCon);

                    DataTable table = new DataTable();
                    MyDA.Fill(table);

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    dataGridView1.DataSource = bSource;

                }
            }

            catch
            {

            }
        }

        private void LEADERS_Control_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
