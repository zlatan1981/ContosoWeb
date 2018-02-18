using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;

namespace Contoso.Services {
    public class CourseService : ICourseService {

        public ICourseRepository Courses { get; private set; }
        private readonly ContosoContext Context;

        public CourseService(ContosoContext context) {
            Context = context;
            Courses = new CourseRepository(Context);

        }


        public int AddCourse(Course course) {
            return Courses.Add(course);
        }


        public List<Course> GetAllCourses() {
            return Courses.GetAll().ToList();
        }

        public List<Course> GetCoursebyDept(int deptId) {
            return Courses.Find(c => c.DepartmentId == deptId).ToList();
        }

        public Course GetCourseById(int courseId) {
            return Courses.Get(courseId);
        }

        public List<Instructor> GetCourseInstructors(int courseId) {
            return Courses.Get(courseId).Instructors.ToList();
        }

        public List<Course> GetCoursesbyInstructor(int instructorId) {
            return Courses.Find(c => c.Instructors.Any(i => i.Id == instructorId)).ToList();
        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }

    public interface ICourseService {

        ICourseRepository Courses { get; }

        int AddCourse(Course Course);
        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        List<Course> GetCoursesbyInstructor(int instructorId);
        List<Course> GetCoursebyDept(int deptId);
        List<Instructor> GetCourseInstructors(int courseId);

        int Complete();

    }
}
