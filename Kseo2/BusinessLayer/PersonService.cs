using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;
using Weakly;

namespace Kseo2.BusinessLayer
{
    public class PersonService
    {
        private readonly KseoContext _kseoContext;

        public PersonService(KseoContext kseoContext)
        {
            _kseoContext = kseoContext;
        }

        public SearchResult<Person> Search(Func<Person, bool> where, int resultsLimit = 20)
        {
            var query = _kseoContext.Persons.Where(where).AsQueryable();
            var result = new SearchResult<Person> {ResultsCounter = query.Count()};
            if (result.ResultsCounter <= resultsLimit)
                result.Results = query.ToList();
            return result;
        }

        public Person GetPersonFiles(int personId)
        {
           return _kseoContext.Persons
                .Include(p => p.Nationality)
                .Include(p => p.Citizenships)
                .Include(p => p.Addresses)
                .Include(p => p.Workplaces)
                .Include(p => p.Reservations)
                .FirstOrDefault(p => p.Id.Equals(personId));
        }

    }
}
