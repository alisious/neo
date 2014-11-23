using Kseo2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly KseoContext _context;

        public UnitOfWork()
        {
            _context = new KseoContext();
        }



        public KseoContext Context()
        {
            return _context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
