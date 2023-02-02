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
    public partial class FormEmps : Form
    {
        public FormEmps()
        {
            InitializeComponent();
        }

        private void FormEmps_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            DBClass.OracleRequest("emps_list", dataGridView1, false);

            dataGridView1.Columns["ID"].Width = 50;
            dataGridView1.Columns["CSHTAT"].Width = 50;
            dataGridView1.Columns["ADR"].Width = 200;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormEmpCard f = new FormEmpCard();
            f.ID = id;
            f.textBox_idemp.Text = id;
            f.ShowDialog();
        }

        private void FormEmps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
