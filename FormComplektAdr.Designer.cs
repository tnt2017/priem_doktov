namespace test111
{
    partial class FormComplektAdr
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
            this.myDataGridView1 = new test111.MyDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrip = new System.Windows.Forms.TextBox();
            this.cadr = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_places = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_org = new System.Windows.Forms.TextBox();
            this.textBox_route = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_idemp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Location = new System.Drawing.Point(12, 73);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.Size = new System.Drawing.Size(825, 419);
            this.myDataGridView1.TabIndex = 0;
            this.myDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellContentClick);
            this.myDataGridView1.DoubleClick += new System.EventHandler(this.myDataGridView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Прочитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrip
            // 
            this.ctrip.Location = new System.Drawing.Point(451, 22);
            this.ctrip.Name = "ctrip";
            this.ctrip.Size = new System.Drawing.Size(83, 20);
            this.ctrip.TabIndex = 2;
            this.ctrip.TextChanged += new System.EventHandler(this.ctrip_TextChanged);
            // 
            // cadr
            // 
            this.cadr.Location = new System.Drawing.Point(540, 21);
            this.cadr.Name = "cadr";
            this.cadr.Size = new System.Drawing.Size(68, 20);
            this.cadr.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(672, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сохранить (в офис)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ctrip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "cadr";
            // 
            // textbox_places
            // 
            this.textbox_places.Location = new System.Drawing.Point(617, 21);
            this.textbox_places.Name = "textbox_places";
            this.textbox_places.Size = new System.Drawing.Size(50, 20);
            this.textbox_places.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Мест";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Клиент";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Маршрут";
            // 
            // textBox_org
            // 
            this.textBox_org.Location = new System.Drawing.Point(195, 23);
            this.textBox_org.Name = "textBox_org";
            this.textBox_org.Size = new System.Drawing.Size(250, 20);
            this.textBox_org.TabIndex = 10;
            // 
            // textBox_route
            // 
            this.textBox_route.Location = new System.Drawing.Point(104, 22);
            this.textBox_route.Name = "textBox_route";
            this.textBox_route.Size = new System.Drawing.Size(85, 20);
            this.textBox_route.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(672, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Сохранить (на складе)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_idemp
            // 
            this.textBox_idemp.Location = new System.Drawing.Point(451, 49);
            this.textBox_idemp.Name = "textBox_idemp";
            this.textBox_idemp.Size = new System.Drawing.Size(83, 20);
            this.textBox_idemp.TabIndex = 14;
            this.textBox_idemp.Text = "1900161";
            // 
            // FormComplektAdr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 504);
            this.Controls.Add(this.textBox_idemp);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_org);
            this.Controls.Add(this.textBox_route);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_places);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cadr);
            this.Controls.Add(this.ctrip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myDataGridView1);
            this.Name = "FormComplektAdr";
            this.Text = "Комплектовка адреса";
            this.Load += new System.EventHandler(this.FormComplektAdr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView myDataGridView1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox ctrip;
        public System.Windows.Forms.TextBox cadr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_places;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox_org;
        public System.Windows.Forms.TextBox textBox_route;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_idemp;
    }
}