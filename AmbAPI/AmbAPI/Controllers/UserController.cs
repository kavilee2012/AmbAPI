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
            MyStatus status = new MyStatus(1, "成功");
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(mobile))
            {
                status.Code = 0;
                status.Msg = "字段为空";
                return status.ToString();
            }

            User user = new Models.User()
            {
                UserCode = code,
                Mobile = mobile,
                Password = pwd,
                Birthday=DateTime.Now
            };

            try
            {
                db.User.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                status.Code = 0;
                status.Msg = "保存异常";
                status.Remark = ex.Message;
            }
            return status.ToString();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="code">用户代号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public string Login(string code, string pwd)
        {
            MyStatus status = new MyStatus(0, "登录失败");
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(pwd))
            {
                status.Msg = "字段为空";
                return status.ToString();
            }
            User user = db.User.FirstOrDefault<User>(X => X.UserCode == code & X.Password == pwd);
            if (user == null)
            {
                status.Msg = "用户不存在";
                return status.ToString();
            }
            string json = JsonConvert.SerializeObject(user);
            return json;
        }


        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {

            return "json";
        }

        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="code">用户代号</param>
        /// <returns>JSON格式用户信息</returns>
        public string GetOne(string code)
        {
            return "";
        }


     


        // PUT api/User/5
        public HttpResponseMessage Update(int id, User user)
        {
            if (ModelState.IsValid && id == user.ID)
            {
                db.Entry(user).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

      

        //// DELETE api/User/5
        //public HttpResponseMessage DeleteUser(int id)
        //{
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.User.Remove(user);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, user);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}