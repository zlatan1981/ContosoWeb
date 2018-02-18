using Contoso.Data.Repositories.IRepositories;
using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories {
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository {

        // cast the Context property from the base Repository<T> into  a ContosoContext before using 
        public ContosoContext ContosoContext { get { return Context as ContosoContext; } }

        public DepartmentRepository(ContosoContext _context) : base(_context) {

        }


    }
}
