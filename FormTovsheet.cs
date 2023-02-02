using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using BarcodeLib;
using System.Data.SQLite;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using RawPrint;
using System.Drawing.Printing;
using Spire.Pdf;
using System.Media;//подключили пространство имен SoundPlayer  


namespace test111
{
    public partial class FormTovsheet : Form
    {
        Dictionary<string, int> picked_tovs = new Dictionary<string, int>(5);
        SQLiteConnection m_dbConn = DBSqlite.Connect();

        DataGridView dataGridView1;

        public FormTovsheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Отборочный лист ID=" + textBox_idsheet.Text;
            DBClass.OracleRequest("tovsheet&idsheet=" + textBox_idsheet.Text, myDataGridView1, false);

            if (myDataGridView1.Rows.Count > 0)
            {
                try
                {
                    myDataGridView1.Columns["IDL"].Width = 5;
                    myDataGridView1.Columns["CMC"].Width = 60;
                    myDataGridView1.Columns["NAME"].Width = 350;
                    myDataGridView1.Columns["NOMENKL"].Width = 80;
                    myDataGridView1.Columns["KOL_UPAK"].Width = 60;
                    myDataGridView1.Columns["KOL"].Width = 40;
                    myDataGridView1.Columns["SECTION"].Width = 60;
                    myDataGridView1.Columns["KG"].Width = 40;
                    myDataGridView1.Columns["CCHECK"].Width = 60;
                    myDataGridView1.Columns["CHECKER"].Width = 60;
                    myDataGridView1.Columns["DCHECK"].Width = 60;
                    myDataGridView1.Columns["KOL_FAKT"].Width = 60;
                }
                catch (Exception ex)
                {

                }

            }


            DBClass.OracleRequest("tovsheet_header&idsheet=" + textBox_idsheet.Text, myDataGridView2, false);
            try
            {
                textBox1.Text = myDataGridView2.Rows[0].Cells["PICKER"].Value.ToString();
                textBox2.Text = myDataGridView2.Rows[0].Cells["PACKER"].Value.ToString();
                textBox3.Text = myDataGridView2.Rows[0].Cells["COLL"].Value.ToString();
                textBox4.Text = myDataGridView2.Rows[0].Cells["DPICK"].Value.ToString();
                textBox5.Text = myDataGridView2.Rows[0].Cells["DPACK"].Value.ToString();
                textBox6.Text = myDataGridView2.Rows[0].Cells["DCOLL"].Value.ToString();

            }

            catch (Exception ex)
            {

            }

            try
            {
                label1.Text = myDataGridView2.Rows[0].Cells["KG_T"].Value.ToString() + "кг / " +
                myDataGridView2.Rows[0].Cells["M3_T"].Value.ToString() + "м3 / " +
                myDataGridView2.Rows[0].Cells["KOR_W"].Value.ToString() + "кор / " +
                myDataGridView2.Rows[0].Cells["PLACES"].Value.ToString() + "мест / " +
                myDataGridView2.Rows[0].Cells["LINES"].Value.ToString() + "строк";

                textBox_npkgs.Text = myDataGridView2.Rows[0].Cells["PLACES"].Value.ToString();
            }

            catch (Exception ex)
            {

            }

            try
            {
                label2.Text = myDataGridView2.Rows[0].Cells["NNAKL"].Value.ToString();
                label3.Text = myDataGridView2.Rows[0].Cells["ORG"].Value.ToString();
                label4.Text = myDataGridView2.Rows[0].Cells["ADR"].Value.ToString();
                string adr_dost = myDataGridView2.Rows[0].Cells["ADR_DOST"].Value.ToString();

                if (adr_dost.Substring(0, 3) == "210")
                {
                    adr_dost="d." + adr_dost.Substring(3, adr_dost.Length - 3);
                }
                if (adr_dost.Substring(0, 3) == "200")
                {
                    adr_dost = "c." + adr_dost.Substring(3, adr_dost.Length - 3);
                }
                if (adr_dost.Substring(0, 3) == "190")
                {
                    adr_dost = "b." + adr_dost.Substring(3, adr_dost.Length - 3);
                }
                if (adr_dost.Substring(0, 3) == "180")
                {
                    adr_dost = "a." + adr_dost.Substring(3, adr_dost.Length - 3);
                }

                textBox_kodadr.Text = adr_dost;
            }
            catch (Exception ex)
            {

            }

