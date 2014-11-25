using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using XYS.MCW.Model;
using System.Runtime.InteropServices;
using Car.DBUtility;

namespace CarSln
{
    public partial class Record : Form
    {
        record recordModel = new record();
        static string connStr = new DbHelperMySQL().getConnStr();
        MySqlConnection conn = new MySqlConnection(connStr);

        #region 设置自动关闭Messagebox
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
#endregion

        public Record()
        {
            InitializeComponent();
           
        }

        private void Record_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“paleDataSet6.record”中。您可以根据需要移动或删除它。
               this.recordTableAdapter1.Fill(this.paleDataSet6.record);

                endTimePicker2.Value = System.DateTime.Now;
                startTimePicker1.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")); 

            if (dataGridView1.RowCount != 0)
            {
           
                int x = 5;
                int y = 0;
                string filepath = System.Environment.CurrentDirectory + "/../../../Resources/palepic/";

                try
                {
                    string photoname = dataGridView1.Rows[y].Cells[x].Value.ToString();
                    filepath += photoname;
                    pictureBox1.Image = Image.FromFile(filepath);
                }
                catch
                {
                    StartKiller();    //自动关闭提示框
                    MessageBox.Show("没有该图片！","错误");
                }
            }
        }

       

        private void pale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                if (pale_textbox.Text.Length - pale_textbox.SelectedText.Length < 6)
                {
                    pale_textbox.SelectedText = char.ToUpper(e.KeyChar).ToString();
                    e.Handled = true;
                }
            }
        }

        private void qur_button_Click(object sender, EventArgs e)
        {
            recordModel.Pale = sur_comboBox.Text + pale_textbox.Text;
            recordModel.Direction = direction_comboBox.Text;
            recordModel.Gate = gate_textBox.Text;
            recordModel.StartTime = startTimePicker1.Text;
            recordModel.EndTime = endTimePicker2.Text;
            recordModel.StartT = DateTime.Parse(recordModel.StartTime);
            recordModel.EndT = DateTime.Parse(recordModel.EndTime);
/////////////////        按时间查询
            if (pale_textbox.Text == "" && recordModel.Direction == "" && recordModel.Gate == "")
            {
                this.recordTableAdapter1.SelectByTim(this.paleDataSet6.record, recordModel.StartT, recordModel.EndT);
            }
////////////////         按车牌时间、车牌方向时间、车牌岗亭时间、车牌岗亭方向时间 查询

            if (pale_textbox.Text != "" && recordModel.Direction == "" && recordModel.Gate == "")
            {
                this.recordTableAdapter1.SelectByPal(this.paleDataSet6.record, recordModel.Pale, recordModel.StartT, recordModel.EndT);
            }
            if (pale_textbox.Text != "" && recordModel.Direction != "" && recordModel.Gate == "")
            {
                this.recordTableAdapter1.SelectByPalDir(this.paleDataSet6.record, recordModel.Direction, recordModel.Pale, recordModel.StartT, recordModel.EndT);
            }
            if (pale_textbox.Text != "" && recordModel.Direction == "" && recordModel.Gate != "")
            {
                recordModel.Gate = gate_textBox.Text + "号";
                this.recordTableAdapter1.SelectByPalGat(this.paleDataSet6.record, recordModel.Gate, recordModel.Pale, recordModel.StartT, recordModel.EndT);
            }
            if (pale_textbox.Text != "" && recordModel.Direction != "" && recordModel.Gate != "")
            {
                recordModel.Gate = gate_textBox.Text + "号";
                this.recordTableAdapter1.SelectByGatPalDir(this.paleDataSet6.record, recordModel.Gate, recordModel.Direction, recordModel.Pale, recordModel.StartT, recordModel.EndT);
            }

//////////////////      按方向时间、岗亭方向时间 查询

            if (pale_textbox.Text == "" && recordModel.Direction != "" && recordModel.Gate == "")
            {
                this.recordTableAdapter1.SelectByDir(this.paleDataSet6.record, recordModel.Direction, recordModel.StartT, recordModel.EndT);
            }
            if (pale_textbox.Text == "" && recordModel.Direction != "" && recordModel.Gate != "")
            {
                recordModel.Gate = gate_textBox.Text + "号";
                this.recordTableAdapter1.SelectByGatDir(this.paleDataSet6.record, recordModel.Gate, recordModel.Direction, recordModel.StartT, recordModel.EndT);
            }
////////////////////     按岗亭时间查询

            if (pale_textbox.Text == "" && recordModel.Direction == "" && recordModel.Gate != "")
            {
                recordModel.Gate = gate_textBox.Text + "号";
                this.recordTableAdapter1.SelectByGat(this.paleDataSet6.record, recordModel.Gate, recordModel.StartT, recordModel.EndT);
            }

/////////////////////
            if (dataGridView1.RowCount != 0)
            {
                int y = 0;
                string filepath = System.Environment.CurrentDirectory + "/../../../Resources/palepic/";

                try
                {
                    string photoname = dataGridView1.Rows[y].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                    filepath += photoname;
                    pictureBox1.Image = Image.FromFile(filepath);
                }
                catch
                {
                    StartKiller();    //自动关闭提示框
                    MessageBox.Show("没有该图片！", "错误");
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

       


        #region  自动关闭Messagebox

        private void StartKiller()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; //2秒启动
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((System.Windows.Forms.Timer)sender).Stop();
        }
        private void KillMessageBox()
        {
            //按照MessageBox的标题，找到MessageBox的窗口
            IntPtr ptr = FindWindow(null, "错误");
            if (ptr != IntPtr.Zero)
            {
                //找到则关闭MessageBox窗口
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }

        }

        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = 4;
            int y = e.RowIndex;
            bool flag = false;  //判断是否点击在表头
            string filepath = System.Environment.CurrentDirectory + "/../../../Resources/palepic/";
            //string photoname = dataGridView1.Rows[y].Cells[x].Value.ToString();
            string photoname = "";
            try
            {
                photoname = dataGridView1.Rows[y].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
            }
            catch { flag = true; };       //解决点击表头会报index越界错误
            filepath += photoname;
            if (!flag)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(filepath);
                }
                catch
                {
                    StartKiller();    //自动关闭提示框
                    MessageBox.Show("没有该图片！", "错误");
                }
            }
        }

        private void Record_VisibleChanged(object sender, EventArgs e)
        {
            this.recordTableAdapter1.Fill(this.paleDataSet6.record);
        }

      


       

        
    }
}
