using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.MCW.Model
{
    public class paleInfo
    {
        public string Community { get; set; }    //   社区
        public string Building { get; set; }     //   楼栋
        public string Unit { get; set; }         //   单元
        public string Room { get; set; }         //   房间
        public string Name { get; set; }         //   姓名
        public string Pale { get; set; }         //   车牌号
        public DateTime regtime { get; set; }   //预约时间
        public string statue { get; set; }         //状态

    }
}
