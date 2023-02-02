using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using DrvFRLib;
using System.Threading;
using System.Configuration;

namespace test111
{
    public partial class FormKassa : Form
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }



        private static string GET(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        DrvFR Driver;
        int KassPwd;
        string ztime="17:30";

        public FormKassa()
        {
            InitializeComponent();
            Driver = new DrvFR();
        }

        private void UpdateResult()
        {
            tbResult.Text = string.Format("Результат: {0}, {1}", Driver.ResultCode, Driver.ResultCodeDescription);
            Logger.WriteLine(tbResult.Text);
            
            if (tbResult.Text == "Результат: 0, Ошибок нет")
            {
                textBox_flagres.Text = GET("http://10.8.0.151/rep/main/pages/get_platdoc.php", "svc_id=setflag&idplat=" + textBox3.Text);
                //button2_Click(null, null);
            }
            else
            {
                MessageBox.Show("Ошибка: " + tbResult.Text);
                checkBox_timer.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idacc = "107";
            if (comboBox1.SelectedIndex == 1)
                idacc = "92";

            string show_all = "0";

            if (checkBox_showall.Checked)
                show_all = "1";
            else
                show_all = "0";

            String sparams= "svc_id=kassa&idacc=" + idacc + "&show_all=" + show_all +
                                                                                    "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") +
                                                                                    "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy");

            textBox1.Text = GET("http://10.8.0.151/rep/main/pages/get_platdoc.php", sparams);


            var data1 = textBox1.Text;

            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                myDataGridView1.DataSource = parsed.data;

                if (myDataGridView1.Rows.Count > 0)
                {
                    myDataGridView1.Columns["ID"].Width = 80;
                    myDataGridView1.Columns["FLAG"].Width = 40;
                    myDataGridView1.Columns["NODOK"].Width = 40;
                    myDataGridView1.Columns["CORG"].Width = 70;
                    myDataGridView1.Columns["ORG"].Width = 150;
                    myDataGridView1.Columns["KASSIR"].Width = 100;
                    myDataGridView1.Columns["VIDOPER"].Width = 20;
                    myDataGridView1.Columns["R"].Width = 20;
                    myDataGridView1.Columns["TXT"].Width = 60;
                    myDataGridView1.Columns[14].Width = 40;
                    myDataGridView1.Columns[15].Width = 60;
                    myDataGridView1.Columns["FLG"].Width = 30;
                    myDataGridView1.Columns["E_MAIL"].Width = 110;
                    myDataGridView1.Columns["NAPECHATAN"].Width = 30;
                    myDataGridView1_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                DateTime dt = DateTime.Now;
                Logger.WriteLine(dt.ToString() + " Exception = " + ex);
            }
        }

        private void FormKassa_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            /*if (comboBox1.SelectedIndex == 0)
                Driver.Password = 2187;
            else
                Driver.Password = 30;*/


            Driver.Password = Convert.ToInt32(ConfigurationManager.AppSettings["KassPwd"]);
            Logger.WriteLine(dt.ToString() + " пароль = " + Driver.Password);

            ztime=ConfigurationManager.AppSettings["ZReport"];
            checkBox_auto_z_otchet.Text = "Автоснятие Z-отчета (в " + ztime + ")";

            textBox2.Text = ConfigurationManager.AppSettings["Interval"];
            timer1.Interval= Convert.ToInt32(ConfigurationManager.AppSettings["Interval"])*1000;

            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);
            // comboBox1.SelectedIndex = 0;
            myDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            button2_Click(null, null);
        }
 

        private void myDataGridView1_Click(object sender, EventArgs e)
        {
            if (myDataGridView1.CurrentRow != null)
            {
                textBox_index.Text = myDataGridView1.CurrentRow.Index.ToString();
                textBox3.Text = myDataGridView1.SelectedCells[0].Value.ToString();
                for (int i = 0; i < myDataGridView1.RowCount; i++)
                {
                    int FLAG = Convert.ToInt16(myDataGridView1.Rows[i].Cells["FLAG"].Value);
                    if ((FLAG & 4) == 4) //
                    {
                        myDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private void кредиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreditHist f = new FormCreditHist();
            f.textBox_org.Text = myDataGridView1.CurrentRow.Cells["ORG"].Value.ToString();
            f.textBox_idorg.Text = myDataGridView1.CurrentRow.Cells["CORG"].Value.ToString();
            f.ShowDialog();
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbResult_TextChanged(object sender, EventArgs e)
        {
         }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox_flagres.Text = GET("http://10.8.0.151/rep/main/pages/get_platdoc.php", "svc_id=setflag&idplat=" + textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = GET("http://10.8.0.151/rep/main/pages/get_platdoc.php", "svc_id=platdoc&idplat=" + textBox3.Text);
            var data1 = textBox1.Text;
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dataGridView2.DataSource = parsed.data;
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.Columns[1].Width = 80;
                dataGridView2.Columns[2].Width = 350;
                dataGridView2.Columns[3].Width = 50;
                dataGridView2.Columns[4].Width = 50;
                dataGridView2.Columns[5].Width = 50;
            }

            FormPlatDoc f = new FormPlatDoc();
            f.textBox_iddoc.Text = textBox3.Text;
            f.ShowDialog();
        }
 

        private void continuePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver.ContinuePrint();
            Driver.ClearPrintBuffer();
        }

        private void closeCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver.CloseCheck();
        }

        private void cancelCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver.CancelCheck();
        }

        private void sysAdminCancelCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver.SysAdminCancelCheck();
        }

 

        private void checkSubTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = Driver.CheckSubTotal();
            MessageBox.Show(n.ToString());
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (dt.ToString("HH") != "00")  // 24-03-2021 // в 00 часов ничего не печатается
            {
                if (dt.ToString("HH:mm") == ztime)
                {
                    if (checkBox_auto_z_otchet.Checked)
                    {
                        Driver.SysAdminCancelCheck();
                        Driver.PrintReportWithCleaning();
                        Logger.WriteLine(dt.ToString() + " Сняли Z-отчет ");
                    }
                }

                dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
                dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);

                button2_Click(null, null);
                myDataGridView1.MultiSelect = false;
                if (myDataGridView1.Rows.Count > 0)
                {
                    myDataGridView1.Rows[0].Selected = true;
                    myDataGridView1_Click(null, null);
                    button_print_check_Click(null, null);
                }
            }
        }

        private void checkBox_timer_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox_timer.Checked;
            myDataGridView1.Enabled= !checkBox_timer.Checked;
            button_print_check.Enabled=!checkBox_timer.Checked;
            button1.Enabled = !checkBox_timer.Checked;
            button2.Enabled = !checkBox_timer.Checked;
        }

        private void button_print_check_Click(object sender, EventArgs e)
        {
            textBox1.Text = GET("http://10.8.0.151/rep/main/pages/get_platdoc.php", "svc_id=platdoc&idplat=" + textBox3.Text);
            var data1 = textBox1.Text;

            if (textBox1.Text != "")
            {
                if (myDataGridView1.CurrentRow != null)
                {
                    dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                    dataGridView2.DataSource = parsed.data;
                    Application.DoEvents();
                    if (checkBox_return.Checked)
                    {
                        Driver.CheckType = 2;
                    }
                    else
                    {
                        Driver.CheckType = 0;
                    }

                    Driver.OpenCheck();


                    string txt = myDataGridView1.CurrentRow.Cells["TXT"].Value.ToString();
                    string email = myDataGridView1.CurrentRow.Cells["E_MAIL"].Value.ToString();

                    if (txt.IndexOf("from") > -1)              /// 08-02-2022
                        email = "sab@trianon-nsk.ru";




                    //if (!checkBox_nocontragent.Checked)
                    //{
                    Driver.EmailAddress = email;
                        Driver.CustomerEmail = email;
                        Driver.FNSendCustomerEmail();
                    //}
                
                    string inn = myDataGridView1.CurrentRow.Cells["INN"].Value.ToString();
                    Driver.INN = inn;
                    Driver.INNOFD = inn;
                    string org = myDataGridView1.CurrentRow.Cells["ORG"].Value.ToString();
                    org = "Покупатель"; /// 08-02-2022

                    double summ = 0;
                    try
                    {
                        for (int i = 0; i < parsed.data.Count; i++)
                        {
                            string s = parsed.data[i].TOVNAME.ToString() + " : " + parsed.data[i].PRICE.ToString() + " : " + parsed.data[i].KOL.ToString() + "\r\n";
                            Driver.Quantity = parsed.data[i].KOL;
                            Driver.Price = parsed.data[i].PRICE;
                            summ += Convert.ToDouble(parsed.data[i].KOL * Convert.ToDouble(parsed.data[i].PRICE.ToString()));
                            Driver.Department = 1;
                            Driver.Tax1 = 1;
                            Driver.StringForPrinting = parsed.data[i].TOVNAME.ToString();
                            Driver.PrintString();

                            if (checkBox_return.Checked)
                            {
                                Driver.ReturnSale();
                            }
                            else
                                Driver.Sale();

                        }

                        DateTime dt = DateTime.Now;
                        Logger.WriteLine(dt.ToString() + " :: ID=" + textBox3.Text + " Контрагент=" + org + " SUMM=" + summ + " Позиций в чеке=" + parsed.data.Count + " E-mail=" + email);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //MessageBox.Show("ИНН=" + inn + "\r\nsumm=" + summ.ToString() + "\r\nSubTotalStringNumber=" + Driver.SubTotalStringNumber + "\r\nCheckSubTotal=" + Driver.CheckSubTotal().ToString());
                        Driver.Summ1 = Convert.ToDecimal(summ);
                        Driver.Summ2 = 0;
                        Driver.Summ3 = 0;
                        Driver.Summ4 = 0;
                        Driver.Tax1 = 0;
                        Driver.Tax2 = 0;
                        Driver.Tax3 = 0;
                        Driver.Tax4 = 0;
                        Driver.DiscountOnCheck = 0;


                        if (checkBox_return.Checked)
                        {
                            Driver.TagNumber = 1222;    //TagNumber
                            Driver.TagType = 1;            //TagType
                            Driver.TagValueInt = 64;  //TagValueStr    
                            Driver.FNSendTag();
                        }


                        //if (!checkBox_nocontragent.Checked)
                        //{
                            Driver.TagNumber = 1227;    //TagNumber
                            Driver.TagType = 7;            //TagType
                            Driver.TagValueStr = org;  //TagValueStr    
                            Driver.FNSendTag();

                            Driver.TagNumber = 1228;    //TagNumber
                            Driver.TagType = 7;            //TagType
                            Driver.TagValueStr = inn;  //TagValueStr    
                            Driver.FNSendTag();
                        //}

                        Driver.StringForPrinting = "";

                        Driver.CloseCheck();
                        UpdateResult();
                    }

                    if (checkBox1.Checked)
                        Application.Exit();
                }
                else
                {
                    MessageBox.Show("myDataGridView1.CurrentRow is null");
                }
            }
            else
            {

            }
        }

        private void printReportWithCleaningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int smen=Driver.GetECRStatus();
            //MessageBox.Show(smen.ToString());

            //Thread.Sleep(3000);

            Driver.SysAdminCancelCheck();
            Driver.PrintReportWithCleaning();

            //int smen2 = Driver.GetECRStatus();
            //MessageBox.Show(smen.ToString());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void printReportWithoutCleaningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver.SysAdminCancelCheck();
            Driver.PrintReportWithoutCleaning();

        }

        private void fNFindDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = "2400";

            if (InputBox("Введите номер чека", "номер чека:", ref value) == DialogResult.OK)
            {
                Driver.DocumentNumber = Convert.ToInt32(value);
                Driver.FNFindDocument();
                Driver.FNGetDocumentAsString();
                MessageBox.Show(Driver.StringForPrinting);
            }
        }
    }
}
