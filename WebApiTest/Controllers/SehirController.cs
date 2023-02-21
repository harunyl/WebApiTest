using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class SehirController : ApiController
    {
        ////Örnek 1
        //public string[] Get()
        //{
        //    return new string[] {"İstanbul","Ankara","Bursa" };
        //}

        //Örnek 2 Array dizisi ile api sorgulama
        private string[] sehirler = { "İstanbul", "Ankara", "Bursa" };

        public string[] Get()
        {
            return sehirler;
        }

        public string Get(int id)
        {
            return sehirler[id];
        }

    }
}
