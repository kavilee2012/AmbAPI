using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<HttpResponseMessage> UploadImage()
        {
            MyResponse response = new MyResponse();

            string filePath = "~//UploadFiles//Photo";
            // 取得文件夹
            string dir = HttpContext.Current.Server.MapPath(filePath);
            //如果不存在文件夹，就创建文件夹
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new CustomMultipartFormDataStreamProvider(dir);
            try
            {
                // Read the form data. 
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    //接收文件
                    //Trace.WriteLine(file.Headers.ContentDisposition.FileName);//获取上传文件实际的文件名
                    //Trace.WriteLine(file.LocalFileName);
                }

                foreach (string key in provider.FormData.AllKeys)
                {
                   // dic.Add(key, provider.FormData[key]);

                }

                response.Code = StatusCode.Success;
            }
            catch
            {
                response.Code = StatusCode.Error;
            }

            return new HttpResponseMessage { Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/json") };

        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

//重写文件名保存
public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider 
{
    public CustomMultipartFormDataStreamProvider(string path)
        : base(path)
    { }

    public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
    {
        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        return fileName + "_" + headers.ContentDisposition.FileName.Replace("\"", string.Empty);//base.GetLocalFileName(headers);
    }
}