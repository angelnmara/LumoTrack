using FirebaseNet.Messaging;
using LumoTrack.Business;
using LumoTrack.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace LumoTrack.BackOffice.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            try
            {
                var notificationBusiness = new NotificationBusiness();

                var notificationList = notificationBusiness.GetList();

                return View("Index", notificationList);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(NotificationDTO notification)
        {
            try
            {
                var isValid = CheckDateTimes(notification);

                if (!ModelState.IsValid)
                {
                    return View(notification);
                }


                if (!isValid)
                    return View(notification);

                notification.UserId = User.Identity.GetUserId();
                notification.CreationDate = DateTime.Now;

                var notificationBusiness = new NotificationBusiness();
                var response = notificationBusiness.Create(notification);

                string firebaseServerKey = ConfigurationSettings.AppSettings["fireBaseServerKey"];
                string restrictedPackageName = ConfigurationSettings.AppSettings["restrictedPackageName"];

                await PushNotification(response, firebaseServerKey, restrictedPackageName);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        private bool CheckDateTimes(NotificationDTO notification)
        {
            bool isValid = true;

            var timeZone = ConfigurationSettings.AppSettings["timezone"];

            TimeZoneInfo timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            DateTime currentDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);

            if (currentDate.Date > notification.NotificationDate)
            {
                ModelState.AddModelError("NotificationDate", "Verifique las fechas");
                isValid = false;
            }
            if (currentDate.Date > notification.ExpiryDate)
            {
                ModelState.AddModelError("ExpiryDate", "Verifique las fechas");
                isValid = false;
            }

            return isValid;
        }

        private async Task<NotificationDTO> PushNotification(NotificationDTO notificationDTO, string serverKey, string appRestrictedPackage)
        {
            FCMClient client = new FCMClient(serverKey);

            Dictionary<string, string> keys = new Dictionary<string, string>();

            keys.Add("title", notificationDTO.Title);
            keys.Add("body", notificationDTO.Message);
            keys.Add("Action", "Notification");

            var message = new FirebaseNet.Messaging.Message()
            {
                To = "/topics/allandroid",
                Data = keys,
            };

            var androidResult = await client.SendMessageAsync(message);

            var notificationIOS = new IOSNotification();
            notificationIOS.Title = notificationDTO.Title;
            notificationIOS.Body = notificationDTO.Message;
            notificationIOS.ClickAction = "Notification";


            message.To = "/topics/allios";

            message.Notification = notificationIOS;

            var iosResult = await client.SendMessageAsync(message);

            return notificationDTO;
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var notificationBusiness = new NotificationBusiness();

                var notification = notificationBusiness.Read(id);

                return View("Edit", notification);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }

        }

        [HttpPost]
        public ActionResult Edit(NotificationDTO notification)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(notification);

                var notificationBusiness = new NotificationBusiness();

                notification.UserId = User.Identity.GetUserId();

                var response = notificationBusiness.Update(notification);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var notificationBusiness = new NotificationBusiness();

                var notification = notificationBusiness.Read(id);

                return View("Delete", notification);
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(NotificationDTO notification)
        {
            try
            {
                var notificationBusiness = new NotificationBusiness();

                bool response = notificationBusiness.Delete(notification.Id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", "Error");
            }
        }
    }
}