using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories {

    public class StudentRepository : Repository<Student>, IStudentRepository {

        public StudentRepository(ContosoContext context) : base(context) {

        }


    }
}
