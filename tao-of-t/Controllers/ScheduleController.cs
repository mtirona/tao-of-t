using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tao_of_t.Models;

namespace tao_of_t.Controllers
{
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Schedule");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(ScheduleModels model)
        {
            // Validate the model being submitted
            if (!ModelState.IsValid)
            {
                // If the incoming request is an Ajax Request 
                // then we just return a partial view (snippet) of HTML 
                // instead of the full page
                if (Request.IsAjaxRequest())
                    return PartialView("_Schedule", model);

                return View(model);
            }

            // TODO: A real app would send some sort of email here

            if (Request.IsAjaxRequest())
            {
                // Same idea as above
                return PartialView("_ThanksForFeedback", model);
            }

            // A standard (non-Ajax) HTTP Post came in
            // set TempData and redirect the user back to the Home page
            TempData["Message"] = string.Format("Thanks for the feedback, {0}! We will contact you shortly.", model.Firstname + " " + model.Lastname);
            return RedirectToAction("Index");
        }

        //
        // GET: /Schedule/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Schedule/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Schedule/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Schedule/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
} 

