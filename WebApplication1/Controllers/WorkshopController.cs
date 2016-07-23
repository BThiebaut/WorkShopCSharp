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
    public class WorkshopController : BaseController<Workshop>
    {
        [Route("api/Workshops")]
        public override Task<IHttpActionResult> Post(IEnumerable<Workshop> values)
        {
            return base.Post(values);
        }

        [Route("api/Workshops")]
        public override Task<IHttpActionResult> Put(IEnumerable<Workshop> values)
        {
            return base.Put(values);
        }

        [Route("api/Workshops")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Workshop> values)
        {
            return base.Delete(values);
        }
    }
}
