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
        private List<Rank> _ranks;
        private List<QuestionForm> _questionForms;
        private List<QuestionReason> _questionReasons;
        private List<Organization> _organizations;
        
        private readonly DictionaryService<Country> _countryService;
        private readonly DictionaryService<Rank> _rankService;
        private readonly DictionaryService<QuestionForm> _questionFormService;
        private readonly DictionaryService<QuestionReason> _questionReasonService;
        private readonly DictionaryService<Organization> _organizationService;

        private readonly UserService _userService;
        private User _user; 

        public UnitOfWork()
        {
            _context = new KseoContext();
            _countryService = new DictionaryService<Country>(_context);
            _rankService = new DictionaryService<Rank>(_context);
            _questionFormService = new DictionaryService<QuestionForm>(_context);
            _questionReasonService = new DictionaryService<QuestionReason>(_context);
            _organizationService = new DictionaryService<Organization>(_context);
            _userService = new UserService(_context);
        }
        
        public KseoContext Context()
        {
            return _context;
        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public User ActiveUser
        {
            get { return _user ?? (_user = _userService.GetSingle(Environment.UserName)); }
        }
        
        public List<Country> Countries
        {
            get
            {
                if (_countries == null) LoadDictionary(typeof(Country));
                return _countries;
            }
        }

        public List<Organization> Organizations
        {
            get
            {
                if (_organizations == null) LoadDictionary(typeof(Organization));
                return _organizations;
            }
         
        }

        public List<QuestionReason> QuestionReasons
        {
            get
            {
                if (_questionReasons == null) LoadDictionary(typeof(QuestionReason));
                return _questionReasons;
            }
        }

        public List<QuestionForm> QuestionForms
        {
            get
            {
                if (_questionForms == null) LoadDictionary(typeof(QuestionForm));
                return _questionForms;
            }
           
        }

        public List<Rank> Ranks
        {
            get
            {
                if (_ranks == null) LoadDictionary(typeof(Rank));
                return _ranks;
            }
         }

        public void LoadDictionary(Type type)
        {
            if (type == typeof (Country)) _countries = _countryService.GetItems();
            if (type == typeof (Organization)) _organizations = _organizationService.GetItems();
            if (type == typeof (QuestionForm)) _questionForms = _questionFormService.GetItems();
            if (type == typeof (QuestionReason)) _questionReasons = _questionReasonService.GetItems();
            if (type == typeof (Rank)) _ranks = _rankService.GetItems();
        }
    }
}
