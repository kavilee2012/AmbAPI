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

namespace AmbAPI.Controllers
{
    public class ReportController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Report
        public IEnumerable<Report> GetReports()
        {
            return db.Reports.AsEnumerable();
        }

        // GET api/Report/5
        public Report GetReport(int id)
        {
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return report;
        }

        // PUT api/Report/5
        public HttpResponseMessage PutReport(int id, Report report)
        {
            if (ModelState.IsValid && id == report.ID)
            {
                db.Entry(report).State = EntityState.Modified;

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

        // POST api/Report
        public HttpResponseMessage PostReport(Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, report);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = report.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Report/5
        public HttpResponseMessage DeleteReport(int id)
        {
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Reports.Remove(report);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, report);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}