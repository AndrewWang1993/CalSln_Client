namespace CarSln
{
    partial class InformationRegister
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sur_comboBox = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.pale_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.room_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buld_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unit_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.coum_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.name_textBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.sur_comboBox);
            this.panel1.Controls.Add(this.save_button);
            this.panel1.Controls.Add(this.pale_textbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.room_textBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buld_textBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.unit_textBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.coum_textBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 100);
            this.panel1.TabIndex = 0;
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(62, 62);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(181, 21);
            this.name_textBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "姓名";
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
            "使"});
            this.sur_comboBox.Location = new System.Drawing.Point(303, 61);
            this.sur_comboBox.Name = "sur_comboBox";
            this.sur_comboBox.Size = new System.Drawing.Size(34, 20);
            this.sur_comboBox.TabIndex = 6;
            this.sur_comboBox.Text = "粤";
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(502, 58);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(97, 24);
            this.save_button.TabIndex = 8;
            this.save_button.Text = "保存";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // pale_textbox
            // 
            this.pale_textbox.Location = new System.Drawing.Point(343, 61);
            this.pale_textbox.MaxLength = 6;
            this.pale_textbox.Name = "pale_textbox";
            this.pale_textbox.Size = new System.Drawing.Size(140, 21);
            this.pale_textbox.TabIndex = 7;
            this.pale_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pale_Keypress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "车牌";
            // 
            // room_textBox
            // 
            this.room_textBox.Location = new System.Drawing.Point(629, 18);
            this.room_textBox.MaxLength = 100;
            this.room_textBox.Name = "room_textBox";
            this.room_textBox.Size = new System.Drawing.Size(99, 21);
            this.room_textBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "房号";
            // 
            // buld_textBox
            // 
            this.buld_textBox.Location = new System.Drawing.Point(302, 18);
            this.buld_textBox.MaxLength = 100;
            this.buld_textBox.Name = "buld_textBox";
            this.buld_textBox.Size = new System.Drawing.Size(120, 21);
            this.buld_textBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "楼栋";
            // 
            // unit_textBox
            // 
            this.unit_textBox.Location = new System.Drawing.Point(476, 18);
            this.unit_textBox.MaxLength = 100;
            this.unit_textBox.Name = "unit_textBox";
            this.unit_textBox.Size = new System.Drawing.Size(99, 21);
            this.unit_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "单元";
            // 
            // coum_textBox
            // 
            this.coum_textBox.Location = new System.Drawing.Point(60, 18);
            this.coum_textBox.MaxLength = 100;
            this.coum_textBox.Name = "coum_textBox";
            this.coum_textBox.Size = new System.Drawing.Size(181, 21);
            this.coum_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "社区";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(850, 499);
            this.dataGridView1.TabIndex = 1;
            // 
            // InformationRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 599);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "InformationRegister";
            this.Text = "InformationRegister";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox pale_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox room_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox buld_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox unit_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox coum_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sur_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.DataGridView dataGridView1;


    }
}