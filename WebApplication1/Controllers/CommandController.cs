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
    public class CommandController : BaseController<Command>
    {
        [Route("api/Commands")]
        public override Task<IHttpActionResult> Post(IEnumerable<Command> values)
        {
            return base.Post(values);
        }

        [Route("api/Commands")]
        public override Task<IHttpActionResult> Put(IEnumerable<Command> values)
        {
            return base.Put(values);
        }

        [Route("api/Commands")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Command> values)
        {
            return base.Delete(values);
        }
    }
}