using FirebaseNet.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumoTrack.Business.Test
{
    [TestClass]
    public class VehicleBusinessTest
    {
        [TestMethod]
        public void Can_I_Get_Vehicles_In_Range()
        {
            var vehicleBusiness = new VehiclesBusiness();

            var location = vehicleBusiness.GetVehiclesInRange("ad2ff71b980e9e1485f585b55fa36c7b", 32.548426, -116.907037).Result;

            Assert.IsNotNull(location);
        }


    }
}
