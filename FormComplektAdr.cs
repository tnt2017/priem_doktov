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
    public partial class FormComplektAdr : Form
    {
        public FormComplektAdr()
        {
            InitializeComponent();
        }

        private void FormComplektAdr_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "list_collect_addr&idtrip=" + ctrip.Text + "&idadr=" + cadr.Text;
            DBClass.OracleRequest(url, myDataGridView1, false);

            try
            {
                myDataGridView1.Columns["ID"].Width = 70;
                myDataGridView1.Columns["NOM"].Width = 70;
                myDataGridView1.Columns["PLACES"].Width = 30;
            }
            catch(Exception ex)
            {

            }

            int PLACES = 0;
            for (int i = 0; i < myDataGridView1.Rows.Count ; i++)
            {
                PLACES += Convert.ToInt16(myDataGridView1.Rows[i].Cells["PLACES"].Value.ToString());
            }
            textbox_places.Text = PLACES.ToString();
         }

        private void ctrip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  -- sHdr='ctrip^cadr^flg^pkg^' ,  19.05.21
            string shdr = ctrip.Text + "^" + cadr.Text + "^" + "0^0^";
            string slns="";
            string s;
            for (int i = 0; i < myDataGridView1.Rows.Count - 1; i++)
            {
                s = myDataGridView1.Rows[i].Cells["ID"].Value.ToString() + "^" + myDataGridView1.Rows[i].Cells["PLACES"].Value.ToString() + "^";
                slns += s;
            }

            MessageBox.Show("shdr=" + shdr + "\r\n" + "slns=" + slns);
            string msg = DBClass.GET(DBClass.api_url, "save_adr_collect&shdr=" + shdr + "&slns=" + slns);
            MessageBox.Show(msg);
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string iddoc = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormTovsheet f = new FormTovsheet();
            f.textBox_idsheet.Text = iddoc;
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "save_adr_collect&ctrip=" + ctrip.Text + "&cadr=" + cadr.Text + "&places=" + textbox_places.Text + "&trip=" + textBox_route.Text + "&idemp=" + textBox_idemp.Text;
            string r = DBClass.GET("http://192.168.1.145/insert.php", s);
            MessageBox.Show(r);
        }
    }
}
