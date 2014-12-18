using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;

namespace Kseo2.BusinessLayer
{
    public class BusinessLayer :IBusinessLayer
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICountryRepository _countryRepository;

        public BusinessLayer()
        {
            _personRepository = new PersonRepository();
            _countryRepository = new CountryRepository();
        }

        public IList<Model.Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public Model.SearchResult<Model.Person> GetPersons(Func<Model.Person, bool> where, int resultsLimit = 20)
        {
            return _personRepository.GetList(where, resultsLimit);
        }

        public Model.Person GetPersonByPesel(string pesel)
        {
            return _personRepository.GetSingle(x => x.Pesel == pesel,p=>p.Nationality,p=>p.Citizenships);
        }

        public void AddPerson(params Model.Person[] persons)
        {
            _personRepository.Add(persons);
        }

        public void UpdatePerson(params Model.Person[] persons)
        {
            _personRepository.Update(persons);
        }

        public void RemovePerson(params Model.Person[] persons)
        {
            _personRepository.Remove(persons);
        }

        public IList<Model.Country> GetAllCountries()
        {
            return _countryRepository.GetAll().OrderBy(c => c.DisplayOrder).ToList();
        }

        public Model.Country GetCountryByName(string name)
        {
            return _countryRepository.GetSingle(c => c.Name.Equals(name));
        }

        public IList<T> GetAllItems<T>() where T : DictionaryItem<T>
        {
            throw new NotImplementedException();
        }

        public void AddItem(params DictItem[] items)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(params DictItem[] items)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(params DictItem[] items)
        {
            throw new NotImplementedException();
        }
    }
}
