using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test111
{
    public partial class FormTovMovement : Form
    {
        public FormTovMovement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String login = "ROSTOA$NSK20";
            String pass = "345544";
            String url = "tov_card&login=" + login + "&pass=" + pass + "&idtov=" + textBox_idtov.Text + "&json=1&lines=" + textBox1.Text;
            String xxx = DBClass.GET("https://svc.trianon-nsk.ru/clients/code_reader/index.php", "p=get_tovcard&login=ROSTOA$NSK20&pass=345544&idtov=" + textBox_idtov.Text + "&json=1&lines=" + textBox1.Text);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(xxx);
            dynamic response;
            response = parsed.data;
            myDataGridView1.DataSource = response;


            myDataGridView1.Columns["NNAKL"].Width = 60;
            myDataGridView1.Columns["IFLG2"].Width = 40;
            myDataGridView1.Columns["KOL_MV"].Width = 40;
            myDataGridView1.Columns["SALDO"].Width = 40;
            myDataGridView1.Columns["SALDO2"].Width = 40;
            myDataGridView1.Columns["NN"].Width = 30;
            myDataGridView1.Columns["SAD"].Width = 30;
            myDataGridView1.Columns["DAT"].Width = 110;
            myDataGridView1.Columns["TXT"].Width = 300;
            myDataGridView1.Columns["TYP"].Width = 40;
            try
            {
                myDataGridView1.Columns["REM_D"].Width = 200;
            }
            catch (Exception ex)
            {

            }
            
            myDataGridView1.Columns["ZNAK"].Width = 40;
            try
            {
                myDataGridView1.Columns["DN"].Width = 50;
            }
            catch(Exception ex)
            {

            }

            for (int i = 0; i < myDataGridView1.RowCount - 1; i++)
            {
                Application.DoEvents();
                try
                {
                    string znak = myDataGridView1.Rows[i].Cells["ZNAK"].Value.ToString();

                    if (znak == "+")
                    {
                        for (int j = 0; j < myDataGridView1.ColumnCount; j++)
                        {
                            myDataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml("#8BFCA2"); // приходы
                        }
                    }

                    string typ = myDataGridView1.Rows[i].Cells["TYP"].Value.ToString();

                    if (typ == "инв")
                    {
                        for (int j = 0; j < myDataGridView1.ColumnCount; j++)
                        {
                            myDataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml("#FFA1C6"); // инвентаризации
                        }
                    }
                    if (typ == "ВозК")
                    {
                        for (int j = 0; j < myDataGridView1.ColumnCount; j++)
                        {
                            myDataGridView1.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml("#F7A13E"); // возвраты
                        }
                    }
                    
                }

                catch (Exception ex)
                {

                }

            }
        }


        private void FormTovMovement_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string id = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            FormDoc f = new FormDoc();
            f.ID = id;
            f.textBox_iddoc.Text = id;
            f.ShowDialog();

        }
    }
}
