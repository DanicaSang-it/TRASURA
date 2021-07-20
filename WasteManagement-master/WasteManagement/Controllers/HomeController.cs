using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WasteManagement.Controllers
{
    public class HomeController : Controller
    {
        [ActionName("Schedule")]
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Home")]
        public ActionResult Home()
        {
            ViewBag.datenow = $"{DateTime.Now:yyyy-MM-dd}";
            return View();
        }

    }
}