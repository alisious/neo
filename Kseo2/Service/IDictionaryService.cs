using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public interface IDictionaryService<T> where T :DictionaryItem<T>
    {
        List<T> GetAll(T group);
        List<T> GetAllByDisplayOrder(T group);
        T GetSingle(int id);
        void AddItem(T newItem);
        void RemoveItem(T removedItem);
        void SaveChanges();
    }
}
