using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test111
{
    public partial class FormStat : Form
    {
        public FormStat()
        {
            InitializeComponent();
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormStat_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itip = comboBox1.SelectedIndex.ToString();
            string iturn = "1";

            if (radioButton2.Checked)
                iturn = "2";

            DBClass.OracleRequest("turn_active&itip=" + itip + "&iturn=" + iturn + "&dbeg=" + dateTimePicker1.Value.ToString("dd.MM.yyyy"), myDataGridView1, false);
        }
    }
}
