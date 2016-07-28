using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.GenericRepository
{
    public class GenericRepository<T> where T : class
    {
        internal PhoneBookDBEntities Context;
        internal DbSet<T> DbSet;

        public GenericRepository(PhoneBookDBEntities context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }
        public virtual T GetById(object o)
        {
            return DbSet.Find(o);
        }
        public virtual void Insert(T entity)
        {
            DbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            T _entity = DbSet.Find(id);
            Delete(_entity);
        }
        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }
        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }


    }
}
