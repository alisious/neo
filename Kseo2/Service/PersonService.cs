using Kseo2.DataAccess;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    /// <summary>
    /// Klasa odpowiedzialna za obsługę operacji dotyczących osoby. 
    /// </summary>
    public class PersonService :IPersonService 
    {
        private readonly IPersonRepository _personRepository;

        private bool CheckPeselDuplicate(string aPesel,int aId)
        {
            return _personRepository.CountListItems(x => x.Pesel.StartsWith(aPesel) && x.Id != aId) > 0;
        }

        public PersonService()
        {
            _personRepository = new PersonRepository();
        }

        public PersonService(KseoContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        public Person AddPerson(Person person)
        {
            try
            {
                _personRepository.Add(person);
                SaveChanges();
                return person;
            }
            catch (Exception e)
            {
                throw new Exception("Błąd dodawania osoby!", e);
                //return null;    
            }
            
        }
/*
        public void DeletePerson(Person person)
        {
            _ctx.Persons.Remove(person);
            _ctx.SaveChanges();
        }

        public Person UpdatePerson(Person person)
        {
            if (CheckPeselDuplicate(person.Pesel, person.Id) == false)
            {
                _ctx.Persons.Add(person);
                _ctx.SaveChanges();
                return person;
            }
            else
                return null;
        
        }
        
        /// <summary>
        /// Metoda zwraca agregat klasy Person.
        /// </summary>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        public Person GetPersonFiles(int personId)
        {
            var query = _ctx.Persons.Include("Verifications").Where<Person>(p => p.Id == personId).FirstOrDefault<Person>();
            return query;
        }

        /// <summary>
        /// Metoda zwraca obiekt klasy Person.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Person GetPerson(int personId)
        {
            var query = from p in _ctx.Persons
                        where p.Id == personId
                        select p;
            return query.ToList().FirstOrDefault<Person>();
        }

        public SearchResult<Person> Find(string aPesel, string aLastName,int aResultsLimit = 15)
        {
            var query = from p in _ctx.Persons
                        where p.Pesel.StartsWith(aPesel) && p.LastName.StartsWith(aLastName)
                        select p;

            SearchResult<Person> _searchResult = new SearchResult<Person>();
            _searchResult.ResultsCounter = query.Count<Person>();
            if (_searchResult.ResultsCounter <= aResultsLimit)
                _searchResult.Results = query.ToList<Person>();
            return _searchResult;
            
        }

        public SearchResult<Person> Find(string aLastName, string aFirstName, string aFatherName, string aBirthDate, int aResultsLimit = 15)
        {
            var query = _ctx.Persons.Where<Person>(p => p.LastName.StartsWith(aLastName)
                                                    && p.FirstName.StartsWith(aFirstName)
                                                    && p.FatherName.StartsWith(aFatherName)
                                                    && p.BirthDate.StartsWith(aBirthDate));
            
            SearchResult<Person> _searchResult = new SearchResult<Person>();
            _searchResult.ResultsCounter = query.Count<Person>();
            if (_searchResult.ResultsCounter <= aResultsLimit)
                _searchResult.Results = query.ToList<Person>();
            return _searchResult;
        }

*/
        /// <summary>
        /// Metoda zapisuje zmiany wprowadzone w agregacie.
        /// Przed zapisaniem sprawdza unikalność PESEL'a
        /// </summary>
        public void SaveChanges()
        {
           _personRepository.SaveChanges();
        }

        public SearchResult<Person> Search(string pesel, string lastName, int resultsLimit = 20)
        {
            var r = new SearchResult<Person>();
            r.ResultsCounter = _personRepository.CountListItems(x => x.Pesel.StartsWith(pesel) && x.LastName.StartsWith(lastName));
            if (r.ResultsCounter <= resultsLimit)
                r.Results = _personRepository.GetList(x => x.Pesel.StartsWith(pesel) && x.LastName.StartsWith(lastName));
            return r;
        }

        public SearchResult<Person> Search(string lastName, string firstName, string fatherName, string birthDate, int resultsLimit = 20)
        {
            throw new NotImplementedException();
        }

        public Person GetSingle(int id)
        {
            throw new NotImplementedException();
        }
        public void RemovePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
