using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContosoAPI.Controllers {
    [RoutePrefix("api/instructors")]
    public class InstructorsController : ApiController {

        IInstructorService _Instructorservice;

        public InstructorsController(IInstructorService InstructorService) {
            _Instructorservice = InstructorService;
        }
        [HttpGet]
        [Route("")]
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


    }
}
