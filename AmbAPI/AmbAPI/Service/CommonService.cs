using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace AmbAPI.Service
{
    public class CommonService
    {

        /// <summary>
        /// 解析GET请求携带的JSON参数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static dynamic ParseHttpGetJson(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                try
                {
                    var json = query.Substring(7, query.Length - 7);  // the number 7 is for data=
                    json = System.Web.HttpUtility.UrlDecode(json);
                    dynamic queryJson = JsonConvert.DeserializeObject<dynamic>(json);

                    return queryJson;
                }
                catch (System.Exception e)
                {
                    throw new ApplicationException("wrong json format in the query string！", e);
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 字符串转MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrToMD5(string str)
        {
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] OutBytes = md5.ComputeHash(data);

            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }

    }
}