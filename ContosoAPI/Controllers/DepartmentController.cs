using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;
using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContosoAPI.Controllers {
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController {
        // GET: api/Department
        IDepartmentService _departmentservice;
        ContosoContext context = new ContosoContext();


        public DepartmentController() {
            IDepartmentRepository deprepo = new DepartmentRepository(context);
            _departmentservice = new DepartmentService(deprepo);
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllDepartments() {
            var depts = _departmentservice.GetAllDepartments();
            if (depts.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, depts);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No departments found.");
            }
        }

        [HttpGet]
        [Route("topFive")]
        public HttpResponseMessage GetTopFiveDepartments() {
            var depts = _departmentservice.GetAllDepartments();
            if (depts.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, depts.Take(5));
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No departments found.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetDepartmentById(int id) {
            if (id < 0) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else {
                var dept = _departmentservice.GetDepartmentById(id);
                if (dept != null)
                    return Request.CreateResponse(HttpStatusCode.OK, dept);
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No dept for id" + id);
                }
            }

        }

    }
}