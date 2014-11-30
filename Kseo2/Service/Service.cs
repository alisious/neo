using Kseo2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public abstract class Service
    {
        #region Private fields
        
            protected readonly KseoContext _context;
 
        #endregion

        #region Constructors

        public Service()
        {
            _context = new KseoContext();
            
        }

        public Service(KseoContext context)
        {
            _context = context;
        }

        #endregion
    }
}
