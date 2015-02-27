using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.Collections;

namespace Kseo2.BusinessLayer
{
    public class BusinessLayer :IBusinessLayer
    {
        private readonly IPersonRepository _personRepository;
        private readonly IOrganizationalUnitRepository _organizationalUnitRepository;
        private readonly Dictionary<Type,IList> _dictionaries = new Dictionary<Type, IList>();

        
        public BusinessLayer()
        {
            _personRepository = new PersonRepository();
            _organizationalUnitRepository = new OrganizationalUnitRepository();
            
            _dictionaries.Add(typeof(Country),new List<Country>());
            _dictionaries.Add(typeof(Organization), new List<Organization>());
            _dictionaries.Add(typeof(QuestionForm), new List<QuestionForm>());
            _dictionaries.Add(typeof(QuestionReason), new List<QuestionReason>());
            _dictionaries.Add(typeof(ReservationPurpose),new List<ReservationPurpose>());
            _dictionaries.Add(typeof(ReservationEndReason), new List<ReservationEndReason>());
            _dictionaries.Add(typeof(Rank), new List<Rank>());


            
        }

        #region DictionaryItem routines

        public void LoadDictionary<T>() where T : DictionaryItem<T>
        {
            var repo = new DictionaryItemRepository<T>();
            var list = repo.GetAll(d => d.IsActive.Equals(true));
            if (_dictionaries.ContainsKey(typeof(T)))
                _dictionaries[typeof(T)] = (IList)list;
            else
            {
                _dictionaries.Add(typeof(T), (IList)list);
            }
        }

        public T GetDictionaryItemByName<T>(string name) where T : DictionaryItem<T>
        {
            var repo = new DictionaryItemRepository<T>();
            return repo.GetSingle(d => d.Name.Equals(name));
        }


        public IList<T> GetDictionaryItems<T>(bool activeOnly = true, T group = null) where T : DictionaryItem<T>
        {
            var repo = new DictionaryItemRepository<T>();
            return activeOnly
                ? repo.GetAll((d => d.IsActive.Equals(true) && d.Masteritem == group), d => d.Masteritem,
                    d => d.Subitems)
                : repo.GetAll(d => d.Masteritem == group, d => d.Masteritem, d => d.Subitems);




        }

        public IList<T> GetAllDictionaryItems<T>(bool activeOnly = true) where T : DictionaryItem<T>
        {
            var repo = new DictionaryItemRepository<T>();
            return activeOnly
                ? repo.GetAll(d => d.IsActive.Equals(true), d => d.Masteritem, d => d.Subitems)
                : repo.GetAll();
        }


        public IList<T> GetDictionary<T>() where T : DictionaryItem<T>
        {
            if (_dictionaries.ContainsKey(typeof(T)))
                return (List<T>)_dictionaries[typeof(T)];
            else
            {
                return new List<T>();
            }

        }
        
        #endregion

        #region Person routines

        public IList<Model.Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        /*
        public Model.SearchResult<Model.Person> GetPersons(Func<Model.Person, bool> where, int resultsLimit = 20)
        {
            return _personRepository.GetList(where, resultsLimit);
        }
        */
        public Model.Person GetPersonByPesel(string pesel)
        {
            return _personRepository.GetSingle(x => x.Pesel == pesel, p => p.Nationality, p => p.Citizenships);
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

        
        #endregion
        
        #region OrganizationalUnit routines
        public IList<OrganizationalUnit> GetOrganizationalUnits(Organization organization, bool activeOnly = true)
        {

            return activeOnly
                ? _organizationalUnitRepository.GetList(
                ou => ou.IsActive.Equals(true) && ou.Organization.Id.Equals(organization.Id),
                ou => ou.MasterUnit,
                ou => ou.Organization,
                ou => ou.Subordinates)
                : _organizationalUnitRepository.GetList(ou => ou.Organization.Id.Equals(organization.Id),
                ou => ou.Organization,
                ou => ou.MasterUnit,
                ou => ou.Subordinates);
        }

        public OrganizationalUnit GetSingle(int id)
        {
            return _organizationalUnitRepository.GetSingle(ou => ou.Id.Equals(id),
                ou => ou.MasterUnit,
                ou => ou.Subordinates,
                ou => ou.Organization);
        }
        
        #endregion

        #region Verification routines

        

        public Verification GetVerificationById(int id)
        {
            throw new NotImplementedException();
        }
        public void AddVerification(params Verification[] verifications)
        {
            throw new NotImplementedException();
        }
        public void UpdateVerification(params Verification[] verifications)
        {
            throw new NotImplementedException();
        }
        public void RemoveVerification(params Verification[] verifications)
        {
            throw new NotImplementedException();
        }

        #endregion


        public Reservation GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Reservation> GetReservationsByPerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
