using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string files , string rows , string columns , bool boolean)
        {
            InitializeComponent();

            DataTable dt = new DataTable() { TableName = "dataGridView1" };

            dt.Columns.Add(new DataColumn("File", typeof(string)));
            dt.Columns.Add(new DataColumn("Row", typeof(string)));
            dt.Columns.Add(new DataColumn("Column", typeof(string)));

            foreach (var row in rows)
            {
                dt.Rows.Add(row);
            }

            if (boolean == false)
            {
                label10.Text = "N/A";
                label11.Text = "N/A";
                label12.Text = "N/A";
            }

            else
            {
                label3.Text = rows;
                label2.Text = columns;
                label1.Text = files;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj3 = new Form1();
            obj3.Show();
        }
    }
}