            try
            {
                label8.Text = myDataGridView2.Rows[0].Cells["ROUTE"].Value.ToString() + "(" + myDataGridView2.Rows[0].Cells["CTRIP"].Value.ToString() + ")";
            }
            catch (Exception ex)
            {

            }
        }


        private void FormTovsheet_Load(object sender, EventArgs e)
        {
            Logger.WriteLine("open tovsheet " + textBox_idsheet.Text);
            button1_Click(null, null);
            this.KeyPreview = true;
            

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormTovCard f = new FormTovCard();
            f.ID = myDataGridView1.CurrentRow.Cells["CMC"].Value.ToString();
            f.textBox_idtov.Text = f.ID;
            f.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDoc f = new FormDoc();
            f.ID = myDataGridView2.CurrentRow.Cells["CPARENT"].Value.ToString();
            f.textBox_iddoc.Text = f.ID;
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormListWhenFound f = new FormListWhenFound();
            f.textBox_idtov.Text = myDataGridView1.CurrentRow.Cells["CMC"].Value.ToString();
            f.ShowDialog();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormTripCard f = new FormTripCard();
            f.textBox_idtrip.Text = myDataGridView2.CurrentRow.Cells["CTRIP"].Value.ToString();
            f.ShowDialog();
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {            
            string s=DBClass.GET(DBClass.api_url, "save_port_sheet&idtrip=" + textBox_idsheet.Text + "&npkgs=" + textBox_npkgs.Text);            
            MessageBox.Show(s);
        }


        /* public void printPDFWithAcrobat(string Filepath)
         {
         //string Filepath = @"C:\Users\sdkca\Desktop\path-to-your-pdf\pdf-sample.pdf";
         using (PrintDialog Dialog = new PrintDialog())
         {
             Dialog.ShowDialog();
             ProcessStartInfo printProcessInfo = new ProcessStartInfo()
             {
                 Verb = "print",
                 CreateNoWindow = true,
                 FileName = Filepath,
                 WindowStyle = ProcessWindowStyle.Hidden
             };
             Process printProcess = new Process();
             printProcess.StartInfo = printProcessInfo;
             printProcess.Start();
             printProcess.WaitForInputIdle();
             Thread.Sleep(3000);
             if (false == printProcess.CloseMainWindow())
             {
                 printProcess.Kill();
             }
         }
     }*/


    
    


    public void printPDF(string Filepath)
        {
            string Filename = "pdf-sample.pdf";
            // The name of the printer that you want to use
            // Note: Check step 1 from the B alternative to see how to list
            // the names of all the available printers with C#
            string PrinterName = GetPrinterName();
            // Create an instance of the Printer
            IPrinter printer = new Printer();
            // Print the file
            printer.PrintRawFile(PrinterName, Filepath, Filename);
        }


        public void Print(string name)
        {
            List<string> PrinterFound = new List<string>();
            PrinterSettings printer = new PrinterSettings();
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                PrinterFound.Add(item.ToString());
            }
           
            printer.PrinterName = PrinterFound[PrinterFound.Count-1];
            printer.PrintFileName = name;
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.DocumentName = name; //@"..\Resources\" + 
            PrintDoc.PrinterSettings.PrinterName = PrinterFound[PrinterFound.Count-1];
            PrintDoc.Print();
        }



