namespace test111
{
    partial class FormNewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_emp = new System.Windows.Forms.TextBox();
            this.dataGridView_orgs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_summ = new System.Windows.Forms.TextBox();
            this.textBox_idemp = new System.Windows.Forms.TextBox();
            this.textBox_prim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orgs)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать ордер";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 187);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "^1800025^4^20^^^1^1^1^^3193^test^";
            // 
            // textBox_emp
            // 
            this.textBox_emp.Location = new System.Drawing.Point(12, 40);
            this.textBox_emp.Name = "textBox_emp";
            this.textBox_emp.Size = new System.Drawing.Size(100, 20);
            this.textBox_emp.TabIndex = 2;
            this.textBox_emp.TextChanged += new System.EventHandler(this.textBox_org_TextChanged);
            // 
            // dataGridView_orgs
            // 
            this.dataGridView_orgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_orgs.Location = new System.Drawing.Point(309, 40);
            this.dataGridView_orgs.Name = "dataGridView_orgs";
            this.dataGridView_orgs.Size = new System.Drawing.Size(271, 167);
            this.dataGridView_orgs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сотрудник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сумма";
            // 
            // textBox_summ
            // 
            this.textBox_summ.Location = new System.Drawing.Point(12, 87);
            this.textBox_summ.Name = "textBox_summ";
            this.textBox_summ.Size = new System.Drawing.Size(100, 20);
            this.textBox_summ.TabIndex = 6;
            this.textBox_summ.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox_idemp
            // 
            this.textBox_idemp.Location = new System.Drawing.Point(170, 40);
            this.textBox_idemp.Name = "textBox_idemp";
            this.textBox_idemp.Size = new System.Drawing.Size(100, 20);
            this.textBox_idemp.TabIndex = 7;
            this.textBox_idemp.TextChanged += new System.EventHandler(this.textBox_idemp_TextChanged);
            // 
            // textBox_prim
            // 
            this.textBox_prim.Location = new System.Drawing.Point(12, 134);
            this.textBox_prim.Name = "textBox_prim";
            this.textBox_prim.Size = new System.Drawing.Size(100, 20);
            this.textBox_prim.TabIndex = 9;
            this.textBox_prim.Text = "test";
            this.textBox_prim.TextChanged += new System.EventHandler(this.textBox_prim_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Прим";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(12, 268);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(568, 89);
            this.textBox_log.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 160);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ордер";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(130, 160);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(137, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Платежное поручение";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // FormNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 377);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.textBox_prim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_idemp);
            this.Controls.Add(this.textBox_summ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_orgs);
            this.Controls.Add(this.textBox_emp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "FormNewOrder";
            this.Text = "Создание ордера";
            this.Load += new System.EventHandler(this.FormNewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orgs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_emp;
        private System.Windows.Forms.DataGridView dataGridView_orgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_summ;
        private System.Windows.Forms.TextBox textBox_idemp;
        private System.Windows.Forms.TextBox textBox_prim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}