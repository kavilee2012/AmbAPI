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
        /// 获取根列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetList()
        {
            MyResponse response = new MyResponse();
            try
            {
                List<AccountReport> reportList = db.AccountReport.Where(X => X.Level == 0).ToList();
                string json = JsonConvert.SerializeObject(reportList);
                response.Count = reportList.Count.ToString();
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
        /// 根据父ID获取子列表
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetList(int fid)
        {
            MyResponse response = new MyResponse();
            try
            {
                List<AccountReport> reportList = db.AccountReport.Where(X => X.FatherID == fid).ToList();
                string json = JsonConvert.SerializeObject(reportList);
                response.Count = reportList.Count.ToString();
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
        /// 获取单个报表项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetOne(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                AccountReport accountreport = db.AccountReport.Find(id);
                if (accountreport == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                string json = JsonConvert.SerializeObject(accountreport);
                response.Data = json;
            }
            catch(Exception ex)
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
        /// 添加报表项
        /// </summary>
        /// <param name="accountreport"></param>
        /// <returns></returns>
        [HttpPost]
        public string Add(AccountReport accountreport)
        {
            MyResponse response = new MyResponse();
            try
            {
                db.AccountReport.Add(accountreport);
                db.SaveChanges();
            }
            catch
            {
                response.Code = StatusCode.Error;
            }
            return response.ToString();
        }


        /// <summary>
        /// 修改报表项
        /// </summary>
        /// <param name="accountreport"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(AccountReport accountreport)
        {
            MyResponse response = new MyResponse();
            try
            {
                db.Entry(accountreport).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                response.Code = StatusCode.Error;
            }
            return response.ToString();
        }

        
        /// <summary>
        /// 删除报表项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Delete(int id)
        {
            MyResponse response = new MyResponse();
            try
            {
                AccountReport accountreport = db.AccountReport.Find(id);
                if (accountreport == null)
                {
                    throw new Exception(StatusCode.ObjectNotFound.ToString());
                }
                db.AccountReport.Remove(accountreport);
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