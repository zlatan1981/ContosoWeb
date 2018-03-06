using Contoso.Model;
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
        [Route("{id:int}", Name = "GetCourseById")]
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

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] Course course) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Course data is invalid.");
            }

            try {
                _Courseservice.AddCourse(course);
                var message = Request.CreateResponse(HttpStatusCode.Created, course);
                message.Headers.Location = new Uri(Url.Link("GetCourseById", new { id = course.Id }));
                return message;

            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] Course course) {
            if (!ModelState.IsValid) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Course data is invalid.");
            }
            try {
                Course cour = _Courseservice.GetCourseById(id);
                if (cour == null) {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Course with Id " + id.ToString() + " not found to update");
                }
                _Courseservice.UpdateCourse(course);
                return Request.CreateResponse(HttpStatusCode.OK, course);

            }
            catch (Exception ex) {// should log ex ourselves, should not return to the user
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Some internal error occurs...");
            }
        }

    }
}
