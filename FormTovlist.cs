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
    public partial class FormTovlist : Form
    {
        public FormTovlist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClass.OracleRequest("list_tovs&idgrp=" + textBox_idgrp.Text, myDataGridView1, false);
            myDataGridView1.Columns["NAME"].Width = 450;
            myDataGridView1.Columns["GF"].Width = 50;
            myDataGridView1.Columns["KOL_UPAK"].Width = 50;            
    }

        private void FormTovlist_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (myDataGridView1.CurrentRow.Cells["GF"].Value.ToString() == "0")
            {
                textBox_idgrp.Text = myDataGridView1.CurrentRow.Cells["CMC"].Value.ToString();
                button1_Click(null, null);
            }
            else
            {
                string id = myDataGridView1.CurrentRow.Cells["CMC"].Value.ToString();
                FormTovCard f = new FormTovCard();
                f.ID = id;
                f.textBox_idtov.Text = id;
                f.ShowDialog();
            }
        }

        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tov_id = myDataGridView1.CurrentRow.Cells["CMC"].Value.ToString();
                string tov_name = myDataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
                string kol_upak = myDataGridView1.CurrentRow.Cells["KOL_UPAK"].Value.ToString();
                //MessageBox.Show(s);
                FormInputKol f = new FormInputKol();
                f.label_tovid.Text = tov_id;
                f.label_tovname.Text = tov_name;
                f.label_kolupak.Text = kol_upak;

                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    listBox1.Items.Add(f.ReturnValue3 + ":" + f.ReturnValue1 + ":" + f.ReturnValue2);
                }
            }
        }
    }
}
