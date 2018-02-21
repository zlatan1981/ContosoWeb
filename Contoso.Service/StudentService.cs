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
    public class StudentService : IStudentService {

        //   private readonly ContosoContext Context;
        private readonly IPersonRepository Persons;
        private readonly IStudentRepository Students;

        public StudentService(IPersonRepository _persons, IStudentRepository _students) {

            //   Context = context;
            Persons = _persons;
            Students = _students;

        }

        public int AddStudent(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                Persons.Add(person);
                Students.Add(new Student() {
                    Id = person.Id
                });
                // Complete();
                tran.Complete();
                return person.Id;
            }

        }

        public int UpdateStudent(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                Persons.AddOrUpdate(person);
                Students.AddOrUpdate(new Student() {
                    Id = person.Id
                });
                // Complete();
                tran.Complete();
                return person.Id;
            }

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


        public List<Course> GetStudentCourses(int stuId) {
            return Students.Get(stuId).Enrollments.Select(e => e.Course).ToList();
        }

        public void UpdateStudent(Student student) {
            Students.Update(student); ///////???? what about person??? 
        }

        //public int Complete() {
        //    return Context.SaveChanges();
        //}

        //public void Dispose() {
        //    Context.Dispose();
        //}


    }

    public interface IStudentService {


        // add student but take a person as input type return the stu Id
        int AddStudent(Person person);
        int UpdateStudent(Person person);
        Student GetStudentById(int StuId);
        List<Student> GetAllStudents();
        List<Student> GetStudentsByCourse(int courseId);
        List<Course> GetStudentCourses(int stuId);
        void UpdateStudent(Student student);

        //int Complete();


    }


}
