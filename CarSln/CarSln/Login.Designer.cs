namespace CarSln
{
    partial class Login
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ext_button = new System.Windows.Forms.Button();
            this.log_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.una_textBox = new System.Windows.Forms.TextBox();
            this.pwd_textBox = new System.Windows.Forms.TextBox();
            this.conte_button = new System.Windows.Forms.Button();
            this.statue_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ext_button
            // 
            this.ext_button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ext_button.Location = new System.Drawing.Point(6, 6);
            this.ext_button.Name = "ext_button";
            this.ext_button.Size = new System.Drawing.Size(75, 34);
            this.ext_button.TabIndex = 0;
            this.ext_button.Text = "退出";
            this.ext_button.UseVisualStyleBackColor = true;
            this.ext_button.Click += new System.EventHandler(this.ext_button_Click);
            // 
            // log_button
            // 
            this.log_button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.log_button.Location = new System.Drawing.Point(90, 6);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(75, 34);
            this.log_button.TabIndex = 1;
            this.log_button.Text = "登录";
            this.log_button.UseVisualStyleBackColor = true;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // una_textBox
            // 
            this.una_textBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.una_textBox.Location = new System.Drawing.Point(103, 29);
            this.una_textBox.Name = "una_textBox";
            this.una_textBox.Size = new System.Drawing.Size(185, 29);
            this.una_textBox.TabIndex = 4;
            // 
            // pwd_textBox
            // 
            this.pwd_textBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwd_textBox.Location = new System.Drawing.Point(103, 83);
            this.pwd_textBox.Name = "pwd_textBox";
            this.pwd_textBox.PasswordChar = '*';
            this.pwd_textBox.Size = new System.Drawing.Size(185, 29);
            this.pwd_textBox.TabIndex = 5;
            // 
            // conte_button
            // 
            this.conte_button.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conte_button.Location = new System.Drawing.Point(213, 129);
            this.conte_button.Name = "conte_button";
            this.conte_button.Size = new System.Drawing.Size(75, 28);
            this.conte_button.TabIndex = 6;
            this.conte_button.Text = "连接测试";
            this.conte_button.UseVisualStyleBackColor = true;
            this.conte_button.Click += new System.EventHandler(this.conte_button_Click);
            // 
            // statue_label
            // 
            this.statue_label.AutoSize = true;
            this.statue_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statue_label.Location = new System.Drawing.Point(104, 132);
            this.statue_label.Name = "statue_label";
            this.statue_label.Size = new System.Drawing.Size(0, 21);
            this.statue_label.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.statue_label);
            this.panel1.Controls.Add(this.conte_button);
            this.panel1.Controls.Add(this.pwd_textBox);
            this.panel1.Controls.Add(this.una_textBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(381, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 169);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.log_button);
            this.panel2.Controls.Add(this.ext_button);
            this.panel2.Location = new System.Drawing.Point(504, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 42);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "当前版本V1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(532, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "版权所有 2014 深圳市******有限公司";
            // 
            // Login
            // 
            this.AcceptButton = this.log_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(793, 356);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "来访车辆预约";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ext_button;
        private System.Windows.Forms.Button log_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox una_textBox;
        private System.Windows.Forms.TextBox pwd_textBox;
        private System.Windows.Forms.Button conte_button;
        private System.Windows.Forms.Label statue_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

