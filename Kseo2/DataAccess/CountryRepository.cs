using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
        public interface ICountryRepository : IRepository<Country> { }
        public class CountryRepository : Repository<Country>, ICountryRepository { }
}
