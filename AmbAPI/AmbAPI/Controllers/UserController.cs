using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AmbAPI.Models;
using AmbAPI.Service;
using Newtonsoft.Json;

namespace AmbAPI.Controllers
{
    public class UserController : ApiController
    {
        private MyContext db = new MyContext();
        

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="code">用户代号</param>
        /// <param name="pwd">密码</param>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        public string Register(string code, string pwd, string mobile)
        {
            MyResponse response = new MyResponse();
            try
            {
                if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(mobile))
                {
                    throw new Exception(StatusCode.ArgsNull.ToString());
                }

                User user = new User()
                {
                    UserCode = code,
                    Mobile = mobile,
                    Password = pwd
                };


                User u = db.User.FirstOrDefault<User>(X => X.UserCode == user.UserCode);
                if (u != null)
                {
                    throw new Exception(StatusCode.ObjectHadExist.ToString());
                }

                db.User.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ArgsNull.ToString())
                {
                    response.Code = StatusCode.ArgsNull;
                }
                else if (ex.Message == StatusCode.ObjectHadExist.ToString())
                {
                    response.Code = StatusCode.ObjectHadExist;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }
            return response.ToString();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="code">用户代号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Login(string code, string pwd)
        {
            MyResponse response = new MyResponse();
            try
            {
                if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(pwd))
                {
                    throw new Exception(StatusCode.ArgsNull.ToString());
                }
                User user = db.User.FirstOrDefault<User>(X => X.UserCode == code & X.Password == pwd);
                if (user == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }

                string token = CommonService.StrToMD5(code + pwd); //验证通过返回token,并保存到数据库

                AmbToken oldToken = db.AmbToken.FirstOrDefault<AmbToken>(X => X.Token == token);
                if (oldToken != null)
                {
                    db.AmbToken.Remove(oldToken);
                    db.SaveChanges();
                }

                AmbToken m = new AmbToken();
                m.Token = token;
                m.Code = code;
                m.ExpireTime = DateTime.Now.AddMonths(1);
                db.AmbToken.Add(m);
                db.SaveChanges();



                string json = JsonConvert.SerializeObject(token);
                response.Data = json;
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ArgsNull.ToString())
                {
                    response.Code = StatusCode.ArgsNull;
                }
                else if (ex.Message == StatusCode.ObjectNotFound.ToString())
                {
                    response.Code = StatusCode.ObjectNotFound;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }

            return new HttpResponseMessage { Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="code">用户代号</param>
        /// <returns>JSON格式用户信息</returns>
        [HttpGet]
        public HttpResponseMessage GetOne(string token)
        {
            MyResponse response = new MyResponse();
            try
            {
                AmbToken t = db.AmbToken.FirstOrDefault<AmbToken>(X => X.Token == token);
                if (t == null) 
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }

                User u = db.User.FirstOrDefault<User>(X => X.UserCode == t.Code);
                if (u == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(u);
                response.Data = json;
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ObjectNotFound.ToString())
                {
                    response.Code = StatusCode.ObjectNotFound;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }
            return new HttpResponseMessage { Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/json") };
        }

        
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<User> userList = db.User.ToList();
                string json = JsonConvert.SerializeObject(userList);
                response.Count = userList.Count.ToString();
                response.Data = json;
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ObjectNotFound.ToString())
                {
                    response.Code = StatusCode.ObjectNotFound;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }
            //return response.ToString();
            return new HttpResponseMessage { Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/json") };

        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(User user)
        {
            MyResponse response = new MyResponse();
            try
            {
                HttpRequestMessage rm = new HttpRequestMessage();
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                response.Code = StatusCode.Error;
            }
            return response.ToString();
        }


        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id">用户代号</param>
        /// <returns></returns>
        [HttpPost]
        public string Delete(string code)
        {
            MyResponse response = new MyResponse();
            try
            {
                User user = db.User.Find(code);
                if (user == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                db.User.Remove(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ObjectNotFound.ToString())
                {
                    response.Code = StatusCode.ObjectNotFound;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }
            return response.ToString();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}