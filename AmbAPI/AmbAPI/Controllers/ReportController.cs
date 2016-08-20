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
    public class ReportController : ApiController
    {
        private MyContext db = new MyContext();

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<Report> list = db.Reports.ToList();
                string json = JsonConvert.SerializeObject(list);
                response.Count = list.Count.ToString();
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
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOne(string id)
        {
            MyResponse response = new MyResponse();
            try
            {
                Report m = db.Reports.Find(id);
                if (m == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(m);
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

        //// PUT api/Report/5
        //public HttpResponseMessage PutReport(int id, Report report)
        //{
        //    if (ModelState.IsValid && id == report.ID)
        //    {
        //        db.Entry(report).State = EntityState.Modified;

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

        //// POST api/Report
        //public HttpResponseMessage PostReport(Report report)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Reports.Add(report);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, report);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = report.ID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// DELETE api/Report/5
        //public HttpResponseMessage DeleteReport(int id)
        //{
        //    Report report = db.Reports.Find(id);
        //    if (report == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Reports.Remove(report);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, report);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}