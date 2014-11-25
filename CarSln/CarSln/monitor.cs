using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using XYS.MCW.Model;
using XYS.MCW.Common;
using Car.DBUtility;
using System.Net.Sockets;
using Advantech.Adam;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;

namespace CarSln
{
    //已添加设备信息结构体
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
    public struct AddDeviceInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LPRSDK.IP_MAX_LEN)]
        public string ucDeviceIP;//设备IP
        public IntPtr ptrDeviceHandle;//设备句柄
    }
     

    public partial class monitor : Form
    {
        #region 变量初始化
        //鼠标移动操作
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        const int MOUSEEVENTF_MOVE = 0x0001;   //   移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标 
        int SH = Screen.PrimaryScreen.Bounds.Height;   //竖向分辨率
        int SW = Screen.PrimaryScreen.Bounds.Width;  //横向分辨率
        const int Int16_Max = 65535;

        

        //摄像机相关变量初始化
        public DeviceInfoCallback DeviceInfofuc = null;
        public DeviceStatusCallback DeviceStatusfuc = null;
        public VehicleDataCallback VehicleDatafuc = null;
        public JPGStreamCallBack JPGStreamfuc = null;
        public Hashtable DeviceTable;

        //ADAM控制器相关变量初始化
        private bool m_bStart;
        private AdamSocket adamModbus;
        private string m_szIP;
        private int m_iPort;
        private int m_iDoTotal, m_iDiTotal;
        string flag = "false";

        //数据库相关操作
        static string connStr = new DbHelperMySQL().getConnStr();
        MySqlConnection conn = new MySqlConnection(connStr);


        //设置自动关闭Messagebox
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;


        //记录进入车辆总数
        static int carInCount = 0;
        static int carOutCount = 0;
        
        //连接标志
        static int dot = 0;
        bool reconn = false;
        bool isconnected = false;

        //其他变量初始化
        public string picpath="";                     //图片路径
        LogManager lm = new LogManager();             //日志类
        static int pv = 1;                            //设置信号量
        static string path = System.Environment.CurrentDirectory + "/../../../conf.ini";
        INIFile inifile = new INIFile(path);          //读取配置文件

        #endregion

        public monitor()
        {
            InitializeComponent();
            initControl();     //初始化开门控制器相关变量
        }
        private void monitor_Loader(object sender, EventArgs e)
        {
            initCamera();     //初始化相机相关变量
        }



        void fucVehicleData(IntPtr pUserData, ref LPRSDK.VehicleData pData)
        {
            for (int count = 0; count < 3; count++)             //三次尝试存储图片，互斥
            {
                if (--pv < 0)
                {
                    pv++;
                    Thread.Sleep(200);
                    if (count == 2)
                    {
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
                
            if (pData.ucPlate.ToString().Length < 6)         //如果抓拍到摩托车和电瓶车偶尔会返回车牌号为空，这时函数直接返回
            {
                return;
            }
            string sIP = "";
            foreach (DictionaryEntry de in DeviceTable)
            {

                AddDeviceInfo info = (AddDeviceInfo)DeviceTable[de.Key];
                if (info.ptrDeviceHandle == pData.pDeviceHandle)
                {
                    sIP = info.ucDeviceIP;
                    break;
                }
            }
            string fileDirectory = string.Empty;
            fileDirectory = string.Format("{0}\\{1}\\{2}{3}{4}\\", Application.StartupPath, pData.ucDeviceIP, pData.ucTime[0] + 2000,
                pData.ucTime[1], pData.ucTime[2]);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            String strSpeFile = "", strPlateFile = "";



            strSpeFile = string.Format("{0}{1}{2}{3}({4})big.jpg", fileDirectory, pData.ucTime[3], pData.ucTime[4], pData.ucTime[5], pData.ucTime[2]);
            strPlateFile = string.Format("{0}{1}{2}{3}({4})plate.jpg", fileDirectory, pData.ucTime[3], pData.ucTime[4], pData.ucTime[5], pData.ucTime[2]);
            picpath = strSpeFile;


            if (pData.uiBigImageLen != 0)
            {
                FileStream fs = new FileStream(strSpeFile, FileMode.Create, FileAccess.Write,FileShare.ReadWrite);
                byte[] bytData = new byte[pData.uiBigImageLen];
                Marshal.Copy(pData.pucBigImage, bytData, 0, (int)pData.uiBigImageLen);

                try
                {
                    fs.Write(bytData, 0, (int)pData.uiBigImageLen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally {                    
                    fs.Close();
                    fs.Dispose();                          //确保fs对象被销毁
                }
            }


            if (pData.uiPlateImageLen != 0)
            {
                FileStream fs = new FileStream(strPlateFile, FileMode.Create, FileAccess.Write,FileShare.ReadWrite);
                byte[] bytData = new byte[pData.uiPlateImageLen];
                Marshal.Copy(pData.pucPlateImage, bytData, 0, (int)pData.uiPlateImageLen);
                try
                {
                    fs.Write(bytData, 0, (int)pData.uiPlateImageLen);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    fs.Close();
                    fs.Dispose();                          //确保fs对象被销毁
                }
            }

            //窗口控件绑定变量置空
            this.picBigImage.Image = null;
            this.picPlateImage.Image = null;

            FileInfo fi = new FileInfo(strSpeFile);
            if (fi.Exists)
            {
                this.picBigImage.Load(strSpeFile);
            }

            fi = new FileInfo(strPlateFile);
            if (fi.Exists)
            {
                this.picPlateImage.Load(strPlateFile);
            }

            ShowPlate(pData.ucPlate.ToString(), pData.PlateColor);





            DateTime dt = DateTime.Now;
            paleInfo paleinfoModel = new paleInfo();
            record recordModel = new Ip_Device().getDeviceInfo(pData.ucDeviceIP);  // 获得该设备所在大门号和车道号
            recordModel.Pale = pData.ucPlate.ToString();
            recordModel.T = dt;
            recordModel.Time = dt.ToString();
            string Endirection = recordModel.Direction.Substring(0, 1) == "入" ? "in" : "out";

            recordModel.picPath = DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") +
                "_" + dt.Hour.ToString().PadLeft(2, '0') + "-" + dt.Minute.ToString().PadLeft(2, '0') + "-" + dt.Second.ToString().PadLeft(2, '0') +
                "_" + recordModel.Gate.Substring(0, 1) + "gate" + "_" + Endirection + recordModel.Direction.Substring(2, 1) + ".jpg";


            string SQL2 = "SELECT * FROM car_pale WHERE pale ='" + recordModel.Pale + "' AND statue='已预约'";
            string SQL3 = "SELECT * FROM car_pale WHERE pale ='" + recordModel.Pale + "' AND statue='已入场'";


            MySqlConnection conn1 = new MySqlConnection(connStr);    //每个进程需实例化一个连接，否则前面进程堵塞时会不能使用该连接
            bool paleflag = false;
            string[] likepale = getpale(recordModel.Pale);
            string DBpale = "";

         
                for (int i = 0; i < 4; i++)
                {
                    string thisstatue = Endirection == "in" ? "已预约" : "已入场";
                    string LikeSQL = "SELECT * FROM car_pale WHERE pale LIKE'" + likepale[i] + "' AND statue='"+thisstatue+"'";
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd2 = new MySqlCommand(LikeSQL, conn);
                        MySqlDataReader rdr2 = cmd2.ExecuteReader();
                        if (rdr2.HasRows)
                        {
                            paleflag = true;
                            if (rdr2.Read())
                            {
                                DBpale = rdr2[0].ToString();
                                recordModel.regtime = DateTime.Parse(rdr2[1].ToString());
                                paleinfoModel.Name = rdr2[2].ToString();
                                paleinfoModel.Community = rdr2[3].ToString();
                                paleinfoModel.Building = rdr2[4].ToString();
                                paleinfoModel.Unit = rdr2[5].ToString();
                                paleinfoModel.Room = rdr2[6].ToString();
                                rdr2.Close();
                            }
                            break;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                        conn.Close();
                        MessageBox.Show(ex.ToString());
                    }
                    finally { conn.Close(); }
                }
          


            while (true)
            {
                if (Endirection == "in")
                {

                    try
                    {
                        //conn1.Open();
                        //MySqlCommand cmd2 = new MySqlCommand(SQL2, conn1);
                        //MySqlDataReader rdr2 = cmd2.ExecuteReader();
                        if (paleflag == false)
                        //if (!rdr2.HasRows) {
                        {
                            this.result.ForeColor = Color.Red;
                            this.result.Text = "未预约";
                            this.picBigImage.Load(strSpeFile);
                            this.picPlateImage.Load(strPlateFile);
                            ShowPlate(pData.ucPlate.ToString(), pData.PlateColor);

                            ListViewItem item = new ListViewItem();
                            item.SubItems[0].Text = recordModel.Time;
                            item.SubItems.Add(DBpale);
                            item.SubItems.Add(recordModel.Pale);
                            item.SubItems.Add(recordModel.Gate);
                            item.SubItems.Add(recordModel.Direction);
                            item.SubItems.Add("");
                            item.SubItems.Add("");
                            item.SubItems.Add("未预约");
                            item.SubItems.Add("手动放行");
                            listView2.Items.Insert(0, item);
                            break;
                        }
                        //while(rdr2.Read())
                        //{
                        //    recordModel.regtime = DateTime.Parse(rdr2[1].ToString());
                        //    paleinfoModel.Name = rdr2[2].ToString();
                        //    paleinfoModel.Community = rdr2[3].ToString();
                        //    paleinfoModel.Building = rdr2[4].ToString();
                        //    paleinfoModel.Unit = rdr2[5].ToString();
                        //    paleinfoModel.Room = rdr2[6].ToString();
                        //}
                        //rdr2.Close();
                        //conn1.Close();

                        try
                        {
                            conn1.Open();
                            string SQL1 = "INSERT INTO record (pale,regtime,gate,direction,time,pic) VALUES ('" + DBpale + "','" + recordModel.regtime.ToString() + "','" + recordModel.Gate + "','" + recordModel.Direction + "','" + recordModel.T.ToString() + "','" + recordModel.picPath + "')";
                            MySqlCommand cmd1 = new MySqlCommand(SQL1, conn1);
                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                conn1.Close();
                                if (recordModel.Direction == "入口1号车道")
                                {
                                    ThreadPAC(0);     //DO 0栏杆打开
                                }
                                else if (recordModel.Direction == "入口2号车道")
                                {
                                    ThreadPAC(1);     //DO 1栏杆打开
                                }
                                else
                                {
                                    
                                }
                                this.result.ForeColor = Color.Green;
                                this.result.Text = "放行";
                                carInCount++;
                                ListViewItem item = new ListViewItem();
                                item.SubItems[0].Text = recordModel.Time;
                                item.SubItems.Add(DBpale);
                                item.SubItems.Add(recordModel.Pale);
                                item.SubItems.Add(recordModel.Gate);
                                item.SubItems.Add(recordModel.Direction);
                                item.SubItems.Add(paleinfoModel.Name);
                                item.SubItems.Add(paleinfoModel.Community + paleinfoModel.Building + paleinfoModel.Unit + paleinfoModel.Room + "室");
                                item.SubItems.Add("已入场");
                                item.SubItems.Add("自动放行");
                                listView2.Items.Insert(0, item);

                                try
                                {
                                    conn1.Open();
                                    string SQL4 = "UPDATE car_pale SET statue ='已入场' WHERE pale = '" + DBpale + "' AND regtime='" + recordModel.regtime.ToString() + "'";
                                    MySqlCommand cmd4 = new MySqlCommand(SQL4, conn1);
                                    if (cmd4.ExecuteNonQuery() > 0)
                                    {

                                        conn1.Close();
                                    }
                                }
                                catch { }
                                finally { conn1.Close(); }


                                #region 存储图片
                                if (pData.uiBigImageLen != 0)
                                {
                                    string filepath = System.Environment.CurrentDirectory + "/../../../Resources/palepic/" + recordModel.picPath;
                                    FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
                                    byte[] bytData = new byte[pData.uiBigImageLen];
                                    Marshal.Copy(pData.pucBigImage, bytData, 0, (int)pData.uiBigImageLen);

                                    try
                                    {
                                        fs.Write(bytData, 0, (int)pData.uiBigImageLen);
                                        fs.Close();
                                      
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                # endregion

                                # region 发送图片到服务器
                                try
                                {

                                    StartSend(System.Environment.CurrentDirectory + "/../../../Resources/palepic/" + recordModel.picPath,
                                        new DbHelperMySQL().getPicServerip(), Convert.ToInt32(new DbHelperMySQL().getPicServerPort()));
                                }
                                catch { }   //忽略图片服务器未打开的情况
                                break;

                                #endregion

                            }


                        }
                        catch (Exception e) { MessageBox.Show(e.ToString()); }

                    }
                    catch { }

                }
                else
                {
                    try
                    {
                        //conn1.Open();
                        //MySqlCommand cmd3 = new MySqlCommand(SQL3, conn1);
                        //MySqlDataReader rdr3 = cmd3.ExecuteReader();
                        //if (!rdr3.HasRows)
                        if (paleflag == false)
                        {
                            this.result.ForeColor = Color.Red;
                            this.result.Text = "未预约";
                            this.picBigImage.Load(strSpeFile);
                            this.picPlateImage.Load(strPlateFile);
                            ShowPlate(pData.ucPlate.ToString(), pData.PlateColor);

                            ListViewItem item = new ListViewItem();
                            item.SubItems[0].Text = recordModel.Time;
                            item.SubItems.Add(DBpale);
                            item.SubItems.Add(recordModel.Pale);
                            item.SubItems.Add(recordModel.Gate);
                            item.SubItems.Add(recordModel.Direction);
                            item.SubItems.Add("");
                            item.SubItems.Add("");
                            item.SubItems.Add("未预约");
                            item.SubItems.Add("手动放行");
                            listView2.Items.Insert(0, item);
                            break;
                        }
                        //while (rdr3.Read())
                        //{
                        //    recordModel.regtime = DateTime.Parse(rdr3[1].ToString());
                        //    paleinfoModel.Name = rdr3[2].ToString();
                        //    paleinfoModel.Community = rdr3[3].ToString();
                        //    paleinfoModel.Building = rdr3[4].ToString();
                        //    paleinfoModel.Unit = rdr3[5].ToString();
                        //    paleinfoModel.Room = rdr3[6].ToString();

                        //}
                        //rdr3.Close();
                        //conn1.Close();

                        try
                        {
                            conn1.Open();
                            string SQL1 = "INSERT INTO record (pale,regtime,gate,direction,time,pic) VALUES ('" + DBpale + "','" + recordModel.regtime.ToString() + "','" + recordModel.Gate + "','" + recordModel.Direction + "','" + recordModel.T.ToString() + "','" + recordModel.picPath + "')";
                            MySqlCommand cmd1 = new MySqlCommand(SQL1, conn1);
                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                conn1.Close();

                                if (recordModel.Direction == "出口1号车道")
                                {
                                    ThreadPAC(2);     //DO 2栏杆打开
                                }
                                else if (recordModel.Direction == "出口2号车道")
                                {
                                    ThreadPAC(3);     //DO 3栏杆打开
                                }
                                else
                                {
                                    MessageBox.Show("你逆行了");
                                    break;
                                }

                                this.result.ForeColor = Color.Green;
                                this.result.Text = "放行";
                                carInCount++;
                                ListViewItem item = new ListViewItem();
                                item.SubItems[0].Text = recordModel.Time;
                                item.SubItems.Add(DBpale);
                                item.SubItems.Add(recordModel.Pale);
                                item.SubItems.Add(recordModel.Gate);
                                item.SubItems.Add(recordModel.Direction);
                                item.SubItems.Add(paleinfoModel.Name);
                                item.SubItems.Add(paleinfoModel.Community + paleinfoModel.Building + paleinfoModel.Unit + paleinfoModel.Room + "室");
                                item.SubItems.Add("已出场");
                                item.SubItems.Add("自动放行");
                                listView2.Items.Insert(0, item);

                                try
                                {
                                    conn1.Open();
                                    string SQL5 = "UPDATE car_pale SET statue ='已出场' WHERE pale = '" + DBpale + "' AND regtime='" + recordModel.regtime.ToString() + "'";
                                    MySqlCommand cmd4 = new MySqlCommand(SQL5, conn1);
                                    if (cmd4.ExecuteNonQuery() > 0)
                                    {
                                        conn1.Close();
                                    }
                                }
                                catch { }


                                #region 存储图片
                                if (pData.uiBigImageLen != 0)
                                {
                                    string filepath = System.Environment.CurrentDirectory + "/../../../Resources/palepic/" + recordModel.picPath;
                                    FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
                                    byte[] bytData = new byte[pData.uiBigImageLen];
                                    Marshal.Copy(pData.pucBigImage, bytData, 0, (int)pData.uiBigImageLen);

                                    try
                                    {
                                        fs.Write(bytData, 0, (int)pData.uiBigImageLen);
                                        fs.Close();

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                # endregion


                                # region 发送图片到服务器
                                try
                                {
                                StartSend(System.Environment.CurrentDirectory + "/../../../Resources/palepic/" + recordModel.picPath, 
                                    new DbHelperMySQL().getPicServerip(), Convert.ToInt32(new DbHelperMySQL().getPicServerPort()));
                                }
                                catch { }  //忽略图片服务器未打开的情况
                                break;

                                #endregion

                            }


                        }
                        catch { }

                    }
                    catch { }
                }
            }


            if (conn.State.ToString() == "Open")
                conn.Close();
            if (conn1.State.ToString() == "Open")
                conn1.Close();



            listview_Color();
            listview_AutoDelet();
            label1.Text = "出入 " + (carInCount + carOutCount).ToString() + " 辆车";
            label2.Text = "入场 " + carInCount.ToString() + " 辆车";
            label3.Text = "出场 " + carOutCount.ToString() + " 辆车";

            pv++;
        }



        public string[] getpale(string pale)
        {
            string[] likepale = new string[4];
            string line = "_";
            for (int i = 0; i < 4; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int tmp = i; tmp > 0; tmp--)
                {
                    sb.Append(line);
                }
                sb.Append(pale.Substring(i, 4));
                for (int tmp = 3 - i; tmp > 0; tmp--)
                {
                    sb.Append(line);
                }
                likepale[i] = sb.ToString();
            }
            return likepale;
        }



        #region   摄像机相关方法
        void fucDeviceInfo(IntPtr pUserData, ref LPRSDK.DeviceInfo pDeviceInfo)    //  LPRSDK.LPR_ScanDevice(); 会回调用此方法
        {
            //将扫描的设备添加到列表并自动进行连接
            String sIP = pDeviceInfo.DeviceNetInfo.ucDeviceIP.ToString();
            record recordModel = new Ip_Device().getDeviceInfo(sIP);
            StringBuilder sbIP = new StringBuilder(sIP);
            IntPtr ptrHandle = IntPtr.Zero;
            if ((LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_ConnectCamera(sbIP, ref ptrHandle) == LPRSDK.FEEKBACK_TYPE.RESULT_OK)
            {
                label4.Hide();
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                if (timer2.Enabled == true)
                {
                    timer2.Stop();
                }
                lm.WriteLog("IP为" + sIP + "的设备连接成功！");
                if (reconn == true)
                {
                    lm.WriteLog("IP为" + sIP + "的设备重新连接成功！");
                    StartKiller();    //自动关闭提示框
                    MessageBox.Show("网络连接已恢复", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try { 
                          listView1.FindItemWithText(sIP).Remove();                    //将连接失败的item删除
                    }
                    catch { }
                    
                }
                ListViewItem item = this.listView1.Items.Add(recordModel.Gate);
                item.SubItems.Add(recordModel.Direction);
                item.SubItems.Add(sIP);                                                   //将该item重新加入listview1
                item.SubItems.Add("摄像机已连接");
                AddDeviceInfo Info = new AddDeviceInfo();
                Info.ptrDeviceHandle = ptrHandle;
                Info.ucDeviceIP = sIP.ToString();
                DeviceTable.Add(sbIP, Info);
                listview_Resort();
                timer3.Start();
            }
            else if ((LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_ConnectCamera(sbIP, ref ptrHandle) == LPRSDK.FEEKBACK_TYPE.DEVICE_DISCONNECT)
            {
                ListViewItem item = this.listView1.Items.Add(recordModel.Gate);
                item.SubItems.Add(recordModel.Direction + "口");
                item.SubItems.Add(sIP);
                item.SubItems.Add("摄像机已断开");
                MessageBox.Show("摄像机已断开！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_ConnectCamera(sbIP, ref ptrHandle) == LPRSDK.FEEKBACK_TYPE.NO_FIND_DEVICE)
            {
                MessageBox.Show("没有发现设备,请检查摄像机网线是否插好！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_ConnectCamera(sbIP, ref ptrHandle) == LPRSDK.FEEKBACK_TYPE.OTHER_ERROR)
            {
                MessageBox.Show("其它错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("未知错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        void fucDeviceStatus(IntPtr pUserData, ref LPRSDK.DeviceStatus pStatus)
        {

        }
        void fucJPGStream(IntPtr pUserData, ref LPRSDK.JPGData pJPGData)
        {

        }
        public void ShowPlate(String strPlate, LPRSDK.PLATE_COLOR nColor)
        {
            labelPlate.Text = strPlate;
            switch (nColor)
            {
                case LPRSDK.PLATE_COLOR.YELLOW_COLOR:
                    labelPlate.BackColor = Color.Yellow;
                    labelPlate.ForeColor = Color.Black;
                    break;
                case LPRSDK.PLATE_COLOR.BLUE_COLOR:
                    labelPlate.BackColor = Color.Blue;
                    labelPlate.ForeColor = Color.White;
                    break;
                case LPRSDK.PLATE_COLOR.WHITE_COLOR:
                    labelPlate.BackColor = Color.White;
                    labelPlate.ForeColor = Color.Black;
                    break;
                case LPRSDK.PLATE_COLOR.BLACK_COLOR:
                    labelPlate.BackColor = Color.Black;
                    labelPlate.ForeColor = Color.White;
                    break;
                default:
                    labelPlate.BackColor = Color.SlateGray;
                    labelPlate.ForeColor = Color.Black;
                    break;
            }
        }

        public void initCamera()          //初始化相机相关变量
        {
            DeviceTable = new Hashtable();
            //初始化动态库
            DeviceInfofuc = new DeviceInfoCallback(fucDeviceInfo);
            VehicleDatafuc = new VehicleDataCallback(fucVehicleData);
            JPGStreamfuc = new JPGStreamCallBack(fucJPGStream);
            DeviceStatusfuc = new DeviceStatusCallback(fucDeviceStatus);
            LPRSDK.LPR_IsWriteLog(true);
            LPRSDK.LPR_Init(this.Handle, IntPtr.Zero, DeviceInfofuc, DeviceStatusfuc, VehicleDatafuc, JPGStreamfuc);
            LPRSDK.LPR_ScanDevice();
        }

        #endregion
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
            m_bStart = false;			                       // the action stops at the beginning
            m_szIP = inifile.IniReadValue("Adam", "controlIp");// modbus slave IP address
            m_iPort = 502;			                        	// modbus TCP port is 502
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
        #region  自动关闭Messagebox

        private void StartKiller()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000; //2秒启动
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
            IntPtr ptr = FindWindow(null, "提示");
            if (ptr != IntPtr.Zero)
            {
                //找到则关闭MessageBox窗口
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }

        }

        #endregion       自动关闭Messagebox
        #region 自动断连
        private void timer1_Tick_1(object sender, EventArgs e)       //重连提示
        {
            string text = "连接失败,正在重连";
            string dotstr = ".";
            StringBuilder sb = new StringBuilder(text);
            for (int tmp = dot++; tmp > 0; tmp--)
            {
                sb.Append(dotstr);
            }
            label4.Text = sb.ToString();
            dot %= 7;
        }

        private void timer2_Tick(object sender, EventArgs e)       //如果连接失败每隔3秒尝试重连一次
        
        
        {
            if (label4.Visible)
            {
                timer3.Enabled = false;
                reconn = true;
                //initCamera();
                LPRSDK.LPR_ScanDevice();     //不能使用初始化方法，否则会导致非托管代码提前关闭。
            }
        }

        private void timer3_Tick(object sender, EventArgs e)   //3秒钟检测一下网络状态 
        {



            foreach (DictionaryEntry de in DeviceTable)
            {
                AddDeviceInfo info = (AddDeviceInfo)DeviceTable[de.Key];
                isconnected = false;
                //LPRSDK.DEVICE_STATUS device_status = LPRSDK.DEVICE_STATUS.CONNECT_ERROR;
                //if (LPRSDK.FEEKBACK_TYPE.RESULT_OK == (LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_CheckStatus(info.ptrDeviceHandle, ref device_status))
                //{

                //}
                //else {
                //    MessageBox.Show("检测状态失败");
                //}
                //LPRSDK.FEEKBACK_TYPE ft = (LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_CheckStatus(info.ptrDeviceHandle, ref device_status);
                //isconnected = false;
                //if (device_status != LPRSDK.DEVICE_STATUS.ABNORMALNET_ERROR)     //检测网络状态
                //{                                                                                                             // 本处厂家SDK中检测网络状态函数有问题，在中断
                //    isconnected = true;                                                                            //重连后检测的网络状态为connectsuccess和connecterror交替出现
                //}                                                                                                             //所以此处将网线拔出产生的错误abnormalnetERROR设为检测条件
                //上面feekback_type 同样问题,init0 和 ok 交替出现

                





                //Ping p = new Ping();
                //PingReply reply=null;
                //try
                //{
                //    reply = p.Send(info.ucDeviceIP, 600);
                //}
                //catch (NetworkInformationException nie)
                //{
                //    MessageBox.Show(nie.StackTrace);
                //};
                //if (reply.Status == IPStatus.Success)
                //{
                //    isconnected = true;
                //}

                int i=0;
                do
                {
                    Thread.Sleep(300 * i);
                    isconnected = Ping(info.ucDeviceIP);

                } while (isconnected == false && i++ <= 3);

                if (isconnected == false)
                {
                    timer3.Stop();                    //需在messagebox弹出前关闭定时器
                    //StartKiller();                     //不能自动关闭，否则进程不同步
                    MessageBox.Show("网络连接断开，点击确定尝试重新连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lm.WriteLog("IP为" + info.ucDeviceIP + "的设备已断开！");  //写日志
                    try
                    {
                        if (LPRSDK.FEEKBACK_TYPE.RESULT_OK != (LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_DisconnectCamera(info.ptrDeviceHandle))  //删除该ip的在设备句柄中的存在
                        {
                            LPRSDK.FEEKBACK_TYPE error= (LPRSDK.FEEKBACK_TYPE)LPRSDK.LPR_DisconnectCamera(info.ptrDeviceHandle);
                            MessageBox.Show(error.ToString(),"连接未关闭");     //反复断开三次以上会出现 FIND_NO_DEVICE 错误
                            lm.WriteLog("IP为" + info.ucDeviceIP + "的设备已经断开但未关闭即资源未释放！");  //写日志
                        };
                    }
                    catch
                    {
                        MessageBox.Show("关闭连接发生错误");
                        lm.WriteLog("关闭IP为" + info.ucDeviceIP + "的设备时发生错误！");  //写日志
                    }
                    //listView1.Items.Clear();
                    try
                    {
                        listView1.FindItemWithText(info.ucDeviceIP).ForeColor = Color.DarkRed;
                        listView1.FindItemWithText(info.ucDeviceIP).SubItems[3].Text = "连接失败";
                    }
                    catch { };
                    label4.Visible = true;
                    if (timer1.Enabled == false)
                    {
                        timer1.Start();
                    }
                    if (timer2.Enabled == false)
                    {
                        timer2.Start();
                    }
                    break;
                }
            }

        }
        
        public bool Ping(string ip)
        {
            bool result = false;
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "T";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000; // Timeout 时间，单位：毫秒  
            try
            {
                System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    result = true;
                else
                    result = false;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        #endregion   自动断连
        #region listviw上色
        public void listview_Color()
        {
            foreach (ListViewItem lv in listView2.Items)
            {
                try
                {
                    if (lv.SubItems[8].Text == "自动放行")
                    {
                        lv.ForeColor = Color.Green;
                    }
                    if (lv.SubItems[8].Text == "手动放行")
                    {
                        lv.ForeColor = Color.Black;
                    }
                    if (lv.SubItems[8].Text == "岗亭预约")
                    {
                        lv.ForeColor = Color.Blue;
                    }
                }
                catch { }
            }
        }

        #endregion
        # region listview根据IP地址重新排序

        public void listview_Resort()
        {

            try
            {
                if (listView1.Items.Count > 1)
                {
                    for (int i = 1; i < listView1.Items.Count; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            string i_IP = listView1.Items[i].SubItems[2].Text.ToString();
                            string j_IP = listView1.Items[j].SubItems[2].Text.ToString();
                            int i_index = i_IP.LastIndexOf('.');
                            int i_lenght = i_IP.Length;
                            int j_index = j_IP.LastIndexOf('.');
                            int j_length = j_IP.Length;
                            int i_subnum = Convert.ToInt32(i_IP.Substring(i_index + 1, i_lenght - i_index - 1));
                            int j_subnum = Convert.ToInt32(j_IP.Substring(j_index + 1, j_length - j_index - 1));

                            if (i_subnum < j_subnum)
                            {
                                ListViewItem tmp_item = (ListViewItem)listView1.Items[i].Clone();
                                listView1.Items.Insert(j, tmp_item);
                                listView1.Items.Remove(listView1.Items[i + 1]);
                                break;
                            }


                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }



        }

        # endregion
        #region listviw超过五十条删除
        public void listview_AutoDelet()
        {
            if (listView2.Items.Count > 50)
            {
                listView2.Items.RemoveAt(50);
            }

        }

        #endregion


        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            ListViewHitTestInfo info = listView2.HitTest(e.X, e.Y);
            var item = info.Item as ListViewItem;
            string statu = item.SubItems[8].Text;  //识别状态

            if (statu == "手动放行")
            {
                record tmpr = new record();
                tmpr.settmppale(item.SubItems[2].Text);
                tmpr.settmpgate(item.SubItems[3].Text);
                tmpr.settmpdirection(item.SubItems[4].Text);

                Point orPoit = MousePosition;
                Point p1 = (this.Parent.Parent as Form).Location;
                p1.Offset(200, 60);
                float dx = (float)p1.X / SW;
                float dy = (float)p1.Y / SH;
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE | MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Convert.ToInt32(dx * Int16_Max), Convert.ToInt32(dy * Int16_Max), 0, 0);

                double ox = (double)(orPoit.X + 1) / SW;
                double oy = (double)(orPoit.Y + 1) / SH;
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, Convert.ToInt32(ox * Int16_Max), Convert.ToInt32(oy * Int16_Max), 0, 0);

            }
            listview_Color();
        }


        public void StartSend(string picpath,string ip,int port)
        {

            FileInfo EzoneFile = new FileInfo(picpath);

            FileStream EzoneStream = EzoneFile.OpenRead();

            int PacketSize = 1000;

            int PacketCount = (int)(EzoneStream.Length / ((long)PacketSize));

            //    this.textBox8.Text = PacketCount.ToString();

            //    this.progressBar1.Maximum = PacketCount;

            int LastDataPacket = (int)(EzoneStream.Length - ((long)(PacketSize * PacketCount)));

            //    this.textBox9.Text = LastDataPacket.ToString();

            //MessageBox.Show(Convert.ToString(PacketCount));

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(ipep);

            //MessageBox.Show(Convert.ToString(PacketCount));
            TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(EzoneFile.Name));

            //         TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketSize.ToString()));

            //        TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketCount.ToString()));

            //        TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(LastDataPacket.ToString()));

            byte[] data = new byte[PacketSize];

            for (int i = 0; i < PacketCount; i++)
            {
                EzoneStream.Read(data, 0, data.Length);

                TransferFiles.SendVarData(client, data);

                //             this.textBox10.Text = ((int)(i + 1)).ToString();

                //             this.progressBar1.PerformStep();
            }

            if (LastDataPacket != 0)
            {
                data = new byte[LastDataPacket];

                EzoneStream.Read(data, 0, data.Length);

                TransferFiles.SendVarData(client, data);

                //            this.progressBar1.Value = this.progressBar1.Maximum;
            }


            client.Close();

            EzoneStream.Close();



        }



    }
}
