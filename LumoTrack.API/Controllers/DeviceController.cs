using LumoTrack.Business;
using LumoTrack.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LumoTrack.API.Controllers
{
    [Route("device")]
    public class DeviceController : ApiController
    {
        [Route("device/register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(DeviceDTO device)
        {
            try
            {
                var deviceBusiness = new DeviceBusiness();

                var deviceResponse = deviceBusiness.Register(device);

                return Ok(deviceResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [Route("device")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]DeviceDTO device)
        {
            try
            {
                var deviceBusiness = new DeviceBusiness();

                device.TimeZone = ConfigurationManager.AppSettings["timezone"];

                var deviceResponse = deviceBusiness.Upsert(device);

                return Ok(deviceResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
