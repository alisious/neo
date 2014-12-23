using System.Data.Entity.Infrastructure;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.DataAccess
{
    public interface IOrganizationalUnitRepository : IRepository<OrganizationalUnit> { }

    public class OrganizationalUnitRepository : Repository<OrganizationalUnit>, IOrganizationalUnitRepository { }
   
}
