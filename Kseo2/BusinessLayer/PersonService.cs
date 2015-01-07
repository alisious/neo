using Kseo2.DataAccess;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.BusinessLayer
{
    public class PersonService :Service<Person>
    {

        public PersonService(KseoContext context) : base(context)
        {
        }

        public override void Add(Person item)
        {
            Context.Persons.Add(item);
            Context.SaveChanges();
        }

        public Person GetPersonById(int id)
        {
            return GetSingle(p => p.Id.Equals(id), p => p.Nationality, p => p.Citizenships);
        }
    }
}
