using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
    public interface IPersonRepository : IRepository<Person> { }
    public class PersonRepository :Repository<Person>, IPersonRepository 
    {
        public PersonRepository(KseoContext context) : base(context) { }
        public PersonRepository() : base() { }

    }
}
