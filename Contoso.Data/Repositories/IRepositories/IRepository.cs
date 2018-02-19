using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data.Repositories.IRepositories {
    public interface IRepository<T> where T : class {

        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        // add the entity and return the id of this new added entity
        int Add(T entity);
        void AddRange(IEnumerable<T> Entities);

        void Remove(T Entity);
        void RemoveRange(IEnumerable<T> Entities);
        void SaveChanges();





    }
}
