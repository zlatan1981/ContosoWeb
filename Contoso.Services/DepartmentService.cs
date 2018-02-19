﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;
using Contoso.Model;
using Contoso.Data.Repositories;

namespace Contoso.Service {
    public class DepartmentService : IDepartmentService {

        private readonly IDepartmentRepository Departments;
        private readonly ContosoContext Context;

        public DepartmentService(ContosoContext context) {
            Context = context;
            Departments = new DepartmentRepository(Context);
        }


        public int AddDepartment(Department dept) {
            int DId = Departments.Add(dept);
            Complete();
            return DId;
        }

        public List<Department> GetAllDepartments() {
            return (List<Department>)Departments.GetAll(); ;
        }

        public List<Department> GetAllDepartmentsIncludeCourses() {
            return null;
        }

        public Department GetDepartmentById(int deptId) {
            throw new NotImplementedException();
        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }


    }


    public interface IDepartmentService {

        int AddDepartment(Department dept);
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsIncludeCourses();
        Department GetDepartmentById(int deptId);
        int Complete();

    }
}
