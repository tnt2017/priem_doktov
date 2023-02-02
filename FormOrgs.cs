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
    public partial class FormOrgs : Form
    {
        public FormOrgs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FormOrgs_Load(object sender, EventArgs e)
        {
            DBClass.OracleRequest("orgs_list", dataGridView1, false);


            var source = new AutoCompleteStringCollection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string nakl = dataGridView1.Rows[i].Cells["NAME"].Value.ToString();
                source.Add(nakl);
            }


            textBox2.AutoCompleteCustomSource = source;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormOrgCard f = new FormOrgCard();
            f.textBox_idorg.Text = id;
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



         /*   Newtonsoft.Json.Linq.JArray dtt = (Newtonsoft.Json.Linq.JArray)dataGridView1.DataSource;
            Newtonsoft.Json.Linq.JArray dtt2;

            MessageBox.Show(dtt[0].ToString());



            string free = dtt
                .Where(jt => (string)jt["NAME"] ==textBox1.Text) ///(bool)jt["NAME"].Contains(textBox1.Text)
                .Select(jt => (string)jt["NAME"])
                .FirstOrDefault();
            
            MessageBox.Show(free);
            */
            //dtt.Select("NAME LIKE '%" + textBox1.Text + "%'");
            // .DefaultView.RowFilter = 
            // dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                        {
                            dataGridView1.CurrentCell= dataGridView1.Rows[i].Cells[0];
                            dataGridView1.Rows[i].Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                String selItem = this.textBox2.Text;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FormCreditHist f = new FormCreditHist();
            f.textBox_idorg.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            f.ShowDialog();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOrgCard f = new FormOrgCard();
            f.textBox_idorg.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            f.ShowDialog();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormOrgCard f = new FormOrgCard();
            f.textBox_idorg.Text = id;
            f.ShowDialog();
        }
    }

}
