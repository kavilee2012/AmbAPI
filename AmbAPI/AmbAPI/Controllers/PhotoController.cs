using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AmbAPI.Models;

namespace AmbAPI.Controllers
{
    public class PhotoController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Photo
        public IEnumerable<Photo> GetPhotos()
        {
            return db.Photo.AsEnumerable();
        }

        // GET api/Photo/5
        public Photo GetPhoto(int id)
        {
            Photo photo = db.Photo.Find(id);
            if (photo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return photo;
        }

        // PUT api/Photo/5
        public HttpResponseMessage PutPhoto(int id, Photo photo)
        {
            if (ModelState.IsValid && id == photo.ID)
            {
                db.Entry(photo).State = EntityState.Modified;

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

        // POST api/Photo
        public HttpResponseMessage PostPhoto(Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Photo.Add(photo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, photo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = photo.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Photo/5
        public HttpResponseMessage DeletePhoto(int id)
        {
            Photo photo = db.Photo.Find(id);
            if (photo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Photo.Remove(photo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, photo);
        }


        [HttpPost]
        public HttpResponseMessage UploadImage()
        {
            string filePath = "~//UploadFiles//Photo";
            string fileType = "";
            string fileName = "";//DateTime.Now.ToString("yyyyMMddHHmmssfff");
            try
            {
                fileType = "";
                fileName = fileName + fileType;
                // 取得文件夹
                string dir = fileName.Substring(0, fileName.LastIndexOf("\\"));
                //如果不存在文件夹，就创建文件夹
                
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                

                foreach (string f in HttpContext.Current.Request.Files.AllKeys)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[f];
                    file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(filePath + fileName));
                }  
            }
            catch
            {
                
            }



            return null;

        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}