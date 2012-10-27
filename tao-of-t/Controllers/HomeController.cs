using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using tao_of_t.Viewmodel;
using System.Text.RegularExpressions;

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

        public ActionResult Schedule()
        {
            ViewBag.Message = "Schedule";

            return View();
        }

        public ActionResult Send(ScheduleViewmodel viewmodel)
        {
            ViewBag.Message = "Send";

            return View("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(ScheduleViewmodel person)
        {
            if (person.Firstname.Trim().Length == 0)
            {
                ModelState.AddModelError("Firstname", "Firstname is required.");
            }
            if (person.Lastname.Trim().Length == 0)
            {
                ModelState.AddModelError("Lastname", "Lastname is required.");
            }
            if (!Regex.IsMatch(person.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            {
                ModelState.AddModelError("Phone", "Phone number is invalid.");
            }
            if (!Regex.IsMatch(person.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                ModelState.AddModelError("Email", "Email format is invalid.");
            }
            if (!ModelState.IsValid)
            {
                Send(person);
                return View("Schedule");
            }

            return RedirectToAction("Index");
        }
    }
}
