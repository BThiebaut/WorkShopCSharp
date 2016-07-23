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
    public class ContactController : BaseController<Contact>
    {
        [Route("api/Contacts")]
        public override Task<IHttpActionResult> Post(IEnumerable<Contact> values)
        {
            return base.Post(values);
        }

        [Route("api/Contacts")]
        public override Task<IHttpActionResult> Put(IEnumerable<Contact> values)
        {
            return base.Put(values);
        }

        [Route("api/Contacts")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Contact> values)
        {
            return base.Delete(values);
        }
    }
}
