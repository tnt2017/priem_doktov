using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace test111
{
    public partial class FormNewOrder : Form
    {
        public FormNewOrder()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string s = DBClass.GET(DBClass.api_url, "svc_id=save_payorder&sdata=" + textBox1.Text);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(s);
            string txt = parsed.data[0].MSG;
            MessageBox.Show(txt);
            textBox_log.Text += txt + "\r\n";
        }

        private void FormNewOrder_Load(object sender, EventArgs e)
        {
            DBClass.OracleRequest("emps_list", dataGridView_orgs, false);
            var source = new AutoCompleteStringCollection();
            for (int i = 0; i < dataGridView_orgs.RowCount - 1; i++)
            {
                string nakl = dataGridView_orgs.Rows[i].Cells["NAME"].Value.ToString();
                source.Add(nakl);
            }


            textBox_emp.AutoCompleteCustomSource = source;
            textBox_emp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_emp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2_TextChanged(null, null);
        }

        private void textBox_org_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_orgs.RowCount; i++)
            {
                dataGridView_orgs.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView_orgs.ColumnCount; j++)
                    if (dataGridView_orgs.Rows[i].Cells[j].Value != null)
                        if (dataGridView_orgs.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox_emp.Text.ToLower()))
                        {
                            dataGridView_orgs.CurrentCell = dataGridView_orgs.Rows[i].Cells[0];
                            dataGridView_orgs.Rows[i].Selected = true;
                            dataGridView_orgs.FirstDisplayedScrollingRowIndex = i;
                            textBox_idemp.Text = dataGridView_orgs.Rows[i].Cells[0].Value.ToString();
                            return;
                        }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String vid = "2"; // было 4=рко, 2=расходное платежное поручение

            if (radioButton1.Checked)
                vid = "4";
            
            if (radioButton2.Checked)
                vid = "2";

            textBox1.Text = "^" + textBox_idemp.Text + "^" + vid + "^20^^^" + textBox_summ.Text + "^1^1^107^1393^" + textBox_prim.Text + "^";
        }
        
        private void textBox_idemp_TextChanged(object sender, EventArgs e)
        {
            textBox2_TextChanged(null, null);
        }

        private void textBox_prim_TextChanged(object sender, EventArgs e)
        {
            textBox2_TextChanged(null, null);
        }
    }
}
