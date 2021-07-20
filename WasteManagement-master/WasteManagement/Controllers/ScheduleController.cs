using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class ScheduleController : Controller
    {
        tbl_Schedule sched = new  tbl_Schedule  ();

        [ActionName("Dashboard")]
        public ActionResult Index()
        {
            var list = sched.Listtbl_Schedule();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Schedule sc)
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
                sched.Create(sc);
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public ActionResult Edit(int ID)
        {
            return View(sched.Findtbl_Schedule(ID));
        }

        [HttpPost]
        public ActionResult Edit(tbl_Schedule sc)
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
                sched.Update(sc);
                return RedirectToAction("Dashboard");
            }
            return View(sc);
        }

        public ActionResult Delete(int ID)
        {
            return View(sched.Findtbl_Schedule(ID));
        }

        [HttpPost]
        public ActionResult Delete(tbl_Schedule sc)
        {
            sched.Delete(sc);
            return RedirectToAction("Dashboard");
        }

    }
}