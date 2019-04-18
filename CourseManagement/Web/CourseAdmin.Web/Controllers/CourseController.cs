using Coures.Core.UseCases;
using Coures.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseAdmin.Web.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {

           
            CourseHandler handler = new CourseHandler();
            List<CourseViewModel> models = handler.List();

            return View(models);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreateViewModel vm)
        {
            try
            {
                // TODO: Add insert logic here
                CourseHandler handler = new CourseHandler();
                handler.Create(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(long id)
        {

            CourseHandler handler = new CourseHandler();
            CourseEditModel vm = handler.QueryById(id);

            return View(vm);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseEditModel vm)
        {
            try
            {
                CourseHandler handler = new CourseHandler();
                handler.Update(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: Course/Delete/5
        [HttpGet]
        public ActionResult Delete(long id)
        {

            // TODO: Add delete logic here

            CourseHandler handler = new CourseHandler();
            handler.Delete(id);

            return RedirectToAction("Index");
         
        }
    }
}
