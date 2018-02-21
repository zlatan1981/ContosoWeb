using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Data;
using Contoso.Model;
using Contoso.Service;



namespace ContosoWeb.Controllers {
    public class DepartmentController : Controller {
        // GET: Department
        //  ContosoContext Context = new ContosoContext();
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }
        public ActionResult Index() {
            var depts = _departmentService.GetAllDepartments();

            return View(depts);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id) {
            var dept = _departmentService.GetDepartmentByIdIncludeCourses(id);

            return View(dept);
        }

        // GET: Department/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Department/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection) {
        //    try {
        //        // TODO: Add insert logic here
        //        Department dept = new Department() {
        //            Name = collection["DepartmentName"],
        //            Budget = Convert.ToDecimal(collection["Budget"])
        //        };

        //        _departmentService.AddOrUpdateDepartment(dept);
        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}


        [HttpPost]
        public ActionResult Create(Department dept) {
            try {
                // TODO: Add insert logic here
                //Department dept = new Department() {
                //    Name = DepartmentName,
                //    Budget = Budget
                //};

                _departmentService.AddOrUpdateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }


        // GET: Department/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Department/Edit/5
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

        // GET: Department/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Department/Delete/5
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
