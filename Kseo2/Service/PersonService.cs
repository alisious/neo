using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using Kseo2.DataAccess;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Kseo2.Service
{
    /// <summary>
    /// Klasa odpowiedzialna za obsługę operacji dotyczących osoby. 
    /// </summary>
    public class PersonService :IPersonService 
    {

        #region Private fields
        
        private readonly KseoContext _context;
 
        #endregion

        #region Constructors

        public PersonService()
        {
            _context = new KseoContext();
            
        }

        public PersonService(KseoContext context)
        {
            _context = context;
        }

        #endregion

        public bool HasPeselDuplicate(Person person)
        {
            return _context.Persons.Count(x => x.Pesel.Equals(person.Pesel) && x.Id != person.Id) > 0;
           
        }

        public void AddPerson(Person person)
        {
            try
            {
                _context.Persons.Add(person);
            }
            catch (Exception e)
            {
                var sb = new StringBuilder(@"Błąd zapisu w repozytorium!");
                sb.AppendLine(e.Message);
                throw new Exception(sb.ToString(), e);
            }

        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder(@"Nie powiodła się walidacja danych osoby!");
                sb.AppendLine(e.Message);
                throw new DbUpdateException(sb.ToString(), e);
            }
            catch (DbUpdateException e)
            {
                var sb = new StringBuilder(@"Próba dodania osoby, której PESEL jest już zarejestrowany!");
                sb.AppendLine(e.Message);
                throw new DbUpdateException(sb.ToString(), e);
            }
            catch (Exception e)
            {
                throw new Exception("Błąd zapisu do bazy danych!", e);
            }

        }

        public void RemovePerson(Person person)
        {
            try
            {
                _context.Persons.Remove(person);
            }
            catch (Exception e)
            {
                var sb = new StringBuilder(@"Błąd zapisu w repozytorium!");
                sb.AppendLine(e.Message);
                throw new Exception(sb.ToString(), e);
            }
        }

        /*
        
        
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

       

*/
      
        

        public SearchResult<Person> Search(string pesel, string lastName, int resultsLimit = 20)
        {
            var r = new SearchResult<Person>
            {
                ResultsCounter = _context.Persons.Count(x => x.Pesel.StartsWith(pesel) && x.LastName.StartsWith(lastName))
            };
            if (r.ResultsCounter <= resultsLimit)
                r.Results = _context.Persons.Where(x => x.Pesel.StartsWith(pesel) && x.LastName.StartsWith(lastName)).ToList();
            return r;
        }

        public SearchResult<Person> Search(string lastName, string firstName, string fatherName, string birthDate, int resultsLimit = 20)
        {
            var r = new SearchResult<Person>
            {
                ResultsCounter = _context.Persons.Count(x=>x.LastName.StartsWith(lastName) 
                                                        && x.FirstName.StartsWith(firstName) 
                                                        && x.FatherName.StartsWith(fatherName) 
                                                        && x.BirthDate.StartsWith(birthDate))
            };
            if (r.ResultsCounter <= resultsLimit)
                r.Results = _context.Persons.Where(x=>x.LastName.StartsWith(lastName) 
                                                   && x.FirstName.StartsWith(firstName) 
                                                   && x.FatherName.StartsWith(fatherName) 
                                                   && x.BirthDate.StartsWith(birthDate)).ToList();
            return r;
        }


        /// <summary>
        /// Metoda zwraca obiekt klasy Person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetSingle(int id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
        }
        
    }
}
