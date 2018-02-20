using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories.IRepositories {
    public class CourseRepository : Repository<Course>, ICourseRepository {

        // cast the Context property from the base Repository<T> into  a ContosoContext before using 
        public ContosoContext ContosoContext { get { return Context as ContosoContext; } }

        public CourseRepository(ContosoContext _context) : base(_context) {

        }

        public Course GetCourseIdIncludeInstructorandStudents(int courseId) {
            return ContosoContext.Courses.Where(c => c.Id == courseId).Include(c => c.Department).Include(c => c.Instructors).Include(c => c.Enrollments.Select(e => e.Student)).FirstOrDefault();
        }
    }
}
