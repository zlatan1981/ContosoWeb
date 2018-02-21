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

        ///  private readonly ContosoContext Context;
        private readonly IPersonRepository Persons;
        private readonly IInstructorRepository Instructors;
        private readonly ICourseRepository Courses;

        public InstructorService(IPersonRepository _persons, IInstructorRepository _instructors, ICourseRepository _courses) {

            // Context = context;
            Persons = _persons;
            Instructors = _instructors;
            Courses = _courses;

        }

        public int AddInstructor(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                Persons.Add(person); // this person is tracked and in context
                // then we can add as instructor by setting the navigation property.
                //person.Instructor = new Instructor() {
                //    Id = person.Id
                //};
                Instructors.Add(new Instructor() {
                    Id = person.Id
                });
                //   Complete();
                tran.Complete();
                return person.Id;
            }

        }


        public int UpdateInstructor(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                Persons.AddOrUpdate(person); // this person is tracked and in context
                // then we can add as instructor by setting the navigation property.
                //person.Instructor = new Instructor() {
                //    Id = person.Id
                //};
                Instructors.AddOrUpdate(new Instructor() {
                    Id = person.Id
                });
                //   Complete();
                tran.Complete();
                return person.Id;
            }

        }


        // add a course with courId to the course list of the instructor with InId
        public int AddCourseToInstructor(int InId, int courId) {
            using (TransactionScope tran = new TransactionScope()) {

                var ins = Instructors.Get(InId);
                var course = Courses.Get(courId);
                if (ins == null || course == null) {
                    tran.Complete();
                    return -1;
                }
                ins.Courses.Add(course);
                //Complete();
                tran.Complete();
                return 0;
            }

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

        public void UpdateInstructor(Instructor instructor) {
            Instructors.Update(instructor);
        }

        //public int Complete() {
        //    return Context.SaveChanges();
        //}

        //public void Dispose() {
        //    Context.Dispose();
        //}


    }

    public interface IInstructorService {

        // add Instructor but take a person as input type return the stu Id
        int AddInstructor(Person person);
        int UpdateInstructor(Person person);
        int AddCourseToInstructor(int InstructorId, int CourseId);

        Instructor GetInstructorById(int StuId);
        List<Instructor> GetAllInstructors();
        List<Instructor> GetInstructorsByOffice(string location);
        List<Instructor> GetInstructorsByCourse(int courseId);
        List<Course> GetInstructorCourses(int instructorId);

        void UpdateInstructor(Instructor instructor);

        //int Complete();


    }
}
