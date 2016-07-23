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
    public class OwnerController : BaseController<Owner>
    {
        [Route("api/Owners")]
        public override Task<IHttpActionResult> Post(IEnumerable<Owner> values)
        {
            return base.Post(values);
        }

        [Route("api/Owners")]
        public override Task<IHttpActionResult> Put(IEnumerable<Owner> values)
        {
            return base.Put(values);
        }

        [Route("api/Owners")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Owner> values)
        {
            return base.Delete(values);
        }
    }
}
