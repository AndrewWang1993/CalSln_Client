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
    public partial class InformationUnregister : Form
    {

        paleInfo paleInfoModel = new paleInfo();
        static string connStr = "server=localhost;user=root;database=pale;port=3306;password=123456;";
        MySqlConnection conn = new MySqlConnection(connStr);
        public InformationUnregister()
        {
            InitializeComponent();
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            paleInfoModel.Pale = sur_comboBox.Text + pale_textbox.Text;
            string sql = "DELETE FROM car_pale WHERE pale = '" + paleInfoModel.Pale + "'";
            
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("车牌 " + paleInfoModel.Pale + " 删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("该车牌不存在","删除失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "数据库错误");
                }
                conn.Close();
            
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
    }
}
