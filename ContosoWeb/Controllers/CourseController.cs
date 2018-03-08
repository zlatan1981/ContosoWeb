using Contoso.Data;
using Contoso.Model;
using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Controllers {
    public class CourseController : Controller {

        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService) {
            _courseService = courseService;
        }

        // GET: Course
        public ActionResult Index() {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id) {
            var course = _courseService.GetCourseIdIncludeInstructorandStudents(id);

            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Course/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection) {
        //    try {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
        // GET: Course/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Course/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection) {
        //    try {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(int id, Course course) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }


        // GET: Course/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
