using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using System.Globalization;

using System.IO;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using BarcodeLib;

namespace test111
{
    public partial class FormDoc : Form
    {
        public string ID = "";
        string api_url = "https://svc.trianon-nsk.ru/clients/main/pages/jrn_kk_svc.php";

        public FormDoc()
        {
            InitializeComponent();
        }
        string OraLogin = ConfigurationManager.AppSettings["OraLogin"];
        string OraPwd = ConfigurationManager.AppSettings["OraPwd"];


        string GetPrinterName()
        {
            string p = "";
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Console.WriteLine(printerName);
                p = printerName;
            }
            return p;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            checkBox1.Checked = false;
            checkBox1.CheckState = CheckState.Unchecked;
            timer1.Enabled = true;
            this.Height = 350;
            this.Height = 600;
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            get_doc_header_Click(null, null);
            get_acts_button_Click(null, null);
            get_origs_btn_Click_1(null, null);
            tabPage2_Click(null, null);
            get_tovsheets_Click(null, null);
            button_audit_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_prim.Text = "на доработку - без печати";
        }

        private void button4_Click(object sender, EventArgs e)
        {

         }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = DBClass.GET(api_url, "svc_id=get_trip&idtrip=" + textBox_ctrip.Text); // + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy"))
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            try
            { 
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView2.DataSource = parsed.data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                textBox_route.Text = dataGridView2.Rows[0].Cells["ROUTE"].Value.ToString();
                textBox_exped.Text = dataGridView2.Rows[0].Cells["EXPED"].Value.ToString();
                textBox_driver.Text = dataGridView2.Rows[0].Cells["DRIVER"].Value.ToString();
                textBox_logist.Text = dataGridView2.Rows[0].Cells["LOGIST"].Value.ToString();
                textBox_tripdat.Text = dataGridView2.Rows[0].Cells["DAT"].Value.ToString();
            }
            catch (Exception)
            {
                /// не хочу ничего писать
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
 
        }
         


        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentCell.ColumnIndex == 2)
            {
                string id = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                FormTovCard f = new FormTovCard();
                f.ID = id;
                f.textBox_idtov.Text = id;
                f.ShowDialog();
            }

         }
         
         
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                this.Height = 600;
            else
                this.Height = 350;
        }
         
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                textBox_prim.Text = "на доработку - без печати";
            else
                textBox_prim.Text = "";
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("dataGridView3_CellValueChanged" + e.RowIndex + " " + e.ColumnIndex);
          /*  dataGridView3.Rows[e.RowIndex].Cells["KOL"].Style.BackColor= Color.Red;

            int kod = 0;
            if (radioButton1.Checked)
                kod = -1;
            if (radioButton2.Checked)
                kod = -2;
            if (radioButton3.Checked)
                kod = -3;
            if (radioButton4.Checked)
                kod = -4;
            if (radioButton5.Checked)
                kod = -5;

            textBox2.Text += dataGridView3.Rows[e.RowIndex].Cells["ID"].Value + "^" + dataGridView3.Rows[e.RowIndex].Cells["KOL"].Value + "^2^" + kod + "^";*/
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams= "svc_id=corr_doc&iddoc=" + textBox_iddoc.Text + "&slines=" + textBox2.Text + "&msg=2&OraLogin=" + OraLogin + "&OraPwd=" + OraPwd;
            //MessageBox.Show(sparams);
            textBox1.Text = DBClass.GET(api_url, sparams);

            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            string s = (string)parsed.data;
            
            MessageBox.Show(s);
            get_doc_header_Click(null, null); // после вычерка меняется сумма док-та
        }
         
        private void write_chat_btn_Click(object sender, EventArgs e)
        {
            if (textBox_prim.Text != "")
                textBox1.Text = DBClass.GET(api_url, "svc_id=save_org_note&cdoc=" + textBox_iddoc.Text +
                "&idorg=" + textBox_idorg.Text + "&subj=ВнесениеОригинала&idemp=" + textBox_idemp.Text + "&ityp=1&text=" +
                "Пришел оригинал: " + textBox_nnakl.Text + "(" + textBox_iddoc.Text + ")" + ":" + textBox_prim.Text);

            //MessageBox.Show(textBox1.Text);
            var data1 = textBox1.Text;
        }

        private void set_flagorig_btn_Click(object sender, EventArgs e)
        {
            int n = (Convert.ToInt32(textBox_vkl_kn.Text) + 4);
            textBox_vkl_kn.Text = n.ToString();

            textBox1.Text = DBClass.GET(api_url, "svc_id=set_flags&iddoc=" + textBox_iddoc.Text + "&ivkl=" + textBox_vkl_kn.Text + "&icredit=" + textBox_credit.Text + "&OraLogin=" + OraLogin + "&OraPwd=" + OraPwd);
            //MessageBox.Show(textBox1.Text);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
            {
                MessageBox.Show("Ошибка: " + data1);
            }
            else
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                string s = (string)parsed.data[0].TXT;
                MessageBox.Show(s);
            }
        }

 

        private void get_doc_header_Click(object sender, EventArgs e)
        {
            string sel_item = "rnk_header&iddoc=" + ID;

            DBClass.OracleRequest(sel_item, dataGridView1, textBox1);
            try
            {
                textBox_org.Text = dataGridView1.Rows[0].Cells["ORG"].Value.ToString();
                textBox_adr.Text = dataGridView1.Rows[0].Cells["ADR"].Value.ToString();
                textBox_nnakl.Text = dataGridView1.Rows[0].Cells["NNAKL"].Value.ToString();
                textBox_vkl_kn.Text = dataGridView1.Rows[0].Cells["VKL_KN"].Value.ToString();
                textBox_credit.Text = dataGridView1.Rows[0].Cells["CREDIT"].Value.ToString();
                textBox_summa.Text = dataGridView1.Rows[0].Cells["SUMMA"].Value.ToString();
                textBox_idorg.Text = dataGridView1.Rows[0].Cells["CORG"].Value.ToString();

                label28.Text= dataGridView1.Rows[0].Cells["KKMAN"].Value.ToString();
                label29.Text = dataGridView1.Rows[0].Cells["DOCMAN"].Value.ToString();
                label31.Text = dataGridView1.Rows[0].Cells["EXP_RCPT"].Value.ToString();
                textBox_audit_prn.Text= dataGridView1.Rows[0].Cells["AUDIT_PRN"].Value.ToString().Replace("<br>","\r\n");



                if (dataGridView1.Rows[0].Cells["IS_NAK"].Value.ToString() == "1")
                    checkBox_nakl.Checked = true;

                string tipsopr = dataGridView1.Rows[0].Cells["TIPSOPR"].Value.ToString();

                if (tipsopr == "1" || tipsopr == "3")
                    comboBox_tipsopr.SelectedIndex = 0;
                if (tipsopr == "2" || tipsopr == "4")
                    comboBox_tipsopr.SelectedIndex = 1;


                if (tipsopr == "3")
                    checkBox_vozvrat.Checked = true;

                if (tipsopr == "7")
                {
                    checkBox_vozvrat.Checked = true;
                    checkBox_bonus.Checked = true;
                }
 

                button5_Click(null, null);
                get_doclines_btn_Click(null, null);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("ROUTE") < 0)
                    MessageBox.Show(ex.Message);
            }



            try
            {
                textBox_ctrip.Text = dataGridView1.Rows[0].Cells["CTRIP"].Value.ToString();
            }
            catch (Exception)
            {
                
            }



            try
            {
                textBox_actsum.Text = dataGridView1.Rows[0].Cells["ACT_SUM"].Value.ToString();
                double d1=0,d2=0;
                try
                {
                    d1 = ToDouble(textBox_summa.Text, new CultureInfo("ru-RU"));
                }
                catch (Exception ex1)
                {
                    //MessageBox.Show(ex1.Message);
                }
                try
                {
                    d2 = ToDouble(textBox_actsum.Text, new CultureInfo("ru-RU"));
                }
                catch (Exception ex2)
                {
                   // MessageBox.Show(ex2.Message);
                }

                //MessageBox.Show(d1.ToString());
                //MessageBox.Show(d2.ToString());

                textBox_itogo.Text = (d1 + d2).ToString();
                //sum1 = ToDouble(textBox_summa_orig.Text, CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                textBox_itogo.Text = textBox_summa.Text;
            }

            try
            {
                textBox10.Text = dataGridView1.Rows[0].Cells["DZAKAZ"].Value.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }


            try
            {
                textBox13.Text = dataGridView1.Rows[0].Cells["REM_D"].Value.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }


            try
            {
                textBox16.Text = dataGridView1.Rows[0].Cells["REM2"].Value.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                var data1 = DBClass.GET(api_url, "svc_id=get_dt_priem&iddoc=" + textBox_iddoc.Text);
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                string s = (string)parsed.data[0].DT;
                label17.Text = s;

           }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
 
        }

        private void get_doclines_btn_Click(object sender, EventArgs e)
        {
            string sel_item = "get_lines&iddoc=" + ID;
            DBClass.OracleRequest(sel_item, dataGridView3, textBox1);

            try
            {
                dataGridView3.Columns["NN"].Width = 20;
                dataGridView3.Columns["CMC"].Width = 60;
                dataGridView3.Columns["NAME"].Width = 230;
                dataGridView3.Columns["NOMENKL"].Width = 60;
                dataGridView3.Columns["KOL"].Width = 40;
                dataGridView3.Columns["PRICE"].Width = 50;
                dataGridView3.Columns["SUMMA"].Width = 50;
                dataGridView3.Columns["VES"].Width = 40;
                dataGridView3.Columns["RAZMER"].Width = 55;
                dataGridView3.Columns["PACK"].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                dataGridView3.Columns["KOLFACT"].Width = 60;
            }
            catch (Exception ex)
            {

            }

            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                try
                {
                    string EMP_ERR = dataGridView3.Rows[i].Cells["EMP_ERR"].Value.ToString();

                    if (EMP_ERR.Length > 3)
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Green; //FromArgb(153, 0, 0);
                }
                catch (Exception ex)
                {
                }
            }
        }
         

        private void comboBox_origs_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams = "svc_id=get_orig_lines&iddoc=" + ID + "&nord=" + comboBox_origs.SelectedIndex;
            textBox1.Text = DBClass.GET(api_url, sparams);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView6.DataSource = parsed.data;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            if (textBox_vkl_kn.Text != "")
            {
                int flags = Convert.ToInt32(textBox_vkl_kn.Text);

                if ((flags & 1) == 1)
                {
                    checkBox_ORIG.Checked = true;
                }

                if ((flags & 2) == 2)
                {
                    checkBox_KK.Checked = true;
                }

                if ((flags & 4) == 4)
                {
                    checkBox_ORIG.Checked = true;
                }

                if ((flags & 32) == 32)
                {
                    checkBox_SFORIG.Checked = true;
                }

                if ((flags & 64) == 64)
                {
                    checkBox_compens.Checked = true;
                }

                if ((flags & 128) == 128)
                {
                    checkBox_trans.Checked = true;
                }

                if ((flags & 1024) == 1024)
                {
                    checkBox_otchet.Checked = true;
                }

                if ((flags & 2048) == 2048)
                {
                    checkBox_rezerv.Checked = true;
                }

                if ((flags & 131072) == 131072)
                {
                    checkBox_exp_rcpt.Checked = true;
                }

                if ((flags & 16777216) == 16777216)
                {
                    checkBox_estscan.Checked = true;
                }

            }
        }



        private void get_acts_button_Click(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams = "svc_id=get_act_lines&iddoc=" + ID;
            textBox1.Text = DBClass.GET(api_url, sparams);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                dataGridView_acts.DataSource = parsed.data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (dataGridView_acts.RowCount > 0)
            {
                checkBox2.Checked = true;
            }


            for (int i = 0; i < dataGridView_acts.RowCount - 1; i++)
            {
                try
                {
                    string DT = dataGridView_acts.Rows[i].Cells["DT"].Value.ToString();
                    string EMP = dataGridView_acts.Rows[i].Cells["EMP"].Value.ToString();
                    comboBox_acts.Items.Add(DT + " " + EMP);
                }
                catch (Exception ex)
                {
                    //
                }
            }

            try
            {
                if (dataGridView_acts.RowCount > 0)
                {
                    if (comboBox_acts.Items.Count > 0)
                        comboBox_acts.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {

            }  

            for (int i = 0; i < dataGridView_acts.RowCount - 1; i++)
            {
                try
                {
                    string IDL = dataGridView_acts.Rows[i].Cells["IDL"].Value.ToString();
                    string KOL_C = dataGridView_acts.Rows[i].Cells["KOL_C"].Value.ToString();
                    string EMP = dataGridView_acts.Rows[i].Cells["EMP"].Value.ToString();

                    for (int j = 0; j < dataGridView3.RowCount - 1; j++)
                    {
                        if (IDL == dataGridView3.Rows[j].Cells["ID"].Value.ToString())
                        {
                            dataGridView3.Rows[j].Cells["KOL"].Value = KOL_C;
                            dataGridView3.Rows[j].Cells["KOL"].Style.BackColor = Color.Red;
                            dataGridView3.Rows[j].Cells["EMP_ERR"].Value = EMP;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ///MessageBox.Show("Ошибка акта: " + ex.Message);
                }
            }
        }

        private void get_origs_btn_Click_1(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams = "svc_id=get_origs&iddoc=" + ID;
            textBox1.Text = DBClass.GET(api_url, sparams);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView_origs.DataSource = parsed.data;


            for (int i = 0; i < dataGridView_origs.RowCount - 1; i++)
            {
                try
                {
                    string DEMP = dataGridView_origs.Rows[i].Cells["DEMP"].Value.ToString();
                    string SUMM = dataGridView_origs.Rows[i].Cells["SUMM"].Value.ToString();
                    string EMP = dataGridView_origs.Rows[i].Cells["EMP"].Value.ToString();
                    comboBox_origs.Items.Add(DEMP + " =" + SUMM + " " + EMP);
                }
                catch (Exception ex)
                {
                    //
                }
            }
            if (dataGridView_origs.RowCount > 0)
            {
                if (comboBox_origs.Items.Count > 0)
                    comboBox_origs.SelectedIndex = 0;
            }
        }


        public static double ToDouble(string value, IFormatProvider provider)
        {
            if (value == null)
            {
                return 0.0;
            }

            return double.Parse(value, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, provider);
        }

        private void save_orig_btn_Click_1(object sender, EventArgs e)
        {
            double sum1=0, sum2=0;
            try
            {
                string t1 = textBox_summa_orig.Text.Replace('.', ','); //////// для линуха с русской локалью
                string t2 = textBox_itogo.Text.Replace('.', ',');
                sum1 = ToDouble(textBox_summa_orig.Text, CultureInfo.InvariantCulture);
                sum2 = ToDouble(textBox_itogo.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Тупой линукс!!! Числа с запятой !!!!");
                return;
            }

            if (sum1 == sum2)
            {
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("Суммы совпали, ставим галку оригинал!");
                    set_flagorig_btn_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Без печати, поэтому галку оригинал не ставим!");
                }
            }
            else
            {
                textBox_prim.Text = "суммы не совпали";
            }
            

            textBox1.Text = DBClass.GET(api_url, "svc_id=save_orig&iddoc=" + textBox_iddoc.Text + "&sdata=22.09.2020^" + textBox_summa_orig.Text + "^" + textBox_prim.Text + "^" + textBox_korob.Text + "^0^0" + "&OraLogin=" + OraLogin + "&OraPwd=" + OraPwd);
            ///MessageBox.Show(textBox1.Text);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            string s = (string)parsed.data[0].TXT;
            MessageBox.Show(s);

            write_chat_btn_Click(null, null);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void get_tovsheets_Click(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams = "svc_id=get_tovsheets&iddoc=" + ID;
            textBox1.Text = DBClass.GET(api_url, sparams);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView_tovsheets.DataSource = parsed.data;

            for (int i = 0; i < dataGridView_tovsheets.RowCount; i++)// - 1
            {
                try
                {
                    string DEMP = dataGridView_tovsheets.Rows[i].Cells["CSHEET"].Value.ToString();
                    string SUMM = dataGridView_tovsheets.Rows[i].Cells["PAGE_NO"].Value.ToString();
                    string EMP = dataGridView_tovsheets.Rows[i].Cells["EMP"].Value.ToString();
                    comboBox_tovsheets.Items.Add(DEMP + " =" + SUMM + " " + EMP);
                }
                catch (Exception ex)
                {
                    //
                }
            }


            if (dataGridView_tovsheets.RowCount > 0)
            {
                if(comboBox_tovsheets.Items.Count>0)
                comboBox_tovsheets.SelectedIndex = 0;
            }



        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            MessageBox.Show("vkl_kn=" + textBox_vkl_kn.Text);

            textBox1.Text = DBClass.GET(api_url, "svc_id=set_flags&iddoc=" + textBox_iddoc.Text + "&ivkl=" + textBox_vkl_kn.Text + "&icredit=" + textBox_credit.Text + "&OraLogin=" + OraLogin + "&OraPwd=" + OraPwd);
            //MessageBox.Show(textBox1.Text);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
            {
                MessageBox.Show("Ошибка: " + data1);
            }
            else
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                string s = (string)parsed.data[0].TXT;
                MessageBox.Show(s);
            }
        }

        private void textBox_route_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "1")
            {
                textBox_summa.Visible = true;
                textBox_actsum.Visible = true;
                textBox_itogo.Visible = true;
                label10.Visible = true;
                label25.Visible = true;
                label26.Visible = true;
            }
        }

        private void checkBox_exp_rcpt_CheckedChanged(object sender, EventArgs e)
        {
            int n = (Convert.ToInt32(textBox_vkl_kn.Text) + 131072);
            textBox_vkl_kn.Text = n.ToString();
        }

        private void get_assoc_btn_Click(object sender, EventArgs e)
        {
            textBox_iddoc.Text = textBox_iddoc.Text.Trim();
            string sparams = "svc_id=doc_assoc_lines&iddoc=" + ID;
            textBox1.Text = DBClass.GET(api_url, sparams);
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);

            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView_assocdocs.DataSource = parsed.data;


            for (int i = 0; i < dataGridView_tovsheets.RowCount - 1; i++)
            {
                try
                {
                    string DEMP = dataGridView_assocdocs.Rows[i].Cells["ID"].Value.ToString();
                    string SUMM = dataGridView_assocdocs.Rows[i].Cells["SKL_ZONE"].Value.ToString();
                    string EMP = dataGridView_assocdocs.Rows[i].Cells["EMP"].Value.ToString();
                    //comboBox_tovsheets.Items.Add(DEMP + " =" + SUMM + " " + EMP);
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }

        private void tabPage5_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(CultureInfo.CurrentUICulture.Name);
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            MessageBox.Show(nfi.CurrencyDecimalSeparator);
        }

        private void button_audit_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = DBClass.GET(api_url, "svc_id=get_doc_audit&iddoc=" + ID); // + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy"))
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView_audit.DataSource = parsed.data;
        }

        private void textBox_itogo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_DoubleClick_1(object sender, EventArgs e)
        {
            FormTovCard f = new FormTovCard();
            f.ID = dataGridView3.CurrentRow.Cells["CMC"].Value.ToString();
            f.textBox_idtov.Text = f.ID;
            f.ShowDialog();
        }

        private void dataGridView_tovsheets_DoubleClick(object sender, EventArgs e)
        {
            FormTovsheet f = new FormTovsheet();
            f.textBox_idsheet.Text = dataGridView_tovsheets.CurrentRow.Cells["CSHEET"].Value.ToString();
            f.ShowDialog();
        }

        private void dataGridView_tovsheets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var barcode = new BarcodeLib.Barcode();
            var saveFileDialog = new SaveFileDialog { FileName = "BD" + textBox_iddoc.Text, Filter = "PDF file (*.pdf)|*.pdf" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                // Для отображения русских букв
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var font8 = new iTextSharp.text.Font(baseFont, 8);
                var font10 = new iTextSharp.text.Font(baseFont, 10);
                var font12 = new iTextSharp.text.Font(baseFont, 12);
                var font14 = new iTextSharp.text.Font(baseFont, 14);
                var font20 = new iTextSharp.text.Font(baseFont, 20);
                var font24 = new iTextSharp.text.Font(baseFont, 24);
                document.Open();
                
                var imageBarcode = barcode.Encode(BarcodeLib.TYPE.CODE128B, "BD" + textBox_iddoc.Text, Color.Black, Color.White, 160, 30); //item.Barcode
                var image = iTextSharp.text.Image.GetInstance(imageBarcode, ImageFormat.Jpeg);
                document.Add(image);
 
                document.Add(new Paragraph("НАКЛАДНАЯ: " + textBox_nnakl.Text + " от " + textBox10.Text, font12)); //клиент
                document.Add(new Paragraph("Контрагент: " + textBox_org.Text, font12)); //клиент
                document.Add(new Paragraph("Адрес: " + textBox_adr.Text, font12)); //адрес
  
                PdfPTable table = new PdfPTable(7);
                table.TotalWidth = 800f;

                float[] cols = { 0.1f, 1.4f, 0.2f, 0.2f, 0.2f, 0.2f, 0.3f  };
                table.SetWidths(cols);

                double sum_kol=0, sum_kor=0, sum_rub=0, sum_ves = 0, sum_razmer = 0;
                for (int i = 0; i < dataGridView3.Rows.Count ; i++)
                {
                    string nomenkl = "";
                    try
                    {
                        if (dataGridView3.Rows[i].Cells["NOMENKL"].Value == null)
                            nomenkl = "";
                        else
                            nomenkl = dataGridView3.Rows[i].Cells["NOMENKL"].Value.ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                                        
                    int korob = Convert.ToInt32(dataGridView3.Rows[i].Cells["KOL"].Value.ToString()) / Convert.ToInt32(dataGridView3.Rows[i].Cells["PACK"].Value.ToString());
                    double price = Math.Round(Convert.ToDouble(dataGridView3.Rows[i].Cells["PRICE"].Value.ToString()), 2); ;
                    int kol = Convert.ToInt32(dataGridView3.Rows[i].Cells["KOL"].Value.ToString());
                    double summa= Convert.ToDouble(dataGridView3.Rows[i].Cells["SUMMA"].Value.ToString());
                    double ves = Convert.ToDouble(dataGridView3.Rows[i].Cells["VES"].Value.ToString());
                    double razmer = Convert.ToDouble(dataGridView3.Rows[i].Cells["RAZMER"].Value.ToString());

                    table.AddCell(new Phrase((i + 1).ToString(), font8));
                    table.AddCell(new Phrase(dataGridView3.Rows[i].Cells["NAME"].Value.ToString(), font8));
                    table.AddCell(new Phrase(nomenkl, font8));
                    table.AddCell(new Phrase(kol.ToString(), font8));
                    sum_kol += kol;
                    table.AddCell(new Phrase(korob + "к", font8));
                    sum_kor += korob;
                    table.AddCell(new Phrase(price.ToString(), font8));                    
                    table.AddCell(new Phrase(summa.ToString(), font8));

                    sum_rub += summa;
                    sum_ves += ves*kol;
                    sum_razmer += razmer * kol;
                }


                table.AddCell(new Phrase("", font12));
                table.AddCell(new Phrase("Итого", font12));
                table.AddCell(new Phrase("", font12));
                table.AddCell(new Phrase(sum_kol.ToString(), font12));
                table.AddCell(new Phrase(sum_kor + "к", font12));
                table.AddCell(new Phrase("", font12));
                table.AddCell(new Phrase(sum_rub.ToString(), font12));

                //Добавляем таблицу в документ
                document.Add(table);
                document.Add(new Paragraph("Вес: " + (sum_ves/1000).ToString() + "кг", font12)); //адрес
                document.Add(new Paragraph("Объем: " + (sum_razmer/1000).ToString() + "м3", font12)); //адрес

                //Закрываем документ
                document.Close();


                // }
                document.Close();


                /*
                Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
                pdfdocument.LoadFromFile(saveFileDialog.FileName);
                pdfdocument.PrinterName = GetPrinterName();
                pdfdocument.PrintDocument.PrinterSettings.Copies = 1;
                pdfdocument.PrintDocument.Print();
                pdfdocument.Dispose();*/

                // Открытие созданного файла
               // System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }

        private void FormDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4_Load(null, null);
        }
    }
}
