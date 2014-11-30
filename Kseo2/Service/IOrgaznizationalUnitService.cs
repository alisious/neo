using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.Service
{
    public interface IOrgaznizationalUnitService
    {
        List<OrganizationalUnit> GetAll(Organization organization);

    }
}
