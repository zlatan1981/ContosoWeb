using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Contoso.Models.Common;
using Contoso.Data.Repositories.IRepositories;

namespace Contoso.Data.Repositories {

    public class Repository<T> : IRepository<T> where T : AudibleEntity {

        protected readonly DbContext Context;
        DbSet<T> Table;

        public Repository(DbContext _context) {
            Context = _context;
            Table = _context.Set<T>();
        }

        // add the entity and return the entity id
        public virtual int Add(T entity) {
            return Table.Add(entity).Id;
        }

        public virtual void AddRange(IEnumerable<T> Entities) {
            Table.AddRange(Entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
            return Table.Where(predicate);
        }

        public virtual T Get(int id) {
            return Table.Find(id);
        }

        public virtual IEnumerable<T> GetAll() {
            return Table.ToList();
        }

        public virtual void Remove(T Entity) {
            Table.Remove(Entity);
        }

        public virtual void RemoveRange(IEnumerable<T> Entities) {
            Table.RemoveRange(Entities);
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate) {
            return Table.SingleOrDefault(predicate);
        }

        public void SaveChanges() {
            Context.SaveChanges();
        }



    }
}
