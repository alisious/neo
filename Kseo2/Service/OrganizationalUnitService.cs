using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<OrganizationalUnit> GetAll(Organization organization=null)
        {
            var query = (organization == null) 
                ? _context.OrganizationalUnits 
                : _context.OrganizationalUnits.Include(x=>x.Subordinates).Where(x => x.Organization == organization);
            return query.OrderBy(x => x.DisplayOrder).ToList();
        }

        public OrganizationalUnit GetSingle(string name)
        {
            var query = _context.OrganizationalUnits
                .Include(x => x.Subordinates)
                .Where(x => x.Name == name);
            return query.OrderBy(x => x.DisplayOrder).FirstOrDefault();
        }

        public OrganizationalUnit GetSingle(int id)
        {
            var query = _context.OrganizationalUnits
                .Include(x => x.Subordinates)
                .Where(x => x.Id == id);
            return query.OrderBy(x => x.DisplayOrder).FirstOrDefault();
        }
    }
}
