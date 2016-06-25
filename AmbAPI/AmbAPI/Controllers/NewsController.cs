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
    public class NewsController : ApiController
    {
        private MyContext db = new MyContext();

        
        /// <summary>
        /// 获取全部新闻列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<News> newsList = db.News.ToList();
                string json = JsonConvert.SerializeObject(newsList);
                response.Data = json;
                response.Count = newsList.Count.ToString();
            }
            catch 
            {
                response.Code = StatusCode.Error;
            }
            return response.ToString();
        }


        /// <summary>
        /// 获取单个新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOne(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                News news = db.News.Find(id);
                if (news == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json=JsonConvert.SerializeObject(news);
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


        //[HttpGet]
        //public HttpResponseMessage Update(int id, News news)
        //{
        //    if (ModelState.IsValid && id == news.ID)
        //    {
        //        db.Entry(news).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}


        /// <summary>
        /// 删除单条新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        public string Delete(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                News news = db.News.Find(id);
                if (news == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                db.News.Remove(news);
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