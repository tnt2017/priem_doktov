using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace test111
{
    public partial class FormTovCard : Form
    {
        public string ID = "";

        public FormTovCard()
        {
            InitializeComponent();
        }
        
        private void FormTovCard_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            button1_Click(null, null);
            pictureBox1.LoadAsync("https://svc.trianon-nsk.ru/tpic/preview.php?src=" + textBox_idtov.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("get_tov&idtov=" + textBox_idtov.Text, dataGridView1, textBox1);

            try
            {
                textBox_name.Text = dataGridView1.Rows[0].Cells["NAME"].Value.ToString();
                textBox_ves.Text = dataGridView1.Rows[0].Cells["VES"].Value.ToString();
                textBox_razmer.Text = dataGridView1.Rows[0].Cells["RAZMER"].Value.ToString();

                textBox_kolupak.Text = dataGridView1.Rows[0].Cells["KOL_UPAK"].Value.ToString();
            }
            catch (Exception ex)
            {
            }

            try
            {
                textBox_DSERT_BEG.Text = dataGridView1.Rows[0].Cells["DSERT_BEG"].Value.ToString();
                textBox_DSERT.Text = dataGridView1.Rows[0].Cells["DSERT"].Value.ToString();
                textBox_NSERT.Text = dataGridView1.Rows[0].Cells["NSERT"].Value.ToString();
            }
            catch (Exception ex)
            {
            }

            try
            {
                textBox_nomenkl.Text = dataGridView1.Rows[0].Cells["NOMENKL"].Value.ToString();
            }
            catch (Exception ex)
            {
            }
            try
            {
                textBox_SECTION.Text= dataGridView1.Rows[0].Cells["SECTION"].Value.ToString();
            }
            catch (Exception ex)
            {
            }
            try
            {
                textBox_BARCODE.Text = dataGridView1.Rows[0].Cells["BARCODE"].Value.ToString();
            }
            catch (Exception ex)
            {
            }

            textBox_PRICE_UCH.Text = dataGridView1.Rows[0].Cells["PRICE_UCH"].Value.ToString();
            textBox_PRICE_SMP.Text = dataGridView1.Rows[0].Cells["PRICE_SMP"].Value.ToString();
            textBox_PRICE_BASE.Text = dataGridView1.Rows[0].Cells["PRICE_BASE"].Value.ToString();

            try
            {
                textBox2.Text = dataGridView1.Rows[0].Cells["BOX_L"].Value.ToString() + "x" + dataGridView1.Rows[0].Cells["BOX_W"].Value.ToString() + "x" + dataGridView1.Rows[0].Cells["BOX_H"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            try

            {
                textBox_OST_FREE.Text= dataGridView1.Rows[0].Cells["OST_FREE"].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTovAudit f = new FormTovAudit();
            f.textBox_idtov.Text = textBox_idtov.Text;
            f.ShowDialog();

            //get_tov_audit
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormListWhenFound f = new FormListWhenFound();
            f.textBox_idtov.Text = textBox_idtov.Text;
            f.ShowDialog();
            
        }

        private void FormTovCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormTovLines f = new FormTovLines();
            f.textBox_idtov.Text = textBox_idtov.Text;
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String login = "ROSTOA$NSK20";
            String pass = "345544";
            String url = "https://svc.trianon-nsk.ru/clients/code_reader/index.php?p=save_inv&login=" + login + "&pass=" + pass
                    + "&idemp=1900161" + "&idtov=" + textBox_idtov.Text + "&kol=" + textBox_OST_FREE.Text + "&section" + textBox_SECTION.Text;
            String sout=DBClass.GET(url, "");

            textBox_name.Text = url;

            MessageBox.Show(sout);          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormTovMovement f = new FormTovMovement();
            f.textBox_idtov.Text = textBox_idtov.Text;
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormReturns f = new FormReturns();
            f.textBox_idtov.Text = textBox_idtov.Text;
            f.ShowDialog();
        }
    }
}
