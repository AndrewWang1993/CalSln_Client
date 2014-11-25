using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.MCW.Model
{
    public class login
    {
        public string Username { get; set; }     //   用户名  
        public string Password { get; set; }     //   密码
        static public  string currentuser { get; set; }  //当前用户
        public void setuser(string user)
        {
            currentuser = user;
        }
        public string getuser()
        {
            return currentuser;
        }
    }
}
