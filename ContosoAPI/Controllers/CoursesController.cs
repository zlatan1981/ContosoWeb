using Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContosoAPI.Controllers {
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController {
        // GET: api/Courses
        ICourseService _Courseservice;

        public CoursesController(ICourseService CourseService) {
            _Courseservice = CourseService;
        }
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllCourses() {
            var courses = _Courseservice.GetAllCourses();
            if (courses.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, courses);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Courses found.");
            }
        }

        [HttpGet]
        [Route("topFive")]
        public HttpResponseMessage GetTopFiveCourses() {
            var courses = _Courseservice.GetAllCourses();
            if (courses.Any()) {
                return Request.CreateResponse(HttpStatusCode.OK, courses.Take(5));
            }
            else {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Courses found.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetCourseById(int id) {
            if (id < 0) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else {
                var course = _Courseservice.GetCourseById(id);
                if (course != null)
                    return Request.CreateResponse(HttpStatusCode.OK, course);
                else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No course for id " + id);
                }
            }

        }

    }
}
