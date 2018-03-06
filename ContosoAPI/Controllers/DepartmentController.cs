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

        public DepartmentController(IDepartmentService departmentService) {
            _departmentservice = departmentService;
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
        [Route("{id}", Name = "GetDepartmentById")]
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

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] Department department) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Department data is invalid.");
            }

            try {
                _departmentservice.AddDepartment(department);
                var message = Request.CreateResponse(HttpStatusCode.Created, department);
                message.Headers.Location = new Uri(Url.Link("GetDepartmentById", new { id = department.Id }));
                return message;

            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] Department department) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Department data is invalid.");
            }
            try {
                Department dept = _departmentservice.GetDepartmentById(id);
                if (dept == null) {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Department with Id " + id.ToString() + " not found to update");
                }
                _departmentservice.UpdateDepartment(department);
                return Request.CreateResponse(HttpStatusCode.OK, department);

            }
            catch (Exception ex) {// should log ex ourselves, should not return to the user
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

    }
}