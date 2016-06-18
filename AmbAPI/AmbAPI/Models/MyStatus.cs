using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{

    /// <summary>
    /// 返回状态信息
    /// </summary>
    public class MyStatus
    {

        public MyStatus(int code,string msg)
        {
            Code = code;
            Msg = msg;
            Remark = "";
        }

        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 友情提示
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 重写ToString()返回JSON
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "{\"code\":\"" + Code + "\",\"msg\":\"" + Msg + "\",\"remark\":\"" + Remark + "\"}";
            return s;
            //return string.Format(s, Code.ToString(), Msg, Remark);
        }
    }
}