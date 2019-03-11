using LumoTrack.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LumoTrack.API.Controllers
{
    [Route("notification")]
    public class NotificationController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var notificationBusiness = new NotificationBusiness();

                var notificationList = notificationBusiness.GetList();

                return Ok(notificationList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
