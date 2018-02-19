using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;

namespace Contoso.Service {
    public class RoleService : IRoleService {

        private readonly ContosoContext Context;
        private readonly IRoleRepository Roles;

        public RoleService(ContosoContext context) {
            Context = context;
            Roles = new RoleRepository(Context);
        }
        // add role and return Id
        public int AddRole(Role r) {
            int RId = Roles.Add(r);
            Complete();
            return RId;

        }

        public List<Role> GetAllRoles() {
            return (List<Role>)Roles.GetAll();
        }


        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }


    public interface IRoleService {


        int AddRole(Role r);
        int Complete();
        List<Role> GetAllRoles();



    }

}
