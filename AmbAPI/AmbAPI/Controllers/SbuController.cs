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
    public class SbuController : ApiController
    {
        private MyContext db = new MyContext();

        /// <summary>
        /// 获取全部SBU
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<SBU> sbuList = db.SBU.ToList();
                string json = JsonConvert.SerializeObject(sbuList);
                response.Count = sbuList.Count.ToString();
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
        /// 获取单个SBU
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOne(string id)
        {
            MyResponse response = new MyResponse();
            try
            {
                SBU sbu = db.SBU.Find(id);
                if (sbu == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(sbu);
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
        /// 添加SBU
        /// </summary>
        /// <param name="sbu"></param>
        /// <returns></returns>
        [HttpPost]
        public string Add(SBU sbu)
        {
            MyResponse response = new MyResponse();
            try
            {
                SBU _sbu = db.SBU.FirstOrDefault(X=>X.Name==sbu.Name);
                if (_sbu != null)
                {
                    throw new Exception(StatusCode.ObjectHadExist.ToString());
                }
                db.SBU.Add(sbu);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Message == StatusCode.ObjectHadExist.ToString())
                {
                    response.Code = StatusCode.ObjectHadExist;
                }
                else
                {
                    response.Code = StatusCode.Error;
                }
            }
            return response.ToString();
        }


        /// <summary>
        /// 修改SBU
        /// </summary>
        /// <param name="sbu"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(SBU sbu)
        {
            MyResponse response = new MyResponse();
            try
            {
                //判断要改的新名字是否存在
                SBU _sbu = db.SBU.Find(sbu.Name);
                if (_sbu == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                db.Entry(sbu).State=EntityState.Modified;
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
        /// 删除SBU
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Delete(string id)
        {
            MyResponse response = new MyResponse();
            try
            {
                SBU sbu = db.SBU.Find(id);
                if (sbu == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }

                db.SBU.Remove(sbu);
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