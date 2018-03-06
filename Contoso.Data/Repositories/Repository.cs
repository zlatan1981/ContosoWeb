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
            // Console.WriteLine("Called");
            Table.Add(entity);
            SaveChanges(); // need savechanges to get the entity.Id
            return entity.Id;// without the savechanges(), this will always be 0, which is not the key Id in Database
        }

        public virtual void AddRange(IEnumerable<T> Entities) {
            Table.AddRange(Entities);
            SaveChanges();
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
        // the table already has a entity that has same id as this entity
        public void Update(T entity) {
            var old = Table.Find(entity.Id);
            Context.Entry(old).State = EntityState.Detached;
            Table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Remove(T Entity) {
            Table.Remove(Entity);
            SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<T> Entities) {
            Table.RemoveRange(Entities);
            SaveChanges();
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate) {
            return Table.SingleOrDefault(predicate);
        }

        public void SaveChanges() {
            Context.SaveChanges();
        }

        // refer to https://msdn.microsoft.com/en-us/data/jj592676
        // Set EntityState value to tell checker to do attach or add....
        public void AddOrUpdate(T entity) {
            Context.Entry(entity).State = entity.Id == 0 ?
                                   EntityState.Added :
                                   EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
