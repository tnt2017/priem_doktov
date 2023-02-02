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
    public partial class FormTovAudit : Form
    {
        public FormTovAudit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("get_tov_audit&idtov=" + textBox_idtov.Text, myDataGridView1, false);
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


        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormTovAudit_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            button1_Click(null, null);
        }

        private void FormTovAudit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
