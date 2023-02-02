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
    public partial class FormListNotMatched : Form
    {
        public FormListNotMatched()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://svc.trianon-nsk.ru/clients/code_reader/index.php?p=get_list_notmatched&login=ROSTOA$NSK20&pass=345544&ssec0=A-00-0&ssec1=Z-99-4&ndays=1000&rsum=1&patt=%D1%82%D0%B5%D1%82%D1%80%D0%B0%D0%B4%D1%8C&json=1";
            // MessageBox.Show(url);
            DBClass.OracleRequest(url, myDataGridView1, false);
          /*  myDataGridView1.Columns["NN"].Width = 30;
            myDataGridView1.Columns["PKGS"].Width = 30;
            myDataGridView1.Columns["PALL"].Width = 30;
            myDataGridView1.Columns["KOR"].Width = 30;
            myDataGridView1.Columns["CNT"].Width = 30;
            myDataGridView1.Columns["PCT"].Width = 30;
            myDataGridView1.Columns["CADR"].Width = 60;
            myDataGridView1.Columns["PCT_CHK"].Width = 30;
            myDataGridView1.Columns["ORG"].Width = 150;*/
        }

        private void FormListNotMatched_Load(object sender, EventArgs e)
        {

        }
    }
}
