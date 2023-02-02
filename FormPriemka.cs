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
    public partial class FormPriemka : Form
    {
        public FormPriemka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "list_takeover&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" +
                                                          dateTimePicker2.Value.ToString("dd.MM.yyyy") + "&login=ROSTOA$NSK20&pass=345544&json=1";
           // MessageBox.Show(url);
            DBClass.OracleRequest(url, myDataGridView1, false);
            myDataGridView1.Columns["NN"].Width = 30;
            myDataGridView1.Columns["PKGS"].Width = 30;
            myDataGridView1.Columns["PALL"].Width = 30;
            myDataGridView1.Columns["KOR"].Width = 30;
            myDataGridView1.Columns["CNT"].Width = 30;
            myDataGridView1.Columns["PCT"].Width = 30;
            myDataGridView1.Columns["CADR"].Width = 60;
            myDataGridView1.Columns["PCT_CHK"].Width = 30;
            myDataGridView1.Columns["ORG"].Width = 150;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNewPriemka f = new FormNewPriemka();
            f.ShowDialog();
        }

        private void FormPriemka_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);

            button1_Click(null, null);
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string s = myDataGridView1.Columns[myDataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();

            if (s == "CTRIP")
            {
                string ctrip = myDataGridView1.CurrentRow.Cells["CTRIP"].Value.ToString();
                FormTripCard f = new FormTripCard();
                f.textBox_idtrip.Text = ctrip;
                f.ShowDialog();
            }
            else
            {
                FormDoc f = new FormDoc();
                f.ID = myDataGridView1.CurrentRow.Cells["CBDOC"].Value.ToString();
                f.textBox_iddoc.Text = f.ID;
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
