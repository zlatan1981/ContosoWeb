﻿using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories.IRepositories {
    public interface ICourseRepository : IRepository<Course> {
        Course GetCourseIdIncludeInstructorandStudents(int courseId);
    }
}
