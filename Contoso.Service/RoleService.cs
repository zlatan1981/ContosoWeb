using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;
using System.Transactions;

namespace Contoso.Service {
    public class RoleService : IRoleService {

        //private readonly ContosoContext Context;
        private readonly IRoleRepository Roles;

        public RoleService(IRoleRepository roles) {
            //  Context = context;
            Roles = roles;
        }


        // add role and return Id
        public int AddOrUpdateRole(Role r) {
            using (TransactionScope tran = new TransactionScope()) {
                Roles.AddOrUpdate(r);
                //    Complete();
                tran.Complete();
                return r.Id;
            }
        }

        public Role GetRoleById(int id) {
            return Roles.Get(id);
        }

        public List<Role> GetAllRoles() {
            return (List<Role>)Roles.GetAll();
        }

        //public void UpdateRole(Role r) {
        //    Roles.Update(r);

        //}


        //public int Complete() {
        //    return Context.SaveChanges();
        //}

        //public void Dispose() {
        //    Context.Dispose();
        //}
    }


    public interface IRoleService {


        int AddOrUpdateRole(Role r);
        Role GetRoleById(int Id);
        //int Complete();
        List<Role> GetAllRoles();
        //void UpdateRole(Role r);


    }

}
