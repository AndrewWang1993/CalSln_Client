using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.MCW.Model;
using System.Runtime.InteropServices;

namespace XYS.MCW.Common
{
    public class Ip_Device
    {
        static string path = System.Environment.CurrentDirectory + "/../../../conf.ini";
        INIFile inifile = new INIFile(path);

        public record getDeviceInfo(string sIP)            //根据设备ip地址返回该设备所在的大门号拍摄方向
        {
            record recordModel = new record();
            recordModel.Gate = inifile.IniReadValue("Ip_Device",sIP).Substring(0, 2);
            recordModel.Direction = inifile.IniReadValue("Ip_Device", sIP).Substring(2);
            return recordModel;
        }



    }
}
