using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services {
    public class StudentService : IStudentService {

        private readonly ContosoContext Context;
        public IPersonRepository Persons { get; private set; }
        public IStudentRepository Students { get; private set; }

        public StudentService(ContosoContext context) {

            Context = context;
            Persons = new PersonRepository(Context);
            Students = new StudentRepository(Context);

        }

        public int AddStudent(Person person) {
            int Pid = Persons.Add(person);
            Students.Add(new Student() {
                Id = Pid
            });
            return Pid;

        }

        public Student GetStudentById(int StuId) {
            return Students.Get(StuId);
        }

        public List<Student> GetAllStudents() {
            return (List<Student>)Students.GetAll();
        }

        public List<Student> GetStudentsByCourse(int courseId) {
            return Students.Find(s => (s.Enrollments.Any(e => (e.CourseId == courseId)))).ToList();
        }



        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }

    public interface IStudentService {

        IPersonRepository Persons { get; }
        IStudentRepository Students { get; }
        // add student but take a person as input type return the stu Id
        int AddStudent(Person person);

        Student GetStudentById(int StuId);
        List<Student> GetAllStudents();
        List<Student> GetStudentsByCourse(int courseId);

        int Complete();


    }


}
