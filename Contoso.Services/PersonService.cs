using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Data;

namespace Contoso.Services {
    public class PersonService : IPersonService {

        private readonly ContosoContext Context;
        public IPersonRepository Persons { get; private set; }

        public PersonService(ContosoContext context) {

            Context = context;
            Persons = new PersonRepository(Context);

        }

        public Person GetPersonById(int Id) {
            return Persons.Get(Id);
        }


        public int Complete() {
            return Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }


        public int AddPerson(Person person, List<string> roles) {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleByRole(int roleId) {
            return Persons.Find((p) => p.Roles.Any((r => r.Id == roleId))).ToList();
        }

        public void RemovePerson(int id) {

        }
    }

    public interface IPersonService {

        IPersonRepository Persons { get; }
        int Complete();
        int AddPerson(Person person, List<string> roles);
        List<Person> GetPeopleByRole(int roleId);



    }





}
