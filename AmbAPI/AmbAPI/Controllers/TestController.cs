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
        public string Get()
        {
            return "Get()";
        }

        public string Get(string id)
        {
            return "Get(a)";
        }

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
