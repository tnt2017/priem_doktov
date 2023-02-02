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
    public partial class FormAuditTovsheet : Form
    {
        public FormAuditTovsheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("get_tovsheet_audit&idsheet=" + textBox_idsheet.Text, myDataGridView1, false);
            try
            {
                myDataGridView1.Columns["FLAGS"].Width = 40;
                myDataGridView1.Columns["VES"].Width = 40;
                myDataGridView1.Columns["RAZMER"].Width = 40;
                myDataGridView1.Columns["KOL_UPAK"].Width = 40;

                myDataGridView1.Columns["DSERT"].Width = 60;
                myDataGridView1.Columns["NOMENKL"].Width = 60;

            }
            catch (Exception ex)
            {

            }
        }

        private void FormAuditTovsheet_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
