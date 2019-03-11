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
    public class NotificationTest
    {
        [TestMethod]
        public void Can_I_Send_Message()
        {
            FCMClient client = new FCMClient("AAAAVLMjgxc:APA91bGUx4_NBJnnM51Jk1zp7cEqacWrNewfC-QsDe_4h7K_hqHFjFlzcDOfOP2ERdHGBDSmDg3nu0oK8P29Avl-Erw9p9z6P-YDzfL_nOcS7xPa8MbCG3x1yKEGWqWWUFuq-D_ZLhjO");

            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("title", "Lumotrack");
            keys.Add("body", "Love you Mario");
            var message = new FirebaseNet.Messaging.Message()
            {
                To = "/topics/all",
               Data=keys,
            };

            var result = client.SendMessageAsync(message).Result;
            Assert.IsNotNull(result);
        }
    }
}
