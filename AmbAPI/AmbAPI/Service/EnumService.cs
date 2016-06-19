using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AmbAPI
{
    public class EnumService
    {
        /// <summary>
        /// 获取描述信息
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }


    }

    /// <summary>
    /// 返回代码
    /// </summary>
    public enum StatusCode 
    { 
        [Description("成功")]
        Success = 0,

        [Description("失败")]
        Fail = 1,

        [Description("错误")]
        Error=2,

        [Description("参数不能为空")]
        ArgsNull=3,

        [Description("用户已存在")]
        UserHadExist=4,

        [Description("用户不存在")]
        UserNotFound=5
    }
}