using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Controllers.Base;
using WorkShop.Entities;

namespace WebApplication1.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        [Route("api/Customers")]
        public override Task<IHttpActionResult> Post(IEnumerable<Customer> values)
        {
            return base.Post(values);
        }

        [Route("api/Customers")]
        public override Task<IHttpActionResult> Put(IEnumerable<Customer> values)
        {
            return base.Put(values);
        }

        [Route("api/Customers")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Customer> values)
        {
            return base.Delete(values);
        }
    }
}
