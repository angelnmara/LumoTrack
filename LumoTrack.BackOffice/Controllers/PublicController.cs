using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LumoTrack.BackOffice.Controllers
{
    [AllowAnonymous]
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}