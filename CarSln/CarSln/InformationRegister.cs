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

namespace CarSln
{
    public partial class InformationRegister : Form
    {
        paleInfo paleInfoModel = new paleInfo();
        static string connStr = "server=localhost;user=root;database=pale;port=3306;password=123456;";
        MySqlConnection conn = new MySqlConnection(connStr);

        public InformationRegister()
        {
            InitializeComponent();
        }

        private void pale_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                if (pale_textbox.Text.Length-pale_textbox.SelectedText.Length < 6)
                {
                    pale_textbox.SelectedText = char.ToUpper(e.KeyChar).ToString();
                    e.Handled = true;
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            paleInfoModel.Community = coum_textBox.Text.Trim();
            paleInfoModel.Building = buld_textBox.Text.Trim();
            paleInfoModel.Unit = unit_textBox.Text.Trim();
            paleInfoModel.Room = room_textBox.Text.Trim();
            paleInfoModel.Name = name_textBox.Text.Trim();
            paleInfoModel.Pale = sur_comboBox.Text+pale_textbox.Text;

            string sql = "INSERT INTO car_pale (pale,name,community,building,unit,room) VALUES ('" + paleInfoModel.Pale + "','" + paleInfoModel.Name + "','" + paleInfoModel.Community + "','" + paleInfoModel.Building + "','" + paleInfoModel.Unit + "','" + paleInfoModel.Room + "')";

            if (paleInfoModel.Name != "" && pale_textbox.Text != "")
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("车牌增加成功！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("该车牌数据库中已存在或输入数据有误，请检查！", "错误");
                }
                conn.Close();
            }
            else {
                MessageBox.Show("姓名和车牌不能为空！");
            }
        }

        
    }
}
