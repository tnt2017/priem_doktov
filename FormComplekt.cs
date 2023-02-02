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
    public partial class FormComplekt : Form
    {
        public FormComplekt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("list_collect&dton=" + dateTimePicker1.Value.ToString("dd.MM.yyyy"), myDataGridView1, false);
            myDataGridView1.Columns["ORG"].Width = 300;
            myDataGridView1.Columns["ADR"].Width = 300;
            myDataGridView1.Columns["ID"].Width = 70;
            myDataGridView1.Columns["ROUTE"].Width = 70;
            myDataGridView1.Columns["CADR"].Width = 70;
            try
            {
                myDataGridView1.Columns["PKG_S"].Width = 30;
                myDataGridView1.Columns["IROUTE"].Width = 30;
                myDataGridView1.Columns["NOREADY"].Width = 200;
            }
            catch (Exception ex)
            {

            }
            myDataGridView1.Columns["NAS_PT"].DisplayIndex = 5;
            myDataGridView1.Columns["PKG_S"].DisplayIndex = 6;
        }

        private void FormComplekt_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string ctrip = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string cadr = myDataGridView1.CurrentRow.Cells["CADR"].Value.ToString();
            string route = myDataGridView1.CurrentRow.Cells["ROUTE"].Value.ToString();
            string org = myDataGridView1.CurrentRow.Cells["ORG"].Value.ToString();

            FormComplektAdr f = new FormComplektAdr();
            f.ctrip.Text = ctrip;
            f.cadr.Text = cadr;
            f.textBox_route.Text = route;
            f.textBox_org.Text = org;

            f.ShowDialog();
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDataGridView1.MultiSelect = false;
            for (int i = 0; i < myDataGridView1.Rows.Count - 1; i++)
            {
                if (myDataGridView1.Rows[i].Cells["ORG"].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()) || myDataGridView1.Rows[i].Cells["ROUTE"].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    myDataGridView1.FirstDisplayedScrollingRowIndex = i;
                    myDataGridView1.Rows[i].Selected = true;
                    myDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                } 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }
    }
}
