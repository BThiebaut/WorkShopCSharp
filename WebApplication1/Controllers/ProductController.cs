﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Controllers.Base;
using WorkShop.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : BaseController<Product>
    {
        [Route("api/Products")]
        public override Task<IHttpActionResult> Post(IEnumerable<Product> values)
        {
            return base.Post(values);
        }

        [Route("api/Products")]
        public override Task<IHttpActionResult> Put(IEnumerable<Product> values)
        {
            return base.Put(values);
        }

        [Route("api/Products")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Product> values)
        {
            return base.Delete(values);
        }
    }
}
