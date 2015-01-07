using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.Data.Entity;

namespace Kseo2.BusinessLayer
{
    public class Service<T> where T :class,IEntity
    {
        private readonly KseoContext _context;

        protected KseoContext Context
        {
            get { return _context; }
        }

        public Service()
        {
            _context = new KseoContext();
        }

        public Service(KseoContext context)
        {
            _context = context;
        }

        public virtual void Add(T item)
        {
            var dbSet = _context.Set<T>();
            dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.SaveChanges();
        }

        public void Remove(T item)
        {
            var dbSet = _context.Set<T>();
            dbSet.Remove(item);
            _context.SaveChanges();
        }

        protected virtual T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
           T item = null;
           IQueryable<T> dbQuery = _context.Set<T>();
           //Apply eager loading
           dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
           item = dbQuery
                   .FirstOrDefault(where); //Apply where clause
           return item;
        }

        protected virtual IList<T> GetList(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            //Apply eager loading
            dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
            var list = dbQuery.ToList<T>();
            return list;
        }
    }
}
