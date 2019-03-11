using FirebaseNet.Messaging;
using LumoTrack.Business;
using LumoTrack.Business.Manager;
using LumoTrack.Common;
using LumoTrack.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LumoTrack.BackOffice.Controllers
{
    [Authorize]
    public class InboxController : Controller
    {
        private UserManager _userManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Inbox
        public ActionResult Index()
        {
            try
            {
                var inboxBusiness = new InboxBusiness();

                var response = inboxBusiness.GetList();

                return View("Index", response);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var inboxBusiness = new InboxBusiness();

                InboxDTO inboxDTO = inboxBusiness.Read(id);

                return View("Edit", inboxDTO);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Edit(InboxDTO inboxDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(inboxDTO);

                var notificationBusiness = new InboxBusiness();

                var devicesBusiness = new DeviceBusiness();


                var devices = devicesBusiness.GetUser(inboxDTO.UserId);

                if (devices != null)
                {
                    await PushNotification(inboxDTO, devices.FireBaseToken, devices.devicesType);
                }
                inboxDTO.UserResponseId = User.Identity.GetUserId();
                inboxDTO.ResponseDate = DateTime.Now;



                InboxDTO response = notificationBusiness.Update(inboxDTO);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        private async System.Threading.Tasks.Task PushNotification(InboxDTO inboxDTO, string FireBaseUserToken, DeviceTypesEnum devicesType)
        {
            string firebaseServerKey = ConfigurationSettings.AppSettings["fireBaseServerKey"];
            string restrictedPackageName = ConfigurationSettings.AppSettings["restrictedPackageName"];

            FCMClient client = new FCMClient(firebaseServerKey);

            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("title", " Mensaje respondido.");
            keys.Add("body", inboxDTO.Response);
            keys.Add("Action", "Inbox");


            var message = new FirebaseNet.Messaging.Message()
            {
                To = FireBaseUserToken,
                Data = keys,
            };

            if (devicesType == DeviceTypesEnum.IOS)
            {
                var notificationIOS = new IOSNotification();
                notificationIOS.Title = "Mensaje respondido.";
                notificationIOS.Body = inboxDTO.Message;
                notificationIOS.ClickAction = "Inbox";

                
                message.Notification = notificationIOS;
            }

            var result = await client.SendMessageAsync(message);

        }
    }
}