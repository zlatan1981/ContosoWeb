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
    public class PersonService : IPersonService {

        private readonly ContosoContext Context;
        private readonly IPersonRepository Persons;
        private readonly IRoleRepository Roles;

        public PersonService(ContosoContext context) {

            Context = context;
            Persons = new PersonRepository(Context);
            Roles = new RoleRepository(Context);

        }

        public Person GetPersonById(int Id) {
            return Persons.Get(Id);
        }


        //public int AddPerson(Person person) {
        //    using (TransactionScope tran = new TransactionScope()) {
        //        int PId = Persons.Add(person);
        //        Complete();
        //        tran.Complete();
        //        return PId;
        //    }

        //}

        public int AddPerson(Person person, List<string> roles) {
            Persons.AddOrUpdate(person);
            HashSet<string> rs = new HashSet<string>(roles);
            person.Roles = Roles.Find(r => rs.Contains(r.RoleName)).ToList();
            Complete();
            return person.Id;
        }
        // create a new person instance and assign this person a role based on the rolename
        // if the rolename is not valid, then no role is added.
        public int AddPerson(Person person, string rolename) {
            using (TransactionScope tran = new TransactionScope()) {
                Persons.AddOrUpdate(person);
                var role = Roles.SingleOrDefault(r => r.RoleName == rolename);
                if (role == null) return -1;
                person.Roles.Add(role);
                Complete();
                tran.Complete();
                return person.Id;
            }
        }

        public int AddOrUpdatePerson(Person person) {

            using (TransactionScope tran = new TransactionScope()) {
                Persons.AddOrUpdate(person);
                //Complete();
                tran.Complete();
                return person.Id;
            }
        }


        public List<Person> GetPeopleByRole(int roleId) {
            return Persons.Find((p) => p.Roles.Any((r => r.Id == roleId))).ToList();
        }

        public void UpdatePerson(Person person) {
            Persons.Update(person);
        }

        public void RemovePerson(int id) {

        }

        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }

    public interface IPersonService {



        // int AddPerson(Person person);
        int AddPerson(Person person, List<string> roles);
        int AddPerson(Person person, string rolename);
        int AddOrUpdatePerson(Person person);
        Person GetPersonById(int Id);
        List<Person> GetPeopleByRole(int roleId);
        void UpdatePerson(Person person);
        int Complete();



    }





}
