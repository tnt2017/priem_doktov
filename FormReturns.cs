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
    public partial class FormReturns : Form
    {
        public FormReturns()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("returns_by_idtov&idtov=" + textBox_idtov.Text, myDataGridView1, false);
        }

        private void FormReturns_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string id = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormDoc f = new FormDoc();
            f.ID = id;
            f.textBox_iddoc.Text = id;
            f.ShowDialog();
        }
    }
}
