using Kseo2.DataAccess;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public class DictionaryService<T> :IDictionaryService<T> where T :DictionaryItem<T>
    {
        private readonly KseoContext _context;
        
 
        
        public DictionaryService()
        {
            _context = new KseoContext();
        }
        
        public DictionaryService(KseoContext context)
        {
            _context = context;
        }

        public List<T> GetAll(T group = null)
        {
            IQueryable<T> query = _context.Set<T>();
            return query.OrderBy(x => x.Name).ToList<T>();
        }

        public List<T> GetAllByDisplayOrder(T group = null)
        {
            IQueryable<T> query = _context.Set<T>();
            return (group==null) ? query.OrderBy(x => x.DisplayOrder).ToList<T>()
                : query.OrderBy(x => x.DisplayOrder).ToList<T>();
        }

        public T GetSingle(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void AddItem(T newItem)
        {
            _context.Set<T>().Add(newItem);
        }

        public void RemoveItem(T removedItem)
        {
            _context.Set<T>().Remove(removedItem);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
