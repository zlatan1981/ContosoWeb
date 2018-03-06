using Contoso.Model;
using Contoso.Models.ViewModels;
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
        [Route("{id:int}", Name = "GetStudentById")]
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
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] StudentPerson student) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student data is invalid.");
            }


            try {
                _Studentservice.AddStudent(student);
                var message = Request.CreateResponse(HttpStatusCode.Created, student);
                message.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = student.Person.Id }));
                return message;

            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage Post([FromBody] Student student) {
        //    if (!ModelState.IsValid) {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Student data is invalid.");
        //    }


        //    try {
        //        _Studentservice.AddStudent(student);
        //        var message = Request.CreateResponse(HttpStatusCode.Created, student);
        //        message.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = student.Person.Id }));
        //        return message;

        //    }
        //    catch (Exception ex) {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
        //    }
        //}



        //[HttpPut]
        //[Route("{id:int}")]
        //public HttpResponseMessage Put([FromUri] int id, [FromBody] Student student) {
        //    if (!ModelState.IsValid) {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Student data is invalid.");
        //    }
        //    try {
        //        Student stu = _Studentservice.GetStudentById(id);
        //        if (stu == null) {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, "Student with Id " + id.ToString() + " not found to update");
        //        }
        //        _Studentservice.UpdateStudent(student);
        //        return Request.CreateResponse(HttpStatusCode.OK, student);

        //    }
        //    catch (Exception ex) {// should log ex ourselves, should not return to the user
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
        //    }
        //}

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] StudentPerson student) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student data is invalid.");
            }
            try {
                Student stu = _Studentservice.GetStudentById(id);
                if (stu == null) {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student with Id " + id.ToString() + " not found to update");
                }
                _Studentservice.UpdateStudent(student);
                return Request.CreateResponse(HttpStatusCode.OK, student);

            }
            catch (Exception ex) {// should log ex ourselves, should not return to the user
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }



    }
}
