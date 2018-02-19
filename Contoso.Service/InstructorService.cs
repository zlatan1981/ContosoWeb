using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;

namespace Contoso.Service {
    public class InstructorService : IInstructorService {

        private readonly ContosoContext Context;
        private readonly IPersonRepository Persons;
        private readonly IInstructorRepository Instructors;

        public InstructorService(ContosoContext context) {

            Context = context;
            Persons = new PersonRepository(Context);
            Instructors = new InstructorRepository(Context);

        }

        public int AddInstructor(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                int Pid = Persons.Add(person);
                Instructors.Add(new Instructor() {
                    Id = Pid
                });
                Complete();
                tran.Complete();
                return Pid;
            }

        }

        // add a course with courId to the course list of the instructor with InId
        public int AddCourseToInstructor(int InId, int courId) {
            using (TransactionScope tran = new TransactionScope()) {



            }
            return 0;
        }


        public Instructor GetInstructorById(int InstructorId) {
            return Instructors.Get(InstructorId);
        }

        public List<Instructor> GetAllInstructors() {
            return (List<Instructor>)Instructors.GetAll();
        }

        public List<Course> GetInstructorCourses(int instructorId) {
            return Instructors.Get(instructorId).Courses.ToList();

        }

        public List<Instructor> GetInstructorsByOffice(string location) {
            return Instructors.Find(i => (i.OfficeAssignments.Location == location)).ToList();
        }

        public List<Instructor> GetInstructorsByCourse(int courseId) {
            return Instructors.Find(i => i.Courses.Any(c => c.Id == courseId)).ToList();
        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }


    }

    public interface IInstructorService {

        // add Instructor but take a person as input type return the stu Id
        int AddInstructor(Person person);
        int AddCourseToInstructor(int InstructorId, int CourseId);

        Instructor GetInstructorById(int StuId);
        List<Instructor> GetAllInstructors();
        List<Instructor> GetInstructorsByOffice(string location);
        List<Instructor> GetInstructorsByCourse(int courseId);
        List<Course> GetInstructorCourses(int instructorId);


        int Complete();


    }
}
