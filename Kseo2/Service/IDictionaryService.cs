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
        List<T> GetItems(bool activeOnly,bool byDisplayOrder, T group);
        T GetSingle(int id);
        void AddItem(T newItem);
        void RemoveItem(T removedItem);
        void SaveChanges();
    }
}
