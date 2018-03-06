using Contoso.Models.ViewModels;
using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.Models;
using Contoso.Model;

namespace ContosoAPI.Controllers {
    [RoutePrefix("api/instructors")]
    public class InstructorsController : ApiController {

        IInstructorService _Instructorservice;

        public InstructorsController(IInstructorService InstructorService) {
            _Instructorservice = InstructorService;
        }
        [HttpGet]
        [Route("", Name = "GetInstructorById")]
        public HttpResponseMessage GetAllInstructors() {
            var Instructors = _Instructorservice.GetAllInstructors();
            if (Instructors.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, Instructors);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Instructors found.");
            }
        }

        [HttpGet]
        [Route("topFive")]
        public HttpResponseMessage GetTopFiveInstructors() {
            var Instructors = _Instructorservice.GetAllInstructors();
            if (Instructors.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, Instructors.Take(5));
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Instructors found.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetInstructorById(int id) {
            if (id < 0) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else {
                var Instructor = _Instructorservice.GetInstructorById(id);
                if (Instructor != null)
                    return Request.CreateResponse(HttpStatusCode.OK, Instructor);
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Instructor for id " + id);
                }
            }

        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] InstructorPerson Instructor) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Instructor data is invalid.");
            }

            try {
                _Instructorservice.AddInstructor(Instructor);
                var message = Request.CreateResponse(HttpStatusCode.Created, Instructor);
                message.Headers.Location = new Uri(Url.Link("GetInstructorById", new { id = Instructor.Person.Id }));
                return message;

            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] InstructorPerson instructor) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Instructor data is invalid.");
            }
            try {
                Instructor ins = _Instructorservice.GetInstructorById(id);
                if (ins == null) {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Instructor with Id " + id.ToString() + " not found to update");
                }
                _Instructorservice.UpdateInstructor(instructor);
                return Request.CreateResponse(HttpStatusCode.OK, instructor);

            }
            catch (Exception ex) {// should log ex ourselves, should not return to the user
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }


    }
}
