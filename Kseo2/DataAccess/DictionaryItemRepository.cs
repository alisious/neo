using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.DataAccess
{
    public interface IDictionaryItemRepository<T> : IRepository<T> where T : DictionaryItem<T>
    {
        IList<T> GetAll(Func<T, bool> where);
    }
    public class DictionaryItemRepository<T> : Repository<T>,IDictionaryItemRepository<T> where T : DictionaryItem<T>
    {
        public IList<T> GetAll(Func<T, bool> where)
        {
            List<T> list;
            using (var context = new KseoContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                //Apply eager loading
               dbQuery = dbQuery
                    .Include(d => d.Masteritem)
                    .Include(d => d.Subitems);
                list = dbQuery.AsNoTracking().Where(where).ToList<T>();
            }
            return list;
        }
    }
}
