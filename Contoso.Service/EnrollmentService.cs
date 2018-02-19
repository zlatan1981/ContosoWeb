using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Contoso.Service {



    public class EnrollmentService : IEnrollmentService {

        private readonly IStudentRepository Students;
        private readonly ICourseRepository Courses;
        private readonly IEnrollmentRepository Enrollments;
        private readonly ContosoContext Context;

        public EnrollmentService(ContosoContext context) {
            Context = context;
            Courses = new CourseRepository(Context);
            Students = new StudentRepository(Context);
            Enrollments = new EnrollmentRepository(Context);
        }

        public int AddEnrollment(int StuId, int CourId) {

            using (TransactionScope tran = new TransactionScope()) {
                Course c = Courses.Get(CourId);
                Student s = Students.Get(StuId);
                if (c == null || s == null) return -1; // if the course or student doesn't exist, invalid
                Enrollment enroll = Enrollments.SingleOrDefault(e => (e.StudentId == StuId && e.CourseId == CourId));
                if (enroll != null) return enroll.Id; // already exist, return

                enroll = new Enrollment() {
                    StudentId = StuId,
                    CourseId = CourId
                };
                int EId = Enrollments.Add(enroll);
                Complete();
                tran.Complete();
                return EId;
            }
        }


        public List<Enrollment> GetAllEnrollments() {
            return (List<Enrollment>)Enrollments.GetAll();
        }

        public List<Enrollment> GetEnrollmentByCourse(int courseId) {
            return Enrollments.Find(e => e.CourseId == courseId).ToList();
        }

        public Enrollment GetEnrollmentById(int EId) {
            return Enrollments.Get(EId);
        }

        public List<Enrollment> GetEnrollmentByStudent(int stuId) {
            return Enrollments.Find(e => e.StudentId == stuId).ToList();
        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }


    public interface IEnrollmentService {

        int AddEnrollment(int StuId, int CourseId);
        Enrollment GetEnrollmentById(int EId);
        List<Enrollment> GetAllEnrollments();
        List<Enrollment> GetEnrollmentByCourse(int courseId);
        List<Enrollment> GetEnrollmentByStudent(int stuId);

        int Complete();



    }
}
