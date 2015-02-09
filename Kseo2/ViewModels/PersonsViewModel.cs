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
        private PersonService _personService; 

        
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


        public void Search()
        {
            
            Items = new ObservableCollection<Person>(_personService.Search("","","","","00000000099").Results);

        }

    }
}
