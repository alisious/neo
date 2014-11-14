using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kseo2.ViewModels
{
    public class PersonSearchViewModel :Screen
    {
                    
        #region Private fields

        //private IPersonRepository _PersonRepository = new PersonRepository(); 
        private PersonService _personService = new PersonService();
        
        private short _PeselLengthLimit = 4;
        private short _NamesLengthLimit = 3;
        private short _DateLengthLimit = 4;
       
        private string _Pesel = string.Empty;
        private string _LastName = string.Empty;
        private string _FirstName = string.Empty;
        private string _FatherName = string.Empty;
        private string _BirthDate = string.Empty;
        private bool _HasPesel = true;

        private bool _CanSearchAutomatically = false;
        private int _ResultsLimit = 15;
        private int _CounterResults = 0;
        private ObservableCollection<Person> _Results = new ObservableCollection<Person>();
        private Person _SelectedResult;
         
        
        #endregion

        #region Public properties
        
        public short PeselLengthLimit
        {
            get { return _PeselLengthLimit; }
            set
            {
                _PeselLengthLimit = value;
                NotifyOfPropertyChange(() => PeselLengthLimit);
                
            }
        }

        public short NamesLengthLimit
        {
            get { return _NamesLengthLimit; }
            set
            {
                _NamesLengthLimit = value;
                NotifyOfPropertyChange(() => NamesLengthLimit);
               
            }
        }

        public short DateLengthLimit
        {
            get { return _DateLengthLimit; }
            set
            {
                _DateLengthLimit = value;
                NotifyOfPropertyChange(() => DateLengthLimit);

            }
        }

        public bool HasPesel
        {
            get { return _HasPesel; }
            set
            {
                _HasPesel = value;
                if (value == false) Pesel = string.Empty;
                NotifyOfPropertyChange(() => HasPesel);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string Pesel
        {
            get { return _Pesel; }
            set
            {
                _Pesel = value;
                NotifyOfPropertyChange(() => Pesel);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string FatherName
        {
            get { return _FatherName; }
            set
            {
                _FatherName = value;
                NotifyOfPropertyChange(() => FatherName);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public string BirthDate
        {
            get { return _BirthDate; }
            set
            {
                _BirthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
                NotifyOfPropertyChange(() => CanSearch);
            }
        }

        public bool CanSearchAutomatically
        {
            get { return _CanSearchAutomatically; }
            set
            {
                _CanSearchAutomatically = value;
                NotifyOfPropertyChange(() => CanSearchAutomatically);
            }
        }

        public int ResultsLimit
        {
            get { return _ResultsLimit; }
            set
            {
                _ResultsLimit = value;
                NotifyOfPropertyChange(() => ResultsLimit);
            }
        }

        public int CounterResults
        {
            get { return _CounterResults; }
            set
            {
                _CounterResults = value;
                NotifyOfPropertyChange(() => CounterResults);
            }
        }

        public ObservableCollection<Person> Results
        {
            get { return _Results; }
            set
            {
                _Results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }
        
        public Person SelectedResult 
        {
            get { return _SelectedResult; }
            set
            {
                _SelectedResult = value;
                NotifyOfPropertyChange(() => SelectedResult);
                NotifyOfPropertyChange(() => CanSelectPerson);
            }
        }

        public bool CanSearch
        {
            get
            {
                if (HasPesel == true)
                    return CanSearchWhenPeselKnown();
                else
                    return CanSearchWhenPeselUnknown();
               
            }
        }


        public bool CanSelectPerson
        {
            get 
            {
                return (SelectedResult != null);
            }
        }

        #endregion



        #region Constructors
        public PersonSearchViewModel()
        { }

        public PersonSearchViewModel(PersonService aPersonService)
        {
            _personService = aPersonService;
        } 
        #endregion

        #region Public methods
        
        public bool CanSearchWhenPeselKnown()
        {
            return (Pesel.Length >= PeselLengthLimit)
                && (LastName.Length >= NamesLengthLimit);
        }

        public bool CanSearchWhenPeselUnknown()
        {
            return (LastName.Length >= NamesLengthLimit)
                && (FirstName.Length >= NamesLengthLimit)
                && (FatherName.Length >= NamesLengthLimit)
                && (BirthDate.Length >= DateLengthLimit);
        }

        public void NewPerson()
        {
            SelectedResult = null;
            this.TryClose(true);
        }

        public void SelectPerson()
        {
            this.TryClose(true);
        }
        
        public void Cancel()
        {
            this.TryClose(false);
        }

       /* public void CountResults()
        {
            CounterResults = _PersonRepository.CountPersonsByPeselFamilyName(PeselToSearch,LastNameToSearch);
        }

        public void GetResults()
        {
            Results = new ObservableCollection<Person>(_PersonRepository.GetPersonsByPeselFamilyName(PeselToSearch, LastNameToSearch));
        }
        */
        
        public void Search()
        {
            var _searchResult = _personService.Find(Pesel, LastName, ResultsLimit);
            CounterResults = _searchResult.ResultsCounter;
            Results = new ObservableCollection<Person>(_searchResult.Results);
            if (Results.Count == 1)
                SelectedResult = Results[0];

            /*
            CountResults();
            if (CounterResults <= ResultsLimit)
                GetResults();
            else
                Results = new ObservableCollection<Person>();

            if (Results.Count == 1)
                SelectedResult = Results[0];
             */
        }

        #endregion

    }
}
