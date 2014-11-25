using System.Runtime.InteropServices;
using Kseo2.DataAccess;
using Kseo2.Model;
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
        private List<Country> _countries;
        private readonly DictionaryService<Country> _countryService;  


        public UnitOfWork()
        {
            _context = new KseoContext();
            _countryService = new DictionaryService<Country>(_context);
        }
        
        public KseoContext Context()
        {
            return _context;
        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Country> Countries
        {
            get
            {
                if (_context == null)
                    _countries = _countryService.GetAllByDisplayOrder(null);
                return _countries;
            }
        }

        public void LoadDictionary(Type type)
        {
            if (type == typeof (Country)) _countries = _countryService.GetAllByDisplayOrder(null);
        }
    }
}
