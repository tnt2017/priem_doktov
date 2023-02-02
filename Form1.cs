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
using BarcodeLib;
using System.IO;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace test111
{
    public partial class Form1 : Form
    {
        string api_url = "https://svc.trianon-nsk.ru/clients/main/pages/jrn_kk_svc.php";
        string update_path = "https://svc.trianon-nsk.ru/clients/main/priemka/";

        string version = "v12.4 (build 08.02.2022)";
        public string OraLogin;
        public string OraPwd;
        public string ComPort;
        public String IdEmp="не задан";
        public int mode = 0;


        public Form1()
        {
            InitializeComponent();
        }


        void FormatColsComplektovka()
        {
            try
            {
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 200;
            }
            catch (Exception) //Exception ex
            {

            }
            
        }


        void FormatColsBills()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                 try
                 {
                    string nakl = dataGridView1.Rows[i].Cells["IS_NAKL"].Value.ToString();
                    string bill = dataGridView1.Rows[i].Cells["IS_BILL"].Value.ToString();

                 if (nakl == "Da")
                 {
                     dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green; //FromArgb(153, 0, 0);
                 }

                 if (bill == "Schet")
                 {
                     dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow; //FromArgb(153, 0, 0);
                 }
                 }
                 catch (Exception)
                 {
                     //
                 }
            }
        }
       
        void OracleRequest(string sel_item)
        {
            textBox1.Text = "";
            
            textBox1.Text = DBClass.GET(api_url, "svc_id=" + sel_item + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "&dend=" + dateTimePicker2.Value.ToString("dd.MM.yyyy"));
            var data1 = textBox1.Text;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dynamic response;

            if (sel_item == "jrn_kk")
                 response = parsed.data.jrn;
            else
                 response = parsed.data;

            string s = parsed.data.ToString();

            if(s != "")
            Text = "Приемка документов :: Строк получено: " +  response.Count.ToString();
            dataGridView1.DataSource = response;
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            comboBox5.SelectedIndex = 0;
            comboBox_mode.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "Обработано документов за сегодня: ";
            textBox_idemp.Text = ConfigurationManager.AppSettings["idemp"];
            
            OraLogin = ConfigurationManager.AppSettings["OraLogin"];
            OraPwd = ConfigurationManager.AppSettings["OraPwd"];

            update_path = ConfigurationManager.AppSettings["update_path"];
 
            timer1.Enabled = true;
            this.Text = "Приемка документов - " + version;
            button_update_Click(null, null);
           // textBox3.Text = "AR" + dateTimePicker1.Value.ToString("dd.MM.yyyy");

            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            dateTimePicker2.Value = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 12, 0, 0);

            ComPort = ConfigurationManager.AppSettings["ComPort"];
            serialPort1.PortName = ComPort;
            try
            {
                serialPort1.Open();
                toolStripStatusLabel2.Text = ComPort + " порт открылся";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = " сканер не найден";
            }

            FormLogin f = new FormLogin();
            f.ShowDialog();

            //MessageBox.Show(f.textBox1.Text);
            textBox_idemp.Text = f.textBox1.Text;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.IDTRIP = textBox_ctrip.Text;
            f.ShowDialog();
        }

        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID;
            ID = Interaction.InputBox("Введите ID документа", "ID", "210079890");
            textBox_iddoc.Text = ID;

            FormDoc f = new FormDoc();
            f.ID = textBox_iddoc.Text;
            f.textBox_iddoc.Text = textBox_iddoc.Text;
            f.textBox_idemp.Text = textBox_idemp.Text;
            f.ShowDialog();
            button_update_stat_Click(null, null);
 
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
        }

        void ManualTest()
        {
            string sel_item = "rnk_header&iddoc=" + textBox_iddoc.Text;
            DBClass.OracleRequest(sel_item, dataGridView1, checkBox_dbg.Checked);
            try
            {
                textBox_ctrip.Text = dataGridView1.Rows[0].Cells["CTRIP"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("В документе отсутствует рейс!");
            }

            accept_doc(textBox_iddoc.Text, textBox_ctrip.Text, textBox_idemp.Text, 1);

            string sel_item1 = comboBox5.SelectedItem.ToString();
            sel_item = sel_item1.Substring(0, sel_item1.IndexOf("//"));
            textBoxSelItem.Text = sel_item1;
            sel_item += "&ctrip=" + textBox_ctrip.Text + "&idtrip=" + textBox_ctrip.Text;

            if(checkBox_dbg.Checked)
            MessageBox.Show(sel_item);

            DBClass.OracleRequest(sel_item, dataGridView1, checkBox_dbg.Checked);
            FormatColsComplektovka();
            button_update_stat_Click(null, null);
            Application.DoEvents();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.Text += e.KeyChar + "";            
        }

        /*
        void insert_priem_doc()
        {
            textBox1.Text = GET(api_url, "svc_id=insert_priem_doc&iddoc=" + textBox_iddoc.Text + "&idtrip=" + textBox_ctrip.Text + "&idemp=" + textBox_idemp.Text);
        }*/
                    
        public void accept_doc(string iddoc, string idtrip, string idemp, int type)
        {
            string myparams= "svc_id=insert_priem_doc&iddoc=" + textBox_iddoc.Text + "&idtrip=" + textBox_ctrip.Text + "&idemp=" + textBox_idemp.Text + "&itip=" + type.ToString() +
                                    "&OraLogin=" + OraLogin + "&OraPwd=" + OraPwd;

            string x = DBClass.GET(api_url, myparams);

            dynamic parsed1 = JsonConvert.DeserializeObject<dynamic>(x);
            string s1 = (string)parsed1.data[0].TXT;
            textBox2.Text += "\r\nПриемка документа";

            if (checkBox_dbg.Checked)
                MessageBox.Show(x);
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = checkBox_dbg.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormScanner f = new FormScanner();
            f.ShowDialog();
        }

        private void button_update_stat_Click(object sender, EventArgs e)
        {
            string x = DBClass.GET(api_url, "svc_id=get_priemdocs_count_today&idemp=" + textBox_idemp.Text);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(x);
            string s = (string)parsed.data[0].CNT;

            string x1 = DBClass.GET(api_url, "svc_id=get_priemdocs_count&idemp=" + textBox_idemp.Text);
            dynamic parsed1 = JsonConvert.DeserializeObject<dynamic>(x1);
            string s1 = (string)parsed1.data[0].CNT;

            toolStripStatusLabel1.Text = "Обработано документов за сегодня: " + s + " за все время " + s1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var barcode = new BarcodeLib.Barcode();
            var saveFileDialog = new SaveFileDialog { FileName = "Barcodes", Filter = "PDF file (*.pdf)|*.pdf" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var document = new Document();
                var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter.GetInstance(document, fileStream);
                // Для отображения русских букв
                var baseFont = BaseFont.CreateFont(@"Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //C:\Windows\Fonts\
                var font = new iTextSharp.text.Font(baseFont, 14);
                document.Open();
               // foreach (var item in items)
               // {
                    var imageBarcode = barcode.Encode(BarcodeLib.TYPE.CODE128B, textBox3.Text, Color.Black, Color.White, 290, 120); //item.Barcode
                    var image = iTextSharp.text.Image.GetInstance(imageBarcode, ImageFormat.Jpeg);
                    document.Add(new Paragraph(textBox3.Text, font)); //item.Description
                    document.Add(image);
               // }
                document.Close();
                // Открытие созданного файла
                System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //button_update_stat_Click(null, null);
        }

        public string GetServerVersion()
        {
            string remoteUri = "http://10.8.0.151/rep/main/priemka/";
            remoteUri = "https://svc.trianon-nsk.ru/clients/main/priemka/";
            string fileName1 = "version.txt";
            WebClient myWebClient = new WebClient();
            string myStringWebResource1 = null;
            myStringWebResource1 = remoteUri + fileName1;

            try
            {
                myWebClient.DownloadFile(myStringWebResource1, "version.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось скачать файл с сервера. Возможно мешает Аваст. " + ex.Message);
            }
            string server_version = System.IO.File.ReadAllText(Application.StartupPath + "\\version.txt");
            return server_version;
        }



        string exename = "priem_doktov";

        public void UpdateExe()
        {
            string s1 = Application.StartupPath + "\\" + exename + ".exe";
            string s2 = Application.StartupPath + "\\" + exename + ".old";
            string s3 = Application.StartupPath + "\\" + exename + ".tmp";


            string fileName2 = exename + ".exe";
            string myStringWebResource2 = null;

            WebClient myWebClient = new WebClient();
            myStringWebResource2 = update_path + fileName2;

            try
            {
                myWebClient.DownloadFile(myStringWebResource2, exename + ".tmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось скачать файл с сервера. Возможно мешает Аваст. " + ex.Message);
            }

            File.Delete(s2);
            File.Move(s1, s2);
            File.Move(s3, s1);
            Process.Start(s1);
            Application.Exit();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string server_version = GetServerVersion();

            if (version != server_version)
            {
                if (textBox1.Text != "live")
                    MessageBox.Show("Текущая версия:" + version + "\r\n. Версия на сервере:" + server_version + "\r\n Запускаем обновление");
                toolStripStatusLabel1.Text = "Текущая версия: " + version + ". Версия на сервере: " + server_version + ". Запускаем обновление";
                UpdateExe();
            }
            {
                //MessageBox.Show("Текущая версия:" + version + "\r\nВерсия на сервере:" + server_version + "\r\nОбновление не требуется");
                toolStripStatusLabel1.Text = "Текущая версия: " + version + ". Версия на сервере: " + server_version + ". Обновление не требуется";
            }
        }

        private void товарПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ID = Interaction.InputBox("Введите ID товара", "ID", "282245");
            //textBox_iddoc.Text = ID;

            FormTovCard f = new FormTovCard();
            f.ID = ID;
            f.textBox_idtov.Text = ID;
            f.ShowDialog();
        }

        private void сорудникПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID;
            ID = Interaction.InputBox("Введите ID сотрудника", "ID", "137");
            //textBox_iddoc.Text = ID;

            FormEmpCard f = new FormEmpCard();
            f.ID = ID;
            f.textBox_idemp.Text = ID;
            f.ShowDialog();
        }

        private void журналККToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_kk";            
            f.ShowDialog();
        }

        private void журналНаклРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_nakl_r";
            f.ShowDialog();
        }

        private void актыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_acts";
            f.ShowDialog();
        }

        private void журналВозвратовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_rets";
            f.ShowDialog();
        }

        private void журналНаклПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_nakl_p";
            f.ShowDialog();
        }

        private void заметкиДоставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_dostav";
            f.ShowDialog();
        }

        private void журналСчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void счетаПриходныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_sfact_p";
            f.ShowDialog();            
        }

        private void счетаРасходныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJournal f = new FormJournal();
            f.textBoxSelItem.Text = "jrn_sfact_r";
            f.ShowDialog();
        }

        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrgs f = new FormOrgs();
            f.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmps f = new FormEmps();
            f.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void карточкаКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreditHist f = new FormCreditHist();
            f.ShowDialog();
        }

        private void тестToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTest f = new FormTest();
            f.ShowDialog();
        }

        private void работаСектораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSector f = new FormSector();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManualTest();
        }

        private void тест2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerateSQL f = new FormGenerateSQL();
            f.ShowDialog();           
        }

        private void кассаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKassa f = new FormKassa();
            f.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void платежПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID;
            ID = Interaction.InputBox("Введите ID документа", "ID", "210028918");

            FormPlatDoc f = new FormPlatDoc();
            f.textBox_iddoc.Text = ID;
            f.ShowDialog();
        }

       /* private System.IO.Stream Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                var response = client.PostAsync(actionUrl, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.Content.ReadAsStreamAsync().Result;
            }
        }
        */

        private void uploadTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  string fileToUpload = @"c:\1.txt";
            string url = "https://svc.trianon-nsk.ru/clients/merch_photos/index.php";
            using (var client = new WebClient())
            {
                byte[] result = client.UploadFile(url, fileToUpload);
                string responseAsString = Encoding.Default.GetString(result);
                MessageBox.Show(responseAsString);
            }*/



            string fileName = "C:\\1.txt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://svc.trianon-nsk.ru/clients/merch_photos/index.php");
            request.ContentType = "multipart/form-data;";
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream requestStream = request.GetRequestStream();

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "file", fileName, "text/txt");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //return (int)response.StatusCode;
                MessageBox.Show(response.StatusCode.ToString());
            }
        }

        private void журналыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оФДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOFD f = new FormOFD();
            f.ShowDialog();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void листПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID;
            ID = Interaction.InputBox("Введите ID отб. листа", "ID", "210177596");

            FormTovsheet f = new FormTovsheet();
            f.textBox_idemp.Text = textBox_idemp.Text;
            f.textBox_idsheet.Text = ID;
            f.ShowDialog();
        }

        private void рейсПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ID = Interaction.InputBox("Введите ID рейса", "ID", "21003794");
            //textBox_iddoc.Text = ID;

            FormTripCard f = new FormTripCard();
            f.textBox_idtrip.Text = ID;
            f.ShowDialog();
        }

        private void рейсыЗаДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void листыЗаДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьОрдерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewOrder f = new FormNewOrder();
            f.ShowDialog();           
        }

        private void клиентПоIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrgCard f = new FormOrgCard();
            f.textBox_idorg.Text = Interaction.InputBox("Введите ID компании", "ID", "2000172");
            f.ShowDialog();
            
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTovlist f = new FormTovlist();
            f.ShowDialog();
        }

        private void комплектовкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string strFromPort = serialPort1.ReadExisting();

            strFromPort = strFromPort.Trim();
            String json = DBClass.GET(api_url, "svc_id=get_tov&barcode=" + strFromPort);
            dynamic parsed1 = JsonConvert.DeserializeObject<dynamic>(json);
 
            if (strFromPort.IndexOf("OL") > -1 || strFromPort.IndexOf("OT") > -1 || strFromPort.IndexOf("BD") > -1)
            {
                if (strFromPort.IndexOf("OL") > -1)
                {
                    String idsheet = strFromPort.Substring(strFromPort.IndexOf("OL") + 2, strFromPort.Length - strFromPort.IndexOf("OL") - 2);

                    if (mode == 0)
                    {
                        FormTovsheet f = new FormTovsheet();
                        f.textBox_idemp.Text = textBox_idemp.Text;
                        f.textBox_idsheet.Text = idsheet;
                        f.ShowDialog();
                    }
                    else // если стоит режим комплектовка
                    {
                        FormComplektAdr f = new FormComplektAdr();
                        MyDataGridView t = new MyDataGridView();
   
                        string s = DBClass.GET(api_url, "svc_id=tovsheet_header&idsheet=" + idsheet);
                        var data1 = s;

                        if (data1.IndexOf("exec fails") > 0 && data1.IndexOf("RASHOD") < 0)
                            MessageBox.Show(data1);
                        dynamic parsed;
                        dynamic response;

                        try
                        {
                            parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                            f.cadr.Text = parsed.data[0]["ADR_DOST"]; 
                            f.ctrip.Text = parsed.data[0]["CTRIP"];
                        }
                        catch (Exception ex)
                        {

                        }

                        //MessageBox.Show(parsed.data[0]);
                        




                        try
                        {
                            string adr_dost= t.Rows[0].Cells["ADR_DOST"].Value.ToString();
                        }
                        catch (Exception ex)
                        {

                        }
                       // f.textBox_route.Text = route;
                       // f.textBox_org.Text = org;*/
                        f.ShowDialog();
                    }

                }
                
                if (strFromPort.IndexOf("BD") > -1)
                {
                    String idsheet = strFromPort.Substring(strFromPort.IndexOf("BD") + 2, strFromPort.Length - strFromPort.IndexOf("BD") - 2);
                    FormDoc f = new FormDoc();
                    f.ID = textBox_iddoc.Text;
                    f.textBox_iddoc.Text = textBox_iddoc.Text;
                    f.textBox_idemp.Text = textBox_idemp.Text;
                    f.ShowDialog();
                }
                
                if (strFromPort.IndexOf("OT") > -1)
                {
                    IdEmp = strFromPort.Substring(strFromPort.IndexOf("OT") + 2, strFromPort.Length - strFromPort.IndexOf("OT") - 2);
                }



            }
            else
            {
                if (mode == 2 || mode == 3)
                {
                    if(mode == 2)
                        MessageBox.Show("Происходит контроль");

                    if (mode == 3)
                        MessageBox.Show("Происходит приемка");

                }
                else
                {
                    MessageBox.Show(parsed1.data[0]);
                    FormTovCard f = new FormTovCard();
                    f.ID = parsed1.data[0].ID;
                    f.textBox_idtov.Text = parsed1.data[0].ID;
                    f.ShowDialog();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "Приемка документов - " + version + " сотрудник=" + IdEmp;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
        }

        private void комплектовкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormComplekt f = new FormComplekt();
            f.ShowDialog();

        }

        private void приемкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPriemka f = new FormPriemka();
            f.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }

        private void листыЗаДеньToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTovsheets f = new FormTovsheets();
            f.ShowDialog();
        }

        private void рейсыЗаДеньF12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrips f = new FormTrips();
            f.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions f = new FormOptions();
            f.ShowDialog();
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новаяПриемкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewPriemka f = new FormNewPriemka();
            f.ShowDialog();

        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = comboBox_mode.SelectedIndex;
        }

        private void новыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыйДокументToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormNewDoc f = new FormNewDoc();
            f.ShowDialog();

        }

        private void проверкаSqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSQLite f = new FormSQLite();
            f.ShowDialog();      

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 122) /// F11
            {
                листыЗаДеньToolStripMenuItem_Click(null, null);
            }


            if (e.KeyValue == 123) /// F12
            {
                рейсыЗаДеньToolStripMenuItem_Click(null, null);
            }

            if (e.KeyValue == 13)
            {
                textBox2.Text += "\r\n";
                String[] words = textBox2.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string last_val = words[words.Count() - 1];

                if (last_val.IndexOf("ЕК") > -1) /* Маршрутный лист */
                {
                    MessageBox.Show("Маршрутный лист");
                    textBox_ctrip.Text = last_val.Substring(2, last_val.Length - 2);
                    Application.DoEvents();
                    button_update_stat_Click(null, null);
                }

                if (last_val.IndexOf("ИВ") > -1 || last_val.IndexOf("BD") > -1 || last_val.IndexOf("ЫК") > -1 || last_val.IndexOf("SR") > -1 || last_val.IndexOf("OL") > -1 || last_val.IndexOf("ЩД") > -1 || last_val.IndexOf("OT") > -1)
                {
                    if (last_val.IndexOf("OL") > -1 || last_val.IndexOf("ЩД") > -1)
                    {
                        String idsheet = last_val.Substring(last_val.IndexOf("OL") + 2, last_val.Length - last_val.IndexOf("OL") - 2);

                        if (last_val.IndexOf("OL") > -1)
                            idsheet = last_val.Substring(last_val.IndexOf("OL") + 2, last_val.Length - last_val.IndexOf("OL") - 2);

                        if (last_val.IndexOf("ЩД") > -1)
                            idsheet = last_val.Substring(last_val.IndexOf("ЩД") + 2, last_val.Length - last_val.IndexOf("ЩД") - 2);
                        
                        if (comboBox_mode.SelectedIndex == 0)
                        {
                            FormTovsheet f = new FormTovsheet();
                            f.textBox_idsheet.Text = idsheet;
                            f.textBox_idemp.Text = textBox_idemp.Text;
                            f.ShowDialog();
                        }
                        else // если стоит режим комплектовка
                        {
                            FormComplektAdr f = new FormComplektAdr();
                            /*f.ctrip.Text = ctrip;
                            f.cadr.Text = cadr;
                            f.textBox_route.Text = route;
                            f.textBox_org.Text = org;*/
                            f.ShowDialog();
                        }
                    }

                    if (last_val.IndexOf("OT") > -1)
                    {
                        IdEmp = last_val.Substring(last_val.IndexOf("OT") + 2, last_val.Length - last_val.IndexOf("OT") - 2);
                    }


                    if (last_val.IndexOf("ИВ") > -1 || last_val.IndexOf("BD") > -1) /* накладная возврат и прочие документы из BASEDOC */
                    {
                        if (last_val.IndexOf("ИВ") > -1)
                            textBox_iddoc.Text = last_val.Substring(last_val.IndexOf("ИВ") + 2, last_val.Length - last_val.IndexOf("ИВ") - 2);

                        if (last_val.IndexOf("BD") > -1)
                            textBox_iddoc.Text = last_val.Substring(last_val.IndexOf("BD") + 2, last_val.Length - last_val.IndexOf("BD") - 2);

                        textBox2.Text += "Документ " + textBox_iddoc.Text;

                        if (checkBox1.Checked)
                        {
                            FormDoc f = new FormDoc();
                            f.ID = textBox_iddoc.Text;
                            f.textBox_iddoc.Text = textBox_iddoc.Text;
                            f.textBox_idemp.Text = textBox_idemp.Text;
                            f.ShowDialog();
                            button_update_stat_Click(null, null);
                        }
                        else
                        {
                            ManualTest();
                        }
                    }

                    if (last_val.IndexOf("ЫК") > -1 || last_val.IndexOf("SR") > -1) /* сверка */
                    {
                        string s = "";

                        if (last_val.IndexOf("ЫК") > -1)
                            s = last_val.Substring(last_val.IndexOf("ЫК") + 2, last_val.Length - last_val.IndexOf("ЫК") - 2);

                        if (last_val.IndexOf("SR") > -1)
                            s = last_val.Substring(last_val.IndexOf("SR") + 2, last_val.Length - last_val.IndexOf("SR") - 2);

                        //MessageBox.Show("Сверка " + s);
                        string dt = s.Substring(0, 6);
                        string idorg = s.Substring(6, s.Length - 6);
                        MessageBox.Show("dt=" + dt + ": iorg=" + idorg);

                        textBox_ctrip.Text = idorg;
                        textBox_iddoc.Text = dt;
                        Application.DoEvents();

                        accept_doc(textBox_iddoc.Text, textBox_ctrip.Text, textBox_idemp.Text, 2);
                        button_update_stat_Click(null, null);

                        string sel_item = "sverki&idorg=" + idorg;
                        OracleRequest(sel_item);
                        Application.DoEvents();
                    }
                }
                else
                {
                   // MessageBox.Show(null, "1", last_val);  // 21-02-2021
                    last_val = last_val.Trim();
                    String json = DBClass.GET(api_url, "svc_id=get_tov&barcode=" + last_val);
                    dynamic parsed1 = JsonConvert.DeserializeObject<dynamic>(json);
                    //MessageBox.Show(null, "ID=" + parsed1.data[0].ID, "2");

                    if (mode == 2 || mode == 3)
                    {
                        if (mode == 2)
                            MessageBox.Show("Происходит контроль");

                        if (mode == 3)
                            MessageBox.Show("Происходит приемка");

                    }
                    else
                    {
                        MyDataGridView dgv = new MyDataGridView();
                        dgv.DataSource = parsed1.data;
                        if (parsed1.data.Count > 0)
                        {
                            //MessageBox.Show("RowCount=" + dgv.RowCount.ToString());
                            FormTovCard f = new FormTovCard();
                            f.ID = parsed1.data[0].ID;
                            f.textBox_idtov.Text = parsed1.data[0].ID;
                            f.ShowDialog();
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void отчетПоРасхождениямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListNotMatched f = new FormListNotMatched();
            f.ShowDialog();
        }

        private void статистикаРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStat f = new FormStat();
            f.ShowDialog();
        }

        private void статистикаПриемкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewStat f = new FormNewStat();
            f.ShowDialog();
        }

        private void печатьЛистовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTovsheetsPrint f = new FormTovsheetsPrint();
            f.textBox_idemp.Text = textBox_idemp.Text;
            f.ShowDialog();
        }

        private void инвентаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInventOst f = new FormInventOst();
            f.ShowDialog();
        }

        private void времяУходаРейсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTripsLeave f = new FormTripsLeave();
            f.ShowDialog();           
        }
    }
}