        private void button_print_Click(object sender, EventArgs e)
        {
            textBox_idsheet.Text = textBox_idsheet.Text.Replace("\r","");
            var barcode = new BarcodeLib.Barcode();
            //var saveFileDialog = new SaveFileDialog { FileName = , Filter = "PDF file (*.pdf)|*.pdf" };
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{

            string fname = "OL" + textBox_idsheet.Text + ".pdf";

                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var fileStream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                // Для отображения русских букв
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                var font10 = new iTextSharp.text.Font(baseFont, 10);
                var font14 = new iTextSharp.text.Font(baseFont, 14);
                var font20 = new iTextSharp.text.Font(baseFont, 20);
                var font24 = new iTextSharp.text.Font(baseFont, 24);

                document.Open();
  
                var imageBarcode = barcode.Encode(BarcodeLib.TYPE.CODE128B, "OL" + textBox_idsheet.Text, Color.Black, Color.White, 160, 30); //item.Barcode
                var image = iTextSharp.text.Image.GetInstance(imageBarcode, ImageFormat.Jpeg);
                
                document.Add(new Paragraph(label3.Text, font24)); //клиент
                document.Add(new Paragraph(label4.Text, font24)); //адрес

                document.Add(new Paragraph("Код: " + textBox_kodadr.Text, font24)); //кодадр                
                document.Add(new Paragraph(label2.Text, font14)); //рнк
                document.Add(new Paragraph("Маршрут: " + label8.Text, font20)); //рейс
                document.Add(new Paragraph("Нас. пункт: " + myDataGridView2.Rows[0].Cells["NAS_PUNKT"].Value.ToString(), font14)); //рейс
                
                String s = myDataGridView2.Rows[0].Cells["LINES"].Value.ToString() + " строк";

                try
                {
                    s += myDataGridView2.Rows[0].Cells["KG_T"].Value.ToString() + " кг";
                }
                catch (Exception ex)
                {

                }

                s += myDataGridView2.Rows[0].Cells["M3_T"].Value.ToString() + " м3";
                document.Add(new Paragraph(s, font14)); //item.Description
                document.Add(new Paragraph(textBox_idsheet.Text, font14)); //item.Description
                document.Add(image);
 

                PdfPTable table = new PdfPTable(6);
                table.TotalWidth = 800f;

                float[] cols = { 0.1f, 1.4f, 0.2f, 0.1f, 0.3f, 0.2f };
                table.SetWidths(cols);
                
                for (int i = 0; i < myDataGridView1.Rows.Count ; i++)
                {
                    table.AddCell(new Phrase((i+1).ToString(), font10));
                    table.AddCell(new Phrase(myDataGridView1.Rows[i].Cells["NAME"].Value.ToString(), font10));
                    table.AddCell(new Phrase(myDataGridView1.Rows[i].Cells["SECTION"].Value.ToString(), font10));
                    table.AddCell(new Phrase(myDataGridView1.Rows[i].Cells["KOL"].Value.ToString(), font10));
                    
                    string nomenkl = "";
                    try
                    {
                        nomenkl=myDataGridView1.Rows[i].Cells["NOMENKL"].Value.ToString();
                    }
                    catch (Exception ex)
                    {

                    }

                    table.AddCell(new Phrase(nomenkl, font10));
                    table.AddCell(new Phrase(myDataGridView1.Rows[i].Cells["KG"].Value.ToString(), font10));
                }

                //Добавляем таблицу в документ
                document.Add(table);
                //Закрываем документ
                document.Close();
                textBox_fname.Text = fname;

                Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
                pdfdocument.LoadFromFile(textBox_fname.Text);
                pdfdocument.PrinterName = GetPrinterName();
                pdfdocument.PrintDocument.PrinterSettings.Copies = 1;
                pdfdocument.PrintDocument.Print();
                pdfdocument.Dispose();
            //}          
        }

        private void FormTovsheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox7.Text += e.KeyChar + "";
        }


