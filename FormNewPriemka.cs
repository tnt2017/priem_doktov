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
    public partial class FormNewPriemka : Form
    {
        public FormNewPriemka()
        {
            InitializeComponent();
        }

        String login = "ROSTOA$NSK20";
        String pass = "345544";


        private void FormPriemka_Load(object sender, EventArgs e)
        {
            DBClass.OracleRequest("orgs_list", dataGridView_orgs, false);
            var source = new AutoCompleteStringCollection();
            for (int i = 0; i < dataGridView_orgs.RowCount - 1; i++)
            {
                string nakl = dataGridView_orgs.Rows[i].Cells["NAME"].Value.ToString();
                source.Add(nakl);
            }

            textBox_org.AutoCompleteCustomSource = source;
            textBox_org.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_org.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DBClass.OracleRequest("emps_list", dataGridView_emps, false);
            var source2 = new AutoCompleteStringCollection();
            for (int i = 0; i < dataGridView_emps.RowCount - 1; i++)
            {
                string nakl = dataGridView_emps.Rows[i].Cells["NAME"].Value.ToString();
                source2.Add(nakl);
            }

            textBox_emp.AutoCompleteCustomSource = source2;
            textBox_emp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_emp.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_org_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_orgs.RowCount; i++)
            {
                dataGridView_orgs.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView_orgs.ColumnCount; j++)
                    if (dataGridView_orgs.Rows[i].Cells[j].Value != null)
                        if (dataGridView_orgs.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox_org.Text.ToLower()))
                        {
                            takeover_idorg.Text = dataGridView_orgs.Rows[i].Cells[0].Value.ToString();
                            return;
                        }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String msg = takeover_idadr.Text + '^' + takeover_idexp.Text + '^' +
            takeover_packages.Text + '^' + takeover_palets.Text + '^' +
            takeover_iddoc.Text + '^' + takeover_prim.Text + '^';
                         

            string msg2 = DBClass.GET(DBClass.api_url, "svc_id=save_takeover&idemp=" + takeover_idexp.Text + "&msg=" + msg);
            MessageBox.Show(msg2);

        }

        private void takeover_iddoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void takeover_idorg_TextChanged(object sender, EventArgs e)
        {
            if (takeover_idorg.Text.ToString().Length > 1)
            {
                DBClass.OracleRequest("prh_list" + "&login=" + login + "&pass=" + pass + "&idorg=" + takeover_idorg.Text, dataGridView_docs, false);

                comboBox1.Items.Clear();
                for (int i = 0; i < dataGridView_docs.RowCount - 1; i++)
                {
                    comboBox1.Items.Add(dataGridView_docs.Rows[i].Cells["ID"].Value.ToString() + " " + 
                                        dataGridView_docs.Rows[i].Cells["DNAKL"].Value.ToString() + " " + 
                                        dataGridView_docs.Rows[i].Cells["NNAKL"].Value.ToString() + " " + 
                                        dataGridView_docs.Rows[i].Cells["SUMMA"].Value.ToString());
                }

                try
                {
                    comboBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }

                DBClass.OracleRequest("adr_list" + "&login=" + login + "&pass=" + pass + "&idorg=" + takeover_idorg.Text, dataGridView_adrs, false);
                comboBox2.Items.Clear();
                for (int i = 0; i < dataGridView_adrs.RowCount - 1; i++)
                {
                    comboBox2.Items.Add(dataGridView_adrs.Rows[i].Cells["ID"].Value.ToString() + " " + 
                                        dataGridView_adrs.Rows[i].Cells["NAME_NP"].Value.ToString() + " " +
                                        dataGridView_adrs.Rows[i].Cells["VID_PRCH"].Value.ToString() + " " +
                                        dataGridView_adrs.Rows[i].Cells["NAME_PRCH"].Value.ToString() + " " +
                                        dataGridView_adrs.Rows[i].Cells["NUM_DOMA"].Value.ToString());
                }

                try
                {
                    comboBox2.SelectedIndex = 0;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.Items[comboBox1.SelectedIndex].ToString();
           // MessageBox.Show(s);
            takeover_iddoc.Text = s.Substring(0, s.IndexOf(" "));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            //MessageBox.Show(s);
            takeover_idadr.Text = s.Substring(0, s.IndexOf(" "));
        }

        private void textBox_emp_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_emps.RowCount; i++)
            {
                dataGridView_emps.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView_emps.ColumnCount; j++)
                    if (dataGridView_emps.Rows[i].Cells[j].Value != null)
                        if (dataGridView_emps.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox_emp.Text.ToLower()))
                        {
                            takeover_idexp.Text = dataGridView_emps.Rows[i].Cells[0].Value.ToString();
                            return;
                        }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
