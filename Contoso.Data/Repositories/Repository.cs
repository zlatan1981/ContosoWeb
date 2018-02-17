using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Contoso.Data.Repositories {

    public class Repository<T> : IRepository<T> where T : class {

        protected readonly DbContext Context;
        DbSet<T> Table;

        public Repository(DbContext _context) {

            Context = _context;
            Table = _context.Set<T>();
        }

        public void Add(T entity) {
            Table.Add(entity);
        }

        public void AddRange(IEnumerable<T> Entities) {

            Table.AddRange(Entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
            return Table.Where(predicate);
        }

        public T Get(int id) {
            return Table.Find(id);
        }

        public IEnumerable<T> GetAll() {
            return Table.ToList();
        }

        public void Remove(T Entity) {
            Table.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> Entities) {
            Table.RemoveRange(Entities);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate) {
            return Table.SingleOrDefault(predicate);
        }
    }
}
