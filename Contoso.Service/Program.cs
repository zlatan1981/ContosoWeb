﻿using System;
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
                IRoleService RoleService = new RoleService(db);

                //int studentId = StudentService.AddStudent(new Person() {
                //    FirstName = "Alexis",
                //    LastName = "Sanchez",
                //    Email = "yuwang5763@gmail.com",
                //    Phone = "512-8503426",
                //    City = "Sterling"
                //});

                //Console.WriteLine(studentId);


                //var p1 = new Person() {

                //    FirstName = "TaoTao",
                //    LastName = "Wang",
                //    Email = "yuwang5763@gmail.com",
                //    Phone = "512-8503426",
                //    City = "Sterling"
                //};

                //int pId = PersonService.AddPerson(p1);

                //List<Role> roles = new List<Role>() {
                //    new Role(){
                //        RoleName = "Google SDE",
                //        Description = "Software Engineer @ Google"
                //    },

                //    new Role(){
                //        RoleName = "Amazon SDE",
                //        Description = "Software Engineer @ Amazon"
                //    },

                //    new Role(){
                //        RoleName = "Microsoft SDE",
                //        Description = "Software Engineer @ Microsoft"

                //    },

                //    new Role(){
                //        RoleName = "Apple SDE",
                //        Description = "Software Engineer @ Apple"

                //    }


                //};

                //foreach (var R in roles) {
                //    RoleService.AddRole(R);
                //}



                var persons = db.Persons;
                //     var roles = db.Roles.ToList();
                //    var googlesde = db.Roles.Single(r => r.RoleName == "Google SDE");

                //    PersonService.AddPerson(persons.Single(p => p.FirstName == "TaoTao"), "Google SDE");


                //List<Department> depts = new List<Department>() {
                //    new Department() {
                //        Name="CSE",
                //        Budget = 50000
                //    },
                //    new Department() {
                //        Name="ECE",
                //        Budget = 50000
                //    },
                //    new Department() {
                //        Name="ME",
                //        Budget = 50000
                //    },
                //    new Department() {
                //        Name="CE",
                //        Budget = 50000
                //    }

                //};

                //DepartmentService.AddDepartments(depts);

                var deps = db.Departments.ToList();
                var cse = deps.SingleOrDefault(d => d.Name == "CSE");
                var ece = deps.SingleOrDefault(d => d.Name == "ECE");

                //List<Course> cours = new List<Course>() {
                //    new Course() {
                //        Name ="Database Principles",
                //        Department = cse
                //    },
                //    new Course() {
                //        Name ="Operating Systems",
                //        Department = cse
                //    },
                //    new Course() {
                //        Name ="Computer Networks",
                //        Department = cse

                //    },
                //    new Course() {
                //        Name ="Digital Design",
                //        Department = ece

                //    },
                //    new Course() {

                //        Name ="Enbedded Systems",
                //        Department = ece
                //    }


                //};

                //CourseService.AddCourses(cours);

                //      db.SaveChanges();


                EnrollmentService.AddEnrollment(1, 1);






            }
        }
    }
}
