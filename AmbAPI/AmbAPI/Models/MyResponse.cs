using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{

    /// <summary>
    /// 返回状态信息
    /// </summary>
    public class MyResponse
    {
        public MyResponse()
        {
            Code = StatusCode.Success;
            Msg = "";
            Count = "";
            Data = "";
        }


        public MyResponse(StatusCode code)
        {
            Code = code;
            Msg = "";
            Count = "";
            Data = "";
        }

        /// <summary>
        /// 返回码
        /// </summary>
        public StatusCode Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据条数
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// 返回数据集
        /// </summary>
        public string Data { get; set; }


        /// <summary>
        /// 重写ToString()返回JSON
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Msg = EnumService.GetDescription(Code);
            string s = "{\"code\":\"" + (int)Code + "\",\"msg\":\"" + Msg + "\",\"count\":\"" + Count + "\",\"data\":\"" + Data + "\"}";
            return s;
        }
    }
}