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

        void LoadDictionary<T>() where T : DictionaryItem<T>;
        IList<T> GetDictionary<T>() where T : DictionaryItem<T>;
        T GetDictionaryItemByName<T>(string name) where T : DictionaryItem<T>;
        IList<T> GetDictionaryItems<T>(bool activeOnly = true,T group = null) where T : DictionaryItem<T>;
        IList<T> GetAllDictionaryItems<T>(bool activeOnly = true) where T : DictionaryItem<T>; 
           
        #endregion

        #region OrganizationalUnit routines

        IList<OrganizationalUnit> GetOrganizationalUnits(Organization organization, bool activeOnly = true);
        OrganizationalUnit GetSingle(int id);
        
        #endregion

        
        IList<Person> GetAllPersons();
        SearchResult<Person> GetPersons(Func<Person, bool> where, int resultsLimit = 20);
        Person GetPersonByPesel(string pesel);
        void AddPerson(params Person[] persons);
        void UpdatePerson(params Person[] persons);
        void RemovePerson(params Person[] persons);


        
        

    }
}
