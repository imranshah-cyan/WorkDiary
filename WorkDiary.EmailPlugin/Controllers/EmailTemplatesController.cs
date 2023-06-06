using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmailPlugin.Models;
using EmailPlugin.Repositories;

namespace EmailPlugin.Controllers
{
    public class EmailTemplatesController : Controller
    {
        public ActionResult DisplayHeader()
        {
            return View();
        }
        public ActionResult DisplayFooter()
        {
            return View();
        }
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult DailyWorkSummary()
        {
            var model = new vmDailyWork();
            return View(model);
        }

        public ActionResult DailyWorkStatus()
        {
            var model = new vmDailyWork();
            return View(model);
        }

        public ActionResult WorkSummary()
        {
            var model = new vmDailyWork();
            return View(model);
        }

        public ActionResult GetScreenLogs(int providerId, int jobId, DateTime createdOn)
        {
            var userRepo = new UserRepository();
            var screenLogs = userRepo.GetScreenLogs(providerId, jobId, createdOn);
            return Json(screenLogs, JsonRequestBehavior.AllowGet);
        }
        
    }
}