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
    public partial class FormNewStat : Form
    {
        public FormNewStat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "list_stat&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" +
                                              dateTimePicker2.Value.ToString("dd.MM.yyyy") + "&login=ROSTOA$NSK20&pass=345544&json=1";
            // MessageBox.Show(url);
            DBClass.OracleRequestCodeReader(url, myDataGridView1, false);

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string idemp = myDataGridView1.CurrentRow.Cells["CPACKER"].Value.ToString();

            string url = "stat_byemp&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend="+ dateTimePicker2.Value.ToString("dd.MM.yyyy") + "&idemp=" + idemp + 
                                              "&login=ROSTOA$NSK20&pass=345544&json=1";

            // MessageBox.Show(url);
            DBClass.OracleRequestCodeReader(url, myDataGridView1, false);
            //SELECT* from NSK20.TOVSHEET ts, NSK20.KATSOTR ks WHERE ts.CPACKER = ks.ID AND CPACKER = 3122 AND to_char(DPACK,'dd.mm.yyyy')= '25.10.2021'
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
