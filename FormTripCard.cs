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
    public partial class FormTripCard : Form
    {
        public FormTripCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("get_trip&idtrip=" + textBox_idtrip.Text, myDataGridView1, false);

            try
            {
                textBox_dat.Text = myDataGridView1.Rows[0].Cells["DAT"].Value.ToString();
                textBox_croute.Text = myDataGridView1.Rows[0].Cells["ROUTE"].Value.ToString() + "(" + myDataGridView1.Rows[0].Cells["CROUTE"].Value.ToString() + ")";
            }
            catch (Exception ex)
            {

            }

            try
            {
                textBox_kg.Text = myDataGridView1.Rows[0].Cells["KG"].Value.ToString();
                textBox_lit.Text = myDataGridView1.Rows[0].Cells["LIT"].Value.ToString();
                textBox_pkgs.Text = myDataGridView1.Rows[0].Cells["PKGS"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            try
            {
                textBox9.Text = myDataGridView1.Rows[0].Cells["PLAN"].Value.ToString();
                textBox10.Text = myDataGridView1.Rows[0].Cells["FAKT"].Value.ToString();
            }
            catch (Exception ex)
            {

            }

            try
            {
                textBox_cexped.Text = myDataGridView1.Rows[0].Cells["EXPED"].Value.ToString() + "(" + myDataGridView1.Rows[0].Cells["CEXPED"].Value.ToString() + ")";
            }
            catch(Exception ex)
            {

            }

            try
            {
                textBox_cdriver.Text = myDataGridView1.Rows[0].Cells["DRIVER"].Value.ToString() + "(" + myDataGridView1.Rows[0].Cells["CDRIVER"].Value.ToString() + ")";
            }
            catch (Exception ex)
            {

            }
        }

        private void FormTripCard_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
            button2_Click(null, null);
            button3_Click(null, null);
            button5_Click(null, null);

            dateTimePicker3_ValueChanged(null, null);
            dateTimePicker4_ValueChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("tripdocs&idtrip=" + textBox_idtrip.Text, myDataGridView2, false);

            try
            {
                myDataGridView2.Columns["ID"].Width = 70;
                myDataGridView2.Columns["VOL"].Width = 50;

                myDataGridView2.Columns["VES"].Width = 40;
                myDataGridView2.Columns["KOR"].Width = 40;
                myDataGridView2.Columns["LINES"].Width = 40;

                myDataGridView2.Columns["SUMMA"].Width = 60;
                myDataGridView2.Columns["CAGENT"].Width = 60;
                myDataGridView2.Columns["AGENT"].Width = 80;

                myDataGridView2.Columns["CFIRM"].Width = 40;
                myDataGridView2.Columns["CORG"].Width = 40;
                myDataGridView2.Columns["ADR_DOST"].Width = 60;
                myDataGridView2.Columns["DPLAT"].Width = 60;
                myDataGridView2.Columns["NNAKL"].Width = 60;
                myDataGridView2.Columns["ORG"].Width = 200;
            }
            catch (Exception ex)
            {

            }
        }

        private void myDataGridView2_DoubleClick(object sender, EventArgs e)
        {
            String col_name = myDataGridView2.Columns[myDataGridView2.CurrentCellAddress.X].Name.ToString();

            if (col_name == "CORG")
            {
                string id = myDataGridView2.CurrentRow.Cells["CORG"].Value.ToString();
                FormOrgCard f = new FormOrgCard();
                f.textBox_idorg.Text = id;
                f.ShowDialog();
            }
            else
            {
                string id = myDataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                FormDoc f = new FormDoc();
                f.ID = id;
                f.textBox_iddoc.Text = id;
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("trip_points&idtrip=" + textBox_idtrip.Text, myDataGridView3, false);

            try
            {
                myDataGridView3.Columns["ID"].Width = 80;

                myDataGridView3.Columns["KM_NSK"].Width = 40;
                myDataGridView3.Columns["KM_OFF"].Width = 40;
                myDataGridView3.Columns["NDOCS"].Width = 40;
                myDataGridView3.Columns["KG"].Width = 40;
                myDataGridView3.Columns["M3"].Width = 40;
                myDataGridView3.Columns["SUMM"].Width = 40;
                myDataGridView3.Columns["PKGS"].Width = 40;
                myDataGridView3.Columns["OSMP"].Width = 40;
                myDataGridView3.Columns["NADR"].Width = 40;
                myDataGridView3.Columns["NADR_I"].Width = 40;
                myDataGridView3.Columns["NO_ORIG"].Width = 40;
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sparams="svc_id=save_trip&idtrip=" + textBox_idtrip.Text + "&min0=" + textBox1.Text + "&min1=" + textBox2.Text + "&min2=" + textBox2.Text + "&min3=" + textBox2.Text;
            string s=DBClass.GET(DBClass.api_url, sparams);
            MessageBox.Show(s);
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            int hh = Convert.ToInt16(dateTimePicker4.Value.ToString("HH")) * 60;
            int mm = Convert.ToInt16(dateTimePicker4.Value.ToString("mm"));
            textBox1.Text = (hh+mm).ToString();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            int hh = Convert.ToInt16(dateTimePicker3.Value.ToString("HH")) * 60;
            int mm = Convert.ToInt16(dateTimePicker3.Value.ToString("mm"));
            textBox2.Text = (hh + mm).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequestCodeReader("list_trip_loaders&idtrip=" + textBox_idtrip.Text + "&login=ROSTOA$NSK20&pass=345544&json=1", myDataGridView4, false);

            try
            {
                
            }
            catch (Exception ex)
            {

            }
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string login = "ROSTOA$NSK20";
            string pass = "345544";
            string sector = "1";
            string flg = "2";

            string dta = textBox3.Text + "^1^" + textBox4.Text + "^";

            string url = "p=save_trip_loaders&login=" + login + "&pass=" + pass +
                    "&idtrip=" + textBox_idtrip.Text + "&msg=test&dta=" + dta;

            string s = DBClass.GET(DBClass.mobile_api_url, url);
            MessageBox.Show(s);//DTA:= '';
        }
    }
}
