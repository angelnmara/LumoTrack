using FirebaseNet.Messaging;
using LumoTrack.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LumoTrack.Business.Test
{
    [TestClass]
    public class DevicesBusinessTest
    {
        [TestMethod]
        public void Can_I_Register_A_Device()
        {
           

            var devicesBusiness = new DeviceBusiness();

            var deviceDTO = new DeviceDTO();

            deviceDTO.FireBaseToken = "";
            deviceDTO.LastNotification = DateTime.Now;
            deviceDTO.Latitude = 21.2;
            deviceDTO.Longitude = 21.2;




            var response = devicesBusiness.Register(deviceDTO);

            Assert.IsNotNull(response);
        }
    }
}
