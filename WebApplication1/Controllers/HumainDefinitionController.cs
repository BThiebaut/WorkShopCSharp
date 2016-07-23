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
    public class HumainDefinitionController : BaseController<HumainDefinition>
    {
        [Route("api/HumainDefinitions")]
        public override Task<IHttpActionResult> Post(IEnumerable<HumainDefinition> values)
        {
            return base.Post(values);
        }

        [Route("api/HumainDefinitions")]
        public override Task<IHttpActionResult> Put(IEnumerable<HumainDefinition> values)
        {
            return base.Put(values);
        }

        [Route("api/HumainDefinitions")]
        public override Task<IHttpActionResult> Delete(IEnumerable<HumainDefinition> values)
        {
            return base.Delete(values);
        }
    }
}
