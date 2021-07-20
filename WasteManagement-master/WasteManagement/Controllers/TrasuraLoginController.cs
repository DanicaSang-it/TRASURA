using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class TrasuraLoginController : Controller
    {
        tbl_user user = new tbl_user();
        // GET: TrasuraLogin

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var item = user.Login(username, password);
            if (!string.IsNullOrEmpty(item.Username))
            {
                Session["ID"] = item.ID;
                if (item.isAdmin)
                {
                    return RedirectToAction("Dashboard", "Schedule");
                }
                else
                {
                    return RedirectToAction("Report", "Remarks");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tbl_user u)
        {
            if (ModelState.IsValid)
            {
                var result = user.Create(u);
                if (!result)
                {
                    ModelState.AddModelError("", "Username is already taken.");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        } 

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Home");
        }
    }
}