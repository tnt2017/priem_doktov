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
    public partial class FormInputKol : Form
    {
        public FormInputKol()
        {
            InitializeComponent();
        }

        private void FormInputKol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReturnValue1 = textBox1.Text;
            this.ReturnValue2 = label_tovname.Text;
            this.ReturnValue3 = label_tovid.Text;
            
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
