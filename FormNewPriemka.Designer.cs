namespace test111
{
    partial class FormNewPriemka
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
            this.textBox_org = new System.Windows.Forms.TextBox();
            this.textBox_emp = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.takeover_palets = new System.Windows.Forms.TextBox();
            this.takeover_packages = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.takeover_prim = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView_orgs = new System.Windows.Forms.DataGridView();
            this.dataGridView_emps = new System.Windows.Forms.DataGridView();
            this.takeover_iddoc = new System.Windows.Forms.TextBox();
            this.takeover_idadr = new System.Windows.Forms.TextBox();
            this.takeover_idexp = new System.Windows.Forms.TextBox();
            this.takeover_idorg = new System.Windows.Forms.TextBox();
            this.dataGridView_adrs = new System.Windows.Forms.DataGridView();
            this.dataGridView_docs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_emps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_adrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_docs)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_org
            // 
            this.textBox_org.Location = new System.Drawing.Point(118, 65);
            this.textBox_org.Name = "textBox_org";
            this.textBox_org.Size = new System.Drawing.Size(315, 20);
            this.textBox_org.TabIndex = 0;
            this.textBox_org.TextChanged += new System.EventHandler(this.textBox_org_TextChanged);
            // 
            // textBox_emp
            // 
            this.textBox_emp.Location = new System.Drawing.Point(118, 133);
            this.textBox_emp.Name = "textBox_emp";
            this.textBox_emp.Size = new System.Drawing.Size(315, 20);
            this.textBox_emp.TabIndex = 1;
            this.textBox_emp.TextChanged += new System.EventHandler(this.textBox_emp_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(315, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер док-та";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Контрагент";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Адрес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Экспедитор";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Палетов (поддонов)";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(118, 98);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(315, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // takeover_palets
            // 
            this.takeover_palets.Location = new System.Drawing.Point(118, 168);
            this.takeover_palets.Name = "takeover_palets";
            this.takeover_palets.Size = new System.Drawing.Size(123, 20);
            this.takeover_palets.TabIndex = 10;
            // 
            // takeover_packages
            // 
            this.takeover_packages.Location = new System.Drawing.Point(118, 203);
            this.takeover_packages.Name = "takeover_packages";
            this.takeover_packages.Size = new System.Drawing.Size(123, 20);
            this.takeover_packages.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Мест (коробок)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Примечание";
            // 
            // takeover_prim
            // 
            this.takeover_prim.Location = new System.Drawing.Point(117, 234);
            this.takeover_prim.Name = "takeover_prim";
            this.takeover_prim.Size = new System.Drawing.Size(123, 20);
            this.takeover_prim.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView_orgs
            // 
            this.dataGridView_orgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_orgs.Location = new System.Drawing.Point(263, 168);
            this.dataGridView_orgs.Name = "dataGridView_orgs";
            this.dataGridView_orgs.Size = new System.Drawing.Size(170, 86);
            this.dataGridView_orgs.TabIndex = 16;
            this.dataGridView_orgs.Visible = false;
            // 
            // dataGridView_emps
            // 
            this.dataGridView_emps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_emps.Location = new System.Drawing.Point(454, 168);
            this.dataGridView_emps.Name = "dataGridView_emps";
            this.dataGridView_emps.Size = new System.Drawing.Size(100, 86);
            this.dataGridView_emps.TabIndex = 17;
            this.dataGridView_emps.Visible = false;
            // 
            // takeover_iddoc
            // 
            this.takeover_iddoc.Location = new System.Drawing.Point(454, 22);
            this.takeover_iddoc.Name = "takeover_iddoc";
            this.takeover_iddoc.Size = new System.Drawing.Size(100, 20);
            this.takeover_iddoc.TabIndex = 18;
            this.takeover_iddoc.TextChanged += new System.EventHandler(this.takeover_iddoc_TextChanged);
            // 
            // takeover_idadr
            // 
            this.takeover_idadr.Location = new System.Drawing.Point(454, 98);
            this.takeover_idadr.Name = "takeover_idadr";
            this.takeover_idadr.Size = new System.Drawing.Size(100, 20);
            this.takeover_idadr.TabIndex = 19;
            // 
            // takeover_idexp
            // 
            this.takeover_idexp.Location = new System.Drawing.Point(454, 133);
            this.takeover_idexp.Name = "takeover_idexp";
            this.takeover_idexp.Size = new System.Drawing.Size(100, 20);
            this.takeover_idexp.TabIndex = 20;
            // 
            // takeover_idorg
            // 
            this.takeover_idorg.Location = new System.Drawing.Point(454, 65);
            this.takeover_idorg.Name = "takeover_idorg";
            this.takeover_idorg.Size = new System.Drawing.Size(100, 20);
            this.takeover_idorg.TabIndex = 21;
            this.takeover_idorg.TextChanged += new System.EventHandler(this.takeover_idorg_TextChanged);
            // 
            // dataGridView_adrs
            // 
            this.dataGridView_adrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_adrs.Location = new System.Drawing.Point(622, 106);
            this.dataGridView_adrs.Name = "dataGridView_adrs";
            this.dataGridView_adrs.Size = new System.Drawing.Size(375, 82);
            this.dataGridView_adrs.TabIndex = 23;
            this.dataGridView_adrs.Visible = false;
            // 
            // dataGridView_docs
            // 
            this.dataGridView_docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_docs.Location = new System.Drawing.Point(622, 18);
            this.dataGridView_docs.Name = "dataGridView_docs";
            this.dataGridView_docs.Size = new System.Drawing.Size(375, 82);
            this.dataGridView_docs.TabIndex = 22;
            this.dataGridView_docs.Visible = false;
            // 
            // FormNewPriemka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 325);
            this.Controls.Add(this.dataGridView_adrs);
            this.Controls.Add(this.dataGridView_docs);
            this.Controls.Add(this.takeover_idorg);
            this.Controls.Add(this.takeover_idexp);
            this.Controls.Add(this.takeover_idadr);
            this.Controls.Add(this.takeover_iddoc);
            this.Controls.Add(this.dataGridView_emps);
            this.Controls.Add(this.dataGridView_orgs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.takeover_prim);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.takeover_packages);
            this.Controls.Add(this.takeover_palets);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_emp);
            this.Controls.Add(this.textBox_org);
            this.Name = "FormNewPriemka";
            this.Text = "Новая приемка";
            this.Load += new System.EventHandler(this.FormPriemka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_emps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_adrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_docs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_org;
        private System.Windows.Forms.TextBox textBox_emp;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox takeover_palets;
        private System.Windows.Forms.TextBox takeover_packages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox takeover_prim;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView_orgs;
        private System.Windows.Forms.DataGridView dataGridView_emps;
        private System.Windows.Forms.TextBox takeover_iddoc;
        private System.Windows.Forms.TextBox takeover_idadr;
        private System.Windows.Forms.TextBox takeover_idexp;
        private System.Windows.Forms.TextBox takeover_idorg;
        private System.Windows.Forms.DataGridView dataGridView_adrs;
        private System.Windows.Forms.DataGridView dataGridView_docs;
    }
}