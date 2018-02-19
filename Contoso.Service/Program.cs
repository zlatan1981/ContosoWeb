using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Model;


namespace Contoso.Service {
    public class Program {

        public static void Main() {
            Console.WriteLine("Hello");

            using (var db = new ContosoContext()) {

                IPersonService PersonService = new PersonService(db);
                IStudentService StudentService = new StudentService(db);
                IInstructorService InstructorService = new InstructorService(db);
                ICourseService CourseService = new CourseService(db);
                IDepartmentService DepartmentService = new DepartmentService(db);
                IEnrollmentService EnrollmentService = new EnrollmentService(db);




            }
        }
    }
}
