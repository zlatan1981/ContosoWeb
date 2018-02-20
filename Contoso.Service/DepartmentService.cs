using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;
using Contoso.Model;
using Contoso.Data.Repositories;
using System.Transactions;

namespace Contoso.Service {
    public class DepartmentService : IDepartmentService {

        private readonly IDepartmentRepository Departments;
        private readonly ContosoContext Context;

        public DepartmentService(ContosoContext context) {
            Context = context;
            Departments = new DepartmentRepository(Context);
        }


        public int AddOrUpdateDepartment(Department dept) {
            using (TransactionScope tran = new TransactionScope()) {
                Departments.AddOrUpdate(dept);
                //Complete();
                tran.Complete();
                return dept.Id;
            }

        }

        public void AddDepartments(IEnumerable<Department> depts) {
            using (TransactionScope tran = new TransactionScope()) {
                Departments.AddRange(depts);
                //   Complete();
                tran.Complete();
            }

        }

        public List<Department> GetAllDepartments() {
            return (List<Department>)Departments.GetAll();
        }

        public List<Department> GetAllDepartmentsIncludeCourses() {
            return null;
        }

        public Department GetDepartmentById(int deptId) {
            return Departments.Get(deptId);
        }

        public Department GetDepartmentByIdIncludeCourses(int deptId) {
            return Departments.GetDepartmentByIdIncludeCourses(deptId);
        }

        public void UpdateDepartment(Department dept) {
            Departments.Update(dept);
        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }


    }


    public interface IDepartmentService {

        int AddOrUpdateDepartment(Department dept);
        void AddDepartments(IEnumerable<Department> depts);
        void UpdateDepartment(Department dept);
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsIncludeCourses();
        Department GetDepartmentById(int deptId);
        Department GetDepartmentByIdIncludeCourses(int deptId);
        int Complete();

    }
}
