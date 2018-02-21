using Contoso.Data;
using Contoso.Model;
using Contoso.Models.ViewModels;
using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Controllers {
    public class StudentController : Controller {
        //ContosoContext Context = new ContosoContext();
        private IStudentService _studentService;

        public StudentController(IStudentService studentService) {
            _studentService = studentService;
        }

        // GET: Student
        public ActionResult Index() {
            var students = _studentService.GetAllStudents();

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Student/Create
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

        //        _studentService.AddStudent(person);
        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Create(StudentPerson SPerson) {
            try {
                // TODO: Add insert logic here
                //Department dept = new Department() {
                //    Name = DepartmentName,
                //    Budget = Budget
                //};

                _studentService.AddStudent(SPerson);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }



        // GET: Student/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Student/Delete/5
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
