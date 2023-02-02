using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test111
{
    public partial class FormTovLines : Form
    {
        public FormTovLines()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("tov_lines&idtov=" + textBox_idtov.Text, myDataGridView1, false);
        //    myDataGridView1.Columns["NAME"].Width = 300;

        }

        private void FormTovLines_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string iddoc = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormDoc f = new FormDoc();
            f.ID = iddoc;
            f.textBox_iddoc.Text = iddoc;
            f.ShowDialog();
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
