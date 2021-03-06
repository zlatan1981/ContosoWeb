﻿using Contoso.Data;
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
        private ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService) {
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Student
        public ActionResult Index() {
            var students = _studentService.GetAllStudents();

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id) {
            var student = _studentService.GetStudentByIdIncludePersonCourses(id);
            //   var stuCourses = _studentService.GetStudentCourses(id);
            TempData["CheckedCourseList"] = GetCheckedCourseList();
            return View(student);
        }
        [HttpPost]
        public ActionResult ProcessCheckedCourses(List<CheckedCourse> courses) {
            //     var student = _studentService.GetStudentByIdIncludePersonCourses(id);

            //   var stuCourses = _studentService.GetStudentCourses(id);
            //    TempData["CheckedCourseList"] = GetCheckedCourseList();
            //    return View(student);

            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }

        }


        // this partial view action will be called by the Details action above
        // to display the checkedbox course list
        [HttpGet]
        public PartialViewResult CheckCoursesList() {
            //for partial view    
            List<CheckedCourse> checkedcourses = new List<CheckedCourse>();
            List<Course> allcourses = _courseService.GetAllCourses();
            foreach (var course in allcourses) {
                CheckedCourse cc = new CheckedCourse(course);
                checkedcourses.Add(cc);
            }
            return PartialView("_CheckCourseListForm", checkedcourses);
        }

        [NonAction]
        private List<CheckedCourse> GetCheckedCourseList() {
            List<CheckedCourse> checkedcourses = new List<CheckedCourse>();
            List<Course> allcourses = _courseService.GetAllCourses();
            foreach (var course in allcourses) {
                CheckedCourse cc = new CheckedCourse(course);
                checkedcourses.Add(cc);
            }
            return checkedcourses;
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
            Student stu = _studentService.GetStudentByIdIncludePerson(id);
            StudentPerson sp = new StudentPerson() {
                Student = stu,
                Person = stu.Person
            };
            return View(sp);
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

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentPerson SPerson) {
            try {

                // TODO: Add update logic here
                _studentService.UpdateStudent(SPerson.Student);
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

        // student/Enroll/5
        public ActionResult Enroll(int id) {

            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }



        // student/Enroll/5
        [HttpPost]
        public ActionResult Enroll() {

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
