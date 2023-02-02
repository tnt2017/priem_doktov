using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using iTextSharp.text.pdf;
using iTextSharp.text;

namespace test111
{
    public partial class FormInventOst : Form
    {
        public FormInventOst()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
            string sparams = "&kol1=" + textBox1.Text + "&kol2=" + textBox2.Text + "&sector=" + comboBox1.SelectedIndex;

            if(comboBox2.SelectedIndex>0)
                sparams += "&letter=" + comboBox2.SelectedItem.ToString();

            string url;

            if (radioButton1.Checked)
            {
                sparams += "&dinv=" + dateTimePicker1.Value.ToString("dd.MM.yyyy");
                sparams += "&dinv2=" + dateTimePicker2.Value.ToString("dd.MM.yyyy");
                url = "invent_by_ost" + sparams;
            }
            else
            {
                sparams += "&dinv=" + dateTimePicker3.Value.ToString("dd.MM.yyyy");
                url = "invent_by_ost2" + sparams;
            }





            textBox3.Text = url;

            DBClass.OracleRequest(url, myDataGridView1, false);

            try
            {
                myDataGridView1.Columns["NN"].Width = 30;
                myDataGridView1.Columns["ID"].Width = 60;
                myDataGridView1.Columns["NAME"].Width = 450;
                myDataGridView1.Columns["SECTION"].Width = 60;
                myDataGridView1.Columns["OST_FREE"].Width = 60;
                myDataGridView1.Columns["OST_REP"].Width = 60;
                myDataGridView1.Columns["DINV_LAST"].Width = 70;
                myDataGridView1.Columns["PAGE_NO"].Width = 60;
                myDataGridView1.Columns["FLAGS"].Width = 60;
            }
            catch (Exception ex)
            {

            }

            label6.Text = myDataGridView1.RowCount.ToString() + " строк";
        }

        private void FormInventOst_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }


        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string s = myDataGridView1.Columns[myDataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();

            if (s == "ID")
            {
                string cmc = myDataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                FormTovCard f = new FormTovCard();
                f.ID = cmc;
                f.textBox_idtov.Text = cmc;
                f.ShowDialog();
            }
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime CusDate = dateTimePicker1.Value;
            string Date = CusDate.ToString("ddMMMyyyy");

            string fname = "INVENT" + Date + ".pdf";

            var barcode = new BarcodeLib.Barcode();
            var saveFileDialog = new SaveFileDialog { FileName = fname, Filter = "PDF file (*.pdf)|*.pdf" };
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


                DateTime date = DateTime.Now;
                string dt=date.ToString();

                document.Add(new Paragraph("Дата печати: " + dt, font12)); //клиент
                //   document.Add(new Paragraph("Контрагент: " + textBox_org.Text, font12)); //клиент
                //   document.Add(new Paragraph("Адрес: " + textBox_adr.Text, font12)); //адрес

                PdfPTable table = new PdfPTable(6);
                table.TotalWidth = 800f;

                float[] cols = { 0.1f, 0.2f, 0.2f, 1.4f, 0.2f,0.1f  };
                table.SetWidths(cols);

                double sum_kol = 0, sum_kor = 0, sum_rub = 0, sum_ves = 0, sum_razmer = 0;
                for (int i = 0; i < myDataGridView1.Rows.Count; i++)
                {
                    string nn = myDataGridView1.Rows[i].Cells["NN"].Value.ToString();
                    string section = myDataGridView1.Rows[i].Cells["SECTION"].Value.ToString();
                    string id = myDataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    string name = myDataGridView1.Rows[i].Cells["NAME"].Value.ToString();
                    string ost_free = myDataGridView1.Rows[i].Cells["OST_FREE"].Value.ToString();
                    string dinv_last = myDataGridView1.Rows[i].Cells["DINV_LAST"].Value.ToString();

                    table.AddCell(new Phrase(nn.ToString(), font8));
                    table.AddCell(new Phrase(section.ToString(), font8));
                    table.AddCell(new Phrase(id.ToString(), font8));
                    table.AddCell(new Phrase(name.ToString(), font8));
                    table.AddCell(new Phrase(ost_free, font8));
                    table.AddCell(new Phrase(dinv_last.ToString(), font8));
                }

                document.Add(table);
                document.Close();

                 
                Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
                pdfdocument.LoadFromFile(fname);
                pdfdocument.PrinterName = GetPrinterName();
                pdfdocument.PrintDocument.PrinterSettings.Copies = 1;
                pdfdocument.PrintDocument.Print();
                pdfdocument.Dispose();
                 
            }
        }
    }
}