        private void FindTovId(string barcode)
        {
            Logger.WriteLine("FindTovId by code " + barcode);

            DataTable dTable = new DataTable();
            String sqlQuery;
            int count = 0;

            //System.Threading.Thread.Sleep(50);


            if (m_dbConn.State != ConnectionState.Open)
            {
                m_dbConn.Open();
                Logger.WriteLine("ConnectionState is not open");
                return;
            }

            try
            {
                sqlQuery = "SELECT kmc.ID, NAME, NOMENKL from KATMC kmc, KATMC_BARCODE bc WHERE kmc.ID=bc.ID AND NOMENKL NOT LIKE 'акц%' AND NOMENKL NOT LIKE 'Уценка%' AND BARCODE='" + barcode + "'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    Logger.WriteLine("Rows.Count > 0");

                    if (dTable.Rows.Count > 1)  //////////////// с этим штрихкодом более 1 товара
                    {
                        Logger.WriteLine("Rows.Count > 1");
                        // MessageBox.Show("с этим штрихкодом более 1 товара");
                        panel1.Visible = true;
                        dataGridView1 = new DataGridView();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Parent = panel1;
                        dataGridView1.Top = 25;
                        dataGridView1.Left = 25;
                        dataGridView1.Width = 480;
                        dataGridView1.Height = 150;
                        dataGridView1.DoubleClick += dataGridView1_DoubleClick;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dTable;
                        dataGridView1.Columns["ID"].Width = 60;
                        dataGridView1.Columns["NAME"].Width = 350;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < myDataGridView1.Rows.Count; j++)
                            {
                                if (dataGridView1.Rows[i].Cells["ID"].Value.ToString() == myDataGridView1.Rows[j].Cells["CMC"].Value.ToString())
                                {
                                    dataGridView1.Rows[i].Cells["ID"].Style.BackColor = Color.Red;
                                    if(myDataGridView1.Rows[j].Cells["KOL"].Value.ToString()== myDataGridView1.Rows[j].Cells["KOLFACT"].Value.ToString())
                                        dataGridView1.Rows[i].Cells["ID"].Style.BackColor = Color.Green;
                                }
                            }
                        }

                      //  m_dbConn.Close();
                        return; // 26-10-2021 если >1 товара то не ищет 
                    }
                    else
                    {
                        panel1.Visible = false;

                        if (dataGridView1 != null)
                        dataGridView1.Visible = false;
                    }

