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
        private int _firstNameTemplateLengthTrigger = 3;
        private string _lastNameTemplate;
        private string _firstNameTemplate;
        private string _middleNameTemplate;
        private string _fatherNameTemplate;
        private string _birthDateTemplate;
        private string _peselTemplate;


        
        public PersonsViewModel(KseoContext kseoContext)
        {
            _kseoContext = kseoContext;
            _personService = new PersonService(kseoContext);
            Items = new ObservableCollection<Person>(_kseoContext.Persons.ToList());
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
            }
        }

        public string FirstNameTemplate
        {
            get { return _firstNameTemplate; }
            set
            {
                _firstNameTemplate = value;
                NotifyOfPropertyChange(()=>FirstNameTemplate);
            }
        }

        public string MiddleNameTemplate
        {
            get { return _middleNameTemplate; }
            set
            {
                _middleNameTemplate = value;
                NotifyOfPropertyChange(()=>MiddleNameTemplate);
            }
        }

        public string FatherNameTemplate
        {
            get { return _fatherNameTemplate; }
            set
            {
                _fatherNameTemplate = value;
                NotifyOfPropertyChange(()=>FatherNameTemplate);
            }
        }

        public string BirthDateTemplate
        {
            get { return _birthDateTemplate; }
            set
            {
                _birthDateTemplate = value;
                NotifyOfPropertyChange(()=>BirthDateTemplate);
            }
        }

        public string PeselTemplate
        {
            get { return _peselTemplate; }
            set
            {
                _peselTemplate = value;
                NotifyOfPropertyChange(()=>PeselTemplate);
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

        public int FirstNameTemplateLengthTrigger
        {
            get { return _firstNameTemplateLengthTrigger; }
            set
            {
                _firstNameTemplateLengthTrigger = value;
                NotifyOfPropertyChange(()=>FirstNameTemplateLengthTrigger);
            }
        }


        public void Search()
        {
            
            Items = new ObservableCollection<Person>(_personService.Search(p=>p.LastName.StartsWith()).Results);

        }

    }
}
