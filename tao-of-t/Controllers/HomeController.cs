using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using tao_of_t.Viewmodel;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

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

            return View("About");
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services Provided";

            return View("Services");
        }

        public ActionResult Questions()
        {
            ViewBag.Message = "Common Questions";

            return View("Questions");
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

            return View("LinksResources");
        }

        public ActionResult Policy()
        {
            ViewBag.Message = "Privacy and Policy";

            return View("Policy");
        }

        public ActionResult ThankYou()
        {
            ViewBag.Message = "Thank You";
            return View();
        }

        [HttpGet]
        public ActionResult Schedule()
        {
            ViewBag.Message = "Schedule";
            ScheduleViewmodel viewmodel = new ScheduleViewmodel();

            return View(viewmodel);
        }
        
        [HttpPost]
        public ActionResult Schedule(ScheduleViewmodel person)
        {
            Regex ShortDate = new Regex(@"^\d{6}$");

            if (person.Firstname == null || person.Firstname.Trim().Length == 0)
            {
                ModelState.AddModelError("Firstname", "Firstname is required.");
            }
            if (person.Lastname == null || person.Lastname.Trim().Length == 0)
            {
                ModelState.AddModelError("Lastname", "Lastname is required.");
            }
            if (person.Phone == null || !Regex.IsMatch(person.Phone, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
            {
                ModelState.AddModelError("Phone", "Phone number is invalid.");
            }
            if (person.Email == null || !Regex.IsMatch(person.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                ModelState.AddModelError("Email", "Email format is invalid.");
            }
            if (ModelState.IsValid)
            {
                SendEmail(person);
                return RedirectToAction("ThankYou");
            }
            else
            {
                return View(person);
            }
        }

        public void SendEmail(ScheduleViewmodel person)
        {
            if (ModelState.IsValid)
            {
                 try
                 {
                     MailMessage message = new MailMessage();
                     message.From = new MailAddress(person.Email, person.Firstname + " " + person.Lastname);
                     message.To.Add(new MailAddress(WebConfigurationManager.AppSettings["sendToEmailAddress"].ToString(), "T Tirona"));
                     message.Subject = WebConfigurationManager.AppSettings["emailSubject"].ToString() + person.ScheduleTimeDate.ToShortDateString() + " at " + person.ScheduleTimeDate.ToShortTimeString();
                     message.Body = person.Concerns;
                     SmtpClient client = new SmtpClient(WebConfigurationManager.AppSettings["emailServer"].ToString(), Convert.ToInt32(WebConfigurationManager.AppSettings["emailPort"].ToString()));
                     client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["username"].ToString(), WebConfigurationManager.AppSettings["password"].ToString());
                     client.EnableSsl = true;
                     client.Send(message);
                 }
                 catch (Exception e)
                 {
                     ModelState.AddModelError("", "There was an issue with sending your email" + e.Message);
                 }
            }
        }
    }
}
