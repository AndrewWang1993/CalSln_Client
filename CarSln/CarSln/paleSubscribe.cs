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
using XYS.MCW.Model;
using XYS.MCW.Common;
using System.Net.Sockets;
using Advantech.Adam;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Car.DBUtility;

namespace CarSln
{


    public partial class paleSubscribe : Form
    {
        //ADAM控制器相关变量初始化
        private bool m_bStart;
        private AdamSocket adamModbus;
        private string m_szIP;
        private int m_iPort;
        private int m_iDoTotal, m_iDiTotal;
        string flag = "false";

        paleInfo paleInfoModel = new paleInfo();
        static string connStr = new DbHelperMySQL().getConnStr();
        MySqlConnection conn = new MySqlConnection(connStr);
        monitor mi = null;
        LogManager log = new LogManager();
        public paleSubscribe(monitor mi)
        {
            this.mi = mi;
            InitializeComponent();
            initControl();     //初始化开门控制器相关变量
        }

        private void paleSearch_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“paleDataSet3.car_pale”中。您可以根据需要移动或删除它。
            this.car_paleTableAdapter1.Fill(this.paleDataSet3.car_pale);

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

        private void button1_Click(object sender, EventArgs e)
        {
            paleInfoModel.Pale = sur_comboBox.Text + pale_textbox.Text;
            if (pale_textbox.Text == "")
            {
                this.car_paleTableAdapter1.Fill(this.paleDataSet3.car_pale);
            }
            else
            {
                this.car_paleTableAdapter1.FillByPale(this.paleDataSet3.car_pale, paleInfoModel.Pale);
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            paleInfoModel.Community = coum_textBox.Text.Trim();
            paleInfoModel.Building = buld_textBox.Text.Trim();
            paleInfoModel.Unit = unit_textBox.Text.Trim();
            paleInfoModel.Room = room_textBox.Text.Trim();
            paleInfoModel.Name = name_textBox.Text.Trim();
            paleInfoModel.Pale = sur_comboBox.Text + pale_textbox.Text;
            paleInfoModel.regtime = DateTime.Now;
            paleInfoModel.statue = "已预约";
            string sql = "INSERT INTO car_pale (pale,regtime,name,community,building,unit,room,statue) VALUES ('" + paleInfoModel.Pale + "','" + paleInfoModel.regtime.ToString() + "','" + paleInfoModel.Name + "','" + paleInfoModel.Community + "','" + paleInfoModel.Building + "','" + paleInfoModel.Unit + "','" + paleInfoModel.Room + "','" + paleInfoModel.statue + "')";
            string sql2 = "SELECT * FROM car_pale WHERE pale='" + paleInfoModel.Pale + "'  AND   statue='已预约'";
            string sql3 = "INSERT INTO car_pale (pale,regtime,name,community,building,unit,room,statue) VALUES ('" + paleInfoModel.Pale + "','" + paleInfoModel.regtime.ToString() + "','" + paleInfoModel.Name + "','" + paleInfoModel.Community + "','" + paleInfoModel.Building + "','" + paleInfoModel.Unit + "','" + paleInfoModel.Room + "','已入库')";
            if (paleInfoModel.Name != "" && pale_textbox.Text != "")
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql2, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("您填写的车牌已经预约", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                    else
                    {
                        rdr.Close();
                        conn.Close();

                        try
                        {
                            conn.Open();
                            record r = new record();
                            if (r.gettmppale().Length == 1)
                            {
                                MySqlCommand cmd2 = new MySqlCommand(sql, conn);
                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    log.WriteLog("操作员:" + new login().getuser() + "预约了车辆 " + paleInfoModel.Pale);
                                    MessageBox.Show("车牌增加成功！");
                                    this.car_paleTableAdapter1.Fill(this.paleDataSet3.car_pale);
                                }
                            }
                            else
                            {
                                MySqlCommand cmd2 = new MySqlCommand(sql3, conn);
                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    conn.Close();
                                    string direction = r.gettmpdirection();
                                    string gate = r.gettmppgate();
                                    string Endirection = direction.Substring(0, 1) == "入" ? "in" : "out";
                                    DateTime dt = DateTime.Now;
                                    string path = DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") +
                                            "_" + dt.Hour.ToString().PadLeft(2, '0') + "-" + dt.Minute.ToString().PadLeft(2, '0') + "-" + dt.Second.ToString().PadLeft(2, '0') +
                                            "_" + gate.Substring(0, 1) + "gate" + "_" + Endirection + direction.Substring(2, 1) + ".jpg";
                                    string SQL1 = "INSERT INTO record (pale,regtime,gate,direction,time,pic) VALUES ('" + paleInfoModel.Pale + "','" + paleInfoModel.regtime.ToString() + "','" + gate + "','" + direction + "','" + paleInfoModel.regtime.ToString() + "','" + path + "')";
                                    conn.Open();
                                    MySqlCommand cmd1 = new MySqlCommand(SQL1, conn);
                                    cmd1.ExecuteNonQuery();
                                    log.WriteLog("操作员:" + new login().getuser() + "预约了车辆 " + paleInfoModel.Pale);
                                    if (direction == "入口1号车道")
                                    {
                                        ThreadPAC(0);     //DO 0栏杆打开
                                    }
                                    else if (direction == "入口2号车道")
                                    {
                                        ThreadPAC(1);     //DO 1栏杆打开
                                    }
                                    else if (direction == "出口1号车道")
                                    {
                                        ThreadPAC(2);     //DO 2栏杆打开
                                    }
                                    else if (direction == "出口2号车道")
                                    {
                                        ThreadPAC(3);     //DO 3栏杆打开
                                    }
                                    else { }

                                    r.settmpdirection(string.Empty);
                                    r.settmpgate(string.Empty);
                                    r.settmppale("n");

                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).ForeColor = Color.Blue;
                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).SubItems[1].Text = paleInfoModel.Pale;
                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).SubItems[5].Text = name_textBox.Text;
                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).SubItems[6].Text = coum_textBox.Text + buld_textBox.Text + unit_textBox.Text + room_textBox.Text;
                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).SubItems[7].Text = "已入库";
                                    mi.listView2.FindItemWithText(paleInfoModel.Pale).SubItems[8].Text = "岗亭预约";
                                    File.Copy(mi.picpath, System.Environment.CurrentDirectory + "/../../../Resources/palepic/"+path, true);
                                    this.car_paleTableAdapter1.Fill(this.paleDataSet3.car_pale);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("该车牌数据库中已存在或输入数据有误，请检查！", "错误");
                        }
                        conn.Close();
                    }

                }
                catch { }
            }
            else
            {
                MessageBox.Show("姓名和车牌不能为空！");
            }
        }


        # region     门闸控制器操作
        private void monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                adamModbus.Disconnect(); // disconnect slave
            }
        }
        private void RefreshDIO(int DO)
        {
            int iDiStart = 1, iDoStart = 17 + DO;
            int iChTotal;
            bool[] bDiData, bDoData, bData;

            if (adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, out bDiData) &&
                adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, out bDoData))
            {
                iChTotal = m_iDiTotal + m_iDoTotal;
                bData = new bool[iChTotal];
                Array.Copy(bDiData, 0, bData, 0, m_iDiTotal);
                Array.Copy(bDoData, 0, bData, m_iDiTotal, m_iDoTotal);

                flag = bData[12].ToString();
            }

            System.GC.Collect();
        }
        public void PermissionPass(int DO)
        {
            int iOnOff, iStart = 17 + DO;
            if (flag == "True") // was ON, now set to OFF
            {
                iOnOff = 0;
            }
            else
            {
                iOnOff = 1;
            }
            initControl();
            if (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
                RefreshDIO(DO);
            else
                MessageBox.Show("When open gate an error is occur...", "Error");
        }
        public void PassAndClose(int DO)
        {
            PermissionPass(DO);    //开门
            Thread.Sleep(1000);
            PermissionPass(DO);   //关门
        }
        public void ThreadPAC(int DO)
        {
            Thread t = new Thread(delegate()
            {
                PassAndClose(DO);
            });
            t.Start();
        }
        public void initControl()
        {
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "192.168.0.121";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            m_iDoTotal = 6;
            m_iDiTotal = 12;
            if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
            { }
            else
                MessageBox.Show("连接IP地址为 " + m_szIP + " 的开门控制器失败！", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        # endregion   门闸控制器操作
    }
}
