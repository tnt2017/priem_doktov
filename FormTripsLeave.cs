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
    public partial class FormTripsLeave : Form
    {
        public FormTripsLeave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sparams = "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy");

            string url = "trips_leave";// + sparams;
            //textBox3.Text = url;

            DBClass.OracleRequest(url, myDataGridView1, false);

            int sum_opozd_min=0;

            int reisov_vovremya = 0;
            int reisov_nevovremya = 0;

            for (int i = 0; i < myDataGridView1.RowCount ; i++)
            {
                string opozdanie = myDataGridView1.Rows[i].Cells["OPOZDANIE"].Value.ToString();
                string vovremya = myDataGridView1.Rows[i].Cells["VOVREMYA"].Value.ToString();

                sum_opozd_min += Convert.ToInt32(opozdanie);

                if(vovremya=="1")
                    reisov_vovremya ++;
                else
                    reisov_nevovremya ++;

                Application.DoEvents();
                try
                {

                    if (vovremya == "0")
                    {
                        for (int j = 0; j < myDataGridView1.ColumnCount; j++)
                        {
                            myDataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml("#FFA1C6");
                        }
                    }
                    else
                    {
                        for (int j = 0; j < myDataGridView1.ColumnCount; j++)
                        {
                            myDataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml("#8BFCA2");
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            label1.Text = "Рейсов вовремя: " + reisov_vovremya.ToString();
            label2.Text = "Рейсов опоздало: " + reisov_nevovremya; 
            label3.Text = "Суммарное опоздание: " + sum_opozd_min.ToString() + " минут";

        }
    }
}
