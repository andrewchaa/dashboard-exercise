using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.App.Board.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Pnl()
        {
            return View();
        }

        public ActionResult Capital()
        {
            return View();
        }

        public ActionResult DailyReturn()
        {
            return View();
        }

        public ActionResult React()
        {
            return View();
        }
    }
}
