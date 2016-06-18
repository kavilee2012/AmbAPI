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
    public class NoticeController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Notice
        public IEnumerable<Notice> GetNotices()
        {
            return db.Notice.AsEnumerable();
        }

        // GET api/Notice/5
        public Notice GetNotice(int id)
        {
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return notice;
        }

        // PUT api/Notice/5
        public HttpResponseMessage PutNotice(int id, Notice notice)
        {
            if (ModelState.IsValid && id == notice.ID)
            {
                db.Entry(notice).State = EntityState.Modified;

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

        // POST api/Notice
        public HttpResponseMessage PostNotice(Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Notice.Add(notice);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, notice);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = notice.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Notice/5
        public HttpResponseMessage DeleteNotice(int id)
        {
            Notice notice = db.Notice.Find(id);
            if (notice == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Notice.Remove(notice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, notice);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}