using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;
using Kseo2.DataAccess;

namespace Kseo2.BusinessLayer
{
    public class BusinessService<T> where T :Entity
    {

        public BusinessService(KseoContext kseoContext)
        {
            KseoContext = kseoContext;
        }

        protected KseoContext KseoContext { get; private set; }

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
                list = dbQuery.AsNoTracking().ToList();
            }
            return list;
        }


        public virtual SearchResult<T> GetList(int resultsLimit = 20, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            return GetList(null, resultsLimit, navigationProperties);
        }

        public virtual SearchResult<T> GetList(Func<T, bool> where, int resultsLimit = 20, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            var result = new SearchResult<T>();
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
                result.ResultsCounter = dbQuery.Where(where).Count();
                if (resultsLimit==0 || result.ResultsCounter <= resultsLimit) 
                    result.Results = dbQuery.Where(where).ToList();
            }
            return result;
        }
        

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
    }
}
