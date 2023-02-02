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
    public partial class FormPlatDoc : Form
    {
        public FormPlatDoc()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FormPlatDoc_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            button1_Click(null, null);
            button5_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("platdoc2&iddoc=" + textBox_iddoc.Text, dataGridView1, textBox_vid);

            try
            {
                textBox_vid.Text = dataGridView1.Rows[0].Cells["VIDOPER"].Value.ToString();
                textBox_flag3.Text = dataGridView1.Rows[0].Cells["FLAG"].Value.ToString();

                textBox_cfirm.Text = dataGridView1.Rows[0].Cells["CFIRM"].Value.ToString();
               // textBox_cperson.Text = dataGridView1.Rows[0].Cells["CPERSON"].Value.ToString();
                //textBox_cagent.Text = dataGridView1.Rows[0].Cells["CAGENT"].Value.ToString();
                textBox_sumpay.Text = dataGridView1.Rows[0].Cells["SUMPAY"].Value.ToString();
                textBox_datob.Text = dataGridView1.Rows[0].Cells["DATOB"].Value.ToString();
                textBox_dmodf.Text = dataGridView1.Rows[0].Cells["DMODF"].Value.ToString();
                textBox_ckasbank.Text = dataGridView1.Rows[0].Cells["CKASBANK"].Value.ToString();
                textBox_ckasir.Text = dataGridView1.Rows[0].Cells["EMP"].Value.ToString();
                textBox_org.Text= dataGridView1.Rows[0].Cells["ORG"].Value.ToString() + " (" + dataGridView1.Rows[0].Cells["CORG"].Value.ToString() + ")";
                textBox_cagent.Text= dataGridView1.Rows[0].Cells["AGENT"].Value.ToString() + " (" + dataGridView1.Rows[0].Cells["CAGENT"].Value.ToString() + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                textBox_osnovanie.Text = dataGridView1.Rows[0].Cells["OSNOVANIE"].Value.ToString();
            }
            catch (Exception ex)
            {

            }


            try
            {
                textBox_kod.Text = dataGridView1.Rows[0].Cells["KOD"].Value.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void FormPlatDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void FormPlatDoc_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void FormPlatDoc_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
            if (e.KeyValue == 27)
                Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOrgs f = new FormOrgs();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEmps f = new FormEmps();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormEmps f = new FormEmps();
            f.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("pay_kinds", myDataGridView1, false);

            myDataGridView1.Columns["ID"].Width = 40;

            for (int i = 0; i < myDataGridView1.RowCount; i++)
            {
                comboBox1.Items.Add(myDataGridView1.Rows[i].Cells["NAME"].Value.ToString() + "(" + myDataGridView1.Rows[i].Cells["ID"].Value.ToString() + ")");
                if (textBox_vid.Text == myDataGridView1.Rows[i].Cells["ID"].Value.ToString())
                    comboBox1.SelectedIndex = i;
            }

            comboBox2.Items.Add("Цен бумаги Меркадо (84)");
            comboBox2.Items.Add("Цен бумаги Сигма (86)");
            comboBox2.Items.Add("Касса Меркадо (92)");
            comboBox2.Items.Add("Касса ТД (107)");

            if (textBox_ckasbank.Text == "107")
            {
                comboBox2.SelectedIndex = 3;
            }

        }
    }
}
