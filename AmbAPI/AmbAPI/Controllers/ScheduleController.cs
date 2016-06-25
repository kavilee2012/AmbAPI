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
    public class ScheduleController : ApiController
    {
        private MyContext db = new MyContext();

        /// <summary>
        /// 获取某个用户的日程安排
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetList(string userCode)
        {
            MyResponse response = new MyResponse();
            try
            {
                List<Schedule> scList = db.Schedules.Where(X => X.UserCode == userCode).ToList();
                string json = JsonConvert.SerializeObject(scList);
                response.Count = scList.Count.ToString();
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
            return response.ToString();
        }

        /// <summary>
        /// 获取某条日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOne(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                Schedule schedule = db.Schedules.Find(id);
                if (schedule == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(schedule);
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
            return response.ToString();
        }


        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        public string Add(Schedule schedule)
        {
            MyResponse response = new MyResponse();
            try
            {
                db.Schedules.Add(schedule);
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


        /// <summary>
        /// 修改日程
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(Schedule schedule)
        {
            MyResponse response = new MyResponse();
            try
            {
                db.Entry(schedule).State = EntityState.Modified;
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

        
        /// <summary>
        /// 删除某条日程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Delete(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                Schedule schedule = db.Schedules.Find(id);
                if (schedule == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }

                db.Schedules.Remove(schedule);
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