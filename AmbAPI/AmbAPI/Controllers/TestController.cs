using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmbAPI.Controllers
{
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string json = "{\"errNum\":300202,\"errMsg\":\"Missing apikey\"}";
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

        //public string Get()
        //{
        //    return "{\"errNum\":300202,\"errMsg\":\"Missing apikey\"}";
        //}

        public string PostX()
        {
            return "Post(a)";
        }

        public string Put()
        {
            return "Put(a)";
        }

        public string Delete()
        {
            return "DeleteA(a)";
        }
    }
}
