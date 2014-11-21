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

namespace Kseo2.ViewModels
{
    public class PersonEditViewModel : ValidatingScreen<PersonEditViewModel>
    {
        private readonly IPersonService _personService;
        
        private string _Pesel;
        private string _LastName;
        private string _FirstName;
        private string _FatherName;
        private string _BirthDate;
        private bool _HasPesel = true;
        private string _MiddleName;
        private string _MotherName;
        private string _BirthPlace;
        private string _MotherMaidenName;


        #region Public properties

        public Person Person { get; set; }

        public string BoldWhenHasNoPesel
        {
            get
            {
                if (HasPesel)
                {
                    return "Normal";
                }
                else
                {
                    return "Bold";
                }
            }
        }

        public string BoldWhenHasPesel
        {
            get
            {
                if (HasPesel)
                {
                    return "Bold";
                }
                else
                {
                    return "Normal";
                }
            }
        }

        public bool HasPesel
        {
            get { return Person.HasPESEL; }
            set
            {
                Person.HasPESEL = value;
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
            get
            {
                if (HasPesel)
                {
                    return "Visible";
                }
                return "Collapsed";
            }
        }

        [RequiredEx(ErrorMessage=@"PESEL jest wymagany!",GuardProperty = "HasPesel")]
        [RegularExpression("[0-9]{11}", ErrorMessage = @"PESEL powinien składać się z 11 cyfr!")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasPeselGroup")]
        public string Pesel
        {
            get { return Person.Pesel; }
            set
            {
                Person.Pesel = value;
                OnPropertyChanged(value);
            }
        }


        [Required(ErrorMessage = @"Nazwisko jest wymagane!", AllowEmptyStrings = false)]
        public string LastName
        {
            get { return Person.LastName; }
            set
            {
                Person.LastName = value;
                OnPropertyChanged(value);
            }
        }

        [Required(ErrorMessage = @"Imię jest wymagane!",AllowEmptyStrings = false)]
        public string FirstName
        {
            get { return Person.FirstName; }
            set
            {
                Person.FirstName = value;
                OnPropertyChanged(value);
            }
        }

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                _MiddleName = value;
                NotifyOfPropertyChange(() => MiddleName);

            }
        }

        

        [RequiredEx(ErrorMessage = @"Imię ojca jest wymagane w przypadku braku PESEL!", AllowEmptyStrings = false,GuardProperty = "HasNoPesel")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string FatherName
        {
            get { return _FatherName; }
            set
            {
                _FatherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherName 
        {
            get { return _MotherName; }
            set
            {
                _MotherName = value;
                NotifyOfPropertyChange(() => MotherName);

            }
        }

        public string MotherMaidenName
        {
            get { return _MotherMaidenName; }
            set
            {
                _MotherMaidenName = value;
                NotifyOfPropertyChange(() => MotherMaidenName);

            }
        }

        [RequiredEx(ErrorMessage = @"Data urodzenia jest wymagana w przypadku braku PESEL!",AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        //[RegularExpression(@"\d{4}([-]\d{2})?([-]\d{2})?",ErrorMessage = @"Rok, Rok-Miesiąc lub data urodzenia.")]
        [RegularExpression(@"((?:19|20)\d\d)([-](0[1-9]|1[012]))?([-](0[1-9]|[12][0-9]|3[01]))?", ErrorMessage = @"Rok, Rok-Miesiąc lub data urodzenia.")]
        //[DataType(DataType.Date)]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string BirthDate
        {
            get { return _BirthDate; }
            set
            {
                _BirthDate = value;
                OnPropertyChanged(value);

            }
        }

        public string BirthPlace
        {
            get { return _BirthPlace; }
            set
            {
                _BirthPlace = value;
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

        #endregion


        public PersonEditViewModel()
        {
            _personService = new PersonService();
            Person = new Person();
        }
               

        public IResult Save()
        {


            if (CanSave == true)
            {
                try
                {
                    _personService.AddPerson(Person);
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
