using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace test111
{
    public partial class FormEmpCard : Form
    {
        public string ID = "";

        public FormEmpCard()
        {
            InitializeComponent();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
             
        }
        private void FormEmpCard_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            DBClass.OracleRequest("get_emp_card&idemp=" + textBox_idemp.Text,dataGridView1, false);
            try
            {
                textBox1.Text = dataGridView1.Rows[0].Cells["NAME"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells["NAME_NAME"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells["NAME_FATHER"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[0].Cells["TEL"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[0].Cells["BIRTHDATE"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells["DEMPLOY"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[0].Cells["PASPORT"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[0].Cells["ADDR_REG"].Value.ToString();
            }
            catch (Exception ex)
            {

            }

            try
            {
                textBox9.Text = dataGridView1.Rows[0].Cells["E_MAIL"].Value.ToString();
                textBox10.Text = dataGridView1.Rows[0].Cells["TEL_INT"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void FormEmpCard_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormEmpCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }

        }
    }
}
