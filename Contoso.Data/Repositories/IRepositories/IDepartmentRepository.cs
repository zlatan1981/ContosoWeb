﻿using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories.IRepositories {
    public interface IDepartmentRepository : IRepository<Department> {
        Department GetDepartmentByIdIncludeCourses(int deptId);
        List<Department> GetDepartmentsIncludeInstructor();
    }
}