                    for (int x = 0; x < dTable.Rows.Count; x++)
                    {
                        string tovid = dTable.Rows[x].ItemArray[0].ToString();
                        for (int i = 0; i < myDataGridView1.Rows.Count; i++)
                        {
                            if (myDataGridView1.Rows[i].Cells["CMC"].Value.ToString() == tovid)
                            {
                                myDataGridView1.Rows[i].Cells["CMC"].Style.BackColor = Color.Red;
                                count = 1;

                                string idl = myDataGridView1.Rows[i].Cells["IDL"].Value.ToString();
                                string kol_upack = myDataGridView1.Rows[i].Cells["KOL_UPAK"].Value.ToString();
                                string pack = myDataGridView1.Rows[i].Cells["PACK"].Value.ToString();

                                int inc = 1;

                                if (radioButton2.Checked)
                                {
                                    inc = Convert.ToInt16(pack);
                                }

                                if (radioButton3.Checked)
                                {
                                    inc = Convert.ToInt16(kol_upack);
                                }


                                if (picked_tovs.ContainsKey(idl))
                                {
                                    picked_tovs[idl]+= inc;
                                    Logger.WriteLine("picked_tovs[" + idl + "]++");

                                }

                                else
                                {
                                    picked_tovs.Add(idl, inc);
                                    Logger.WriteLine("picked_tovs Add idl");
                                }

                                SoundPlayer sp = new SoundPlayer();
                                if (picked_tovs[idl].ToString() == myDataGridView1.Rows[i].Cells["KOL"].Value.ToString())
                                {
                                    sp.SoundLocation = "bonus2.wav";
                                }
                                else
                                {
                                    sp.SoundLocation = "bonus1.wav";
                                }
                                sp.Play();

                            }
                        }
                    }

                }
                else
                {
                    Logger.WriteLine("Database is empty");
                    MessageBox.Show("Database is empty");
                }
            }
            catch (SQLiteException ex)
            {
                Logger.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }

            if (count == 0)
            {
                Logger.WriteLine("Товар не найден");
                MessageBox.Show("Товар не найден");
            }

           // m_dbConn.Close();
        }

        private void FormTovsheet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Text += "\r\n";
                String[] words = textBox7.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string last_val = words[words.Count() - 1];

                last_val = last_val.Replace("\r", " ");
                last_val = last_val.Replace("\n", " ");
                last_val = last_val.Replace("", " ");
                last_val = last_val.Trim();

               // MessageBox.Show(last_val);
                if (last_val!="")
                FindTovId(last_val);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (panel1.Visible == true)
                    panel1.Visible =false;
            }
       }

        private void FormTovsheet_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_idsheet.Text = textBox_idsheet.Text.Replace("\r","");
            string login = "ROSTOA$NSK20";
            string pass = "345544";
            string idemp = "1900161";
            string izone = "1";
            DateTime now = DateTime.Now;
            string dt = now.ToString("dd.MM.yyyy HH:mm:ss");

            string hdr = textBox_idsheet.Text + "^" + dt + "^" + idemp + "^2^"; //hdr='idSh^dcurr^cemp^flg^'
            string lns = "";
            //'idL^kol^afx^inv^sec^dt^chktip^dtil^
            foreach (KeyValuePair<string, int> kv in picked_tovs)
            {
                lns += kv.Key + "^" + kv.Value + "^^^^" + dt + "^M^^";
            }
            //api_url

            string dta="1900161^1^test^16^1^0045^";


            string url = "svc_id=save_tovsheet&login=" + login + "&pass=" + pass + "&idemp=" + idemp + "&izone=" + izone + "&dta=" + dta + 
                    "&idsheet=" + textBox_idsheet.Text + "&iflg=16" +
                    "&npkgkg=" + textBox_npkgs.Text + "&hdr=" + hdr + "&lns=" + lns;
            
            string msg = DBClass.GET(DBClass.api_url, url);
            var data1 = msg;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
            dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
            dynamic response=parsed.data;

            FormTovsWithOneBarcode f = new FormTovsWithOneBarcode();
            f.textBox1.Text = url;
            f.textBox2.Text = response[0].MSG;
            
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = "";

            foreach (KeyValuePair<string, int> kv in picked_tovs)
            {
                s += kv.Key + ": " + kv.Value.ToString(); 
            }

            MessageBox.Show(s);
        }

        private void myDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (KeyValuePair<string, int> kv in picked_tovs)
            {
                //MessageBox.Show(kv.Key + ": " + kv.Value.ToString());

                for (int i = 0; i < myDataGridView1.Rows.Count; i++)
                {
                    if (myDataGridView1.Rows[i].Cells["IDL"].Value.ToString() == kv.Key)
                    {
                        myDataGridView1.Rows[i].Cells["IDL"].Style.BackColor = Color.Red;
                        myDataGridView1.Rows[i].Cells["CMC"].Style.BackColor = Color.Red;
                        myDataGridView1.Rows[i].Cells["KOLFACT"].Value = kv.Value.ToString();

                        if (myDataGridView1.Rows[i].Cells["KOL"].Value==myDataGridView1.Rows[i].Cells["KOLFACT"].Value)
                        {
                            myDataGridView1.Rows[i].Cells["CMC"].Style.BackColor = Color.Green;
                            SoundPlayer sp = new SoundPlayer();
                            sp.SoundLocation = "test.wav";
                            sp.Play();

                        }

                    }
                }

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string idtov = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            for (int i = 0; i < myDataGridView1.Rows.Count; i++)
            {
                if (myDataGridView1.Rows[i].Cells["CMC"].Value.ToString() == idtov)
                {
                    string idl = myDataGridView1.Rows[i].Cells["IDL"].Value.ToString();
                    //MessageBox.Show(idl);

                    if (picked_tovs.ContainsKey(idl))
                        picked_tovs[idl]++;
                    else
                        picked_tovs.Add(idl, 1);

                    SoundPlayer sp = new SoundPlayer();
                    if (picked_tovs[idl].ToString() == myDataGridView1.Rows[i].Cells["KOL"].Value.ToString())
                    {
                        sp.SoundLocation = "bonus2.wav";
                    }
                    else
                    {
                        sp.SoundLocation = "bonus1.wav";
                    }
                    sp.Play();
                }
            }

            panel1.Visible = false;
            dataGridView1.Visible = false;

            try
            {
                dataGridView1.Dispose();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("111");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormAuditTovsheet f = new FormAuditTovsheet();
            f.textBox_idsheet.Text = textBox_idsheet.Text;
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sdata = textBox_idsheet.Text.Trim() + "^" + textBox_npkgs.Text.Trim() + "^";
            MessageBox.Show(sdata);
            string s = DBClass.GET(DBClass.mobile_api_url, "p=save_collect&sdata=" + sdata + "&login=ROSTOA$NSK20&pass=345544&msg=1900161");
            MessageBox.Show(s);
        }


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


        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "test.wav";
            sp.Play();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> kv in picked_tovs)
            {
                string url = "idemp=" + textBox_idemp.Text + "&idsheet=" + textBox_idsheet.Text  + "&cmc=" + kv.Key + "&kol=" + kv.Value.ToString();
                Logger.WriteLine("url=" + url);
                //MessageBox.Show(url);
                string msg = DBClass.GET("http://192.168.1.145/insert_control.php", url);
                MessageBox.Show(msg);
            }

        }

        /*String ConvertEAN(String barcode)
        {
            barcode = barcode.Substring(1, 13);

            int t1 = 0, t2 = 0;
            for (int i = 0; i < 12; i++)
            {
                char c = barcode.IndexOf(i);
                int a = Int32.Parse(c);
                if (i % 2 == 0)
                    t1 += a;
                else
                    t2 += a;
            }

            /*int summa = t1 + t2 * 3;
            String str_summa = String.valueOf(summa);
            char last_sym = str_summa.charAt(str_summa.length() - 1);
            int res = 10 - Integer.parseInt(String.valueOf(last_sym));*/
            //String ret = barcode + String.valueOf(res);
            //Toast.makeText(this, ret, Toast.LENGTH_SHORT).show();

            /*return ret;
        }*/


        private void button10_Click_1(object sender, EventArgs e)
        {
            //ConvertEAN
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string login = "ROSTOA$NSK20";
            string pass = "345544";
            string sector = "1";
            string flg = "2";

            string dta = textBox_idemp.Text.Trim() + "^" + textBox_npkgs.Text.Trim() + "^test^" + flg + "^" + sector + "^0045^";

            string url = "p=save_tovsheet_header&login=" + login + "&pass=" + pass +
                    "&idsheet=" + textBox_idsheet.Text + "&msg=test&dta=" + dta;

            string s = DBClass.GET(DBClass.mobile_api_url, url);
            MessageBox.Show(s);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string login = "ROSTOA$NSK20";
            string pass = "345544";
            string sector = "1";
            string flg = "1";

            string dta = textBox_idemp.Text.Trim() + "^" + textBox_npkgs.Text.Trim() + "^test^" + flg + "^" + sector + "^0045^";

            string url = "p=save_tovsheet_header&login=" + login + "&pass=" + pass +
                    "&idsheet=" + textBox_idsheet.Text + "&msg=test&dta=" + dta;

            string s = DBClass.GET(DBClass.mobile_api_url, url);
            MessageBox.Show(s);
        }
    }
}
