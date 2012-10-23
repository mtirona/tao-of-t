using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using tao_of_t.Viewmodel;

namespace tao_of_t.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Tao-of-T";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "All about me.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services Provided";

            return View();
        }

        public ActionResult Questions()
        {
            ViewBag.Message = "Common Questions";

            return View();
        }

        public ActionResult Appointment()
        {
            ViewBag.Message = "Appointment Request";
            HomeViewmodel viewModel = new HomeViewmodel();
            viewModel.GoogleCalendarUrl = WebConfigurationManager.AppSettings["gCalendarUrl"].ToString();

            return View(viewModel);
        }


        public ActionResult LinksResources()
        {
            ViewBag.Message = "Links and Resources";

            return View();
        }

        public ActionResult Policy()
        {
            ViewBag.Message = "Privacy and Policy";

            return View();
        }
    }
}
