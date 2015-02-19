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
    public class PersonsViewModel :ListViewModel<Person>
    {

        #region Private fields
            private readonly PersonService _personService;
            private string _lastNameTemplate = String.Empty;
            private string _firstNameTemplate = String.Empty;
            private string _middleNameTemplate = String.Empty;
            private string _fatherNameTemplate = String.Empty;
            private string _birthDateTemplate = String.Empty;
            private string _peselTemplate = String.Empty; 
        #endregion
        
        
        public PersonsViewModel(KseoContext kseoContext) :base(kseoContext)
        {
            
            _personService = new PersonService(kseoContext);
            NotifyOfPropertyChange(()=>CanSearch);
        }



        #region Public properties
        
        public string LastNameTemplate
        {
            get { return _lastNameTemplate; }
            set
            {
                _lastNameTemplate = value;
                NotifyOfPropertyChange(() => LastNameTemplate);
                NotifyOfPropertyChange(() => CanSearch);
                SearchAutomatically();
            }
        }

        public string FirstNameTemplate
        {
            get { return _firstNameTemplate; }
            set
            {
                _firstNameTemplate = value;
                NotifyOfPropertyChange(() => FirstNameTemplate);
                SearchAutomatically();
            }
        }

        public string MiddleNameTemplate
        {
            get { return _middleNameTemplate; }
            set
            {
                _middleNameTemplate = value;
                NotifyOfPropertyChange(() => MiddleNameTemplate);
                SearchAutomatically();
            }
        }

        public string FatherNameTemplate
        {
            get { return _fatherNameTemplate; }
            set
            {
                _fatherNameTemplate = value;
                NotifyOfPropertyChange(() => FatherNameTemplate);
                SearchAutomatically();
            }
        }

        public string BirthDateTemplate
        {
            get { return _birthDateTemplate; }
            set
            {
                _birthDateTemplate = value;
                NotifyOfPropertyChange(() => BirthDateTemplate);
                SearchAutomatically();
            }
        }

        public string PeselTemplate
        {
            get { return _peselTemplate; }
            set
            {
                _peselTemplate = value;
                NotifyOfPropertyChange(() => PeselTemplate);
                SearchAutomatically();
            }
        } 
        
        #endregion

        
        public override bool CanSearch
        {
            get { return LastNameTemplate.Length >= FilterTemplateLengthTrigger; }
        }


        public override void Search()
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

        public void Add()
        {
            var personViewModel = new PersonViewModel(new EventAggregator(),0);
            personViewModel.DisplayName = "Nowa osoba.";
            var windowManager = new WindowManager();
            
            if (windowManager.ShowDialog(personViewModel) == true)
            {
               
            }
        }

        public void Edit()
        {
            if (SelectedItem != null)
            {
                var personViewModel = new PersonViewModel(new EventAggregator(), SelectedItem.Id);
                personViewModel.DisplayName = "Zmiana danych osoby.";
                var windowManager = new WindowManager();

                if (windowManager.ShowDialog(personViewModel) == true)
                {

                }
            }
        }

    }
}
