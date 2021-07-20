using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement.Models;

namespace WasteManagement.Controllers
{
    public class BinsController : Controller
    {
        tbl_Bin b = new tbl_Bin();
        // GET: Bin
        public ActionResult Index()
        {
            return View(b.Listtbl_Bin());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Bin bin)
        {
            if (ModelState.IsValid)
            {
                b.Create(bin);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int ID)
        {
            var item = b.Findtbl_Bin(ID);
            item.DeploymentDate = $"{Convert.ToDateTime(item.DeploymentDate):yyyy-MM-dd}";
            return View();
        }

        [HttpPost]
        public ActionResult Edit(tbl_Bin bin)
        {
            if (ModelState.IsValid)
            {
                b.Update(bin);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}