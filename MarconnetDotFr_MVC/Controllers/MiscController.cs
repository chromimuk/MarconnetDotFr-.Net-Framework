using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarconnetDotFr_MVC.Controllers
{
    public class MiscController : Controller
    {
        public ActionResult AbraCanada()
        {
            double nbDays = Math.Round((new DateTime(2020, 5, 21) - DateTime.Now).TotalDays, 0);
            return View(nbDays);
        }
    }
}