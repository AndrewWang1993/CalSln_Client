using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using XYS.MCW.Model;
using Car.DBUtility;
using XYS.MCW.Common;

namespace CarSln
{
    public partial class Login : Form
    {
        login loginModel =new login();
        static string connStr = new DbHelperMySQL().getConnStr();
        MySqlConnection conn = new MySqlConnection(connStr);
        LogManager log = new LogManager();
        public static string currentuser = "";
        public Login()
        {
            InitializeComponent();
        }

        private void conte_button_Click(object sender, EventArgs e)
        {
            bool flag = true;

            try
            {
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                flag = false;
                this.statue_label.ForeColor = Color.Red;
                this.statue_label.Text = "未连接数据库";
            }
            finally { 
                conn.Close();
            }
            if (flag)
            {
                this.statue_label.ForeColor = Color.Green;
                this.statue_label.Text = "已连接数据库";
            }
        }

        private void log_button_Click(object sender, EventArgs e)
        {

            bool i = true;
            while (i)
            {
                bool b = false;
                loginModel.Username = una_textBox.Text.ToString();
                loginModel.Password = pwd_textBox.Text.ToString();
                if (loginModel.Username == "" || loginModel.Password == "")
                {
                    MessageBox.Show("用户名或密码不能为空！");
                    i = false;
                    break;
                }
                string sql = "SELECT * FROM user Where usr = '" + loginModel.Username + "' AND " + "pwd='" + loginModel.Password + "'";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        b = true;
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();

                if (b)
                {
                    this.Hide();
                    MainForm mf = new MainForm();
                    currentuser = loginModel.Username;
                    setuser();
                    log.WriteLog("用户" +currentuser+ "登陆成功");
                    mf.Show();
                    i = false;
                    break;
                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入");
                    i = false;
                    break;
                }


            }
        }

        private void ext_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void setuser()
        {
            login lg = new login();
            lg.setuser(currentuser);
        }

    }
}
