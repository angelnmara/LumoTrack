using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LumoTrack.Repository.Repositories;
using LumoTrack.Repository;
using LumoTrack.Model;

namespace LumoTrack.Business.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new LumoTrackContext();

            var userRepository = new UserRepository(context);

            var user = new User();

            var response = userRepository.Create(user);

            Assert.IsNotNull(response);
        }
    }
}
