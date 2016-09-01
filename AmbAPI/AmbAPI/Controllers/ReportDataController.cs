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
    public class ReportDataController : ApiController
    {
        private MyContext db = new MyContext();

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList(string ym)
        {
            MyResponse response = new MyResponse();
            try
            {
                List<ReportData> list = db.ReportDatas.Where(X => X.YM == ym).ToList();
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

        // PUT api/ReportData/5
        public HttpResponseMessage PutReportData(int id, ReportData reportdata)
        {
            if (ModelState.IsValid && id == reportdata.ID)
            {
                db.Entry(reportdata).State = EntityState.Modified;

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

        // POST api/ReportData
        public HttpResponseMessage PostReportData(ReportData reportdata)
        {
            if (ModelState.IsValid)
            {
                db.ReportDatas.Add(reportdata);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, reportdata);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = reportdata.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/ReportData/5
        public HttpResponseMessage DeleteReportData(int id)
        {
            ReportData reportdata = db.ReportDatas.Find(id);
            if (reportdata == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ReportDatas.Remove(reportdata);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, reportdata);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}