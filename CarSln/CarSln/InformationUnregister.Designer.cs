namespace CarSln
{
    partial class InformationUnregister
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
            this.sur_comboBox = new System.Windows.Forms.ComboBox();
            this.del_button = new System.Windows.Forms.Button();
            this.pale_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sur_comboBox);
            this.panel1.Controls.Add(this.del_button);
            this.panel1.Controls.Add(this.pale_textbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 68);
            this.panel1.TabIndex = 1;
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
            this.sur_comboBox.Location = new System.Drawing.Point(94, 28);
            this.sur_comboBox.Name = "sur_comboBox";
            this.sur_comboBox.Size = new System.Drawing.Size(34, 20);
            this.sur_comboBox.TabIndex = 33;
            this.sur_comboBox.Text = "粤";
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(293, 25);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(97, 24);
            this.del_button.TabIndex = 32;
            this.del_button.Text = "删除";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // pale_textbox
            // 
            this.pale_textbox.Location = new System.Drawing.Point(134, 28);
            this.pale_textbox.MaxLength = 6;
            this.pale_textbox.Name = "pale_textbox";
            this.pale_textbox.Size = new System.Drawing.Size(140, 21);
            this.pale_textbox.TabIndex = 31;
            this.pale_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pale_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "车牌";
            // 
            // InformationUnregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 342);
            this.Controls.Add(this.panel1);
            this.Name = "InformationUnregister";
            this.Text = "InformationUnregister";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox sur_comboBox;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.TextBox pale_textbox;
        private System.Windows.Forms.Label label1;
    }
}