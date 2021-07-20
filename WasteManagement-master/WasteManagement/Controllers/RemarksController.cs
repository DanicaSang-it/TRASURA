using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class RemarksController : Controller
    {
        tbl_Remarks rem = new tbl_Remarks();
        tbl_user user = new tbl_user();
        // GET: Remarks
        [ActionName("Report")]
        public ActionResult Index()
        {
            ViewBag.user = user.Findtbl_user(Convert.ToInt32(Session["ID"]));
            var item = rem.Listtbl_Remarks();
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Remarks re)
        {
            var list = ModelState.Keys.ToList();
            list.ForEach(l =>
            {
                if (l.Contains("encBy."))
                {
                    if (l != "encBy.ID")
                    {
                        ModelState.Remove(l);
                    }
                }
            });
            if (ModelState.IsValid)
            {
                rem.Create(re);
                return RedirectToAction("Report");
            }
            return View();
        }

        public ActionResult Edit(int ID)
        {
            return View(rem.Findtbl_Remarks(ID));
        }

        [HttpPost]
        public ActionResult Edit(tbl_Remarks re)
        {
            var list = ModelState.Keys.ToList();
            list.ForEach(l =>
            {
                if (l.Contains("encBy."))
                {
                    if (l != "encBy.ID")
                    {
                        ModelState.Remove(l);
                    }
                }
            });
            if (ModelState.IsValid)
            {
                rem.Update(re);
                return RedirectToAction("Report");
            }
            return View();
        }
    }
}