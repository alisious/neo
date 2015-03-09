using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Helpers;
using Kseo2.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kseo2.ViewModels
{
    public class PersonViewModel :ValidatingScreen<PersonViewModel>,IHasState
    {

        private readonly IEventAggregator _events = IoC.Get<IEventAggregator>();

        public PersonViewModel(Person currentPerson,KseoContext kseoContext)
        {
            IsDirty = false;
            CurrentPerson = currentPerson;
            KseoContext = kseoContext;
            Countries = KseoContext.Countries.Where(c => c.IsActive.Equals(true)).ToList();
            PersonWorkplaces = new PersonWorkplacesViewModel(currentPerson,KseoContext);
            PersonAddresses = new PersonAddressesViewModel(currentPerson,KseoContext);
        }
        
        public KseoContext KseoContext { get; private set; }
        public Person CurrentPerson { get; private set; }
        public List<Country> Countries { get; private set; }
        public PersonAddressesViewModel PersonAddresses { get; private set; }
        public PersonWorkplacesViewModel PersonWorkplaces { get; private set; }

        
        //Personalities
        public string FullName
        {
            get { return CurrentPerson.FullName; }
        }

        
        #region CurrentPerson properties

        [Required(ErrorMessage = @"Nazwisko jest wymagane!", AllowEmptyStrings = false)]
        public string LastName
        {
            get { return CurrentPerson.LastName; }
            set
            {
                CurrentPerson.LastName = value;
                OnPropertyChanged(value);
                _events.PublishOnUIThread(new PersonFilesTittleChangeEvent(CurrentPerson.FullName));
            }
        }

        [Required(ErrorMessage = @"Imię jest wymagane!", AllowEmptyStrings = false)]
        public string FirstName
        {
            get { return CurrentPerson.FirstName; }
            set
            {
                CurrentPerson.FirstName = value;
                OnPropertyChanged(value);
                _events.PublishOnUIThread(new PersonFilesTittleChangeEvent(CurrentPerson.FullName));
            }
        }

        public string MiddleName
        {
            get { return CurrentPerson.MiddleName; }
            set
            {
                CurrentPerson.MiddleName = value;
                OnPropertyChanged(value);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        #region PESEL properties

        [RequiredEx(ErrorMessage = @"PESEL jest wymagany!", GuardProperty = "HasPesel")]
        [RegularExpression("[0-9]{11}", ErrorMessage = @"PESEL powinien składać się z 11 cyfr!")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasPeselGroup")]
        public string Pesel
        {
            get { return CurrentPerson.Pesel; }
            set
            {
                CurrentPerson.Pesel = value;
                if (value.Length >= 6 && String.IsNullOrEmpty(BirthDate))
                {
                    var d = PeselValidator.GetBirthDateFromPESEL(value);
                    if (d.HasValue)
                        BirthDate = d.Value.ToString("yyyy-MM-dd");
                }
                if (value.Length >= 9 && String.IsNullOrEmpty(Sex))
                {
                    Sex = PeselValidator.GetSexFromPESEL(value);
                }

                OnPropertyChanged(value);
            }
        }

        public string BoldWhenHasNoPesel
        {
            get { return HasPesel ? "Normal" : "Bold"; }
        }

        public string BoldWhenHasPesel
        {
            get { return HasPesel ? "Bold" : "Normal"; }
        }

        public bool HasPesel
        {
            get { return CurrentPerson.HasPESEL; }
            set
            {
                CurrentPerson.HasPESEL = value;
                if (value == false) Pesel = string.Empty;
                NotifyOfPropertyChange(() => PeselVisibility);
                NotifyOfPropertyChange(() => BoldWhenHasNoPesel);
                NotifyOfPropertyChange(() => BoldWhenHasPesel);
                NotifyOfPropertyChange(() => Pesel);
                NotifyOfPropertyChange(() => FatherName);
                NotifyOfPropertyChange(() => BirthDate);
                OnPropertyChanged(value);
            }
        }

        public bool HasNoPesel { get { return !HasPesel; } }

        public string PeselVisibility
        {
            get { return HasPesel ? "Visible" : "Hidden"; }
        }
        #endregion

        #region Sex properties




        [Required(ErrorMessage = @"Płeć jest wymagana!")]
        public string Sex
        {
            get { return CurrentPerson.Sex; }
            set
            {
                CurrentPerson.Sex = value;
                NotifyOfPropertyChange(() => IsMale);
                NotifyOfPropertyChange(() => IsFemale);
                OnPropertyChanged(value);
            }
        }

        public bool IsMale
        {
            get { return Sex == "M"; }
            set
            {
                Sex = value ? "M" : "K";
                NotifyOfPropertyChange(() => IsMale);
            }
        }

        public bool IsFemale
        {
            get { return Sex == "K"; }
            set
            {
                Sex = value ? "K" : "M";
                NotifyOfPropertyChange(() => IsFemale);
            }
        }

        #endregion

        [RequiredEx(ErrorMessage = @"Data urodzenia jest wymagana w przypadku braku PESEL!", AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        [RegularExpression(@"((?:19|20)\d\d)([-](0[1-9]|1[012]))?([-](0[1-9]|[12][0-9]|3[01]))?", ErrorMessage = @"Data urodzenia w jednym z trzech formatów: RRRR, RRRR-MM, RRRR-MM-DD")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string BirthDate
        {
            get { return CurrentPerson.BirthDate; }
            set
            {
                CurrentPerson.BirthDate = value;
                OnPropertyChanged(value);
            }
        }

        public string BirthPlace
        {
            get { return CurrentPerson.BirthPlace; }
            set
            {
                CurrentPerson.BirthPlace = value;
                OnPropertyChanged(value);

            }
        }

        [RequiredEx(ErrorMessage = @"Imię ojca jest wymagane w przypadku braku PESEL!", AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string FatherName
        {
            get { return CurrentPerson.FatherName; }
            set
            {
                CurrentPerson.FatherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherName
        {
            get { return CurrentPerson.MotherName; }
            set
            {
                CurrentPerson.MotherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherMaidenName
        {
            get { return CurrentPerson.MotherMaidenName; }
            set
            {
                CurrentPerson.MotherMaidenName = value;
                OnPropertyChanged(value);

            }
        }

        public Country Nationality
        {
            get { return CurrentPerson.Nationality; }
            set
            {
                CurrentPerson.Nationality = value;
                OnPropertyChanged(value);
            }

        }



        public HashSet<Country> Citizenships
        {
            get { return CurrentPerson.Citizenships; }
        }


        public void EditCitizenships()
        {
            var windowManager = new WindowManager();
            var vm = new CountrySelectViewModel(this.Countries);
            vm.SetSelectedCountries(Citizenships);
            if (windowManager.ShowDialog(vm) == true)
            {
                CurrentPerson.Citizenships = new HashSet<Country>(vm.GetSelectedCountries());

                NotifyOfPropertyChange(() => Citizenships);
                IsDirty = true;
            }
        }
        
        #endregion


        //IHasState implementation
        public bool IsDirty { get; set; }
        
        public bool CanSave
        {
            get { return !HasErrors; }
        }


        //ValidatingScreen<> implementation
        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
            IsDirty = true;
           
             

        }
    }
}
