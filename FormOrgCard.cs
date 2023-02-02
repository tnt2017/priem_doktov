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
    public partial class FormOrgCard : Form
    {
        public FormOrgCard()
        {
            InitializeComponent();
        }

        private void FormOrgCard_Load(object sender, EventArgs e)
        {
            DBClass.OracleRequest("org_card&idorg=" + textBox_idorg.Text, dataGridView1, false);
            try
            {
                textBox1.Text = dataGridView1.Rows[0].Cells["NAME"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells["INN"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells["ADR"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells["CAGENT"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[0].Cells["AG_NAME"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[0].Cells["TEL"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[0].Cells["E_MAIL"].Value.ToString();
            }
            catch (Exception ex)
            {

            }

            try
            {
                textBox7.Text = dataGridView1.Rows[0].Cells["TEL2"].Value.ToString();
                textBox9.Text = dataGridView1.Rows[0].Cells["STATUS"].Value.ToString();
                textBox10.Text = dataGridView1.Rows[0].Cells["SVIDET"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
}

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
