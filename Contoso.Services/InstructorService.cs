using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;

namespace Contoso.Services {
    public class InstructorService : IInstructorService {

        private readonly ContosoContext Context;
        public IPersonRepository Persons { get; private set; }
        public IInstructorRepository Instructors { get; private set; }

        public InstructorService(ContosoContext context) {

            Context = context;
            Persons = new PersonRepository(Context);
            Instructors = new InstructorRepository(Context);

        }

        public int AddInstructor(Person person) {
            int Pid = Persons.Add(person);
            Instructors.Add(new Instructor() {
                Id = Pid
            });
            return Pid;

        }

        public Instructor GetInstructorById(int StuId) {
            return Instructors.Get(StuId);
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

        IPersonRepository Persons { get; }
        IInstructorRepository Instructors { get; }
        // add Instructor but take a person as input type return the stu Id
        int AddInstructor(Person person);

        Instructor GetInstructorById(int StuId);
        List<Instructor> GetAllInstructors();
        List<Instructor> GetInstructorsByOffice(string location);
        List<Instructor> GetInstructorsByCourse(int courseId);
        List<Course> GetInstructorCourses(int instructorId);

        int Complete();


    }
}
