using Contoso.Model;
using Contoso.Models.ViewModels;
using Contoso.Service;
using ContosoWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Controllers {
    public class InstructorController : Controller {

        //ContosoContext Context = new ContosoContext();
        private IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService) {
            _instructorService = instructorService;
        }

        // GET: Instructor
        public ActionResult Index() {
            var instructors = _instructorService.GetAllInstructors();
            return View(instructors);

        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Instructor/Create
        public ActionResult Create() {
            return View();
        }

        //// POST: Instructor/Create
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

        //// when creating a student, we actually passed in a person cuz of my implementation
        //[HttpPost]
        //public ActionResult Create(Person person) {
        //    try {
        //        // TODO: Add insert logic here
        //        //Department dept = new Department() {
        //        //    Name = DepartmentName,
        //        //    Budget = Budget
        //        //};

        //        _instructorService.AddInstructor(person);
        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}


        [HttpPost]
        public ActionResult Create(InstructorPerson IPerson) {
            try {
                // TODO: Add insert logic here
                //Department dept = new Department() {
                //    Name = DepartmentName,
                //    Budget = Budget
                //};

                _instructorService.AddInstructor(IPerson);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Instructor/Delete/5
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
