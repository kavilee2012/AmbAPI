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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AmbAPI.Models;
using Newtonsoft.Json;

namespace AmbAPI.Controllers
{
    public class PhotoController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Photo
        [HttpGet]
        public HttpResponseMessage GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<Photo> mList = db.Photo.ToList();
                string json = JsonConvert.SerializeObject(mList);
                response.Data = json;
                response.Count = mList.Count.ToString();
            }
            catch
            {
                response.Code = StatusCode.Error;
            }
            //return response.ToString();
            return new HttpResponseMessage { Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/json") };
        }

        // GET api/Photo/5
        [HttpGet]
        public string GetOne(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                Photo photo = db.Photo.Find(id);
                if (photo == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(photo);
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

            string filePath = "~\\UploadFiles\\Photo";
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
                    //file.Headers.ContentDisposition.FileName;//上传文件前的文件名
                    //file.LocalFileName;//上传后的文件名
                    Photo p = new Photo();
                    p.ImgInfo = file.LocalFileName.Substring(file.LocalFileName.LastIndexOf("\\"));
                    p.Sort = "员工相册";
                    p.AddUser = "admin";
                    p.AddTime = DateTime.Now;
                    p.Url = filePath + p.ImgInfo;

                    db.Photo.Add(p);
                    db.SaveChanges();
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


        //public HttpResponseMessage DownloadImage(string url)
        //{
        //    //string filePath = HttpContext.Current.Server.MapPath(url);
        //    //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read,FileShare.Read);
        //    //HttpResponseMessage respone = new HttpResponseMessage();
        //    //respone.Content = new StreamContent(fs);
        //    //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        //    //response.Content.Headers.ContentDisposition.FileName = customFileName;
        //    //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");  // 这句话要告诉浏览器要下载文件  
        //    //response.Content.Headers.ContentLength = new FileInfo(filePath).Length;
        //    //return response;  
        //}


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

    //重写上传文件名
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