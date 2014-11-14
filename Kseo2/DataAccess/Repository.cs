using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Kseo2.DataAccess
{
    public class Repository<T> :IRepository<T> where T :class
    {

        private readonly KseoContext context;

        public Repository()
        {
            context = new KseoContext();
        }

        public Repository(KseoContext context)
        {
            this.context = context;
        }

        public virtual IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                   dbQuery = dbQuery.Include<T, object>(navigationProperty);

           list = dbQuery
                 .ToList<T>();
           
            return list;
        }

        public int CountAllItems(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            var r = dbQuery.Count<T>();

            return r;
        }

        public virtual IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = context.Set<T>();
            
            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                 dbQuery = dbQuery.Include<T, object>(navigationProperty);

           list = dbQuery
                 .Where(where)
                 .ToList<T>();
           return list;
        }

        public int CountListItems(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
           
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            var r = dbQuery
                  .Where(where)
                  .Count<T>();
            return r;
        }

        public virtual T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                   dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                      .FirstOrDefault(where); //Apply where clause
            return item;
        }

        public void Add(params T[] items)
        {
               foreach (T item in items)
                    context.Set<T>().Add(item);
        }

       // public void Update(params T[] items)
       // {
       //     throw new NotImplementedException();
       // }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
                context.Set<T>().Remove(item);
        }


        public void SaveChanges()
        {
            context.SaveChanges();
        }


       

        
    }
}
