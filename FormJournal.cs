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
    public partial class FormJournal : Form
    {
        public FormJournal()
        {
            InitializeComponent();
        }

        void ConstructTitle()
        {
            switch (textBoxSelItem.Text)
            {
                case "jrn_kk": this.Text = "Журнал КК"; break;
                case "jrn_nakl_r": this.Text = "Журнал расходных накладных"; break;
                case "jrn_nakl_p": this.Text = "Журнал приходных накладных"; break;
                case "jrn_sfakt_r": this.Text = "Журнал счетов расх"; break;
                case "jrn_sfakt_p": this.Text = "Журнал счетов прих"; break;
                case "jrn_acts": this.Text = "Журнал актов"; break;
                case "jrn_rets": this.Text = "Журнал возвратов"; break;
                case "jrn_dostav": this.Text = "Журнал доставки"; break;
            }

            this.Text += " - " + dataGridView1.RowCount + " строк";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.SelectedItem=

            if (comboBox1.SelectedIndex > -1)
            {
                string sel_item = comboBox1.SelectedItem.ToString();
                sel_item = sel_item.Substring(0, sel_item.IndexOf("//"));
                textBoxSelItem.Text = sel_item;
            }
            else
            {

            }
            DBClass.OracleRequest(textBoxSelItem.Text+ "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy") + "&filter=" + textBox_filter.Text, dataGridView1, false);
            ConstructTitle();
            FormatCols();
        }

        void FormatCols()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns["ID"].Width = 80;
                    dataGridView1.Columns["FLAGS"].Width = 10;
                    dataGridView1.Columns["SF"].Width = 30;
                    dataGridView1.Columns["TYP"].Width = 40;
                    dataGridView1.Columns["TIPSOPR"].Width = 0;

                    dataGridView1.Columns["NDS_10"].Width = 0;
                    dataGridView1.Columns["NDS_18"].Width = 0;
                    dataGridView1.Columns["CHRG"].Width = 0;
                    dataGridView1.Columns["PRN_FLAGS"].Width = 0;
                    dataGridView1.Columns["SKL"].Width = 0;
                    dataGridView1.Columns["FIRM"].Width = 0;

                    dataGridView1.Columns["NNAKL"].Width = 60;
                    dataGridView1.Columns["SUMMA"].Width = 60;

                    dataGridView1.Columns["TXT"].Width = 200;
                    dataGridView1.Columns["ORG"].Width = 200;
                    dataGridView1.Columns["ADR"].Width = 200;

                    dataGridView1.Columns["CORG"].Width = 40;
                    dataGridView1.Columns["KG"].Width = 40;
                }
            }
            catch (Exception ex)
            {

            }
        }                    

    private void FormJournal_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(textBoxSelItem.Text);
            if(textBoxSelItem.Text== "jrn_sfact_p")
                dateTimePicker1.Value = DateTime.Today.AddDays(-4);
            else
                dateTimePicker1.Value = DateTime.Today.AddDays(-1);

            dateTimePicker2.Value = DateTime.Today.AddDays(1);

            DBClass.OracleRequest(textBoxSelItem.Text + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy"), dataGridView1, false);
            ConstructTitle();
            FormatCols();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string s=dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();

            if (s == "CTRIP")
            {
                string ctrip = dataGridView1.CurrentRow.Cells["CTRIP"].Value.ToString();
                FormTripCard f = new FormTripCard();
                f.textBox_idtrip.Text = ctrip;
                f.ShowDialog();
            }
            else
            {
                string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                FormDoc f = new FormDoc();
                f.ID = id;
                f.textBox_iddoc.Text = id;
                f.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
