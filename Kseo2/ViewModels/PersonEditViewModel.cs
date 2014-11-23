using System.Text.RegularExpressions;
using Caliburn.Micro;
using Caliburn.Micro.Extras;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using Kseo2.Service;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Kseo2.ViewModels
{
    public class PersonEditViewModel : ValidatingScreen<PersonEditViewModel>
    {
        private readonly IPersonService _personService;
        private readonly IDictionaryService<Country> _countryService;
        private readonly UnitOfWork _uow;


        private Person _person { get; set; }
        private List<Country> _countries;


        #region Public properties

        

        public string BoldWhenHasNoPesel 
        {
            get { return HasPesel?"Normal":"Bold"; }
        }

        public string BoldWhenHasPesel
        {
            get { return HasPesel ? "Bold" : "Normal";}
        }

        public bool HasPesel
        {
            get { return _person.HasPESEL; }
            set
            {
                _person.HasPESEL = value;
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
            get { return HasPesel ? "Visible" : "Collapsed"; }
        }

        [RequiredEx(ErrorMessage=@"PESEL jest wymagany!",GuardProperty = "HasPesel")]
        [RegularExpression("[0-9]{11}", ErrorMessage = @"PESEL powinien składać się z 11 cyfr!")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasPeselGroup")]
        public string Pesel
        {
            get { return _person.Pesel; }
            set
            {
                _person.Pesel = value;
                OnPropertyChanged(value);
            }
        }

        #region Sex properties
        
        [Required(ErrorMessage = @"Płeć jest wymagana!")]
        public string Sex
        {
            get { return _person.Sex; }
            set
            {
                _person.Sex = value;
                NotifyOfPropertyChange(() => IsMale);
                NotifyOfPropertyChange(() => IsFemale);
                OnPropertyChanged(value);
            }
        }

        public bool IsMale
        {
            get { return Sex=="M"; }
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




        [Required(ErrorMessage = @"Nazwisko jest wymagane!", AllowEmptyStrings = false)]
        public string LastName
        {
            get { return _person.LastName; }
            set
            {
                _person.LastName = value;
                OnPropertyChanged(value);
            }
        }

        [Required(ErrorMessage = @"Imię jest wymagane!",AllowEmptyStrings = false)]
        public string FirstName
        {
            get { return _person.FirstName; }
            set
            {
                _person.FirstName = value;
                OnPropertyChanged(value);
            }
        }

        public string MiddleName
        {
            get { return _person.MiddleName; }
            set
            {
                _person.MiddleName = value;
                NotifyOfPropertyChange(() => MiddleName);

            }
        }

        

        [RequiredEx(ErrorMessage = @"Imię ojca jest wymagane w przypadku braku PESEL!", AllowEmptyStrings = false,GuardProperty = "HasNoPesel")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string FatherName
        {
            get { return _person.FatherName; }
            set
            {
                _person.FatherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherName 
        {
            get { return _person.MotherName; }
            set
            {
                _person.MotherName = value;
                NotifyOfPropertyChange(() => MotherName);

            }
        }

        public string MotherMaidenName
        {
            get { return _person.MotherMaidenName; }
            set
            {
                _person.MotherMaidenName = value;
                NotifyOfPropertyChange(() => MotherMaidenName);

            }
        }

        [RequiredEx(ErrorMessage = @"Data urodzenia jest wymagana w przypadku braku PESEL!",AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        [RegularExpression(@"((?:19|20)\d\d)([-](0[1-9]|1[012]))?([-](0[1-9]|[12][0-9]|3[01]))?", ErrorMessage = @"Rok, Rok-Miesiąc lub data urodzenia.")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string BirthDate
        {
            get { return _person.BirthDate; }
            set
            {
                _person.BirthDate = value;
                OnPropertyChanged(value);

            }
        }

        public string BirthPlace
        {
            get { return _person.BirthPlace; }
            set
            {
                _person.BirthPlace = value;
                NotifyOfPropertyChange(() => BirthPlace);

            }
        }

        public bool CanSave
        {
            get
            {
                var r = HasErrorsByGroup();
                if (HasPesel)
                    return !r && !HasErrorsByGroup("HasPeselGroup");
                else
                    return !r && !HasErrorsByGroup("HasNoPeselGroup");
            }
        }

        public List<Country> Countries
        {
            get { return _countries; }
            set 
            { 
                _countries = value;
                NotifyOfPropertyChange(() => Countries);
            }
        }

        #endregion


        public PersonEditViewModel()
        {

            _uow = new UnitOfWork();
            _personService = new PersonService(_uow.Context());
            _countryService = new DictionaryService<Country>(_uow.Context());
            Countries = _countryService.GetAll(null);
            _person = new Person();
        }
               

        public IResult Save()
        {


            if (CanSave == true)
            {
                try
                {
                    _personService.AddPerson(_person);
                    _personService.SaveChanges();
                    return new MessengerResult("Zmiany zostały zapisane.")
                        .Caption("Informacja")
                        .Image(MessageImage.Information);
                }
                catch (Exception e)
                {
                    return new MessengerResult(e.Message)
                        .Caption("Błąd!")
                        .Image(MessageImage.Error);
                }
            }
            else
            {
                return null;
            }

        }

        public void Cancel()
        {
            this.TryClose(false);
        }
        

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }


       
    }
}
