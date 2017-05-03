using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class BrandNameController : ApiController
    {
        [HttpPost]
        public List<A> GetBrandName()
        {
            KeChuangeEntities ke = new KeChuangeEntities();
            var ret = ke.youhoo_BasicArchive_brand.Select(x=>new A { id=x.id,name=x.Name});

            return ret.ToList();
        }

        public class A
        {
            public string name { get; set; }
            public int id { get; set; }

        }

    }
}
