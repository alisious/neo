using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        
        private IList<Country> _dictionaryCountries;
        private IList<Organization> _dictionaryOrganizations;
        private IList<QuestionForm> _dictionaryQuestionForms;
        private IList<QuestionReason> _dictionaryQuestionReasons;


        public BusinessLayer()
        {
            _personRepository = new PersonRepository();
            _countryRepository = new CountryRepository();
            _dictionaryCountries = new List<Country>();
            _dictionaryOrganizations = new List<Organization>();
            _dictionaryQuestionForms = new List<QuestionForm>();
            _dictionaryQuestionReasons = new List<QuestionReason>();
        }

        public IList<Country> DictionaryCountries
        {
            get { return _dictionaryCountries; }
        }

        public IList<Organization> DictionaryOrganizations
        {
            get { return _dictionaryOrganizations; }
        }

        public IList<QuestionForm> DictionaryQuestionForms
        {
            get { return _dictionaryQuestionForms; }
        }

        public IList<QuestionReason> DictionaryQuestionReasons
        {
            get { return _dictionaryQuestionReasons; }
        }


        public void ReloadDictionary(Type dictionaryItemType)
        {
            
            if (dictionaryItemType == typeof (Country)) _dictionaryCountries = new Repository<Country>().GetAll();
            if (dictionaryItemType == typeof(Organization)) _dictionaryOrganizations = new Repository<Organization>().GetAll();
            if (dictionaryItemType == typeof(QuestionForm)) _dictionaryQuestionForms = new Repository<QuestionForm>().GetAll();
            if (dictionaryItemType == typeof(QuestionReason)) _dictionaryQuestionReasons = new Repository<QuestionReason>().GetAll();

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




        public IList<OrganizationalUnit> GetAllOrganizationalUnits(Organization organization = null)
        {
            var organizationalUnitRepository = new Repository<OrganizationalUnit>();

            return (organization == null)
                ? organizationalUnitRepository.GetAll()
                : organizationalUnitRepository.GetAll(ou=>ou.Organization==organization);
        }

        public IList<OrganizationalUnit> GetOrganizationalUnits(OrganizationalUnit masterUnit = null)
        {
            throw new NotImplementedException();
        }
        

        public Country GetCountryByName(string name)
        {
            var repo = new CountryRepository();
            return repo.GetSingle(c => c.Name.Equals(name));
        }
    }
}
