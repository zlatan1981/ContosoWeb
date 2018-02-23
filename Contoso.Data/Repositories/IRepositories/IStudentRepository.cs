using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories.IRepositories {

    public interface IStudentRepository : IRepository<Student> {

        Student GetStudentByIdIncludeCourses(int stuId);
        Student GetStudentByIdIncludePerson(int stuId);
        Student GetStudentByIdIncludePersonCourses(int stuId);



    }
}
