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
    public partial class FormTovsheets : Form
    {
        public FormTovsheets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String url = "get_tovsheets_period" + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") +
                                                  "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy");
            if (comboBox1.SelectedIndex > 0)
                url += "&tip=" + comboBox1.SelectedIndex;

            if (comboBox2.SelectedIndex > 0)
                url += "&sector=" + comboBox2.SelectedItem;


            DBClass.OracleRequest(url, myDataGridView1, false);

            if (myDataGridView1.Rows.Count > 0)
            {
                try
                {
                    myDataGridView1.Columns["ID"].Width = 70;
                    myDataGridView1.Columns["ORG"].Width = 150;
                    myDataGridView1.Columns["NNAKL"].Width = 60;
                    myDataGridView1.Columns["KG_T"].Width = 30;
                    myDataGridView1.Columns["M3_T"].Width = 30;
                    myDataGridView1.Columns["LINES"].Width = 30;
                    myDataGridView1.Columns["ADR_DOST"].Width = 50;
                    myDataGridView1.Columns["KOR_W"].Width = 30;
                    myDataGridView1.Columns["PLACES"].Width = 30;
                }
                catch (Exception ex)
                {

                }

                try
                {
                    myDataGridView1.Columns["CHK_PCT"].Width = 20;
                    myDataGridView1.Columns["PRINTED"].Width = 20;
                    myDataGridView1.Columns["SKL_ZONE"].Width = 30;
                    myDataGridView1.Columns["PICKER"].Width = 60;
                    myDataGridView1.Columns["PACKER"].Width = 60;
                    myDataGridView1.Columns["COLL"].Width = 60;
                    myDataGridView1.Columns["DPRINT"].Width = 70;
                    myDataGridView1.Columns["DPICK"].Width = 70;
                    myDataGridView1.Columns["DPACK"].Width = 70;
                    myDataGridView1.Columns["DCOLL"].Width = 70;

                    myDataGridView1.Columns["CTRIP"].Width = 70;
                    myDataGridView1.Columns["CPARENT"].Width = 70;

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void FormTovsheets_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
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
