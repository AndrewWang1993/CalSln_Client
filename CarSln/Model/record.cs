using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.MCW.Model
{
    public class record
    {
        public string Gate { get; set; }          //   大门号  
        public string Direction { get; set; }     //   方向
        public string StartTime { get; set; }     //   开始时间（string）
        public string EndTime { get; set; }       //   结束时间（string）
        public string Time { get; set; }         //    车辆进出时间
        public string Pale { get; set; }          //   车牌号
        public string picPath { get; set; }       //   图片路径
        public DateTime StartT { get; set; }      //   开始时间（DateTime）
        public DateTime EndT { get; set; }        //   结束时间（DataTime）
        public DateTime T { get; set; }       //   车辆进出时间（DataTime）
        public DateTime regtime { get; set; }   //预约时间

        static private string tmppale="n";
        static private string tmpgate;
        static private string tmpdirection;

        public void settmppale(string pale)
        {
            tmppale = pale;
        }

        public string gettmppale(){
            return tmppale;
        }

        public void settmpgate(string gate)
        {
            tmpgate = gate;
        }

        public string gettmppgate()
        {
            return tmpgate;
        }

        public void settmpdirection(string direction)
        {
            tmpdirection = direction;
        }

        public string gettmpdirection()
        {
            return tmpdirection;
        }

    }
}
