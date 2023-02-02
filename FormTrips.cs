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
    public partial class FormTrips : Form
    {
        public FormTrips()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("list_daily_trips&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy"), myDataGridView1, false);
            try
            {
                myDataGridView1.Columns["NN"].Width = 20;
                myDataGridView1.Columns["DT"].Width = 70;
                myDataGridView1.Columns["ROUTE"].Width = 120;

                myDataGridView1.Columns["KG"].Width = 40;
                myDataGridView1.Columns["M3"].Width = 40;
                myDataGridView1.Columns["PLC"].Width = 40;
                myDataGridView1.Columns["LINPRC"].Width = 50;
                myDataGridView1.Columns["KOR_AU"].Width = 30;

                myDataGridView1.Columns["LN_NO_1"].Width = 0;
                myDataGridView1.Columns["LN_NO_2"].Width = 0;
                myDataGridView1.Columns["LN_NO_3"].Width = 0;
                myDataGridView1.Columns["LN_NO_4"].Width = 0;
                myDataGridView1.Columns["LN_NO_5"].Width = 0;
                myDataGridView1.Columns["LN_NO_6"].Width = 0;
                myDataGridView1.Columns["CLPKG"].Width = 40;
                myDataGridView1.Columns["LINES"].Width = 40;
                myDataGridView1.Columns["ADR_CNT"].Width = 30;
                myDataGridView1.Columns["SHEETS"].Width = 40;

                myDataGridView1.Columns["H1"].Width = 50;
                myDataGridView1.Columns["H2"].Width = 50;
                myDataGridView1.Columns["H3"].Width = 50;
                myDataGridView1.Columns["H4"].Width = 50;
                myDataGridView1.Columns["H5"].Width = 50;


                myDataGridView1.Columns["LINES_NO"].Width = 30;
                myDataGridView1.Columns["LINES_K"].Width = 30;
                myDataGridView1.Columns["LINES_K_NO"].Width = 30;
                myDataGridView1.Columns["LINES_2CHECK"].Width = 50;
                myDataGridView1.Columns["LINES_PRN"].Width = 30;
                myDataGridView1.Columns["SHEETS_NOT"].Width = 30;
                myDataGridView1.Columns["NO_PACK"].Width = 30;
                myDataGridView1.Columns["CTRIP"].Width = 60;

            }
            catch (Exception ex)
            {

            }
            double kg_night = 0;
            double m3_night = 0;
            double kg_day = 0;
            double m3_day = 0;

            for (int i = 0; i < myDataGridView1.RowCount; i++)
            {
                int hour = Convert.ToInt16(myDataGridView1.Rows[i].Cells["DT"].Value.ToString()[6].ToString() + myDataGridView1.Rows[i].Cells["DT"].Value.ToString()[7].ToString());
               // MessageBox.Show(myDataGridView1.Rows[i].Cells["DT"].Value.ToString() + " : " + hour.ToString());
                if (hour>20 || hour < 7)
                {
                    kg_night += Convert.ToDouble(myDataGridView1.Rows[i].Cells["KG"].Value);
                    m3_night += Convert.ToDouble(myDataGridView1.Rows[i].Cells["M3"].Value);
                }
                else
                {
                    kg_day += Convert.ToDouble(myDataGridView1.Rows[i].Cells["KG"].Value);
                    m3_day += Convert.ToDouble(myDataGridView1.Rows[i].Cells["M3"].Value);
                }

            }
            textBox1.Text = kg_night.ToString();
            textBox2.Text = m3_night.ToString();

            textBox8.Text = kg_day.ToString();
            textBox9.Text = m3_day.ToString();

            textBox3.Text = (kg_night + kg_day).ToString();
            textBox4.Text = (m3_night + m3_day).ToString();
        }

        private void FormTrips_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);
            dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);
            dateTimePicker3.Value = new DateTime(DateTime.Now.AddDays(2).Year, DateTime.Now.AddDays(2).Month, DateTime.Now.AddDays(2).Day, 12, 0, 0);

            button1_Click(null, null);
            button2_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormTripCard f = new FormTripCard();
            f.textBox_idtrip.Text = myDataGridView1.CurrentRow.Cells["CTRIP"].Value.ToString();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("ves_prihodov&dbeg=" + dateTimePicker2.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker3.Value.ToString("dd.MM.yyyy"), myDataGridView2, false);
            double kg = 0;
            double m3 = 0;
            double ln = 0;
            double pk = 0;

            for (int i = 0; i < myDataGridView2.RowCount; i++)
            {
                kg += Convert.ToDouble(myDataGridView2.Rows[i].Cells["VES"].Value);
                m3 += Convert.ToDouble(myDataGridView2.Rows[i].Cells["VOL"].Value);
            }
            textBox5.Text = kg.ToString();
            textBox6.Text = m3.ToString();
 
            double itogo = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox5.Text);
            textBox_itogo.Text = itogo.ToString();
            double loaders = itogo / 12000;
            textBox7.Text = Math.Round(loaders,2).ToString();
        }

        private void myDataGridView2_DoubleClick(object sender, EventArgs e)
        {
            string id = myDataGridView2.CurrentRow.Cells["ID"].Value.ToString();
            FormDoc f = new FormDoc();
            f.ID = id;
            f.textBox_iddoc.Text = id;
            f.ShowDialog();
        }
    }
}
