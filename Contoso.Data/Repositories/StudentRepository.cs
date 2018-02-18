﻿using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories {

    public class StudentRepository : Repository<Student>, IStudentRepository {

        // cast the Context property from the base Repository<T> into  a ContosoContext before using 
        public ContosoContext ContosoContext { get { return Context as ContosoContext; } }

        public StudentRepository(ContosoContext _context) : base(_context) {

        }


    }
}
