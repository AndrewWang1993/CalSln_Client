using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using XYS.MCW.Model;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace CarSln
{
     public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

         static  monitor mi = new monitor();
        Record rc =new Record();
        paleSubscribe ps=new paleSubscribe( mi);

        int SH = Screen.PrimaryScreen.Bounds.Height;   //竖向分辨率
        int SW = Screen.PrimaryScreen.Bounds.Width;  //横向分辨率

        public MainForm()
        {
            InitializeComponent();
        }

        //整个窗口最小化，任务栏有图标显示
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        //整个窗口隐藏，任务栏没有图标，隐藏在右下角的托盘
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            iconMain.Visible = true;
            this.ShowInTaskbar = false;
        }

        //拖动panel就类似于拖动标题栏一样，能让整个窗口移动
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #region 托盘
        private void TrayIconClose()
        {
            iconMain.Dispose();
        }
        private void TrayIconShow()
        {
            iconMain.Visible = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }
        private void TrayIconHide()
        {
            iconMain.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region 托盘菜单
        private void tmExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmShow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                TrayIconHide();
        }
        #endregion

       



        private void myOpaqueLayer3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.ContainsKey("Record"))
            {
            panel3.Controls.Clear();
            rc.FormBorderStyle = FormBorderStyle.None; // 无边框
            rc.TopLevel = false; // 不是最顶层窗体
            panel3.Controls.Add(rc);  // 添加到 Panel中
            rc.Show();     // 显示
            label8.Text = "出入记录";
        }
        }

        private void myOpaqueLayer4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            mi.FormBorderStyle = FormBorderStyle.None; // 无边框
            mi.TopLevel = false; // 不是最顶层窗体
            panel3.Controls.Add(mi);  // 添加到 Panel中
            mi.Show();     // 显示
            label8.Text = "出入监视";
            rc.Hide();
         
        }

        private void myOpaqueLayer5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.ContainsKey("paleSubscribe"))
            {
                record r = new record();
                panel3.Controls.Clear();
                ps.FormBorderStyle = FormBorderStyle.None; // 无边框
                ps.TopLevel = false; // 不是最顶层窗体
                if (r.gettmppale().Length > 1)
                {
                    ps.sur_comboBox.Text = r.gettmppale().Substring(0, 1);
                    ps.pale_textbox.Text = r.gettmppale().Substring(1, 6);
                }
                else
                {
                    setPSclear();
                }
                ps.name_textBox.Text = "";
                panel3.Controls.Add(ps);  // 添加到 Panel中
                ps.Show();     // 显示
                ps.car_paleTableAdapter1.Fill(ps.paleDataSet3.car_pale);  //刷新数据
                label8.Text = "车牌预约";
                rc.Hide();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mi.FormBorderStyle = FormBorderStyle.None; // 无边框
            mi.TopLevel = false; // 不是最顶层窗体
            panel3.Controls.Add(mi);  // 添加到 Panel中
            mi.Show();     // 显示
            label8.Text = "出入监视";
            rc.Hide();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                Point pClose = new Point(panel1.Width + panel1.Location.X - 40, panel1.Location.Y + 10);
                Point pMax = new Point(panel1.Width + panel1.Location.X - 80, panel1.Location.Y + 10);
                Point pMin = new Point(panel1.Width + panel1.Location.X - 120, panel1.Location.Y + 10);
                Point pPicbox1 = new Point(panel1.Width + panel1.Location.X - 230, panel1.Location.Y + 50);
                Point pLabel2 = new Point(panel2.Width-400 , 8);
                btnMin.Location = pMin;
                btnMax.Location = pMax;
                btnClose.Location = pClose;
                pictureBox1.Location = pPicbox1;
                label2.Location = pLabel2;

                rc.dataGridView1.Height = 750;

                ps.dataGridView1.Height = 750;

                mi.groupBox1.Height = 850;
                mi.listView2.Height = 820;
                mi.groupBox1.Width =SW-mi.groupBox1.Location.X-300;
                mi.listView2.Width = mi.groupBox1.Width-20;


                mi.groupBox2.Height = SH-mi.groupBox2.Location.Y-200;
                mi.listView1.Height = mi.groupBox2.Height-50;
            }
            else {
                this.WindowState = FormWindowState.Normal;
                Point pClose = new Point(panel1.Width + panel1.Location.X - 40, panel1.Location.Y + 10);
                Point pMax = new Point(panel1.Width + panel1.Location.X - 80, panel1.Location.Y + 10);
                Point pMin = new Point(panel1.Width + panel1.Location.X - 120, panel1.Location.Y + 10);
                Point pPicbox1 = new Point(panel1.Width + panel1.Location.X - 230, panel1.Location.Y + 50);
                Point pLabel2 = new Point(panel2.Width-300 , 8);
                btnMin.Location = pMin;
                btnMax.Location = pMax;
                btnClose.Location = pClose;
                pictureBox1.Location = pPicbox1;
                label2.Location = pLabel2;               
                rc.dataGridView1.Height = 452;
                ps.dataGridView1.Height = 452;
                mi.groupBox1.Height = 549;
                mi.listView2.Height = 511;
                mi.groupBox1.Width = 860;
                mi.listView2.Width = 847;
                mi.groupBox2.Height = 147;
                mi.listView1.Height = 105;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "现在时间："+DateTime.Now.ToString();
        }

        private void setPSclear()
        {
            ps.sur_comboBox.Text = "";
            ps.pale_textbox.Text = "";
            ps.name_textBox.Text = "";
        }
     
    }
}
