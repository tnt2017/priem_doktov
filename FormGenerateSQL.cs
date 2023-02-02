using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace test111
{
    public partial class FormGenerateSQL : Form
    {
        public FormGenerateSQL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "";
            for (int i = 0; i < arr.Count(); i++)
            {
               // s += "spool \"C:\\NSK08." + arr[i] + ".sql\"\r\n";
                s += "INSERT into LAST_PRIHOD(CMC, dt) VALUES(" + arr[i] + ", GET_LAST_PRIHOD(" + arr[i] + "))" + ";\r\n";
             // s += "spool off;\r\n\r\n";
            }
            textBox3.Text = s;
            string path = "C:\\Users\\User\\Desktop\\script_export11.txt";
            File.WriteAllText(path, s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "";
            for (int i = 0; i < arr.Count(); i++)
            {
                // s += "spool \"C:\\NSK08." + arr[i] + ".sql\"\r\n";
                s += "SELECT NSK20.AUX_A.TOV_OSTATOK(" + arr[i] + ")  into ret from DUAL;\r\n";          
                // s += "spool off;\r\n\r\n";
            }
            textBox3.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "";

            progressBar1.Maximum = arr.Count();
            for (int i = 0; i < arr.Count(); i++)
            {
                // s += "spool \"C:\\NSK08." + arr[i] + ".sql\"\r\n";
                s += "INSERT into LAST_BASE(CMC, PRICE_B) VALUES(" + arr[i] + ", NSK20.LAST_BASE(" + arr[i] + ", to_date('24.12.21', 'dd.mm.yy')))" + ";\r\n";
                // s += "spool off;\r\n\r\n";
                progressBar1.Value = i;
            }

            if(checkBox1.Checked)
            textBox3.Text = s;

            string path = "C:\\Users\\User\\Desktop\\LAST_BASE.txt";
            File.WriteAllText(path, s);

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            textBox2.Text = fileContent;

        }
    }
}
