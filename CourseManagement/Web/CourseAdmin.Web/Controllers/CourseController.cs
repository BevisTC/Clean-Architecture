using Coures.Core.Gateways;
using Coures.Core.UseCases;
using Coures.Core.ViewModels;
using CourseManagement.EF;
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

            IDataAccess<Course> dataAccess = new CourseEFDataAccess();
           
            CourseHandler handler = new CourseHandler(dataAccess);
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

                IDataAccess<Course> dataAccess = new CourseEFDataAccess();
                CourseHandler handler = new CourseHandler(dataAccess);
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
            IDataAccess<Course> dataAccess = new CourseEFDataAccess();
            CourseHandler handler = new CourseHandler(dataAccess);
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
                IDataAccess<Course> dataAccess = new CourseEFDataAccess();
                CourseHandler handler = new CourseHandler(dataAccess);
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

            IDataAccess<Course> dataAccess = new CourseEFDataAccess();
            CourseHandler handler = new CourseHandler(dataAccess);
            handler.Delete(id);

            return RedirectToAction("Index");
         
        }
    }
}
