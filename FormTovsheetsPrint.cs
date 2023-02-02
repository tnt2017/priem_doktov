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
    public partial class FormTovsheetsPrint : Form
    {
        public FormTovsheetsPrint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                string url = "list_sheet_print&login=ROSTOA$NSK20&pass=345544&idemp=" + textBox_idemp.Text + "&izone=1&json=1";
                DBClass.OracleRequestCodeReader(url, myDataGridView1, false);
                myDataGridView1.Columns["DT"].Width = 70;
                myDataGridView1.Columns["ROUTE"].Width = 150;
                myDataGridView1.Columns["LNS"].Width = 30;
                myDataGridView1.Columns["KOR"].Width = 30;
                myDataGridView1.Columns["M3"].Width = 30;
                myDataGridView1.Columns["KG"].Width = 30;
                myDataGridView1.Columns["CTRL"].Width = 30;
                myDataGridView1.Columns["NN"].Width = 30;
                myDataGridView1.Columns["ITRIP"].Width = 30;
                myDataGridView1.Columns["CZONE"].Width = 30;
                myDataGridView1.Columns["NNAKL"].Width = 60;
                myDataGridView1.Columns["ID"].Width = 80;
                myDataGridView1.Columns["ORG"].Width = 60;
            }
            else
            {
                string url = "list_sheet_4check&login=ROSTOA$NSK20&pass=345544&idemp=" + textBox_idemp.Text + "&izone=1&json=1";
                DBClass.OracleRequestCodeReader(url, myDataGridView1, false);
                myDataGridView1.Columns["LINES"].Width = 30;
                myDataGridView1.Columns["PICK"].Width = 30;
                myDataGridView1.Columns["FLG"].Width = 30;
                myDataGridView1.Columns["MISS"].Width = 30;
                myDataGridView1.Columns["IDT"].Width = 70;
                myDataGridView1.Columns["ID"].Width = 70;
                myDataGridView1.Columns["IDS"].Width = 70;

            }
        }

        private void FormTovsheetsPrint_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormTovsheet f = new FormTovsheet();
            f.textBox_idsheet.Text = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            f.ShowDialog();
        }
    }
}
