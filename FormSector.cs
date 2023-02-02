using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace test111
{
    public partial class FormSector : Form
    {
        public FormSector()
        {
            InitializeComponent();
        }

        private void FormSector_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        string order;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            string d1 = dateTimePicker1.Value.ToString("dd.MM.yyyy HH:mm");
            string d2 = dateTimePicker2.Value.ToString("dd.MM.yyyy HH:mm");
            d1 =d1.Replace(" ", "_");
            d2 = d2.Replace(" ", "_");

            DBClass.OracleRequest("sector_work&sector=" + comboBox1.Items[comboBox1.SelectedIndex].ToString() + "&d1=" + d1 + "&d2=" + d2 + "&order=" + order, dataGridView1, false);
            FormatCols();
        }


        public static double ToDouble(string value, IFormatProvider provider)
        {
            if (value == null)
            {
                return 0.0;
            }

            return double.Parse(value, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, provider);
        }


        Dictionary<string, string> pickers = new Dictionary<string, string>();

        void FormatCols()
        {
            pickers.Clear();
            try
            {
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 70;


                dataGridView1.Columns[3].Width = 95;
                dataGridView1.Columns[4].Width = 95;
                dataGridView1.Columns[5].Width = 95;
                dataGridView1.Columns[6].Width = 95;
                dataGridView1.Columns[7].Width = 95;



                dataGridView1.Columns[8].Width = 50;
                dataGridView1.Columns[9].Width = 30;
                dataGridView1.Columns[10].Width = 30;
                dataGridView1.Columns[11].Width = 30;

                dataGridView1.Columns[13].Width = 50;
                dataGridView1.Columns[14].Width = 50;
                dataGridView1.Columns[15].Width = 50;
                dataGridView1.Columns[16].Width = 50;
                dataGridView1.Columns[17].Width = 50;
                dataGridView1.Columns[18].Width = 50;
            }
            catch (Exception ex)
            {

            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                Application.DoEvents();
                pickers[dataGridView1.Rows[i].Cells["PICKER"].Value.ToString()]="1";
                
                try
                {
                    string DELTA_OTBORA = dataGridView1.Rows[i].Cells["DOTBOR"].Value.ToString();
                    double d_otbora = ToDouble(DELTA_OTBORA, CultureInfo.InvariantCulture);

                    string DELTA_UPAKOVKI = dataGridView1.Rows[i].Cells["DUPAK"].Value.ToString();
                    double d_upak = ToDouble(DELTA_UPAKOVKI, CultureInfo.InvariantCulture);

                    string DELTA_COMPLEKT = dataGridView1.Rows[i].Cells["DCOMPL"].Value.ToString();
                    double d_coll = ToDouble(DELTA_COMPLEKT, CultureInfo.InvariantCulture);

                    if (d_otbora > 2)
                    {
                        dataGridView1.Rows[i].Cells["DOTBOR"].Style.BackColor = ColorTranslator.FromHtml("#F08080");
                    }

                    if (d_upak > 2)
                    {
                        dataGridView1.Rows[i].Cells["DUPAK"].Style.BackColor = ColorTranslator.FromHtml("#F08080");
                    }

                    if (d_coll > 2)
                    {
                        dataGridView1.Rows[i].Cells["DCOMPL"].Style.BackColor = ColorTranslator.FromHtml("#F08080");
                    }

                }
                catch (Exception ex)
                {
                }

                
            }

            int j = 0;

            foreach (var kvp in pickers)
            {
                j++;
                //MessageBox.Show(kvp.Key + ": " + kvp.Value.ToString());
                Button b = new Button();//this
                b.Left = 400 + j * 120;
                b.Top = 10+20*comboBox1.SelectedIndex;
                b.Height = 20;
                b.Width = 100;
                b.Text = kvp.Key;
                b.BringToFront();
                b.Click += ButtonOnClick;

                this.Controls.Add(b);
           }

        }



        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show(eventArgs.ToString());
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
