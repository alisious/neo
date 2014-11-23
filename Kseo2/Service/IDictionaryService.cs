using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public interface IDictionaryService<T> where T :DictionaryItem
    {
        List<T> GetAll(T group=null);
        List<T> GetAllByDisplayOrder(T group=null);
        T GetSingle(int id);
        void AddItem(DictionaryItem newItem);
        void RemoveItem(DictionaryItem removedItem);
        void SaveChanges();
    }
}
