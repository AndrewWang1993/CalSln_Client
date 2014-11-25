namespace CarSln
{
    partial class Record
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.endTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gate_textBox = new System.Windows.Forms.TextBox();
            this.direction_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sur_comboBox = new System.Windows.Forms.ComboBox();
            this.qur_button = new System.Windows.Forms.Button();
            this.pale_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.paleDataSet6 = new CarSln.paleDataSet6();
            this.recordTableAdapter1 = new CarSln.paleDataSet6TableAdapters.recordTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paleDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.endTimePicker2);
            this.panel1.Controls.Add(this.startTimePicker1);
            this.panel1.Controls.Add(this.gate_textBox);
            this.panel1.Controls.Add(this.direction_comboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sur_comboBox);
            this.panel1.Controls.Add(this.qur_button);
            this.panel1.Controls.Add(this.pale_textbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 100);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(943, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "图片";
            // 
            // endTimePicker2
            // 
            this.endTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker2.Location = new System.Drawing.Point(328, 62);
            this.endTimePicker2.Name = "endTimePicker2";
            this.endTimePicker2.Size = new System.Drawing.Size(196, 21);
            this.endTimePicker2.TabIndex = 41;
            this.endTimePicker2.Value = new System.DateTime(2014, 8, 18, 0, 0, 0, 0);
            // 
            // startTimePicker1
            // 
            this.startTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker1.Location = new System.Drawing.Point(74, 62);
            this.startTimePicker1.MinDate = new System.DateTime(1753, 7, 19, 0, 0, 0, 0);
            this.startTimePicker1.Name = "startTimePicker1";
            this.startTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startTimePicker1.Size = new System.Drawing.Size(181, 21);
            this.startTimePicker1.TabIndex = 40;
            this.startTimePicker1.Value = new System.DateTime(2014, 8, 18, 0, 0, 0, 0);
            // 
            // gate_textBox
            // 
            this.gate_textBox.Location = new System.Drawing.Point(328, 24);
            this.gate_textBox.Name = "gate_textBox";
            this.gate_textBox.Size = new System.Drawing.Size(48, 21);
            this.gate_textBox.TabIndex = 39;
            // 
            // direction_comboBox
            // 
            this.direction_comboBox.FormattingEnabled = true;
            this.direction_comboBox.Items.AddRange(new object[] {
            "",
            "出口1号车道",
            "出口2号车道",
            "入口1号车道",
            "入口2号车道"});
            this.direction_comboBox.Location = new System.Drawing.Point(417, 24);
            this.direction_comboBox.Name = "direction_comboBox";
            this.direction_comboBox.Size = new System.Drawing.Size(107, 20);
            this.direction_comboBox.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "岗亭号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "开始时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "车道";
            // 
            // sur_comboBox
            // 
            this.sur_comboBox.FormattingEnabled = true;
            this.sur_comboBox.Items.AddRange(new object[] {
            "粤",
            "赣",
            "京",
            "津",
            "沪",
            "渝",
            "蒙",
            "新",
            "藏",
            "宁",
            "桂",
            "港",
            "澳",
            "黑",
            "警",
            "吉",
            "辽",
            "晋",
            "冀",
            "青",
            "鲁",
            "豫",
            "苏",
            "皖",
            "浙",
            "闽",
            "湘",
            "鄂",
            "琼",
            "甘",
            "陕",
            "黔",
            "滇",
            "川",
            "使",
            "军"});
            this.sur_comboBox.Location = new System.Drawing.Point(75, 24);
            this.sur_comboBox.Name = "sur_comboBox";
            this.sur_comboBox.Size = new System.Drawing.Size(34, 20);
            this.sur_comboBox.TabIndex = 33;
            this.sur_comboBox.Text = "粤";
            // 
            // qur_button
            // 
            this.qur_button.Location = new System.Drawing.Point(555, 60);
            this.qur_button.Name = "qur_button";
            this.qur_button.Size = new System.Drawing.Size(97, 24);
            this.qur_button.TabIndex = 32;
            this.qur_button.Text = "查询";
            this.qur_button.UseVisualStyleBackColor = true;
            this.qur_button.Click += new System.EventHandler(this.qur_button_Click);
            // 
            // pale_textbox
            // 
            this.pale_textbox.Location = new System.Drawing.Point(115, 24);
            this.pale_textbox.MaxLength = 6;
            this.pale_textbox.Name = "pale_textbox";
            this.pale_textbox.Size = new System.Drawing.Size(140, 21);
            this.pale_textbox.TabIndex = 31;
            this.pale_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pale_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "车牌";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 444);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(801, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 452);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.regtimeDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView1.DataSource = this.recordBindingSource1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(17, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(778, 452);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "pale";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "车牌号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "gate";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "岗亭号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "direction";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "车道";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // regtimeDataGridViewTextBoxColumn
            // 
            this.regtimeDataGridViewTextBoxColumn.DataPropertyName = "regtime";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.regtimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.regtimeDataGridViewTextBoxColumn.HeaderText = "预约时间";
            this.regtimeDataGridViewTextBoxColumn.Name = "regtimeDataGridViewTextBoxColumn";
            this.regtimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.regtimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "time";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "出入时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "pic";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "截图路径";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 230;
            // 
            // recordBindingSource1
            // 
            this.recordBindingSource1.DataMember = "record";
            this.recordBindingSource1.DataSource = this.paleDataSet6;
            // 
            // paleDataSet6
            // 
            this.paleDataSet6.DataSetName = "paleDataSet6";
            this.paleDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recordTableAdapter1
            // 
            this.recordTableAdapter1.ClearBeforeFill = true;
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 862);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Record";
            this.Text = "Record";
            this.Load += new System.EventHandler(this.Record_Load);
            this.VisibleChanged += new System.EventHandler(this.Record_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paleDataSet6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox sur_comboBox;
        private System.Windows.Forms.Button qur_button;
        private System.Windows.Forms.TextBox pale_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker startTimePicker1;
        private System.Windows.Forms.TextBox gate_textBox;
        private System.Windows.Forms.ComboBox direction_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn paleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn picDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private paleDataSet6 paleDataSet6;
        private System.Windows.Forms.BindingSource recordBindingSource1;
        private paleDataSet6TableAdapters.recordTableAdapter recordTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn regtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}