using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using XYS.MCW.Common;

namespace Car.DBUtility
{

    public  class DbHelperMySQL
    {

        static string path = System.Environment.CurrentDirectory + "/../../../conf.ini";
        INIFile inifile = new INIFile(path);

        public string getConnStr()
        {
           
            string section = "Database";
            string username = inifile.IniReadValue(section, "username");
            string password = inifile.IniReadValue(section, "password");
            string server = inifile.IniReadValue(section, "server");
            string database = inifile.IniReadValue(section, "database");
            string port = inifile.IniReadValue(section, "port");
            string connStr = @"server=" + server + ";user=" + username + ";database=" + database + ";port=" + port + ";password=" + password + ";";
            return connStr;
        }
        public string getPicServerip()
        {
            return inifile.IniReadValue("PicServer", "server");
        }
        public string getPicServerPort()
        {
            return inifile.IniReadValue("PicServer", "port");
        }
    }
}
