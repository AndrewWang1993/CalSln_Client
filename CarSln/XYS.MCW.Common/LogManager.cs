using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace XYS.MCW.Common
{
    public class LogManager
    {
        private int fileSize;

        private string fileLogPath;

        private string logFileName;


        public LogManager()
        {
            this.fileSize = 2048 * 1024;//日志文件大于2M自动删除
            this.fileLogPath = System.Environment.CurrentDirectory + "/../../../Log/";
            DateTime dt=DateTime.Now;
            string date= string.Format("{0:D}",dt);
            this.logFileName = date+"Log.txt";
        }

        public int FileSize
        {
            set
            {
                fileSize = value;
            }
            get
            {
                return fileSize;
            }
        }

        public string LogFileName
        {
            set
            {
                this.logFileName = value;
            }
            get
            {
                return this.logFileName;
            }

        }

        public void WriteLog(string Message)
        {
            this.WriteLog(this.logFileName, Message);
        }



        public void WriteLog(string LogFileName, string Message)
        {
            //如果日志文件目录不存在,则创建
            if (!Directory.Exists(this.fileLogPath))
            {
                Directory.CreateDirectory(this.fileLogPath);
            }

            FileInfo finfo = new FileInfo(this.fileLogPath + LogFileName);
            if (finfo.Exists && finfo.Length > fileSize)
            {
                finfo.Delete();
            }
            try
            {
                FileStream fs = new FileStream(this.fileLogPath + LogFileName, FileMode.Append);
                StreamWriter strwriter = new StreamWriter(fs);
                try
                {

                    DateTime d = DateTime.Now;
                    strwriter.WriteLine("时间:" + d.ToString());
                    strwriter.WriteLine(Message);
                    strwriter.WriteLine();
                    strwriter.Flush();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("日志文件写入错误");
                }
                finally
                {
                    strwriter.Close();
                    strwriter = null;
                    fs.Close();
                    fs = null;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("日志文件没有打开");
            }


        }
    }
}