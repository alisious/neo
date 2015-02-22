using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;
using Kseo2.Model;

namespace Kseo2.DataAccess
{
    public class Repository<T> :IRepository<T> where T :class,IEntity
    {

        private readonly KseoContext _context;
        public Repository()
        {
            _context = null;
        }

        public Repository(KseoContext context)
        {
            _context = context;
        }


        protected static System.Data.Entity.EntityState GetEntityState(Kseo2.Model.EntityState entityState)
        {
            switch (entityState)
            {
                case Model.EntityState.Unchanged:
                    return System.Data.Entity.EntityState.Unchanged;
                case Model.EntityState.Added:
                    return System.Data.Entity.EntityState.Added;
                case Model.EntityState.Modified:
                    return System.Data.Entity.EntityState.Modified;
                case Model.EntityState.Deleted:
                    return System.Data.Entity.EntityState.Deleted;
                default:
                    return System.Data.Entity.EntityState.Detached;
            }
        }
       
        
        public virtual IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                //foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                //    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
                list = dbQuery.AsNoTracking().ToList<T>();
            }
            return list;
        }

        /*
        public virtual SearchResult<T> GetList(Func<T, bool> where, int resultsLimit = 20, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            var result = new SearchResult<T>();
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
                result.Counter = dbQuery.Where(where).Count();
                if (result.Counter <= resultsLimit) 
                    result.Results = dbQuery.Where(where).ToList<T>();
            }
            return result;
        }
        */
        
        public virtual T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                item = dbQuery
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public void Add(params T[] items)
        {
            Update(items);
        }

        
        public void Update(params T[] items)
        {
            try
            {
                using (var context = new KseoContext())
                {
                    var dbSet = context.Set<T>();
                    foreach (var item  in items)
                    {
                        item.EntityState = Kseo2.Model.EntityState.Deleted;
                        dbSet.Add(item);
                        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
                        {
                            var entity = entry.Entity;
                            entry.State = GetEntityState(entity.EntityState);
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException exception)
            {
                var m = (exception.InnerException!=null)?"; " + exception.InnerException.Message:
                String.Empty;
                 
                throw new DataAccessLayerException(String.Concat("Błąd walidacji danych!",m),exception);
            }
            catch (DbUpdateException exception)
            {
                throw new DataAccessLayerException("Błąd zapisu do bazy danych!", exception);
            }
            catch (Exception exception)
            {
                throw new DataAccessLayerException("Inny błąd!", exception);
            }
            

        }

        public void UpdateGraph(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(params T[] items)
        {
            Update(items);
        }



        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> result;
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
                result = dbQuery.Where(where).ToList<T>();
            }
            return result;
        }

        public int Count(Func<T, bool> where)
        {
            int result;
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                result = dbQuery.Where(where).Count();
            }
            return result;
        }
    }

    [Serializable]
    public class DataAccessLayerException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DataAccessLayerException()
        {
        }

        public DataAccessLayerException(string message) : base(message)
        {
        }

        public DataAccessLayerException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DataAccessLayerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    } 
}
