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
    public partial class FormListWhenFound : Form
    {
        public FormListWhenFound()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("list_when_found&idtov=" + textBox_idtov.Text, myDataGridView1, false);
        }

        private void FormListWhenFound_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
