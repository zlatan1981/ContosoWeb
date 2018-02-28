using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContosoAPI.Controllers {
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController {

        IStudentService _Studentservice;

        public StudentsController(IStudentService StudentService) {
            _Studentservice = StudentService;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllStudents() {
            var students = _Studentservice.GetAllStudents();
            if (students.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Students found.");
            }
        }

        [HttpGet]
        [Route("topFive")]
        public HttpResponseMessage GetTopFiveStudents() {
            var students = _Studentservice.GetAllStudents();
            if (students.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, students.Take(5));
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Students found.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetStudentById(int id) {
            if (id < 0) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else {
                var student = _Studentservice.GetStudentById(id);
                if (student != null)
                    return Request.CreateResponse(HttpStatusCode.OK, student);
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No student for id " + id);
                }
            }

        }

    }
}
