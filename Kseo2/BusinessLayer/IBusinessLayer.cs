using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.BusinessLayer
{
    public interface IBusinessLayer
    {


        #region Dictionary routines

        IList<T> GetAllItems<T>() where T : DictionaryItem<T>;
        //IList<T> GetItemsByGroup<T>(T group) where T : DictionaryItem<T>;
        //IList<T> GetItemsByGroup<T>(string groupName) where T : DictionaryItem<T>;
        void AddItem(params DictItem[] items);
        void UpdateItem(params DictItem[] items);
        void RemoveItem(params DictItem[] items);


            #endregion
        
        
        IList<Person> GetAllPersons();
        SearchResult<Person> GetPersons(Func<Person, bool> where, int resultsLimit = 20);
        Person GetPersonByPesel(string pesel);
        void AddPerson(params Person[] persons);
        void UpdatePerson(params Person[] persons);
        void RemovePerson(params Person[] persons);

        IList<Country> GetAllCountries();
        Country GetCountryByName(string name);

    }
}
