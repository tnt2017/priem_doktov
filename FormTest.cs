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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "";
            for (int i = 0; i < arr.Count(); i++)
            {
                s += "spool \"C:\\Users\\User\\Desktop\\NSK20." + arr[i] + ".sql\"\r\n";
                s += "SELECT  /*insert*/ * from NSK20." + arr[i] + ";\r\n"; //\\*insert*\\
                s += "spool off;\r\n\r\n";
            }
            textBox1.Text = s;
            string path = "C:\\Users\\User\\Desktop\\script_export.txt";
            File.WriteAllText(path, s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "SET LONG 5000\r\n";
            for (int i = 0; i < arr.Count(); i++)
            {
                s += "SELECT dbms_metadata.get_ddl('TABLE', '" + arr[i] + "') FROM DUAL;\r\n";
            }
            textBox1.Text = s;
            string path = "C:\\Users\\User\\Desktop\\script_export_ddl.txt";
            File.WriteAllText(path, s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] separator = { Environment.NewLine };
            string[] arr = textBox2.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show(arr.Count().ToString());
            string s = "SET LONG 5000\r\n";
            for (int i = 0; i < arr.Count(); i++)
            {
                s += "create table " + arr[i] + " as select* from NSK20." + arr[i] + " where 1 = 0;\r\n";
            }
            textBox1.Text = s;
            string path = "C:\\Users\\User\\Desktop\\copy_all_tables.txt";
            File.WriteAllText(path, s);
        }
    }
}
