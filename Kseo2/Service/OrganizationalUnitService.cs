using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.DataAccess;
using Kseo2.Model;

namespace Kseo2.Service
{
    public class OrganizationalUnitService :Service, IOrgaznizationalUnitService
    {
        public OrganizationalUnitService(KseoContext context) : base(context)
        {
        }

        public List<OrganizationalUnit> GetAll(Organization organization)
        {
            var query = (organization == null) 
                ? _context.OrganizationalUnits 
                : _context.OrganizationalUnits.Where(x => x.Organization == organization);
            return query.OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
