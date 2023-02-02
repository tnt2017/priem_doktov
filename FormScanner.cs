using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace test111
{
    public partial class FormScanner : Form
    {
        public FormScanner()
        {
            InitializeComponent();
        }

        public int ExtractPages(string sourcePdfPath, string DestinationFolder)
        {
            int p = 0;
            try
            {
                iTextSharp.text.Document document;
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdfPath), new ASCIIEncoding().GetBytes(""));
                if (!Directory.Exists(sourcePdfPath.ToLower().Replace(".pdf", "")))
                {
                    Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                }
                else
                {
                    Directory.Delete(sourcePdfPath.ToLower().Replace(".pdf", ""), true);
                    Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                }

                progressBar1.Maximum = reader.NumberOfPages;

                for (p = 1; p <= reader.NumberOfPages; p++)
                {
                    progressBar1.Value++;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        document = new iTextSharp.text.Document();
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
                        writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_2);
                        writer.CompressionLevel = iTextSharp.text.pdf.PdfStream.BEST_COMPRESSION;
                        writer.SetFullCompression();
                        document.SetPageSize(reader.GetPageSize(p));
                        document.NewPage();
                        document.Open();
                        document.AddDocListener(writer);
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                        iTextSharp.text.pdf.PdfImportedPage pageImport = writer.GetImportedPage(reader, p);
                        int rot = reader.GetPageRotation(p);
                        if (rot == 90 || rot == 270)
                        {
                            cb.AddTemplate(pageImport, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(p).Height);
                        }
                        else
                        {
                            cb.AddTemplate(pageImport, 1.0F, 0, 0, 1.0F, 0, 0);
                        }
                        document.Close();
                        document.Dispose();

                        string page_num = p.ToString();

                        if (page_num.Length == 1)
                            page_num = "00" + page_num;

                        if (page_num.Length == 2)
                            page_num = "0" + page_num;

                        File.WriteAllBytes(DestinationFolder + "/" + page_num + ".pdf", memoryStream.ToArray());
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
            return p - 1;

        }

        int tick = 0;
        string dir;
        private void button1_Click(object sender, EventArgs e)
        {
            ExtractPages(textBox1.Text, textBox2.Text);
            update_listbox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "O:\\!сканы\\";    //"\\10.8.0.151\\obmen\\!сканы";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                string fname = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                dir = AppDomain.CurrentDomain.BaseDirectory + "\\" + fname;
                Directory.CreateDirectory(dir);
                textBox2.Text = dir;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.FileName = "BarcodeReaderDemo.exe";
            pi.Arguments = "\"" + listBox1.SelectedItem.ToString() + "\"";
            p.StartInfo = pi;
            p.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int startpos = listBox1.SelectedIndex;
            for (int i = startpos; i < startpos + 5; i++)
            {
                if (i < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = i;
                    button3_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Цикл кончился!");
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    break;
                }
                //MessageBox.Show(item.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void FormScanner_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tick++;
            label5.Text = tick.ToString();

            this.Text = "Работа со сканером " + listBox1.SelectedIndex.ToString() + " из " + listBox1.Items.Count;
            if (tick % numericUpDown1.Value == 0)
            {
                progressBar2.Maximum = listBox1.Items.Count;
                progressBar2.Value = listBox1.SelectedIndex;

                //MessageBox.Show("жмем кнопку");
                button4_Click(null, null);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void update_listbox()
        {
            listBox1.Items.Clear();
            string[] second = Directory.GetFiles(textBox2.Text); // путь к папке
            for (int i = 0; i < second.Length; i++)
            {
                if ((second[i].Substring(second[i].Length - 4, 4) == ".pdf"))
                    listBox1.Items.Add(second[i]);
                if ((second[i].Substring(second[i].Length - 4, 4) == ".txt"))
                    listBox2.Items.Add(second[i]);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = Application.StartupPath;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = FBD.SelectedPath;
                dir = textBox2.Text;

                update_listbox();

                if (listBox1.Items.Count>0)
                listBox1.SelectedIndex = 0;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] second = Directory.GetFiles(textBox2.Text); // путь к папке
            for (int i = 0; i < second.Length; i++)
            {
                if((second[i].Substring(second[i].Length-4,4)==".txt"))
                listBox2.Items.Add(second[i]);
            }
            label7.Text = "Обработано страниц: " + listBox2.Items.Count.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s=listBox2.SelectedItem.ToString();
           // MessageBox.Show(s);
            textBox5.Text = File.ReadAllText(s);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int list_num = 0;
            string last_code = "";
            textBox4.Text = "";


            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string[] x = File.ReadAllLines(listBox2.Items[i].ToString());
                if (x.Count() > 0)
                {
                    list_num = 0;
                    textBox4.Text += Path.GetFileName(Path.ChangeExtension(listBox2.Items[i].ToString(), ".pdf")) + " -> " + x[0] + "_0.pdf\r\n";
                    last_code = x[0];
                }
                else
                {
                    list_num++;
                    textBox4.Text += Path.GetFileName(Path.ChangeExtension(listBox2.Items[i].ToString(), ".pdf")) + " -> пустой штрихкод (" + last_code + "_" + list_num + ".pdf?)\r\n";
                }

                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button7_Click_1(null, null);
        }
    }
}
