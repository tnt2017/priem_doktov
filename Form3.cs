using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace test111
{
    public partial class Form3 : Form
    {
        public string IDTRIP = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "http://10.8.0.151/rep/main/trip_print.php?idtrip=" + IDTRIP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text);
            Process.Start(textBox1.Text);

        }
    }
}
