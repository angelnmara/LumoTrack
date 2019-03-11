using LumoTrack.API.Helpers;
using LumoTrack.Business;
using LumoTrack.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace LumoTrack.API.Controllers
{
    [Route("vehicles")]
    public class VehiclesController : ApiController
    {
        private readonly HttpClient _httpClient;
        private readonly HashHelper _hashHelper;

        [Inject]
        public VehiclesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _hashHelper = new HashHelper(_httpClient);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(LumoLocationDTO location)
        {
            try
            {
                string token = await _hashHelper.GetHash();

                var vehiclesBusiness = new VehiclesBusiness();

                var vehiclesInRange = await vehiclesBusiness.GetVehiclesInRange(token, location.Latitude, location.Longitude);

                return Ok(vehiclesInRange);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [Route("vehicles/trucks")]
        [HttpPost]
        public async Task<IHttpActionResult> Trucks([FromBody]string hash)
        {
            try
            {
                string token = await _hashHelper.GetHash();

                var vehiclesBusiness = new VehiclesBusiness();

                var vehiclesInRange = await vehiclesBusiness.GetVehicles(token);

                return Ok(vehiclesInRange);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

    }
}