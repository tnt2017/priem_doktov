namespace test111
{
    partial class FormKassa
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_print_check = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.кредиткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.continuePrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSubTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysAdminCancelCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportWithCleaningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportWithoutCleaningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fNFindDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_flagres = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_index = new System.Windows.Forms.TextBox();
            this.checkBox_timer = new System.Windows.Forms.CheckBox();
            this.checkBox_showall = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_auto_z_otchet = new System.Windows.Forms.CheckBox();
            this.checkBox_return = new System.Windows.Forms.CheckBox();
            this.checkBox_nocontragent = new System.Windows.Forms.CheckBox();
            this.myDataGridView1 = new test111.MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID платежа";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ТД Трианон",
            "Меркадо"});
            this.comboBox1.Location = new System.Drawing.Point(131, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 23;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(354, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker2.TabIndex = 22;
            this.dateTimePicker2.Value = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(221, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(482, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "autoclose";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Список чеков";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(636, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "200069681";
            // 
            // button_print_check
            // 
            this.button_print_check.Location = new System.Drawing.Point(716, 3);
            this.button_print_check.Name = "button_print_check";
            this.button_print_check.Size = new System.Drawing.Size(119, 23);
            this.button_print_check.TabIndex = 17;
            this.button_print_check.Text = "Напечатать чек";
            this.button_print_check.UseVisualStyleBackColor = true;
            this.button_print_check.Click += new System.EventHandler(this.button_print_check_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(348, 505);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 25;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 367);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1319, 167);
            this.dataGridView2.TabIndex = 26;
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(590, 505);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(735, 20);
            this.tbResult.TabIndex = 27;
            this.tbResult.TextChanged += new System.EventHandler(this.tbResult_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кредиткаToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // кредиткаToolStripMenuItem
            // 
            this.кредиткаToolStripMenuItem.Name = "кредиткаToolStripMenuItem";
            this.кредиткаToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.кредиткаToolStripMenuItem.Text = "Кредитка";
            this.кредиткаToolStripMenuItem.Click += new System.EventHandler(this.кредиткаToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(841, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Принудительно поставить флаг";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continuePrintToolStripMenuItem,
            this.closeCheckToolStripMenuItem,
            this.cancelCheckToolStripMenuItem,
            this.checkSubTotalToolStripMenuItem,
            this.sysAdminCancelCheckToolStripMenuItem,
            this.printReportWithCleaningToolStripMenuItem,
            this.printReportWithoutCleaningToolStripMenuItem,
            this.fNFindDocumentToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(205, 180);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // continuePrintToolStripMenuItem
            // 
            this.continuePrintToolStripMenuItem.Name = "continuePrintToolStripMenuItem";
            this.continuePrintToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.continuePrintToolStripMenuItem.Text = "ContinuePrint";
            this.continuePrintToolStripMenuItem.Click += new System.EventHandler(this.continuePrintToolStripMenuItem_Click);
            // 
            // closeCheckToolStripMenuItem
            // 
            this.closeCheckToolStripMenuItem.Name = "closeCheckToolStripMenuItem";
            this.closeCheckToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.closeCheckToolStripMenuItem.Text = "CloseCheck";
            this.closeCheckToolStripMenuItem.Click += new System.EventHandler(this.closeCheckToolStripMenuItem_Click);
            // 
            // cancelCheckToolStripMenuItem
            // 
            this.cancelCheckToolStripMenuItem.Name = "cancelCheckToolStripMenuItem";
            this.cancelCheckToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.cancelCheckToolStripMenuItem.Text = "CancelCheck";
            this.cancelCheckToolStripMenuItem.Click += new System.EventHandler(this.cancelCheckToolStripMenuItem_Click);
            // 
            // checkSubTotalToolStripMenuItem
            // 
            this.checkSubTotalToolStripMenuItem.Name = "checkSubTotalToolStripMenuItem";
            this.checkSubTotalToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.checkSubTotalToolStripMenuItem.Text = "CheckSubTotal";
            this.checkSubTotalToolStripMenuItem.Click += new System.EventHandler(this.checkSubTotalToolStripMenuItem_Click);
            // 
            // sysAdminCancelCheckToolStripMenuItem
            // 
            this.sysAdminCancelCheckToolStripMenuItem.Name = "sysAdminCancelCheckToolStripMenuItem";
            this.sysAdminCancelCheckToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sysAdminCancelCheckToolStripMenuItem.Text = "SysAdminCancelCheck";
            this.sysAdminCancelCheckToolStripMenuItem.Click += new System.EventHandler(this.sysAdminCancelCheckToolStripMenuItem_Click);
            // 
            // printReportWithCleaningToolStripMenuItem
            // 
            this.printReportWithCleaningToolStripMenuItem.Name = "printReportWithCleaningToolStripMenuItem";
            this.printReportWithCleaningToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.printReportWithCleaningToolStripMenuItem.Text = "Снять отчет с гашением";
            this.printReportWithCleaningToolStripMenuItem.Click += new System.EventHandler(this.printReportWithCleaningToolStripMenuItem_Click);
            // 
            // printReportWithoutCleaningToolStripMenuItem
            // 
            this.printReportWithoutCleaningToolStripMenuItem.Name = "printReportWithoutCleaningToolStripMenuItem";
            this.printReportWithoutCleaningToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.printReportWithoutCleaningToolStripMenuItem.Text = "Снять отчет без гашения";
            this.printReportWithoutCleaningToolStripMenuItem.Click += new System.EventHandler(this.printReportWithoutCleaningToolStripMenuItem_Click);
            // 
            // fNFindDocumentToolStripMenuItem
            // 
            this.fNFindDocumentToolStripMenuItem.Name = "fNFindDocumentToolStripMenuItem";
            this.fNFindDocumentToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.fNFindDocumentToolStripMenuItem.Text = "FNFindDocument";
            this.fNFindDocumentToolStripMenuItem.Click += new System.EventHandler(this.fNFindDocumentToolStripMenuItem_Click);
            // 
            // textBox_flagres
            // 
            this.textBox_flagres.Location = new System.Drawing.Point(1032, 6);
            this.textBox_flagres.Name = "textBox_flagres";
            this.textBox_flagres.Size = new System.Drawing.Size(105, 20);
            this.textBox_flagres.TabIndex = 30;
            // 
            // timer1
            // 
            this.timer1.Interval = 25000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_index
            // 
            this.textBox_index.Location = new System.Drawing.Point(1143, 5);
            this.textBox_index.Name = "textBox_index";
            this.textBox_index.ReadOnly = true;
            this.textBox_index.Size = new System.Drawing.Size(36, 20);
            this.textBox_index.TabIndex = 31;
            this.textBox_index.Text = "0";
            // 
            // checkBox_timer
            // 
            this.checkBox_timer.AutoSize = true;
            this.checkBox_timer.Location = new System.Drawing.Point(1260, 6);
            this.checkBox_timer.Name = "checkBox_timer";
            this.checkBox_timer.Size = new System.Drawing.Size(65, 17);
            this.checkBox_timer.TabIndex = 32;
            this.checkBox_timer.Text = "Таймер";
            this.checkBox_timer.UseVisualStyleBackColor = true;
            this.checkBox_timer.CheckedChanged += new System.EventHandler(this.checkBox_timer_CheckedChanged);
            // 
            // checkBox_showall
            // 
            this.checkBox_showall.AutoSize = true;
            this.checkBox_showall.Location = new System.Drawing.Point(12, 32);
            this.checkBox_showall.Name = "checkBox_showall";
            this.checkBox_showall.Size = new System.Drawing.Size(96, 17);
            this.checkBox_showall.TabIndex = 33;
            this.checkBox_showall.Text = "Показать все";
            this.checkBox_showall.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1234, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 34;
            this.textBox2.Text = "25";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1185, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Interval";
            // 
            // checkBox_auto_z_otchet
            // 
            this.checkBox_auto_z_otchet.AutoSize = true;
            this.checkBox_auto_z_otchet.Checked = true;
            this.checkBox_auto_z_otchet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_auto_z_otchet.Location = new System.Drawing.Point(131, 32);
            this.checkBox_auto_z_otchet.Name = "checkBox_auto_z_otchet";
            this.checkBox_auto_z_otchet.Size = new System.Drawing.Size(176, 17);
            this.checkBox_auto_z_otchet.TabIndex = 36;
            this.checkBox_auto_z_otchet.Text = "Автоснятие Z-отчета (в 17:30)";
            this.checkBox_auto_z_otchet.UseVisualStyleBackColor = true;
            // 
            // checkBox_return
            // 
            this.checkBox_return.AutoSize = true;
            this.checkBox_return.Location = new System.Drawing.Point(716, 29);
            this.checkBox_return.Name = "checkBox_return";
            this.checkBox_return.Size = new System.Drawing.Size(105, 17);
            this.checkBox_return.TabIndex = 37;
            this.checkBox_return.Text = "Чек на возврат";
            this.checkBox_return.UseVisualStyleBackColor = true;
            // 
            // checkBox_nocontragent
            // 
            this.checkBox_nocontragent.AutoSize = true;
            this.checkBox_nocontragent.Location = new System.Drawing.Point(841, 33);
            this.checkBox_nocontragent.Name = "checkBox_nocontragent";
            this.checkBox_nocontragent.Size = new System.Drawing.Size(190, 17);
            this.checkBox_nocontragent.TabIndex = 38;
            this.checkBox_nocontragent.Text = "Не печатать email и контрагента";
            this.checkBox_nocontragent.UseVisualStyleBackColor = true;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.AllowUserToDeleteRows = false;
            this.myDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.myDataGridView1.Location = new System.Drawing.Point(6, 32);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.Size = new System.Drawing.Size(1319, 314);
            this.myDataGridView1.TabIndex = 0;
            this.myDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellContentClick);
            this.myDataGridView1.Click += new System.EventHandler(this.myDataGridView1_Click);
            this.myDataGridView1.DoubleClick += new System.EventHandler(this.myDataGridView1_DoubleClick);
            // 
            // FormKassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 546);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.checkBox_nocontragent);
            this.Controls.Add(this.checkBox_return);
            this.Controls.Add(this.checkBox_auto_z_otchet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox_showall);
            this.Controls.Add(this.checkBox_timer);
            this.Controls.Add(this.textBox_index);
            this.Controls.Add(this.textBox_flagres);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button_print_check);
            this.Controls.Add(this.myDataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FormKassa";
            this.Text = "Кассовые операции";
            this.Load += new System.EventHandler(this.FormKassa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView myDataGridView1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_print_check;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem кредиткаToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem continuePrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkSubTotalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sysAdminCancelCheckToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_flagres;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_index;
        public System.Windows.Forms.CheckBox checkBox_timer;
        private System.Windows.Forms.CheckBox checkBox_showall;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem printReportWithCleaningToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_auto_z_otchet;
        private System.Windows.Forms.CheckBox checkBox_return;
        private System.Windows.Forms.ToolStripMenuItem printReportWithoutCleaningToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_nocontragent;
        private System.Windows.Forms.ToolStripMenuItem fNFindDocumentToolStripMenuItem;
    }
}