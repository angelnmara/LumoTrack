using LumoTrack.Business;
using LumoTrack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LumoTrack.API.Controllers
{
    [Route("inbox")]
    public class InboxController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hola");
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            try
            {
                IEnumerable<string> headerValues =  Request.Headers.GetValues("UserID");

                var userId = headerValues.FirstOrDefault();

                var inboxBusiness = new InboxBusiness();

                var inboxList = inboxBusiness.GetList(userId);

                return Ok(inboxList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("inbox/create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody]InboxDTO inboxDTO)
        {
            try
            {
                var inboxBusiness = new InboxBusiness();

                var inbox = inboxBusiness.Create(inboxDTO);

                return Ok(inbox);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
