using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace test111
{
    public partial class FormNewDoc : Form
    {
        String login = "ROSTOA$NSK20";
        String pass = "345544";
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;



        public FormNewDoc()
        {
            InitializeComponent();
        }

        private void FormNewDoc_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            dbFileName = "test.db";

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
        }

        private void textBox_idorg_TextChanged(object sender, EventArgs e)
        {
            DBClass.OracleRequest("adr_list" + "&login=" + login + "&pass=" + pass + "&idorg=" + textBox_idorg.Text, dataGridView_adrs, false);
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

        private void textBox_org_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_orgs.RowCount; i++)
            {
                dataGridView_orgs.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView_orgs.ColumnCount; j++)
                    if (dataGridView_orgs.Rows[i].Cells[j].Value != null)
                        if (dataGridView_orgs.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox_org.Text.ToLower()))
                        {
                            textBox_idorg.Text = dataGridView_orgs.Rows[i].Cells[0].Value.ToString();
                            return;
                        }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
