using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.DataAccess
{
    public interface IRepository<T> where T :class,IEntity
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        SearchResult<T> GetList(Func<T, bool> where, int resultsLimit = 0, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
        
    }
}
