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
    public partial class FormCreditHist : Form
    {
        public FormCreditHist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("cred_hist&idorg=" + textBox_idorg.Text + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy"), dataGridView1 , false);
            Application.DoEvents();

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                Application.DoEvents();
                try
                {
                    string typ = dataGridView1.Rows[i].Cells["TYP"].Value.ToString();
                    string tip = dataGridView1.Rows[i].Cells["CTIP"].Value.ToString();

                    if (typ == "БонРсх")
                    {
                        dataGridView1.Rows[i].Cells["NNAKL"].Style.BackColor = ColorTranslator.FromHtml("#96FFFF");   
                    }
                    if (typ == "Сверка")
                    {
                        dataGridView1.Rows[i].Cells["NNAKL"].Style.BackColor = ColorTranslator.FromHtml("#A0FFA0"); 
                    }
                    if (typ == "ПлатПор" && tip=="2" )
                    {
                        dataGridView1.Rows[i].Cells["TYP"].Style.BackColor = ColorTranslator.FromHtml("#A0A0FF"); 
                    }
                    if (typ == "КрНотаСф")
                    {
                        dataGridView1.Rows[i].Cells["TYP"].Style.BackColor = ColorTranslator.FromHtml("#A0A0FF");  
                    }

                    string dorig = dataGridView1.Rows[i].Cells["DORIG"].Value.ToString();

                    if (dorig != "")
                    {
                        dataGridView1.Rows[i].Cells["SHIP"].Style.BackColor = ColorTranslator.FromHtml("#FFB460");  
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    int flag = Convert.ToInt32(dataGridView1.Rows[i].Cells["FLAG"].Value.ToString());
                    int val = 16;
                    if (flag != 0)
                    { 
                        if ((flag & val) == flag)
                        {
                            dataGridView1.Rows[i].Cells["TYP"].Style.BackColor = ColorTranslator.FromHtml("#66CDAA");
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            
            dataGridView1.Columns["DNAK"].Width = 60;
            dataGridView1.Columns["DPL"].Width = 60;
            dataGridView1.Columns["NOM"].Width = 70;
            dataGridView1.Columns["TYP"].Width = 60;
            dataGridView1.Columns["SHIP"].Width = 60;
            dataGridView1.Columns["PAY"].Width = 60;
            dataGridView1.Columns["KOD"].Width = 60;
            dataGridView1.Columns["RM"].Width = 100;
            dataGridView1.Columns["IDD"].Width = 100;
            dataGridView1.Columns["CTAB"].Width = 60;
            dataGridView1.Columns["IS_INI"].Width = 30;
            dataGridView1.Columns["SF"].Width = 30;
            dataGridView1.Columns[12].Width = 10;
            dataGridView1.Columns[14].Width = 40;
            dataGridView1.Columns[15].Width = 10;
            dataGridView1.Columns[16].Width = 40;
            dataGridView1.Columns[17].Width = 40;
            dataGridView1.Columns[18].Width = 40;


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormDoc f = new FormDoc();
            f.ID = id;
            f.textBox_iddoc.Text = id;
            f.ShowDialog();
        }

        private void FormCreditHist_Load(object sender, EventArgs e)
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

            button1_Click(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_orgs.RowCount; i++)
            {
                dataGridView_orgs.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView_orgs.ColumnCount; j++)
                    if (dataGridView_orgs.Rows[i].Cells[j].Value != null)
                        if (dataGridView_orgs.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox_org.Text.ToLower()))
                        {
                            dataGridView_orgs.CurrentCell = dataGridView_orgs.Rows[i].Cells[0];
                            dataGridView_orgs.Rows[i].Selected = true;
                            dataGridView_orgs.FirstDisplayedScrollingRowIndex = i;
                            textBox_idorg.Text = dataGridView_orgs.Rows[i].Cells[0].Value.ToString();
                            //
                            return;
                        }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Text = "Кредитная история " + textBox_org.Text;
                button1_Click(null, null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
