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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s= listBox1.SelectedItem.ToString();
            s = s.Substring(0, s.IndexOf(" "));
            textBox1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateList(string filePath)
        {
            if (File.Exists("emps.txt"))
            {
                listBox1.Items.Clear();
                string[] readText = File.ReadAllLines("emps.txt");
                listBox1.Items.AddRange(readText);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            PopulateList("emps.txt");
        }
        
    }
}
