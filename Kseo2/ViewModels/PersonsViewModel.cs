using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.BusinessLayer;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.Collections.ObjectModel;

namespace Kseo2.ViewModels
{
    public class PersonsViewModel :Screen
    {
        private readonly KseoContext _kseoContext;
        private ObservableCollection<Person> _items;
        private Person _selectedItem;
        private readonly PersonService _personService;

        private int _resultsLimit = 20;
        private bool _canSearchAutomatically = true;
        private int _resultsCounter = 0;
        private int _lastNameTemplateLengthTrigger = 3;
        private string _lastNameTemplate=String.Empty;
        private string _firstNameTemplate = String.Empty;
        private string _middleNameTemplate = String.Empty;
        private string _fatherNameTemplate = String.Empty;
        private string _birthDateTemplate = String.Empty;
        private string _peselTemplate = String.Empty;


        
        public PersonsViewModel(KseoContext kseoContext)
        {
            _kseoContext = kseoContext;
            _personService = new PersonService(kseoContext);
            Items = new ObservableCollection<Person>();
            ResultsCounter = Items.Count;
            NotifyOfPropertyChange(()=>CanSearch);
        }

        public ObservableCollection<Person> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyOfPropertyChange(()=>Items);
            }
        }

        public Person SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(()=>SelectedItem);
                NotifyOfPropertyChange(()=>CanEdit);
                NotifyOfPropertyChange(()=>CanRemove);
            }
        }
     

        
        public bool CanEdit
        {
            get { return SelectedItem != null; }
        }

        public bool CanRemove { get { return SelectedItem != null; } }

        
        public string LastNameTemplate
        {
            get { return _lastNameTemplate; }
            set
            {
                _lastNameTemplate = value;
                NotifyOfPropertyChange(()=>LastNameTemplate);
                NotifyOfPropertyChange(()=>CanSearch);
                SearchAutomatically();
            }
        }

        public string FirstNameTemplate
        {
            get { return _firstNameTemplate; }
            set
            {
                _firstNameTemplate = value;
                NotifyOfPropertyChange(()=>FirstNameTemplate);
                SearchAutomatically();
            }
        }

        public string MiddleNameTemplate
        {
            get { return _middleNameTemplate; }
            set
            {
                _middleNameTemplate = value;
                NotifyOfPropertyChange(()=>MiddleNameTemplate);
                SearchAutomatically();
            }
        }

        public string FatherNameTemplate
        {
            get { return _fatherNameTemplate; }
            set
            {
                _fatherNameTemplate = value;
                NotifyOfPropertyChange(()=>FatherNameTemplate);
                SearchAutomatically();
            }
        }

        public string BirthDateTemplate
        {
            get { return _birthDateTemplate; }
            set
            {
                _birthDateTemplate = value;
                NotifyOfPropertyChange(()=>BirthDateTemplate);
                SearchAutomatically();
            }
        }

        public string PeselTemplate
        {
            get { return _peselTemplate; }
            set
            {
                _peselTemplate = value;
                NotifyOfPropertyChange(()=>PeselTemplate);
                SearchAutomatically();
            }
        }

        public int ResultsLimit
        {
            get { return _resultsLimit; }
            set
            {
                _resultsLimit = value;
                NotifyOfPropertyChange(()=>ResultsLimit);
            }
        }

        public bool CanSearchAutomatically
        {
            get { return _canSearchAutomatically; }
            set
            {
                _canSearchAutomatically = value;
                NotifyOfPropertyChange(()=>CanSearchAutomatically);
            }
        }

        public int LastNameTemplateLengthTrigger
        {
            get { return _lastNameTemplateLengthTrigger; }
            set
            {
                _lastNameTemplateLengthTrigger = value;
                NotifyOfPropertyChange(()=>LastNameTemplateLengthTrigger);
                NotifyOfPropertyChange(()=>CanSearch);
            }
        }

        public int ResultsCounter
        {
            get { return _resultsCounter; }
            set
            {
                _resultsCounter = value;
                NotifyOfPropertyChange(()=>ResultsCounter);
            }
        }

        public bool CanSearch
        {
            get { return LastNameTemplate.Length >= LastNameTemplateLengthTrigger; }
        }


        public void Search()
        {

            var sr = _personService.Search(p => p.LastName.StartsWith(LastNameTemplate ?? String.Empty)
                                                && p.FirstName.StartsWith(FirstNameTemplate ?? String.Empty)
                                                && p.MiddleName.StartsWith(MiddleNameTemplate ?? String.Empty)
                                                && p.FatherName.StartsWith(FatherNameTemplate ?? String.Empty)
                                                && p.BirthDate.StartsWith(BirthDateTemplate ?? String.Empty)
                                                && p.Pesel.StartsWith(PeselTemplate ?? String.Empty),ResultsLimit);
            if (sr.ResultsCounter<=ResultsLimit)
                Items = new ObservableCollection<Person>(sr.Results);
            else
            {
                Items.Clear();
            }
            ResultsCounter = sr.ResultsCounter;

        }

        private void SearchAutomatically()
        {
            if (CanSearchAutomatically && CanSearch)
                Search();
        }

    }
}
