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

        void ReloadDictionary(Type dictionaryItemType);
        
        
        #endregion

        #region OrganizationalUnit routines

        IList<OrganizationalUnit> GetAllOrganizationalUnits(Organization organization=null);
        IList<OrganizationalUnit> GetOrganizationalUnits(OrganizationalUnit masterUnit=null);
        
        #endregion

        
        IList<Person> GetAllPersons();
        SearchResult<Person> GetPersons(Func<Person, bool> where, int resultsLimit = 20);
        Person GetPersonByPesel(string pesel);
        void AddPerson(params Person[] persons);
        void UpdatePerson(params Person[] persons);
        void RemovePerson(params Person[] persons);


        Country GetCountryByName(string name);

    }
}
