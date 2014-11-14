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
    public class PersonService
    {
        private KseoContext _ctx;

        private bool CheckPeselDuplicate(string aPesel,int aId)
        {
            var query = from p in _ctx.Persons
                        where p.Pesel == aPesel && p.Id != aId
                        select p;
            return (query.ToList<Person>().Count>0);
        }

        public PersonService()
        {
            _ctx = new KseoContext();
        }

        public PersonService(KseoContext context)
        {
            _ctx = context;
        }

        public Person AddPerson(Person person)
        {
            if (CheckPeselDuplicate(person.Pesel, person.Id)==false)
            {
                _ctx.Persons.Add(person);
                _ctx.SaveChanges();
                return person;
            }
            else
                return null;
            
        }

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


        /// <summary>
        /// Metoda zapisuje zmiany wprowadzone w agregacie.
        /// Przed zapisaniem sprawdza unikalność PESEL'a
        /// </summary>
        public void SaveChanges()
        {
           _ctx.SaveChanges();
        }
    }
}
