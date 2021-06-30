namespace WAGOTemplate
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownDI = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDO = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAI = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAO = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownUC = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUC)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownDI
            // 
            this.numericUpDownDI.Location = new System.Drawing.Point(195, 119);
            this.numericUpDownDI.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDownDI.Name = "numericUpDownDI";
            this.numericUpDownDI.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownDI.TabIndex = 0;
            this.numericUpDownDI.Tag = "";
            this.numericUpDownDI.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // numericUpDownDO
            // 
            this.numericUpDownDO.Location = new System.Drawing.Point(195, 169);
            this.numericUpDownDO.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDownDO.Name = "numericUpDownDO";
            this.numericUpDownDO.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownDO.TabIndex = 0;
            this.numericUpDownDO.Tag = "";
            this.numericUpDownDO.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // numericUpDownAI
            // 
            this.numericUpDownAI.Location = new System.Drawing.Point(195, 218);
            this.numericUpDownAI.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numericUpDownAI.Name = "numericUpDownAI";
            this.numericUpDownAI.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownAI.TabIndex = 0;
            this.numericUpDownAI.Tag = "";
            this.numericUpDownAI.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // numericUpDownAO
            // 
            this.numericUpDownAO.Location = new System.Drawing.Point(195, 266);
            this.numericUpDownAO.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numericUpDownAO.Name = "numericUpDownAO";
            this.numericUpDownAO.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownAO.TabIndex = 0;
            this.numericUpDownAO.Tag = "";
            this.numericUpDownAO.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "DI Channels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "DO Channels";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "AI Channels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "AO Channels";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 366);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(223, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(69, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create Template...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // numericUpDownUC
            // 
            this.numericUpDownUC.Location = new System.Drawing.Point(195, 313);
            this.numericUpDownUC.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownUC.Name = "numericUpDownUC";
            this.numericUpDownUC.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownUC.TabIndex = 0;
            this.numericUpDownUC.Tag = "";
            this.numericUpDownUC.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "UC Channels";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "WAGO"});
            this.comboBox1.Location = new System.Drawing.Point(149, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "EtherNet/IP(EIP)",
            "CANOPen"});
            this.comboBox2.Location = new System.Drawing.Point(149, 71);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(111, 20);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Company";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Protocol";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 472);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownUC);
            this.Controls.Add(this.numericUpDownAO);
            this.Controls.Add(this.numericUpDownAI);
            this.Controls.Add(this.numericUpDownDO);
            this.Controls.Add(this.numericUpDownDI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "WAGOCANOpenTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownDI;
        private System.Windows.Forms.NumericUpDown numericUpDownDO;
        private System.Windows.Forms.NumericUpDown numericUpDownAI;
        private System.Windows.Forms.NumericUpDown numericUpDownAO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownUC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

