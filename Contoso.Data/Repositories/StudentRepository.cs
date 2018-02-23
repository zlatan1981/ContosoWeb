using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories {

    public class StudentRepository : Repository<Student>, IStudentRepository {

        // cast the Context property from the base Repository<T> into  a ContosoContext before using 
        public ContosoContext ContosoContext { get { return Context as ContosoContext; } }

        public StudentRepository(ContosoContext _context) : base(_context) {

        }

        public Student GetStudentByIdIncludeCourses(int stuId) {
            return ContosoContext.Students.Where(s => s.Id == stuId).Include(s => s.Enrollments.Select(e => e.Course)).FirstOrDefault();
        }

        public Student GetStudentByIdIncludePerson(int stuId) {
            return ContosoContext.Students.Where(s => s.Id == stuId).Include(s => s.Person).FirstOrDefault();
        }

        public Student GetStudentByIdIncludePersonCourses(int stuId) {
            return ContosoContext.Students.Where(s => s.Id == stuId).Include(s => s.Person).Include(s => s.Enrollments.Select(e => e.Course)).FirstOrDefault();
        }
    }
}
